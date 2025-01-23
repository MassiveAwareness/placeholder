import { Building } from './buildings.js';
import { Player } from './player.js';

export class Production {
    constructor(ui) {
        this.building = new Building();
        this.player = new Player();
        this.ui = ui;
    }

    productionLevels = {
        farms: {
            1: 10,
            2: 20,
            3: 35,
            4: 50,
            5: 70,
            6: 95,
            7: 120
        },
        mines: {
            1: 15,
            2: 30,
            3: 50,
            4: 75,
            5: 100,
            6: 125,
            7: 150
        },
        houses: {
            1: 5,
            2: 10,
            3: 15,
            4: 20,
            5: 25,
            6: 30,
            7: 35
        }
    };

    getProduction(buildingType, level) {
        return this.productionLevels[buildingType]?.[level] || 0;
    }

    calculateProduction(buildingType) {
        let totalProduction = 0;

        if (!this.building.buildings[buildingType]) {
            console.error(`Building type ${buildingType} not found in buildings!`);
            return totalProduction;
        }

        for (let i = 1; i <= this.building.buildings[buildingType].count; i++) {
            const levelKey = `${buildingType}${i}Level`;
            const level = this.building.buildings[buildingType][levelKey];

            if (!level) {
                console.warn(`Level for ${levelKey} is not defined`);
                continue;
            }

            const baseProduction = this.getProduction(buildingType, level);
            totalProduction += baseProduction;
        }

        return totalProduction;
    }

    calculatePopulation() {
        const totalHousePopulation = this.calculateProduction('houses');
        document.getElementById('population').textContent = totalHousePopulation;
    }

    increaseResources() {
        try {
            const farmProduction = this.calculateProduction('farms');
            const mineProduction = this.calculateProduction('mines');

            this.player.playerData.food += farmProduction;
            this.player.playerData.gold += mineProduction;
            this.ui.updateResources();
        } catch (err) {
            console.error('Error in increaseResources: ', err.message);
        }
    }
}
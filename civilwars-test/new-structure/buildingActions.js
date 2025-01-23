import { Player } from "./player.js";
import { Building } from "./buildings.js";
import { Production } from "./production.js";

export class BuildingActions {
    constructor(ui) {
        this.ui = ui;
        this.player = new Player();
        this.building = new Building();
        this.production = new Production(ui);
    }

    buildFarm() {
        if (this.building.buildings.farms.count >= this.building.buildings.farms.maxCount) {
            alert('Max number of farms reached!');
            return;
        }

        const requirements = this.building.getUpgradeCosts(1);
        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to build!');
            return;
        }

        const farmNumber = this.building.buildings.farms.count + 1;
        this.building.buildings.farms[`farms${farmNumber}Level`] = 1;
        this.building.buildings.farms.count += 1;

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }

    buildMine() {
        if (this.building.buildings.mines.count >= this.building.buildings.mines.maxCount) {
            alert('Max number of mines reached!');
            return;
        }

        const requirements = this.building.getUpgradeCosts(1);
        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to build!');
            return;
        }

        const mineNumber = this.building.buildings.mines.count + 1;
        this.building.buildings.mines[`mines${mineNumber}Level`] = 1;
        this.building.buildings.mines.count += 1;

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }

    buildHouse() {
        if (this.building.buildings.houses.count >= this.building.buildings.houses.maxCount) {
            alert('Max number of houses reached!');
            return;
        }

        const requirements = this.building.getUpgradeCosts(1);
        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to build!');
            return;
        }

        const houseNumber = this.building.buildings.houses.count + 1;
        this.building.buildings.houses[`houses${houseNumber}Level`] = 1;
        this.building.buildings.houses.count += 1;

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.production.calculatePopulation();
        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }

    upgradeFarm(farmNumber) {
        const farmKey = `farms${farmNumber}Level`;
        const nextLevel = this.building.buildings.farms[farmKey] + 1;
        const requirements = this.building.getUpgradeCosts(nextLevel);

        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to upgrade!');
            return;
        }

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.building.buildings.farms[farmKey] += 1;
        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }

    upgradeMine(mineNumber) {
        const mineKey = `mines${mineNumber}Level`;
        const nextLevel = this.building.buildings.mines[mineKey] + 1;
        const requirements = this.building.getUpgradeCosts(nextLevel);

        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to upgrade!');
            return;
        }

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.building.buildings.mines[mineKey] += 1;
        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }

    upgradeHouse(houseNumber) {
        const houseKey = `houses${houseNumber}Level`;
        const nextLevel = this.building.buildings.houses[houseKey] + 1;
        const requirements = this.building.getUpgradeCosts(nextLevel);

        if (
            this.player.playerData.food < requirements.food ||
            this.player.playerData.gold < requirements.gold ||
            (requirements.population && this.player.playerData.population < requirements.population)
        ) {
            alert('Not enough resources to upgrade!');
            return;
        }

        this.player.playerData.food -= requirements.food;
        this.player.playerData.gold -= requirements.gold;
        if (requirements.population) this.player.playerData.population -= requirements.population;

        this.building.buildings.houses[houseKey] += 1;
        this.production.calculatePopulation();
        this.ui.renderBuildingButtons();
        this.ui.updateResources();
    }
}
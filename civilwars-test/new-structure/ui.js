import { Player } from "./player.js";
import { Building } from "./buildings.js";

export class UI {
    constructor() {
        this.building = new Building();
        this.player = new Player();
        this.production = null; // Initialize as null
        this.buildingActions = null; // Initialize as null
    }

    setProduction(production) {
        this.production = production;
    }

    setBuildingActions(buildingActions) {
        this.buildingActions = buildingActions;
    }

    updateResources() {
        const player = this.player;
        const building = this.building;

        try {
            document.getElementById('population').textContent = player.playerData.population;
            document.getElementById('food').textContent = player.playerData.food;
            document.getElementById('gold').textContent = player.playerData.gold;
            document.getElementById('houses').textContent = building.buildings.houses.count;
            document.getElementById('farms').textContent = building.buildings.farms.count;
            document.getElementById('mines').textContent = building.buildings.mines.count;
        } catch (err) {
            console.error('Error in resourceUpdates: ', err.message);
        }
    }

    renderBuildingButtons() {
        document.getElementById('buildingActions').innerHTML = '';
        const production = this.production;
        const building = this.building;

        const createButton = ({ text, tooltipText, onClick, isDisabled, extraStyles }) => {
            const button = document.createElement('button');
            button.className = 'tooltip';
            button.textContent = text;
            button.disabled = isDisabled;

            if (onClick) button.onclick = onClick;
            if (extraStyles) for (const [key, value] of Object.entries(extraStyles)) button.style[key] = value;

            const tooltip = document.createElement('span');
            tooltip.className = 'tooltipText';
            tooltip.textContent = tooltipText;

            button.appendChild(tooltip);
            return button;
        };

        const renderBuildingGroup = ({ buildingType, maxCount, count, levels, upgradeFn, buildFn }) => {
            const groupDiv = document.createElement('div');
            groupDiv.className = `${buildingType}-section`;

            for (let i = 1; i <= count; i++) {
                const currentLevel = levels[`${buildingType}${i}Level`];
                const nextLevel = currentLevel + 1;

                const isMaxLevel = nextLevel > Object.keys(production.productionLevels[buildingType]).length;
                const displayName = buildingType.slice(0, -1);
                const text = isMaxLevel
                    ? `${displayName.charAt(0).toUpperCase() + displayName.slice(1)} ${i} (Max Level)`
                    : `Upgrade ${displayName.charAt(0).toUpperCase() + displayName.slice(1)} ${i} to Level ${nextLevel}`;
                const tooltipText = isMaxLevel ? 'Max level reached!' : building.getUpgradeRequirements(nextLevel);

                const extraStyles = isMaxLevel ? { backgroundColor: 'green', color: 'black' } : {};

                const upgradeButton = createButton({
                    text,
                    tooltipText,
                    onClick: isMaxLevel ? null : () => upgradeFn(i),
                    isDisabled: isMaxLevel,
                    extraStyles
                });

                groupDiv.appendChild(upgradeButton);
            }

            const displayName = buildingType.slice(0, -1);
            const buildText = `Build New ${displayName.charAt(0).toUpperCase() + displayName.slice(1)}`;
            const buildingTooltipText = count >= maxCount ? 'Max count reached!' : building.getUpgradeRequirements(1);
            const extraStyles = count >= maxCount
                ? { backgroundColor: 'gray', color: 'black' }
                : {};

            const buildButton = createButton({
                text: buildText,
                tooltipText: buildingTooltipText,
                onClick: count >= maxCount ? null : buildFn,
                isDisabled: count >= maxCount,
                extraStyles
            });

            groupDiv.appendChild(buildButton);
            return groupDiv;
        };

        const farmsDiv = renderBuildingGroup({
            buildingType: 'farms',
            maxCount: building.buildings.farms.maxCount,
            count: building.buildings.farms.count,
            levels: building.buildings.farms,
            upgradeFn: this.buildingActions.upgradeFarm.bind(this.buildingActions),
            buildFn: this.buildingActions.buildFarm.bind(this.buildingActions)
        });
        const minesDiv = renderBuildingGroup({
            buildingType: 'mines',
            maxCount: building.buildings.mines.maxCount,
            count: building.buildings.mines.count,
            levels: building.buildings.mines,
            upgradeFn: this.buildingActions.upgradeMine.bind(this.buildingActions),
            buildFn: this.buildingActions.buildMine.bind(this.buildingActions)
        });
        const housesDiv = renderBuildingGroup({
            buildingType: 'houses',
            maxCount: building.buildings.houses.maxCount,
            count: building.buildings.houses.count,
            levels: building.buildings.houses,
            upgradeFn: this.buildingActions.upgradeHouse.bind(this.buildingActions),
            buildFn: this.buildingActions.buildHouse.bind(this.buildingActions)
        });

        document.getElementById('buildingActions').appendChild(farmsDiv);
        document.getElementById('buildingActions').appendChild(minesDiv);
        document.getElementById('buildingActions').appendChild(housesDiv);
    }
}
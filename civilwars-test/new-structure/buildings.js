export class Building {
    buildings = {
        farms: JSON.parse(localStorage.getItem('farms')) || { count: 2, farms1Level: 1, farms2Level: 1, maxCount: 5 },
        mines: JSON.parse(localStorage.getItem('mines')) || { count: 2, mines1Level: 1, mines2Level: 1, maxCount: 5 },
        houses: JSON.parse(localStorage.getItem('houses')) || { count: 2, houses1Level: 1, houses2Level: 1, maxCount: 5 }
    };

    upgradeCosts = {
        1: { food: 25, gold: 50 },
        2: { food: 50, gold: 100 },
        3: { food: 75, gold: 150 },
        4: { food: 125, gold: 225 },
        5: { food: 200, gold: 300 },
        6: { food: 300, gold: 450 },
        7: { food: 500, gold: 750 }
    };

    getUpgradeCosts = (level) => {
        return this.upgradeCosts[level] || null;
    }

    getUpgradeRequirements(level) {
        const requirements = this.getUpgradeCosts(level);
        if(!requirements || Object.keys(requirements).length === 0) {
            alert('No further upgrades available!');
            return;
        }

        let requirementText = 'Requires: ';
        if(requirements.food) requirementText += `Food: ${requirements.food} `;
        if(requirements.gold) requirementText += `Gold: ${requirements.gold} `;
        if(requirements.population) requirementText += `Population: ${requirements.population}`;

        return requirementText.trim();
    }
}
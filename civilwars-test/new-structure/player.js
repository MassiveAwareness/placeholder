export class Player {
    playerData = {
        xp: parseInt(localStorage.getItem('playerXP')) || 0,
        level: parseInt(localStorage.getItem('playerLevel')) || 1,
        population: parseInt(localStorage.getItem('playerPopulation')) || 10,
        food: parseInt(localStorage.getItem('playerFood')) || 25,
        gold: parseInt(localStorage.getItem('gold')) || 50
    };

    giveXP() {
        const amount = Math.floor(Math.random() * 35) + 1;
        if(this.playerData && typeof this.playerData.xp === 'number') this.playerData.xp += amount;
        else alert('Player XP is not defined or is not a number!');
    }
}
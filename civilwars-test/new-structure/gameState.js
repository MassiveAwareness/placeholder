import { Timer } from './timers.js';
import { Player } from './player.js';
import { Building } from './buildings.js';

export class GameState {
    constructor() {
        this.timer = new Timer();
        this.player = new Player();
        this.building = new Building();
    }

    saveGameState() {
        localStorage.setItem('gameTime', this.timer.gameTime);
        localStorage.setItem('playerLevel', this.player.playerData.level);
        localStorage.setItem('playerPopulation', this.player.playerData.population);
        localStorage.setItem('playerFood', this.player.playerData.food);
        localStorage.setItem('playerGold', this.player.playerData.gold);

        localStorage.setItem('farms', JSON.stringify(this.building.buildings.farms));
        localStorage.setItem('mines', JSON.stringify(this.building.buildings.mines));
        localStorage.setItem('houses', JSON.stringify(this.building.buildings.houses));
    }
}
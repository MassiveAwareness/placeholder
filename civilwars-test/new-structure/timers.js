import { Production } from './production.js';

export class Timer {
    constructor() {
        this.production = new Production();
        this.now = Date.now();
        this.gameTime = 0;
        this.gameTick = this.gameTick.bind(this);
        this.timerInterval = setInterval(this.gameTick, 1000);
    }

    formatTime(seconds) {
        const hours = Math.floor(seconds / 3600);
        const minutes = Math.floor((seconds % 3600) / 60);
        const secs = seconds % 60;

        return `${String(hours).padStart(2, '0')}:${String(minutes).padStart(2, '0')}:${String(secs).padStart(2, '0')}`;
    }

    updateTimerDisplay() {
        const timerElement = document.getElementById('timer');
        if(timerElement) {
            timerElement.textContent = this.formatTime(this.gameTime);
        } else {
            console.error('Timer element not found!');
            return;
        }
    }

    gameTick() {
        this.gameTime++;
        this.updateTimerDisplay();
        if(this.gameTime % 10 === 0) this.production.increaseResources();
    }
}
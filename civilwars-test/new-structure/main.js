import { UI } from './ui.js';
import { Production } from './production.js';
import { Timer } from './timers.js';
import { BuildingActions } from './buildingActions.js';

const ui = new UI();

const buildingActions = new BuildingActions(ui);

const production = new Production(ui);
const timer = new Timer(production);

ui.setProduction(production);
ui.setBuildingActions(buildingActions);

document.addEventListener('DOMContentLoaded', () => {
    production.calculatePopulation();
    timer.updateTimerDisplay();
    ui.renderBuildingButtons();
    ui.updateResources();
});
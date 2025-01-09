document.getElementById('inputForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const inputData = {
        level: document.getElementById('level').value,
        type: document.getElementById('questType').value,
        title: document.getElementById('title').value,
        description: document.getElementById('description').value,
        xCord: document.getElementById('xCord').value,
        yCord: document.getElementById('yCord').value,
        rewards: {
            food: document.getElementById('food').value,
            gold: document.getElementById('gold').value
        }
    };

    const jsonString = JSON.stringify([inputData]);

    const blob = new Blob([jsonString], { type: 'application/json' });
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'quests.json';
    a.click();
    URL.revokeObjectURL(url);
});
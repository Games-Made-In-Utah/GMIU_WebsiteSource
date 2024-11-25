const express = require('express');
const bodyParser = require('body-parser');
const fs = require('fs');
const path = require('path');

const app = express();
app.use(bodyParser.json());

// Serve static files
app.use(express.static('public'));

// Endpoint to handle POST requests for creating new Game Jam
app.post('/js/createGameJam', (req, res) => {
    const newGameJam = req.body;

    // Define the path to the JSON file
    const filePath = path.join(__dirname, 'data', 'gamejams.json');

    // Read the current gamejams.json file
    fs.readFile(filePath, 'utf-8', (err, data) => {
        if (err) {
            return res.status(500).json({ message: 'Error reading file' });
        }

        let gameJams = JSON.parse(data);

        // Add the new Game Jam to the list
        newGameJam.id = gameJams.gameJams.length + 1; // Create a new ID
        gameJams.gameJams.push(newGameJam);

        // Write the updated JSON back to the file
        fs.writeFile(filePath, JSON.stringify(gameJams, null, 2), (err) => {
            if (err) {
                return res.status(500).json({ message: 'Error writing to file' });
            }
            res.status(200).json({ message: 'Game Jam created successfully!' });
        });
    });
});

// Start the server locally on port 3000
const PORT = process.env.PORT || 3000;
app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});

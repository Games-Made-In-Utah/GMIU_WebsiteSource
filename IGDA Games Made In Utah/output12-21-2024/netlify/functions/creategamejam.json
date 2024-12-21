const fs = require('fs').promises;
const path = require('path');

exports.handler = async function (event, context) {
    if (event.httpMethod !== 'POST') {
        return {
            statusCode: 405,
            body: JSON.stringify({ message: 'Method Not Allowed' }), // Ensure JSON response
        };
    }

    try {
        // Ensure the event body is valid
        if (!event.body) {
            throw new Error("No data sent in the request body");
        }

        // Parse the incoming body to JSON
        const newGameJam = JSON.parse(event.body);

        // Ensure the file path is correct
        const filePath = path.resolve(__dirname, '../../public/data/gamejams.json');
        
        // Check if the file exists
        const fileData = await fs.readFile(filePath, 'utf8');
        const gameJams = JSON.parse(fileData);

        // Add the new game jam with an incremented ID
        newGameJam.id = gameJams.length + 1;
        gameJams.push(newGameJam);

        // Write back to the JSON file
        await fs.writeFile(filePath, JSON.stringify(gameJams, null, 2));

        return {
            statusCode: 200,
            body: JSON.stringify({ message: 'Game Jam created successfully!' }),
        };
    } catch (error) {
        return {
            statusCode: 500,
            body: JSON.stringify({ message: `Error: ${error.message}` }), // Error handling as JSON
        };
    }
};

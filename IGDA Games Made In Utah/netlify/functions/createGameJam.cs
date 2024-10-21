const fs = require('fs').promises;
const path = require('path');

exports.handler = async function(event, context) {
    if (event.httpMethod !== 'POST') {
        return {
            statusCode: 405,
            body: 'Method Not Allowed',
        };
    }

    try {
        const newGameJam = JSON.parse(event.body);
        const filePath = path.resolve(__dirname, '../../public/data/gamejams.json');
        const fileData = await fs.readFile(filePath, 'utf8');
        const gameJams = JSON.parse(fileData);

        // Add the new game jam
        newGameJam.id = gameJams.length + 1;
        gameJams.push(newGameJam);

        // Write back to file
        await fs.writeFile(filePath, JSON.stringify(gameJams, null, 2));

        return {
            statusCode: 200,
            body: JSON.stringify({ message: 'Game Jam created successfully!' }),
        };
    } catch (error) {
        return {
            statusCode: 500,
            body: `Error: ${error.message}`,
        };
    }
};

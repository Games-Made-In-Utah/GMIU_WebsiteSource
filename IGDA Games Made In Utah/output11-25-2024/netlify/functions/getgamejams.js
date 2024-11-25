const fs = require('fs').promises;
const path = require('path');

exports.handler = async function(event, context) {
    try {
        const filePath = path.resolve(__dirname, '../../public/data/gamejams.json');
        const fileData = await fs.readFile(filePath, 'utf8');
        const gameJams = JSON.parse(fileData);

        return {
            statusCode: 200,
            body: JSON.stringify(gameJams),
        };
    } catch (error) {
        return {
            statusCode: 500,
            body: `Error: ${error.message}`,
        };
    }
};

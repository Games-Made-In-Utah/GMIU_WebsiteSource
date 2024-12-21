const fs = require('fs').promises
const path = require('path')

exports.handler = async function (event, context) {
    if (event.httpMethod !== 'GET') {
        return { statusCode: 405, body: 'Method Not Allowed' }
    }

    try {
        const filePath = path.join(__dirname, '../public/data/gamejams.json')
        const fileData = await fs.readFile(filePath, 'utf8')
        const gameJams = JSON.parse(fileData)

        return {
            statusCode: 200,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(gameJams)
        }
    } catch (error) {
        return {
            statusCode: 500,
            body: JSON.stringify({ error: 'Failed to read game jams' })
        }
    }
}
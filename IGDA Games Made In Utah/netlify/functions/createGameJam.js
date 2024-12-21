const fs = require('fs').promises
const path = require('path')

exports.handler = async function (event, context) {
    if (event.httpMethod !== 'POST') {
        return { statusCode: 405, body: 'Method Not Allowed' }
    }

    try {
        const filePath = path.join(__dirname, '../wwwroot/data/gamejams.json')
        const fileData = await fs.readFile(filePath, 'utf8')
        let gameJams = JSON.parse(fileData)

        const newGameJam = JSON.parse(event.body)
        newGameJam.id = gameJams.gameJams.length + 1
        gameJams.gameJams.push(newGameJam)

        await fs.writeFile(filePath, JSON.stringify(gameJams, null, 2))

        return {
            statusCode: 200,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ message: 'Game Jam created successfully!' })
        }
    } catch (error) {
        return {
            statusCode: 500,
            body: JSON.stringify({ error: 'Failed to create game jam' })
        }
    }
}
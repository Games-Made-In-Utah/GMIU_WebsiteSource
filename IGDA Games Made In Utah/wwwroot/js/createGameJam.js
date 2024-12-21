import { promises as fs } from 'fs'
import path from 'path'

export default async function handler(req, res) {
  if (req.method !== 'POST') {
    return res.status(405).json({ message: 'Method Not Allowed' })
  }

  try {
    const newGameJam = req.body
    const filePath = path.join(process.cwd(), 'public/data/gamejams.json')
    
    const fileData = await fs.readFile(filePath, 'utf8')
    let gameJams = JSON.parse(fileData)

    newGameJam.id = gameJams.gameJams.length + 1
    gameJams.gameJams.push(newGameJam)

    await fs.writeFile(filePath, JSON.stringify(gameJams, null, 2))

    res.status(200).json({ message: 'Game Jam created successfully!' })
  } catch (error) {
    res.status(500).json({ message: `Error: ${error.message}` })
  }
}
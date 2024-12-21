import { promises as fs } from 'fs'
import path from 'path'

export default async function handler(req, res) {
  if (req.method !== 'GET') {
    return res.status(405).json({ message: 'Method Not Allowed' })
  }

  try {
    const filePath = path.join(process.cwd(), 'public/data/gamejams.json')
    const fileData = await fs.readFile(filePath, 'utf8')
    const gameJams = JSON.parse(fileData)

    res.status(200).json(gameJams)
  } catch (error) {
    res.status(500).json({ message: `Error: ${error.message}` })
  }
}
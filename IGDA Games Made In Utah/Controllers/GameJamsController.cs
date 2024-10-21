using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using IGDA_Games_Made_In_Utah.Models;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class GameJamsController : Controller
    {
        private readonly string _jsonFilePath = "wwwroot/data/gamejams.json"; // Path to your game jams JSON file

        // Method to fetch and deserialize the game jams data
        public async Task<List<GameJam>> GetGameJamsAsync()
        {
            if (System.IO.File.Exists(_jsonFilePath))
            {
                var json = await System.IO.File.ReadAllTextAsync(_jsonFilePath);
                var gameJamRoot = JsonConvert.DeserializeObject<GameJamRoot>(json);
                return gameJamRoot.GameJams;
            }
            return new List<GameJam>();
        }

        // Index method to display the game jams on the view
        public async Task<IActionResult> Index()
        {
            var gameJams = await GetGameJamsAsync();
            return View(gameJams);
        }

        // GET: Create view for creating a new Game Jam
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Handle the form submission for creating a new Game Jam
        [HttpPost]
        public async Task<IActionResult> Create(GameJam newGameJam)
        {
            var gameJams = await GetGameJamsAsync();

            // Assign a new Id to the new game jam
            newGameJam.Id = gameJams.Count + 1;

            // Add the new game jam to the list
            gameJams.Add(newGameJam);

            // Serialize the updated list back to JSON and save it
            var gameJamRoot = new GameJamRoot { GameJams = gameJams };
            var updatedJson = JsonConvert.SerializeObject(gameJamRoot, Formatting.Indented);
            await System.IO.File.WriteAllTextAsync(_jsonFilePath, updatedJson);

            // Redirect back to the Index page after creation
            return RedirectToAction(nameof(Index));
        }
    }

    // Class to represent the root of the JSON structure
    public class GameJamRoot
    {
        [JsonProperty("gameJams")]
        public List<GameJam> GameJams { get; set; }
    }
}

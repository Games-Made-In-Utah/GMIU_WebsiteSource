using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        // GET: GameJams/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GameJams/Create
        [HttpPost]
        public async Task<IActionResult> Create(GameJam newGameJam)
        {
            if (ModelState.IsValid)
            {
                // Fetch the existing game jams
                var gameJams = await GetGameJamsAsync();

                // Assign an ID and add the new game jam
                newGameJam.Id = gameJams.Count + 1;
                gameJams.Add(newGameJam);

                // Serialize and save back to the JSON file
                var gameJamRoot = new GameJamRoot { GameJams = gameJams };
                var updatedJson = JsonConvert.SerializeObject(gameJamRoot, Formatting.Indented);
                await System.IO.File.WriteAllTextAsync(_jsonFilePath, updatedJson);

                // Redirect to the index view after creating the game jam
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, return the same view with validation errors
            return View(newGameJam);
        }

        // GET: GameJams/Index
        public async Task<IActionResult> Index()
        {
            var gameJams = await GetGameJamsAsync();
            return View(gameJams);
        }
    }

    // Class to represent the root of the JSON structure
    public class GameJamRoot
    {
        [JsonProperty("gameJams")]
        public List<GameJam> GameJams { get; set; }
    }
}

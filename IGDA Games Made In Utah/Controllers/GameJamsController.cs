using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using IGDA_Games_Made_In_Utah.Models;  // For List<T> usage

namespace IGDA_Games_Made_In_Utah.Controllers
{
    // MVC Controller to handle both API and views
    public class GameJamsController : Controller
    {
        private readonly string _dataPath;

        // Constructor that sets the path to the data file
        public GameJamsController(IWebHostEnvironment webHostEnvironment)
        {
            _dataPath = Path.Combine(webHostEnvironment.WebRootPath, "data", "gamejams.json");
        }

        // Action to display the Game Jams in the MVC view
        public IActionResult Index()
        {
            try
            {
                var jsonString = System.IO.File.ReadAllText(_dataPath);
                var gameJams = JsonSerializer.Deserialize<List<GameJam>>(jsonString);  // Deserialize the JSON into a list of GameJam objects
                return View(gameJams);  // Pass the game jams to the view
            }
            catch (Exception ex)
            {
                // If there is an error (e.g., file not found, or deserialization error), return an error view.
                return View("Error", new ErrorViewModel { Message = ex.Message });
            }
        }


        // API Endpoint: Get game jams in JSON format
        [ApiController]
        [Route("api/[controller]")]
        public class ApiGameJamsController : ControllerBase
        {
            private readonly string _dataPath;

            // Constructor that sets the path to the data file
            public ApiGameJamsController(IWebHostEnvironment webHostEnvironment)
            {
                _dataPath = Path.Combine(webHostEnvironment.WebRootPath, "data", "gamejams.json");
            }

            // API action to get game jams data as JSON
            [HttpGet]
            public async Task<IActionResult> GetGameJams()
            {
                try
                {
                    var jsonString = await System.IO.File.ReadAllTextAsync(_dataPath);
                    var gameJams = JsonSerializer.Deserialize<List<GameJam>>(jsonString);  // Deserialize the data into a list of GameJam objects
                    return Ok(gameJams);  // Return the data as a JSON response
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Error: {ex.Message}");  // Handle errors
                }
            }
        }

        // POST Endpoint for creating a new Game Jam (for API)
        [HttpPost]
        [Route("api/[controller]")]
        public async Task<IActionResult> CreateGameJam([FromBody] GameJam newGameJam)
        {
            try
            {
                var jsonString = await System.IO.File.ReadAllTextAsync(_dataPath);
                var gameJams = JsonSerializer.Deserialize<List<GameJam>>(jsonString);

                // Add the new game jam to the list
                gameJams.Add(newGameJam);

                // Serialize the updated list and save it back to the file
                var updatedJson = JsonSerializer.Serialize(gameJams, new JsonSerializerOptions { WriteIndented = true });
                await System.IO.File.WriteAllTextAsync(_dataPath, updatedJson);

                return Ok(new { message = "Game Jam created successfully!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using IGDA_Games_Made_In_Utah.Models;
using System.Collections.Generic;
using System.Linq;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class HomeController : Controller
    {
        // Sample data for events and games
        private readonly List<Event> _events;
        private readonly List<Game> _games;

        public HomeController()
        {
            // Initialize sample events and games
            _events = new List<Event>
            {
                new Event { Name = "ICE: The 3D Environment Conference", Date = new DateTime(2024, 10, 1), Location = "Online" },
                new Event { Name = "Game Development Meetup", Date = new DateTime(2024, 10, 10), Location = "Salt Lake City" }
            };

            _games = new List<Game>
            {
                new Game { Title = "Snail Simulator", Developer = "Small Solar Sloth Studios" },
                new Game { Title = "Familiars.io", Developer = "Familiars.io" }
            };
        }

        // The Index action for the Home page
        public IActionResult Index()
        {
            return View();
        }

        // Search action for the search form
        [HttpGet]
        public IActionResult Search(string query)
        {
            var searchResults = new
            {
                Events = new List<Event>(),  // Initialize with empty lists
                Games = new List<Game>()
            };

            // If a query is provided, perform search logic
            if (!string.IsNullOrEmpty(query))
            {
                searchResults = new
                {
                    Events = _events.Where(e => e.Name.ToLower().Contains(query.ToLower())).ToList(),
                    Games = _games.Where(g => g.Title.ToLower().Contains(query.ToLower())).ToList()
                };
            }

            ViewData["SearchQuery"] = query;
            return View("SearchResults", searchResults);
        }
        public IActionResult Events()
        {
            var upcomingEvents = _events.Where(e => e.Date >= DateTime.Now).ToList(); // Only show future events
            return View(upcomingEvents);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

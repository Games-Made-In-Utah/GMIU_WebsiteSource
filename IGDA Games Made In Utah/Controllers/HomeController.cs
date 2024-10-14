using Microsoft.AspNetCore.Mvc;
using IGDAGamesMadeInUtah.Services;
using System.Threading.Tasks;

namespace IGDAGamesMadeInUtah.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventScraper _eventScraper;

        public HomeController(IEventScraper eventScraper)
        {
            _eventScraper = eventScraper;
        }

        public async Task<IActionResult> Index()
        {
            // Optionally scrape and display events on the home page
            var events = await _eventScraper.ScrapeEvents();
            return View(events);
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult PrivacyPolicy()
        {
            return View();
        }
        public IActionResult TermsOfService()
        {
            return View();
        }

        private List<(string Developer, string Game, string ImageUrl)> indies = new List<(string, string, string)>
        {
            ("Small Solar Sloth Studios", "Snail Simulator", "~/images/SnailSimulator.png"),
            ("Familiars.io", "Familiars.io", "~/images/Familiars.png"),
            ("Kogoy Galaxy", "Moniker", "~/images/Moniker.png"),
            ("Oakie Studio", "It's A Game Changer", "~/images/ItsAGameChanger.png"),
            ("Frostbane Studios", "Airlock Arena & Purrseus", "~/images/FrostBaneStudios.png"),
            ("Lotus Mountain Creative", "Narcalid", "~/images/LotusMtn.png"),
            ("D20 Studios", "Abalon", "~/images/abalon.png"),
            ("Craft Lake City", "Craft Lake City", "~/images/craft_lake_city.png"),
            ("Justin Whitchurch", "Table Top Creature Tracker", "~/images/TableTopCreatureTracker.png")
        };

        [HttpGet]
        public IActionResult Search(string query)
        {
            // Check if the query is valid
            if (string.IsNullOrEmpty(query))
            {
                return View("SearchResults", new List<(string, string, string)>());  // Return an empty list if no query is provided
            }

            // Perform the search on both developer names and game titles
            var searchResults = indies
                .Where(indie => indie.Developer.Contains(query, System.StringComparison.OrdinalIgnoreCase)
                             || indie.Game.Contains(query, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Pass the search results to the view
            return View("SearchResults", searchResults);
        }

    }
}

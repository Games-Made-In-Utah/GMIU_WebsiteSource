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
    }
}

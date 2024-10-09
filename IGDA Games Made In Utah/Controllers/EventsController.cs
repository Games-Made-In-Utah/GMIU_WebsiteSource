using Microsoft.AspNetCore.Mvc;
using IGDA_Games_Made_In_Utah.Models;
using IGDAGamesMadeInUtah.Services;
using System.Threading.Tasks;

namespace IGDAGamesMadeInUtah.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventScraper _eventScraper;

        // Inject the EventScraper service
        public EventsController(IEventScraper eventScraper)
        {
            _eventScraper = eventScraper;
        }

        // Index action that scrapes the events and passes them to the view
        public async Task<IActionResult> Index()
        {
            // Call the EventScraper to get the list of events
            var events = await _eventScraper.ScrapeEvents();

            // Pass the events data to the View
            return View(events);
        }
    }
}

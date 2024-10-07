using IGDA_Games_Made_In_Utah.Models;
using Microsoft.AspNetCore.Mvc;

public class EventsController : Controller
{
    private readonly List<Event> _events;

    public EventsController()
    {
        // Initialize sample events
        _events = new List<Event>
        {
            new Event { Name = "ICE: The 3D Environment Conference", Date = new DateTime(2024, 10, 1), Location = "Online" },
            new Event { Name = "Game Development Meetup", Date = new DateTime(2024, 10, 10), Location = "Salt Lake City" },
            new Event { Name = "GameSoundCon", Date = new DateTime(2024, 10, 29), Location = "Burbank, CA" },
            new Event { Name = "GDEX", Date = new DateTime(2024, 10, 24), Location = "Midwest, USA" }
        };
    }

    // Action to show all upcoming events
    public IActionResult Index()
    {
        var upcomingEvents = _events.Where(e => e.Date >= DateTime.Now).ToList();
        return View("Events", upcomingEvents);
        // This returns the view named 'Index.cshtml' in Views/Events
    }
}
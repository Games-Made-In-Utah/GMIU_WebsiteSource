// IEventScraper.cs
using IGDA_Games_Made_In_Utah.Models;

namespace IGDAGamesMadeInUtah.Services
{
    public interface IEventScraper
    {
        Task<List<Events>> ScrapeEvents();
    }
}

// EventScraper.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IGDA_Games_Made_In_Utah.Models;

namespace IGDAGamesMadeInUtah.Services
{
    public class EventScraper : IEventScraper
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<Events>> ScrapeEvents()
        {
            var url = "https://igda.org/events/";
            var html = await client.GetStringAsync(url);
            var events = new List<Events>();

            // Regex for extracting event details
            var eventPattern = @"<div class=""col-md-2 no-pad"">\s*<div class=""date"">\s*<div class=""affari-table"">\s*<div class=""cell"">\s*<span class=""d"">(?<day>\d+)</span>\s*<span class=""M-y"">(?<monthYear>.+?)</span>\s*</div>\s*</div>\s*</div>\s*</div>\s*<div class=""col-md-8"">\s*<h3 class=""hl2"">(?<title>.+?)<\/h3>\s*<p>.*<\/p>\s*<p>(?<description>.+?)<\/p>\s*<a href=""(?<link>.+?)"" class=""cta-link"">Learn More<\/a>";
            var imagePattern = @"<div class=""event-thumb"" style=""background-image:\s*url\('(?<imageUrl>.+?)'\);""";

            var eventMatches = Regex.Matches(html, eventPattern);
            var imageMatches = Regex.Matches(html, imagePattern);

            // Iterate over matches and populate the event model list
            for (int i = 0; i < eventMatches.Count; i++)
            {
                var eventMatch = eventMatches[i];
                var imageMatch = imageMatches[i];

                var day = eventMatch.Groups["day"].Value;
                var monthYear = eventMatch.Groups["monthYear"].Value;
                var title = eventMatch.Groups["title"].Value;
                var description = eventMatch.Groups["description"].Value;
                var link = eventMatch.Groups["link"].Value;
                var imageUrl = imageMatch.Groups["imageUrl"].Value;

                var eventModel = new Events
                {
                    Day = day,
                    MonthYear = monthYear,
                    Title = title,
                    Description = description,
                    Link = link,
                    ImageUrl = imageUrl
                };

                events.Add(eventModel);
            }

            return events;
        }
    }
}

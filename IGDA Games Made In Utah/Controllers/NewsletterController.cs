using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly string _filePath = "wwwroot/data/subscribers.json"; // Path to the JSON file

        // Email validation regex pattern
        private readonly string _emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        [HttpPost]
        public async Task<IActionResult> Subscribe([FromBody]EmailModel emailModel)
        {
            string email = emailModel.Email; // Use a model to capture the posted email

            // Validate email with regex
            if (!string.IsNullOrEmpty(email) && Regex.IsMatch(email, _emailPattern))
            {
                // Load existing subscribers from the JSON file
                var subscribers = new List<string>();
                if (System.IO.File.Exists(_filePath))
                {
                    var json = await System.IO.File.ReadAllTextAsync(_filePath);
                    if (!string.IsNullOrEmpty(json))
                    {
                        subscribers = JsonConvert.DeserializeObject<List<string>>(json);
                    }
                }

                // Check if email is already subscribed
                if (!subscribers.Contains(email))
                {
                    subscribers.Add(email);

                    // Ensure the directory exists
                    var directoryPath = Path.GetDirectoryName(_filePath);
                    if (!Directory.Exists(directoryPath))
                    {
                        Directory.CreateDirectory(directoryPath);  // Create the directory if it doesn't exist
                    }

                    // Save updated list to the file
                    var updatedJson = JsonConvert.SerializeObject(subscribers, Formatting.Indented);
                    await System.IO.File.WriteAllTextAsync(_filePath, updatedJson);

                    return Json(new { success = true, message = "You have been subscribed to the newsletter!" });
                }

                return Json(new { success = true, message = "You're already subscribed to the newsletter!" });
            }

            return Json(new { success = false, message = "Invalid email address." });
        }
    }

    public class EmailModel
    {
        public string Email { get; set; }
    }
}

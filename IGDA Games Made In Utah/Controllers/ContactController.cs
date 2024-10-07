using Microsoft.AspNetCore.Mvc;
using System;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class ContactController : Controller
    {
        // GET: /Contact/
        public IActionResult Index()
        {
            return View("Contact");  // Return the Contact.cshtml view
        }

        // POST: /Contact/Submit
        [HttpPost]
        public IActionResult Submit(string name, string email, string message)
        {
            // Log the contact form details (for development purposes)
            Console.WriteLine($"Name: {name}, Email: {email}, Message: {message}");

            // Pass a success message to the view using ViewBag
            ViewBag.Message = "Thank you for reaching out!";
            
            // Return the Contact view to show the thank-you message
            return View("Contact");
        }

    }

}

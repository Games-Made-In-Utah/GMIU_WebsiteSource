using Microsoft.AspNetCore.Mvc;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class IndiesController : Controller
    {
        // GET: /Indies/
        public IActionResult Index()
        {
            return View("Indies");  // Explicitly returning the Indies view
        }

        // GET: /Indies/Details/1
        public IActionResult Details(int id)
        {
            ViewBag.IndieId = id;  
            return View("Details");  
        }
    }
}

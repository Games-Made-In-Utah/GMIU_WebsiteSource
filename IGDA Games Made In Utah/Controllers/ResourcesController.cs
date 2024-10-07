using Microsoft.AspNetCore.Mvc;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class ResourcesController : Controller
    {
        public IActionResult Index()
        {
            return View("Resources");
        }
    }
    
}

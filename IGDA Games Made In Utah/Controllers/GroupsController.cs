using Microsoft.AspNetCore.Mvc;

namespace IGDA_Games_Made_In_Utah.Controllers
{
    public class GroupsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Project.Hub.Controllers
{
    public class VersionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Entities;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var text = System.IO.File.ReadAllText("hub.config.json");
            var config = new RawConfig
            {
                Text = text
            };

            return View(config);
        }
    }
}

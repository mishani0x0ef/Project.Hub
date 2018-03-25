using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Hub.Models;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public HomeController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> Index()
        {
            var config = await _provider.GetConfig();
            return View(config);
        }

        public async Task<IActionResult> Environment(string id)
        {
            var config = await _provider.GetConfig();
            var environment = config.GetEnvironment(id);
            return View(environment);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

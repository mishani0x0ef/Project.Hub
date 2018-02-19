using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project.Hub.Models;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;

namespace Project.Hub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public HomeController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Index()
        {
            return View(_provider.GetConfig());
        }

        public IActionResult Environment(string id)
        {
            var config = _provider.GetConfig();
            var environment = config.GetEnvironment(id);
            return View(environment);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

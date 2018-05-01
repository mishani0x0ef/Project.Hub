using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public ComponentController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> Index(string id)
        {
            var config = await _provider.GetConfig();
            foreach (var env in config.Environments)
            {
                var components = env.GetAllComponents();
                foreach(var component in components)
                {
                    if(component.Name == id)
                    {
                        return View(component);
                    }
                }
            }

            return View(null);
        }
    }
}

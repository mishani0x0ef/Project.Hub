using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IComponentProvider _provider;

        public ComponentController(IComponentProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> Index(string id)
        {
            var component = await _provider.GetByName(id);
            return View(component);
        }
    }
}

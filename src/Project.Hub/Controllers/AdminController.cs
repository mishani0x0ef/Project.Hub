using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRawConfigProvider _configProvider;

        public AdminController(IRawConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public async Task<IActionResult> Index()
        {
            var config = await _configProvider.GetConfig();
            return View(config);
        }

        [HttpPost]
        public async Task SaveHubConfig([FromBody] string config)
        {
            // todo: clear cache. MR
            await _configProvider.UpdateHubConfig(config);
        }

        [HttpPost]
        public async Task SaveNlogConfig([FromBody] string config)
        {
            await _configProvider.UpdateNLogConfig(config);
        }
    }
}

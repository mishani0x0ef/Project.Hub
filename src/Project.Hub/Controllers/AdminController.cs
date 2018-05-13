using Common.Cache;
using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRawConfigProvider _configProvider;
        private readonly ICache _cache;

        public AdminController(IRawConfigProvider configProvider, ICache cache)
        {
            _configProvider = configProvider;
            _cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            var config = await _configProvider.GetConfig();
            return View(config);
        }

        [HttpPost]
        public async Task SaveHubConfig([FromBody] string config)
        {
            await _configProvider.UpdateHubConfig(config);
            // clear cache to make all data refresh after config change.
            _cache.Clear();
        }

        [HttpPost]
        public async Task SaveNlogConfig([FromBody] string config)
        {
            await _configProvider.UpdateNLogConfig(config);
        }
    }
}

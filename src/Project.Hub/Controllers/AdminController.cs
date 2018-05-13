using Common.Cache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using Project.Hub.Models.Admin;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IRawConfigProvider _configProvider;
        private readonly ICache _cache;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPasswordHasher<IdentityUser> _passwordHasher;

        public AdminController(
            IRawConfigProvider configProvider, 
            ICache cache,
            UserManager<IdentityUser> userManager,
            IPasswordHasher<IdentityUser> passwordHasher)
        {
            _configProvider = configProvider;
            _cache = cache;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        public async Task<IActionResult> Index(string passwordHash = null)
        {
            var config = await _configProvider.GetConfig();
            return View(new RawConfigExtended(config, passwordHash));
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

        [HttpPost]
        public async Task<IActionResult> GeneratePasswordHash([FromForm] string password)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var passwordHash = _passwordHasher.HashPassword(user, password);
            return RedirectToAction(nameof(AdminController.Index), "Admin", new { passwordHash });
        }
    }
}

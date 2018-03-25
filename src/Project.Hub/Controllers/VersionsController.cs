using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class VersionsController : Controller
    {
        private readonly IVersionProvider _versionProvider;

        public VersionsController(IVersionProvider versionProvider)
        {
            _versionProvider = versionProvider;
        }

        public async Task<IActionResult> Index()
        {
            var version = await _versionProvider.GetVersions();
            return View(version);
        }
    }
}

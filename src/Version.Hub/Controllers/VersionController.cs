using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Version.Hub.Config;
using Version.Hub.Domain;

namespace Version.Hub.Controllers
{
    [Route("api/[controller]")]
    public class VersionController : Controller
    {
        private readonly IVersionProvider _versionProvider;

        public VersionController(IVersionProvider provider)
        {
            _versionProvider = provider;
        }

        [HttpGet("{id}")]
        public async Task<VersionInfo> Get(string id)
        {
            var version = await _versionProvider.GetVersion(id);
            return version;
        }
    }
}

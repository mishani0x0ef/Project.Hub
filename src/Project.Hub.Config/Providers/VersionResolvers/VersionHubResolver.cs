using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using System.Net.Http;
using Version.Hub.Domain;
using Microsoft.Extensions.Logging;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class VersionHubResolver : ResolverWithFallback, IVersionResolver
    {
        public VersionHubResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
        }

        protected override async Task<string> GetRealVersion(VersionOptions options)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(options.Path);
            response.EnsureSuccessStatusCode();
            var versionInfo = await response.Content.ReadAsAsync<VersionInfo>();

            return versionInfo.Version;
        }
    }
}

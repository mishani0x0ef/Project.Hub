using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using System.Net.Http;
using Version.Hub.Domain;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class VersionHubResolver : IVersionResolver
    {
        private readonly IVersionResolver _fallBackResolver;

        public VersionHubResolver(IVersionResolver fallback)
        {
            _fallBackResolver = fallback;
        }

        public async Task<string> GetVersion(VersionOptions options)
        {
            var apiUrl = options.Path;
            var client = new HttpClient();

            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var versionInfo = await response.Content.ReadAsAsync<VersionInfo>();

                return versionInfo.Version;
            }
            catch
            {
                return await _fallBackResolver.GetVersion(options);
            }
        }
    }
}

using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using System.Net.Http;
using Version.Hub.Domain;
using Microsoft.Extensions.Logging;
using System;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class VersionHubResolver : IVersionResolver
    {
        private readonly IVersionResolver _fallBackResolver;
        private readonly ILogger _logger;

        public VersionHubResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger)
        {
            _fallBackResolver = fallback;
            _logger = logger;
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
            catch (Exception ex)
            {
                var message = $"Cannot resolve version by path '{apiUrl}'. Use falback resolver.";
                _logger.LogError(ex, message);
                return await _fallBackResolver.GetVersion(options);
            }
        }
    }
}

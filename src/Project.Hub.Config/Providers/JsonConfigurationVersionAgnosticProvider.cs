using Common.File;
using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.v1;
using Project.Hub.Config.Interfaces;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hub.Config.Providers
{
    /// <summary>
    /// Provide strategy to select correct resolver based on format version.
    /// </summary>
    public class JsonConfigurationVersionAgnosticProvider : JsonCachableReader<ConfigurationVersion>, IConfigurationProvider
    {
        private readonly Dictionary<string, IConfigurationProvider> _providers;

        public JsonConfigurationVersionAgnosticProvider(IOptionsProvider configPathResolver) : base(configPathResolver.ConfigPath)
        {
            _providers = new Dictionary<string, IConfigurationProvider>()
            {
                { string.Empty, new JsonConfigurationProvider(configPathResolver) },
                { "1.0", new JsonConfigurationProvider(configPathResolver) },
                { "2.0", new JsonConfigurationProviderV2(configPathResolver) },
            };
        }

        public async Task<Configuration> GetConfig()
        {
            var config = await GetOrResolveIfChanged();

            if (!_providers.TryGetValue(config.Version, out var provider))
            {
                throw new KeyNotFoundException($"Cannot find appropriate provider for format with version '{config.Version}'. Please check version of your configuration file.");
            }

            return await provider.GetConfig();
        }
    }
}

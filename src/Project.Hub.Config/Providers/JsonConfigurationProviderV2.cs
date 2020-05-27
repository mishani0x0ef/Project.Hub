using System.Linq;
using System.Threading.Tasks;
using Common.File;
using Project.Hub.Config.Entities.v1;
using Project.Hub.Config.Entities.v2;
using Project.Hub.Config.Interfaces;

namespace Project.Hub.Config.Providers
{
    /// <summary>
    /// Support second version of json configuration.
    /// </summary>
    public class JsonConfigurationProviderV2 : JsonCachableReader<HubConfiguration>, IConfigurationProvider
    {
        public JsonConfigurationProviderV2(IOptionsProvider configPathResolver) : base(configPathResolver.ConfigPath)
        {
        }

        public async Task<Configuration> GetConfig()
        {
            var config = await GetOrResolveIfChanged();
            return ToConfiguration(config);
        }

        private Configuration ToConfiguration(HubConfiguration initialConfig)
        {
            return new Configuration
            {
                SystemLinks = initialConfig.CommonServices
                    .Select(s => new SiteLink(s.Name, s.Url, s.Description)
                    {
                        ShowFavicon = true
                    })
                    .ToList(),
                Environments = initialConfig.Environments
                    .Select(env => new EnvironmentConfig(env.Name, env.Description)
                    {
                        Sites = initialConfig.Websites
                            .Where(s => s.Environments.Any(e => e.Environment == env.Name))
                            .Select(s =>
                            {
                                var envSite = s.Environments.First(e => e.Environment == env.Name);
                                return new SiteLink
                                {
                                    Name = s.Name,
                                    Description = s.Description,
                                    ShowFavicon = true,
                                    Url = envSite.Url,
                                    VersionOptions = envSite.VersionOptions,
                                };
                            }).ToList()
                    }).ToList()
            };
        }
    }
}

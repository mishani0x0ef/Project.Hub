using System.Collections.Generic;
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

        private Configuration ToConfiguration(HubConfiguration config)
        {
            return new Configuration
            {
                SystemLinks = config.CommonServices
                    .Select(AddaptToV1)
                    .ToList(),
                Environments = config.Environments
                    .Select(env => new EnvironmentConfig(env.Name, env.Description)
                    {
                        Sites = AddaptToV1(config.Websites, env.Name),
                        Services = AddaptToV1(config.Apis, env.Name),
                        Downloads = AddaptToV1(config.Downloads, env.Name),
                    }).ToList()
            };
        }

        private SiteLink AddaptToV1(CommonService website)
        {
            return new SiteLink(website.Name, website.Url, website.Description)
            {
                ShowFavicon = true
            };
        }

        private List<SiteLink> AddaptToV1(IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> websites, string environment)
        {
            return websites
                .Where(site => site.Environments.Any(e => e.Environment == environment))
                .Select(site =>
                {
                    var env = site.Environments.First(e => e.Environment == environment);
                    return new SiteLink
                    {
                        Name = site.Name,
                        Description = site.Description,
                        Url = env.Url,
                        VersionOptions = env.VersionOptions,
                        ShowFavicon = true,
                    };
                })
                .ToList();
        }

        private List<DownloadLink> AddaptToV1(IEnumerable<Download> downloads, string environment)
        {
            return downloads
                .Where(download => download.Environments.Any(e => e.Environment == environment))
                .Select(download =>
                {
                    var env = download.Environments.First(e => e.Environment == environment);
                    return new DownloadLink
                    {
                        Name = download.Name,
                        Description = download.Description,
                        Type = download.Type,
                        Mode = download.Mode,
                        DownloadPath = env.DownloadPath,
                        VersionOptions = env.VersionOptions,
                    };
                })
                .ToList();
        }
    }
}

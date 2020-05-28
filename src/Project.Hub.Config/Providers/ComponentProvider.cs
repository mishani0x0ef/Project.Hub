using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities.Common.Component;
using System.Threading.Tasks;
using Project.Hub.Config.Util;
using System.Collections.Generic;
using System.Linq;
using Project.Hub.Config.Entities.Common.Version;
using Project.Hub.Config.Entities.v1;

namespace Project.Hub.Config.Providers
{
    public class ComponentProvider : IComponentProvider
    {
        private readonly IConfigurationProvider _configProvider;
        private readonly IVersionProvider _versionProvider;

        public ComponentProvider(IConfigurationProvider configProvider, IVersionProvider versionProvider)
        {
            _configProvider = configProvider;
            _versionProvider = versionProvider;
        }

        public async Task<ComponentDetails> GetByName(string name)
        {
            var config = await _configProvider.GetConfig();
            var component = GetBaseInfo(name, config);

            var environments = await GetComponentEnvironments(name, config.Environments);
            component.Environments = new HashSet<EnvironmentDetails>(environments);

            return component;
        }

        private ComponentDetails GetBaseInfo(string componentName, Configuration config)
        {
            var environments = config.Environments;
            var component = environments
                .Aggregate(new List<ComponentConfig>(), (list, env) => list.Concat(env.GetAllComponents()).ToList())
                .FirstOrDefault(c => c.Name == componentName);

            return component == null
                ? null
                : new ComponentDetails()
                {
                    Name = component.Name,
                    Description = component.Description,
                    Tags = component.Tags,
                };
        }

        private async Task<IEnumerable<EnvironmentDetails>> GetComponentEnvironments(string componentName, IEnumerable<EnvironmentConfig> envs)
        {
            var allVersions = await _versionProvider.GetVersions();
            var versions = allVersions.Components.First(v => v.Name == componentName).Versions;
            var envDetails = versions
                .Select(v => GetEnvironmentDetails(componentName, envs, v))
                .Where(v => v != null);
            return envDetails;
        }

        private EnvironmentDetails GetEnvironmentDetails(string componentName, IEnumerable<EnvironmentConfig> envs, ComponentVersion version)
        {
            var environment = envs.First(e => e.Name == version.EnvironmentName);
            var component = environment.GetAllComponents().FirstOrDefault(c => c.Name == componentName);

            return component == null ? null : new EnvironmentDetails()
            {
                Name = environment.Name,
                Description = environment.Description,
                Version = version.Version,
                Link = GetComponentLink(component)
            };
        }

        private string GetComponentLink(ComponentConfig component)
        {
            if (component is SiteLink)
            {
                var siteLink = component as SiteLink;
                return siteLink.Url;
            }
            else if (component is DownloadLink)
            {
                var downloadLink = component as DownloadLink;
                return downloadLink.DownloadPath;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}

using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities.Version;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Project.Hub.Config.Entities;
using System;
using Project.Hub.Config.Util;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigVersionProvider : IVersionProvider
    {
        private readonly IConfigurationProvider _configProvider;

        public JsonConfigVersionProvider(IConfigurationProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public async Task<VersionsModel> GetVersions()
        {
            // todo: implement time based caching. MR
            return await ReloadVersions();
        }

        private Task<VersionsModel> ReloadVersions()
        {
            // todo: make config provider async. MR
            var config = _configProvider.GetConfig();

            var environments = config.Environments.Select(e => e.Name);
            var components = GetComponents(config);

            var versions = new VersionsModel
            {
                Environments = new HashSet<string>(environments),
                Components = new HashSet<Component>(components),
                LastUpdated = DateTimeOffset.Now
            };

            return Task.FromResult(versions);
        }

        private IEnumerable<Component> GetComponents(Configuration config)
        {
            var componentNames = GetComponentsNames(config);
            var uniqComponentNames = new HashSet<string>(componentNames);

            foreach(var name in uniqComponentNames)
            {
                var component = new Component { Name = name };
                var versions = config.Environments.Select(e => GetComponentVersion(name, e));
                component.Versions = new HashSet<ComponentVersion>(versions);
                yield return component;
            }
        }

        private IEnumerable<string> GetComponentsNames(Configuration config)
        {
            var names = new List<string>();
            foreach (var env in config.Environments)
            {
                var configs = env.GetAllConfigs();
                names.AddRange(configs.Select(c => c.Name));
            }
            return names;
        }

        private ComponentVersion GetComponentVersion(string name, EnvironmentConfig environment)
        {
            var components = environment.GetAllConfigs();
            var component = components.FirstOrDefault(c => c.Name == name);
            var version = component != null ? "3.196.63" : "-";
            return new ComponentVersion(environment.Name, version);
        }
    }
}

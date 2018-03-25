﻿using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities.Version;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Project.Hub.Config.Entities;
using System;
using Project.Hub.Config.Util;
using Project.Hub.Config.Providers.VersionResolvers;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigVersionProvider : IVersionProvider
    {
        private readonly IConfigurationProvider _configProvider;
        private readonly VersionResolverFactory _versionFactory;

        public JsonConfigVersionProvider(IConfigurationProvider configProvider, VersionResolverFactory factory)
        {
            _configProvider = configProvider;
            _versionFactory = factory;
        }

        public async Task<VersionsModel> GetVersions()
        {
            // todo: implement time based caching. MR
            return await ReloadVersions();
        }

        private async Task<VersionsModel> ReloadVersions()
        {
            // todo: make config provider async. MR
            var config = _configProvider.GetConfig();

            var environments = config.Environments.Select(e => e.Name);
            var components = await GetComponents(config);

            var versions = new VersionsModel
            {
                Environments = new HashSet<string>(environments),
                Components = new HashSet<Component>(components),
                LastUpdated = DateTimeOffset.Now
            };

            return versions;
        }

        private async Task<IEnumerable<Component>> GetComponents(Configuration config)
        {
            var componentNames = GetComponentsNames(config);
            var uniqComponentNames = new HashSet<string>(componentNames);
            var components = new List<Component>();

            foreach(var name in uniqComponentNames)
            {
                var versions = new List<ComponentVersion>();
                foreach (var env in config.Environments)
                {
                    versions.Add(await GetComponentVersion(name, env));
                }
                var component = new Component { Name = name, Versions = new HashSet<ComponentVersion>(versions) };
                components.Add(component);
            }
            return components;
        }

        private IEnumerable<string> GetComponentsNames(Configuration config)
        {
            var names = new List<string>();
            foreach (var env in config.Environments)
            {
                var configs = env.GetAllComponents();
                names.AddRange(configs.Select(c => c.Name));
            }
            return names;
        }

        private async Task<ComponentVersion> GetComponentVersion(string name, EnvironmentConfig environment)
        {
            var components = environment.GetAllComponents();
            var component = components.FirstOrDefault(c => c.Name == name);

            IVersionResolver resolver = _versionFactory.GetResolver(component);
            var version = await resolver.GetVersion(component?.VersionOptions);

            return new ComponentVersion(environment.Name, version);
        }
    }
}

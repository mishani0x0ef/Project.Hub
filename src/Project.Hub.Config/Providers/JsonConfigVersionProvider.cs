﻿using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities.Version;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Project.Hub.Config.Entities;
using System;
using Project.Hub.Config.Util;
using Project.Hub.Config.Providers.VersionResolvers;
using Microsoft.Extensions.Caching.Memory;
using Common.Cache;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigVersionProvider : IVersionProvider
    {
        private const string CacheKey = "versions-config";

        private readonly IConfigurationProvider _configProvider;
        private readonly ICacheExpirationProvider _cacheExpirationProvider;
        private readonly VersionResolverFactory _versionFactory;
        private readonly ICache _cache;

        public JsonConfigVersionProvider(IConfigurationProvider configProvider,
            ICacheExpirationProvider cacheExpirationProvider,
            VersionResolverFactory factory,
            ICache cache)
        {
            _configProvider = configProvider;
            _cacheExpirationProvider = cacheExpirationProvider;
            _versionFactory = factory;
            _cache = cache;
        }

        public async Task<VersionsModel> GetVersions()
        {
            return await _cache.GetOrCreateAsync(CacheKey, async (entry) =>
            {
                entry.AbsoluteExpiration = _cacheExpirationProvider.GetExpiration();
                return await ReloadVersions();
            });
        }

        private async Task<VersionsModel> ReloadVersions()
        {
            var config = await _configProvider.GetConfig();

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
            var componentTasks = uniqComponentNames.Select(c => GetComponent(c, config.Environments));
            var components = await Task.WhenAll(componentTasks.ToArray());
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

        private async Task<Component> GetComponent(string name, IEnumerable<EnvironmentConfig> environments)
        {
            var versionTasks = environments.Select(e => GetComponentVersion(name, e));
            var versions = await Task.WhenAll(versionTasks.ToArray());
            var component = new Component { Name = name, Versions = new HashSet<ComponentVersion>(versions) };
            return component;
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

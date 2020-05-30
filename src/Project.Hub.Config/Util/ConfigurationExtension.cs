using System;
using System.Linq;
using System.Collections.Generic;
using Project.Hub.Config.Entities.v1;
using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.v2;

namespace Project.Hub.Config.Util
{
    public static class ConfigurationExtension
    {
        /// <summary>
        /// Get specific environment from the configuration.
        /// </summary>
        /// <param name="config">Configuration.</param>
        /// <param name="name">Name of the environment to resolve.</param>
        /// <returns>Info about specific environment.</returns>
        public static EnvironmentConfig GetEnvironment(this Configuration config, string name)
        {
            return
                config?.Environments.FirstOrDefault(
                    e => string.Equals(e.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Get specific download from the environment configuration.
        /// </summary>
        /// <param name="environment">Environment that contains downloads.</param>
        /// <param name="name">Name of the downloads to resolve.</param>
        /// <returns>Info about the specific download for current environment.</returns>
        public static DownloadLink GetDownloadLink(this EnvironmentConfig environment, string name)
        {
            return
                environment?.Downloads.FirstOrDefault(
                    d => string.Equals(d.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Get all sites, downloads and services related to environment.
        /// </summary>
        public static IEnumerable<ComponentConfig> GetAllComponents(this EnvironmentConfig environment)
        {
            foreach (var site in environment.Sites)
            {
                yield return site;
            }
            foreach (var download in environment.Downloads)
            {
                if (download.Type != DownloadType.RemoteDesktop)
                {
                    yield return download;
                }
            }
            foreach (var service in environment.Services)
            {
                yield return service;
            }
        }

        /// <summary>
        /// Get specific downloads from the specific environment.
        /// </summary>
        /// <param name="config">Configuration.</param>
        /// <param name="environmentName">Environment to look for download.</param>
        /// <param name="name">Download's name to search for.</param>
        /// <returns>Info about the specific download for provided environment.</returns>
        public static DownloadLink GetDownloadLink(this Configuration config, string environmentName, string name)
        {
            var environement = config.GetEnvironment(environmentName);
            return environement.GetDownloadLink(name);
        }

        /// <summary>
        /// Get specific downloads based on it's path parameter.
        /// </summary>
        /// <param name="config">Configuration.</param>
        /// <param name="path">Path to download.</param>
        /// <returns>Info about the specific download.</returns>
        public static DownloadLink GetDownloadLink(this Configuration config, string path)
        {
            if (config == null)
                return null;

            foreach (var environment in config.Environments)
            {
                foreach (var download in environment.Downloads)
                {
                    if (download.DownloadPath == path)
                        return download;
                }
            }
            return null;
        }

        /// <summary>
        /// Search websites, downloads, environments that match query.
        /// </summary>
        /// <param name="config">Configuration to search.</param>
        /// <param name="query">Text to search.</param>
        public static HubConfiguration SearchByQuery(this Configuration config, string query)
        {
            var seachResults = new HubConfiguration();

            if (config.CanSearch(query))
            {
                bool nameMatch(BaseConfig site) => site.IsMatchSearch(query);

                seachResults.Websites = config.Environments.Select(e => e.Sites).SearchWith(nameMatch);
                seachResults.Apis = config.Environments.Select(e => e.Services).SearchWith(nameMatch);
                seachResults.Downloads = config.Environments.Select(e => e.Downloads).SearchWith(nameMatch);
                seachResults.CommonServices = config.SearchCommonWebsites(nameMatch);
                seachResults.Environments = config.Environments
                    .Where(nameMatch)
                    .Select(env => new BaseConfig(env.Name, env.Description));
            }

            return seachResults;
        }

        // <summary>
        /// Search websites, downloads that contains specific tag.
        /// </summary>
        /// <param name="config">Configuration to search.</param>
        /// <param name="tah">Tag to search.</param>
        public static HubConfiguration SearchForTag(this Configuration config, string tag)
        {
            var seachResults = new HubConfiguration();

            if (config.CanSearch(tag))
            {
                bool hasTag(ITagged site) => site.ContainsTag(tag);

                seachResults.Websites = config.Environments.Select(e => e.Sites).SearchWith(hasTag);
                seachResults.Apis = config.Environments.Select(e => e.Services).SearchWith(hasTag);
                seachResults.Downloads = config.Environments.Select(e => e.Downloads).SearchWith(hasTag);
                seachResults.CommonServices = config.SearchCommonWebsites(hasTag);
            }

            return seachResults;
        }

        private static bool CanSearch(this Configuration config, string query) => config != null && !string.IsNullOrWhiteSpace(query);

        private static IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> SearchWith(
            this IEnumerable<IEnumerable<SiteLink>> sites,
            Func<SiteLink, bool> predicate)
        {
            return sites
                .SelectMany(site => site)
                .DistinctBy(site => site.Name)
                .Where(predicate)
                .Select(api => new EnvironmentalComponent<WebsiteEnvironment>
                {
                    Name = api.Name,
                    Description = api.Description,
                    Tags = api.Tags,
                    FaviconFallback = api.FaviconFallback,
                });
        }

        private static IEnumerable<Download> SearchWith(
            this IEnumerable<IEnumerable<DownloadLink>> downloads,
            Func<DownloadLink, bool> predicate)
        {
            return downloads
                .SelectMany(download => download)
                .DistinctBy(download => download.Name)
                .Where(predicate)
                .Select(download => new Download
                {
                    Name = download.Name,
                    Description = download.Description,
                    Tags = download.Tags,
                    Mode = download.Mode,
                    Type = download.Type,
                });
        }

        private static IEnumerable<CommonWebsite> SearchCommonWebsites(this Configuration config, Func<SiteLink, bool> predicate)
        {
            return config.SystemLinks
                .Where(predicate)
                .Select(site => new CommonWebsite
                {
                    Name = site.Name,
                    Description = site.Description,
                    FaviconFallback = site.FaviconFallback,
                    Url = site.Url
                });
        }
    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using Project.Hub.Config.Entities.v1;
using Project.Hub.Config.Entities.Common;

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
                if(download.Type != DownloadType.RemoteDesktop)
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
    }
}

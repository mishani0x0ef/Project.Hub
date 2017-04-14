using System;
using System.Linq;
using Project.Hub.Config.Entities;

namespace Project.Hub.Config.Util
{
    public static class ConfigurationExtension
    {
        public static EnvironmentConfig GetEnvironment(this Configuration config, string name)
        {
            return
                config?.Environments.FirstOrDefault(
                    e => string.Equals(e.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static DownloadLink GetDownloadLink(this EnvironmentConfig environment, string name)
        {
            return
                environment?.Downloads.FirstOrDefault(
                    d => string.Equals(d.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

        public static DownloadLink GetDownloadLink(this Configuration config, string environmentName, string name)
        {
            var environement = config.GetEnvironment(environmentName);
            return environement.GetDownloadLink(name);
        }

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

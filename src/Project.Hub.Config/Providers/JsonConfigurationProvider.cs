using System.IO;
using Project.Hub.Config.Entities;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System;
using Newtonsoft.Json;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigurationProvider : IConfigurationProvider
    {
        private readonly string _configPath;

        private DateTime lastConfigReload = DateTime.MinValue;
        private Configuration config = new Configuration();

        public JsonConfigurationProvider(IConfigPathResolver configPathResolver)
        {
            _configPath = configPathResolver.ConfigPath;
        }

        public Configuration GetConfig()
        {
            var configChanged = FileUtil.IsFileChangedSince(lastConfigReload, _configPath);

            if (configChanged)
            {
                lastConfigReload = DateTime.Now;

                var jsonConfig = File.ReadAllText(_configPath);
                config = JsonConvert.DeserializeObject<Configuration>(jsonConfig);
            }

            return config;
        }
    }
}

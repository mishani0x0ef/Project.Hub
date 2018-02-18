using System.IO;
using System.Web.Script.Serialization;
using Project.Hub.Config.Entities;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigurationProvider : IConfigurationProvider
    {
        private readonly string _configPath;

        private DateTime lastConfigReload = DateTime.MinValue;
        private Configuration config = new Configuration();

        public JsonConfigurationProvider(string configPath)
        {
            _configPath = configPath;
        }

        public Configuration GetConfig()
        {
            var configChanged = FileUtil.IsFileChangedSince(lastConfigReload, _configPath);

            if (configChanged)
            {
                lastConfigReload = DateTime.Now;

                var serializer = new JavaScriptSerializer();
                var jsonConfig = File.ReadAllText(_configPath);
                config = serializer.Deserialize<Configuration>(jsonConfig);
            }

            return config;
        }
    }
}

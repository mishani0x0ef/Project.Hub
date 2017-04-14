using System.IO;
using System.Web.Script.Serialization;
using Project.Hub.Config.Entities;
using Project.Hub.Config.Interfaces;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigurationProvider : IConfigurationProvider
    {
        private readonly string _configPath;

        public JsonConfigurationProvider(string configPath)
        {
            _configPath = configPath;
        }

        public Configuration GetConfig()
        {
            var serializer = new JavaScriptSerializer();

            var jsonConfig = File.ReadAllText(_configPath);

            var config = serializer.Deserialize<Configuration>(jsonConfig);

            return config;
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Project.Hub.Config.Interfaces;
using System.IO;

namespace Project.Hub.Settings
{
    public class ConfigResolver : IConfigPathResolver
    {
        public string ConfigPath { get; }

        public ConfigResolver(IOptions<AppConfiguration> configuration, IHostingEnvironment hostingEnvironment)
        {
            var relativePath = configuration.Value.ConfigPath;
            ConfigPath = Path.Combine(hostingEnvironment.ContentRootPath, relativePath);
        }
    }
}

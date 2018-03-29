using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System.IO;
using Version.Hub.Config;

namespace Version.Hub.Settings
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

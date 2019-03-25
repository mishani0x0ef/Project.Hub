using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Version;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class JsonFileVersionResolver : ResolverWithFallback, IVersionResolver
    {
        public JsonFileVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
        }

        protected async override Task<string> GetRealVersion(VersionOptions options)
        {
            var parts = options.Path.Split('|');
            var filePath = parts[0];
            var jsonSelector = $"$.{parts[1]}";

            using (var stream = File.OpenText(filePath))
            {
                // todo: improve, don't reread file if it's not changed. MR
                var json = await stream.ReadToEndAsync();
                var token = JObject
                    .Parse(json)
                    .SelectToken(jsonSelector);
                return token.Value<string>();
            }
        }
    }
}

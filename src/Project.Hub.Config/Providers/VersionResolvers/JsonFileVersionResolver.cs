using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Version;
using Newtonsoft.Json.Linq;
using Project.Hub.Config.Interfaces;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class JsonFileVersionResolver : ResolverWithFallback, IVersionResolver
    {
        private readonly IFileService _fileService;

        public JsonFileVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger, IFileService fileService) : base(fallback, logger)
        {
            _fileService = fileService;
        }

        protected override async Task<string> GetRealVersion(VersionOptions options)
        {
            var parts = options.Path.Split('|');
            var filePath = parts[0];
            var jsonSelector = parts[1];
            var json = await _fileService.ReadAsync(filePath);
            var token = JObject
                    .Parse(json)
                    .SelectToken(jsonSelector);

            return token.Value<string>();
        }
    }
}

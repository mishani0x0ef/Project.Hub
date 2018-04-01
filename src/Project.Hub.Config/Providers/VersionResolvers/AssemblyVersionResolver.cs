using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using Common.File;
using System;
using Microsoft.Extensions.Logging;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class AssemblyVersionResolver : IVersionResolver
    {
        private readonly IVersionResolver _fallBackResolver;
        private readonly ILogger _logger;

        public AssemblyVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger)
        {
            _fallBackResolver = fallback;
            _logger = logger;
        }

        public async Task<string> GetVersion(VersionOptions options)
        {
            var path = options.Path;

            try
            {
                return AssemblyUtils.GetVersion(path);
            }
            catch (Exception ex)
            {
                var message = $"Cannot resolve version by path '{path}'. Use falback resolver.";
                _logger.LogError(ex, message);
                return await _fallBackResolver.GetVersion(options);
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using Project.Hub.Config.Entities.Common.Version;
using Microsoft.Extensions.Logging;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public abstract class ResolverWithFallback : IVersionResolver
    {
        private readonly IVersionResolver _fallBackResolver;
        private readonly ILogger _logger;

        public ResolverWithFallback(IVersionResolver fallback, ILogger<IVersionResolver> logger)
        {
            _fallBackResolver = fallback;
            _logger = logger;
        }

        public async Task<string> GetVersion(VersionOptions options)
        {
            try
            {
                var version = await GetRealVersion(options);
                return version;
            }
            catch(Exception ex)
            {
                var message = $"Cannot resolve version by path '{options?.Path}'. Use falback resolver.";
                _logger.LogError(ex, message);
                return await _fallBackResolver.GetVersion(options);
            }
        }

        protected abstract Task<string> GetRealVersion(VersionOptions options);
    }
}

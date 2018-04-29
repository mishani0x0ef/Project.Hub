using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities.Version;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class PowerShellVersionResolver : ResolverWithFallback, IVersionResolver
    {
        public PowerShellVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
        }

        protected override Task<string> GetRealVersion(VersionOptions options)
        {
            throw new NotImplementedException();
        }
    }
}

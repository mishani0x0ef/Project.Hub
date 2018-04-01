using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using Common.File;
using Microsoft.Extensions.Logging;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class AssemblyVersionResolver : ResolverWithFallback, IVersionResolver
    {
        public AssemblyVersionResolver(IVersionResolver fallback, ILogger<IVersionResolver> logger) : base(fallback, logger)
        {
        }

        protected override Task<string> GetRealVersion(VersionOptions options)
        {
            var path = options.Path;
            var version = AssemblyUtils.GetVersion(path);
            return Task.FromResult(version);
        }
    }
}

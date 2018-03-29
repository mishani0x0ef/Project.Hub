using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using Version.Util;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class AssemblyVersionResolver : IVersionResolver
    {
        private readonly IVersionResolver _fallBackResolver;

        public AssemblyVersionResolver(IVersionResolver fallback)
        {
            _fallBackResolver = fallback;
        }

        public async Task<string> GetVersion(VersionOptions options)
        {
            var path = options.Path;

            if(AssemblyUtils.TryGetVersion(path, out var version))
            {
                return version;
            }
            else
            {
                return await _fallBackResolver.GetVersion(options);
            }
        }
    }
}

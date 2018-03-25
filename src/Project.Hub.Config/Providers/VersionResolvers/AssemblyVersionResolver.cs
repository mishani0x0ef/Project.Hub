using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using System.IO;
using System.Reflection;

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
            if (!File.Exists(path))
            {
                return await _fallBackResolver.GetVersion(options);
            }

            try
            {
                var assembly = Assembly.LoadFile(path);
                var version = assembly.GetName().Version.ToString();
                return version;
            }
            catch
            {
                // todo: provide logging of error. MR
                return await _fallBackResolver.GetVersion(options);
            }
        }
    }
}

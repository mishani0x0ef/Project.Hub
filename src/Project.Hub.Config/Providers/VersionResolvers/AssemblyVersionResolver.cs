using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;
using System.IO;
using System.Reflection;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class AssemblyVersionResolver : IVersionResolver
    {
        private IVersionResolver FallBackResolver = new DefaultVersionResolver();

        public async Task<string> GetVersion(VersionOptions options)
        {
            var path = options.Path;
            if (!File.Exists(path))
            {
                return await FallBackResolver.GetVersion(options);
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
                return await FallBackResolver.GetVersion(options);
            }
        }
    }
}

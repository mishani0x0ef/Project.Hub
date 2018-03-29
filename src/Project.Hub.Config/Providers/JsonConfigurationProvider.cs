using Project.Hub.Config.Entities;
using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;
using Common.File;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigurationProvider : JsonCachableReader<Configuration>, IConfigurationProvider
    {
        public JsonConfigurationProvider(IConfigPathResolver configPathResolver) : base(configPathResolver.ConfigPath)
        {
        }

        public async Task<Configuration> GetConfig()
        {
            return await GetOrResolveIfChanged();
        }
    }
}

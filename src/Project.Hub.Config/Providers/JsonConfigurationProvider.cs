using Project.Hub.Config.Interfaces;
using System.Threading.Tasks;
using Common.File;
using Project.Hub.Config.Entities.v1;

namespace Project.Hub.Config.Providers
{
    public class JsonConfigurationProvider : JsonCachableReader<Configuration>, IConfigurationProvider
    {
        public JsonConfigurationProvider(IOptionsProvider configPathResolver) : base(configPathResolver.ConfigPath)
        {
        }

        public async Task<Configuration> GetConfig()
        {
            return await GetOrResolveIfChanged();
        }
    }
}

using Common.File;
using System.Threading.Tasks;

namespace Version.Hub.Config.Providers
{
    public class JsonConfigProvider : JsonCachableReader<Entities.Config>, IConfigProvider
    {
        public JsonConfigProvider(IConfigPathResolver configPathResolver) : base(configPathResolver.ConfigPath)
        {
        }

        public async Task<Entities.Config> GetConfig()
        {
            return await GetOrResolveIfChanged();
        }
    }
}

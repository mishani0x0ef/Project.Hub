using Common.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Version.Hub.Domain;

namespace Version.Hub.Config.Providers
{
    public class AssemblyVersionProvider : IVersionProvider
    {
        private readonly IConfigProvider _configProvider;

        public AssemblyVersionProvider(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public async Task<VersionInfo> GetVersion(string component)
        {
            var configs = await _configProvider.GetConfig();
            var componentConfig = configs.VersionConfigs
                .FirstOrDefault(v => String.Equals(v.UniqName, component, StringComparison.InvariantCultureIgnoreCase));

            if(componentConfig != null && AssemblyUtils.TryGetVersion(componentConfig.Path, out var version))
            {
                return new VersionInfo
                {
                    UniqName = component,
                    Version = version
                };
            }
            else
            {
                throw new KeyNotFoundException($"'{component}' not found.");
            }
        }
    }
}

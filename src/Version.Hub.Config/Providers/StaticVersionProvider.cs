using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Version.Hub.Domain;

namespace Version.Hub.Config.Providers
{
    public class StaticVersionProvider : IVersionProvider
    {
        public List<VersionInfo> Versions { get; set; }

        public StaticVersionProvider()
        {
            Versions = new List<VersionInfo>
            {
                new VersionInfo { UniqName = "WebSite", Version = "3.1.4214" },
                new VersionInfo { UniqName = "API", Version = "3.1.6363" },
                new VersionInfo { UniqName = "WinService", Version = "3.1.322" },
            };
        }

        public Task<VersionInfo> GetVersion(string component)
        {
            var version = Versions
                .FirstOrDefault(v => String.Equals(v.UniqName, component, StringComparison.InvariantCultureIgnoreCase));

            if(version == null)
            {
                throw new KeyNotFoundException($"'{component}' not found");
            }

            return Task.FromResult(version);
        }
    }
}

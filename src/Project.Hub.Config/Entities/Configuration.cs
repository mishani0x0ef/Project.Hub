using System.Collections.Generic;

namespace Project.Hub.Config.Entities
{
    public class Configuration
    {
        public List<EnvironmentConfig> Environments { get; set; }

        public List<SiteLink> SystemLinks { get; set; }
    }
}

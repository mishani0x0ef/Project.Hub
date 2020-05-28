using Project.Hub.Config.Entities.Common;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    public class EnvironmentConfig : BaseConfig
    {
        public List<SiteLink> Sites { get; set; }
        public List<SiteLink> Services { get; set; }
        public List<DownloadLink> Downloads { get; set; }

        public EnvironmentConfig()
        {
            Sites = new List<SiteLink>();
            Services = new List<SiteLink>();
            Downloads = new List<DownloadLink>();
        }

        public EnvironmentConfig(string name, string description = null)
        {
            Name = name;
            Description = description;
        }
    }
}

using Project.Hub.Config.Entities.Common;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Configuration that describes specific environment.
    /// </summary>
    public class EnvironmentConfig : BaseConfig
    {
        /// <summary>
        /// Websites that are available within environment.
        /// </summary>
        public List<SiteLink> Sites { get; set; }

        /// <summary>
        /// APIs that are available within environment.
        /// </summary>
        public List<SiteLink> Services { get; set; }

        /// <summary>
        /// Downloads that are available within environment.
        /// </summary>
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

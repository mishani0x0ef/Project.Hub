using Project.Hub.Config.Entities.Common;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Root-level hub configuration that describe all content which is displayed on the website.
    /// Version 2.
    /// </summary>
    public class HubConfiguration
    {
        /// <summary>
        /// List of all environments of the project.
        /// </summary>
        public IEnumerable<BaseConfig> Environments { get; set; }

        /// <summary>
        /// List of all general websites that has no particular environment.
        /// </summary>
        public IEnumerable<CommonWebsite> CommonServices { get; set; }

        /// <summary>
        /// List of all websites that present on different environments.
        /// </summary>
        public IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> Websites { get; set; }

        /// <summary>
        /// List of all APIs that present on different environments.
        /// </summary>
        public IEnumerable<EnvironmentalComponent<WebsiteEnvironment>> Apis { get; set; }

        /// <summary>
        /// List of all downloads that present on different environments.
        /// </summary>
        public IEnumerable<Download> Downloads { get; set; }
    }
}

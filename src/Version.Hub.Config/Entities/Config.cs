using System.Collections.Generic;

namespace Version.Hub.Config.Entities
{
    public class Config
    {
        /// <summary>
        /// List of available configs for versions.
        /// </summary>
        public List<VersionConfig> VersionConfigs { get; set; }
    }
}

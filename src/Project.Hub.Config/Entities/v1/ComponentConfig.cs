using Project.Hub.Config.Entities.Version;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    public class ComponentConfig : BaseConfig
    {
        /// <summary>
        /// Collection of tags that can additionaly describe current item.
        /// </summary>
        public IEnumerable<string> Tags { get; set; }

        /// <summary>
        /// Describe component version resolution options.
        /// </summary>
        public VersionOptions VersionOptions { get; set; }

        public bool IsVersionProvider
        {
            get
            {
                return VersionOptions != null && !string.IsNullOrWhiteSpace(VersionOptions.Path);
            }
        }

        public ComponentConfig()
        {
        }

        public ComponentConfig(string name, string description = null)
        {
            Name = name;
            Description = description;
        }
    }
}

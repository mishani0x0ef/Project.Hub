using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.Common.Version;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Configuration of the specific component (website, downloads).
    /// </summary>
    public class ComponentConfig : BaseConfig, ITagged, IVersioned
    {
        public IEnumerable<string> Tags { get; set; }

        public VersionOptions VersionOptions { get; set; }

        /// <summary>
        /// Gets if options to resolve component's version is provided.
        /// </summary>
        public bool IsVersionProvider => !string.IsNullOrWhiteSpace(VersionOptions?.Path);

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

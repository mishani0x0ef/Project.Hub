using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Version
{
    /// <summary>
    /// Describe basic component (any service, site or application).
    /// </summary>
    public class Component
    {
        /// <summary>
        /// Display name of the component.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Component versions on different environments.
        /// </summary>
        public HashSet<ComponentVersion> Versions { get; set; }
    }
}

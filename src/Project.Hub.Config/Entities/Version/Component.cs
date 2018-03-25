using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Version
{
    /// <summary>
    /// Describe basic component (any service, site or app).
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

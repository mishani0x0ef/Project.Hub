using Project.Hub.Config.Entities.v2;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Component
{
    /// <summary>
    /// Detailed information about the component (website, download, etc.).
    /// </summary>
    public class ComponentDetails : BaseConfig, ITagged
    {
        /// <summary>
        /// List of environments where component is present on and links to component on that environments.
        /// </summary>
        public HashSet<EnvironmentDetails> Environments { get; set; }

        public IEnumerable<string> Tags { get; set; }

        public ComponentDetails()
        {
            Environments = new HashSet<EnvironmentDetails>();
        }
    }
}

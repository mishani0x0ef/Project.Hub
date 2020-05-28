using System.Collections.Generic;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Global application configuration.
    /// Root of the application logic.
    /// Based on the configuration all content is displayed.
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// List of environments that supported by the project.
        /// </summary>
        public List<EnvironmentConfig> Environments { get; set; }

        /// <summary>
        /// Common links that has no specific environment (e.g. Google Analytics, Helpdesk, etc.).
        /// </summary>
        public List<SiteLink> SystemLinks { get; set; }
    }
}

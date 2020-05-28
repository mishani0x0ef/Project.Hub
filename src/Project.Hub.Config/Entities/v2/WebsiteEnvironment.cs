using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.Common.Version;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Description of the website on a specific environment.
    /// </summary>
    public class WebsiteEnvironment : IEnvironmentable, IVersioned
    {
        public string Environment { get; set; }

        /// <summary>
        /// URL to the website on the current environment.
        /// </summary>
        public string Url { get; set; }

        public VersionOptions VersionOptions { get; set; }
    }
}

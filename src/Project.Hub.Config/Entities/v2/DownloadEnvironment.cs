using Project.Hub.Config.Entities.Common;
using Project.Hub.Config.Entities.Common.Version;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Description of the download on a specific environment.
    /// </summary>
    public class DownloadEnvironment : IEnvironmentable, IVersioned
    {
        public string Environment { get; set; }

        /// <summary>
        /// Path to the resource to download.
        /// Depending on Mode can be file system path or URL.
        /// </summary>
        public string DownloadPath { get; set; }

        public VersionOptions VersionOptions { get; set; }
    }
}

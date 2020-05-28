using Project.Hub.Config.Entities.Common;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Describe downloads - component that can be downloaded and then installed (e.g desktop application's installer).
    /// </summary>
    public class DownloadLink : ComponentConfig
    {
        /// <summary>
        /// Mode that should be used to download the component.
        /// </summary>
        public DownloadMode Mode { get; set; }

        /// <summary>
        /// Download type.
        /// </summary>
        public DownloadType Type { get; set; }

        /// <summary>
        /// Path to the resource to download.
        /// Depending on Mode can be file system path or URL.
        /// </summary>
        public string DownloadPath { get; set; }

        public DownloadLink()
        {
        }

        public DownloadLink(string name, string description = null) : base(name, description)
        {
        }
    }
}

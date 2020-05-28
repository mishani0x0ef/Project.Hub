using Project.Hub.Config.Entities.Common;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Resource which can be downloaded as a single file.
    /// </summary>
    public class Download : EnvironmentalComponent<DownloadEnvironment>
    {
        /// <summary>
        /// Download type.
        /// </summary>
        public DownloadType Type { get; set; }

        /// <summary>
        /// Mode that should be used to download the component.
        /// </summary>
        public DownloadMode Mode { get; set; }
    }
}

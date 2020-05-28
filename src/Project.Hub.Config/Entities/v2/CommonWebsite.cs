using Project.Hub.Config.Entities.Common;

namespace Project.Hub.Config.Entities.v2
{
    /// <summary>
    /// Generic website that has no environment.
    /// </summary>
    public class CommonWebsite : BaseConfig
    {
        /// <summary>
        /// URL to the website.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Favicon fallback.
        /// </summary>
        public string FaviconFallback { get; set; }
    }
}

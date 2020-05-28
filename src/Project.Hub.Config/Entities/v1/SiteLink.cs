using Project.Hub.Config.Util;

namespace Project.Hub.Config.Entities.v1
{
    /// <summary>
    /// Website description.
    /// </summary>
    public class SiteLink : ComponentConfig
    {
        /// <summary>
        /// URL to the website.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Defines is website's favicon should be displayed on the Hub GUI. 
        /// If false - displayed default icon.
        /// If true - Hib will try to resolve website's favicon.
        /// </summary>
        public bool ShowFavicon { get; set; }

        /// <summary>
        /// Favicon that will be used if Hub failed to resolve website's favicon automatically.
        /// </summary>
        public string FaviconFallback { get; set; }

        /// <summary>
        /// Website's favicon URL.
        /// </summary>
        public string Favicon
        {
            get
            {
                UriUtil.TryGetFavicon(Url, out var faviconUrl);
                return faviconUrl;
            }
        }

        public SiteLink()
        {
        }

        public SiteLink(string name, string url, string description = null) : base(name, description)
        {
            Url = url;
        }
    }
}

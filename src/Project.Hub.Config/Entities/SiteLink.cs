using Project.Hub.Config.Util;

namespace Project.Hub.Config.Entities
{
    public class SiteLink : BaseConfig
    {
        public string Url { get; set; }

        public bool ShowFavicon { get; set; }

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

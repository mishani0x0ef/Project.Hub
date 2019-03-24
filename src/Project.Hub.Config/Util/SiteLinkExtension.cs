using Project.Hub.Config.Entities;
using System;

namespace Project.Hub.Config.Util
{
    public static class SiteLinkExtension
    {
        public static bool HasFavicon(this SiteLink link)
        {
            if (link == null)
                throw new ArgumentNullException(nameof(link));

            return link.ShowFavicon
                && !(string.IsNullOrEmpty(link.Favicon) && string.IsNullOrEmpty(link.FaviconFallback));
        }
    }
}

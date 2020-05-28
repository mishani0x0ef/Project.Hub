using Project.Hub.Config.Entities.v1;
using System;

namespace Project.Hub.Config.Util
{
    public static class SiteLinkExtension
    {
        /// <summary>
        /// Check is current website can have favicon displayed.
        /// </summary>
        /// <param name="link">Website info.</param>
        /// <returns>True of favicon can be displayed.</returns>
        public static bool HasFavicon(this SiteLink link)
        {
            if (link == null)
                throw new ArgumentNullException(nameof(link));

            return link.ShowFavicon
                && !(string.IsNullOrEmpty(link.Favicon) && string.IsNullOrEmpty(link.FaviconFallback));
        }
    }
}

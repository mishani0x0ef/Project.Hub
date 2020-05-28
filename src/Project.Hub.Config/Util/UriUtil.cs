using System;

namespace Project.Hub.Config.Util
{
    public static class UriUtil
    {
        /// <summary>
        /// Try to automatically resolve website favicon from the default location - {websiteUrl}/favicon.com.
        /// </summary>
        /// <param name="siteUrl">Website URL.</param>
        /// <param name="faviconLink">Resulting link to the favicon.</param>
        /// <returns>True if favicon found in default location. Otherwise - false.</returns>
        public static bool TryGetFavicon(string siteUrl, out string faviconLink)
        {
            faviconLink = null;

            if (string.IsNullOrEmpty(siteUrl))
                return false;

            var uriValid = Uri.TryCreate(siteUrl, UriKind.RelativeOrAbsolute, out var url);
            if (uriValid)
            {
                var baseUrl = url.GetLeftPart(UriPartial.Authority);
                faviconLink = $"{baseUrl}/favicon.ico";
            }

            return uriValid;
        }
    }
}

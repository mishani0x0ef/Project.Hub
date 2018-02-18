using System;

namespace Project.Hub.Config.Util
{
    public static class UriUtil
    {
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

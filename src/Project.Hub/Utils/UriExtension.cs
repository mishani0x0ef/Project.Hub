using System;
using System.Web.Mvc;

namespace Project.Hub.Utils
{
    public static class UriExtension
    {
        public static string AbsoluteUri(this UrlHelper urlHelper, string contentPath)
        {
            var requestUrl = urlHelper.RequestContext.HttpContext.Request.Url;
            if (requestUrl == null)
                throw new NullReferenceException();

            return $"{requestUrl.Scheme}://{requestUrl.Authority}{urlHelper.Content(contentPath)}";
        }
    }
}
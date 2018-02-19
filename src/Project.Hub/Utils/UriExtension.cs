using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Project.Hub.Utils
{
    public static class UriExtension
    {
        public static string AbsoluteUri(this IUrlHelper urlHelper, string contentPath)
        {
            var requestUrl = urlHelper.ActionContext.HttpContext.Request.GetEncodedUrl();
            if (string.IsNullOrEmpty(requestUrl))
                throw new ArgumentNullException(nameof(urlHelper), "Request URL is not defined.");

            var url = new Uri(requestUrl);

            return $"{url.Scheme}://{url.Authority}{urlHelper.Content(contentPath)}";
        }
    }
}
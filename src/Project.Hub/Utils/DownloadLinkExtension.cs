using System;
using System.Web.Mvc;
using Project.Hub.Config.Entities;

namespace Project.Hub.Utils
{
    public static class DownloadLinkExtension
    {
        public static string GetDownloadLink(this UrlHelper helper, DownloadLink link)
        {
            switch (link.Mode)
            {
                case DownloadMode.FileSystem:
                    return helper.Action("Download", "Shared", new {path = link.DownloadPath});
                default:
                    return link.DownloadPath.IndexOf("://", StringComparison.Ordinal) > -1
                        ? link.DownloadPath
                        : helper.AbsoluteUri(link.DownloadPath);
            }
        }
    }
}
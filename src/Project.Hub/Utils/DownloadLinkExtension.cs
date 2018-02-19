using System;
using Project.Hub.Config.Entities;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Project.Hub.Utils
{
    public static class DownloadLinkExtension
    {
        public static string GetDownloadLink(this UrlHelper helper, DownloadLink link)
        {
            switch (link.Mode)
            {
                case DownloadMode.FileSystem:
                    var action = new UrlActionContext
                    {
                        Action = "Download",
                        Controller = "Shared",
                        Values = new { path = link.DownloadPath }
                    };
                    return helper.Action(action);
                default:
                    return link.DownloadPath.IndexOf("://", StringComparison.Ordinal) > -1
                        ? link.DownloadPath
                        : helper.AbsoluteUri(link.DownloadPath);
            }
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Entities.v1;

namespace Project.Hub.Utils
{
    public static class DownloadLinkExtension
    {
        public static string GetDownloadLink(this IUrlHelper helper, DownloadLink link)
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
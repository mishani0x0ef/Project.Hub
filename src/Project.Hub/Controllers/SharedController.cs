using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System;
using System.IO;
using System.Linq;

namespace Project.Hub.Controllers
{
    public class SharedController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public SharedController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public IActionResult Download(string path)
        {
            var config = _provider.GetConfig();
            var download = config.GetDownloadLink(path);

            if (download == null)
                throw new FileNotFoundException();

            var file = GetLatestFile(path);
            byte[] fileBytes = System.IO.File.ReadAllBytes(file.FullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
        }

        private FileInfo GetLatestFile(string path)
        {
            // todo: move to some separate service. MR
            var lastSlashIndex = path.LastIndexOf("\\", StringComparison.Ordinal);
            var firstMask = path.IndexOf("*", StringComparison.Ordinal);
            var fileNamePattern = path.Substring(lastSlashIndex + 1);
            var dirPath = path.Substring(0, lastSlashIndex);
            if (firstMask > 0 && firstMask < lastSlashIndex)
            {
                dirPath = path.Substring(0, firstMask);
                fileNamePattern = path.Substring(firstMask);
            }

            var dir = new DirectoryInfo(dirPath);
            var innerItems = fileNamePattern.Split('\\');
            for (int i = 0; i < innerItems.Length - 1; i++)
            {
                dir = GetNextDir(dir, innerItems[i]);
            }

            return dir.GetFiles(innerItems.Last(), SearchOption.AllDirectories).OrderBy(f => f.CreationTime).Last();
        }

        private DirectoryInfo GetNextDir(DirectoryInfo current, string nextDirPattern)
        {
            var dirs = current.GetDirectories(nextDirPattern);
            var dir = dirs.OrderBy(d => d.CreationTime).Last();
            return dir;
        }
    }
}

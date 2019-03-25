using Project.Hub.Config.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Project.Hub.Config.Providers
{
    /// <summary>
    /// Use cache during work with files to optimize read performance.
    /// </summary>
    internal class CacheableFileService : IFileService
    {
        protected Dictionary<string, (DateTime Time, string Text)> files;

        public CacheableFileService()
        {
            files = new Dictionary<string, (DateTime, string)>();
        }

        public async Task<string> ReadAsync(string path)
        {
            var lastWriteTime = File.GetLastWriteTimeUtc(path);
            if (files.TryGetValue(path, out var value) && value.Time == lastWriteTime)
                return value.Text;

            var text = await ReadFile(path);
            files[path] = (lastWriteTime, text);

            return text;
        }

        private async Task<string> ReadFile(string path)
        {
            using (var stream = File.OpenText(path))
            {
                return await stream.ReadToEndAsync();
            }
        }
    }
}

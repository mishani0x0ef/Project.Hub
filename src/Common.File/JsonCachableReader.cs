using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Common.File
{
    /// <summary>
    /// Provide ability to read JSON file and cache results.
    /// If file wasn't changed - use cached results to optimize performance.
    /// </summary>
    /// <typeparam name="T">Type of the object to read from JSON file.</typeparam>
    public class JsonCachableReader<T>
    {
        private readonly string _path;

        private DateTime _lastReload = DateTime.MinValue;
        private T _content;

        public JsonCachableReader(string jsonPath)
        {
            _path = jsonPath;
        }

        protected async Task<T> GetOrResolveIfChanged()
        {
            var configChanged = FileUtil.IsFileChangedSince(_lastReload, _path);

            if (configChanged)
            {
                _lastReload = DateTime.Now;

                using (var reader = System.IO.File.OpenText(_path))
                {
                    var json = await reader.ReadToEndAsync();
                    _content = JsonConvert.DeserializeObject<T>(json);
                }
            }

            return _content;
        }
    }
}

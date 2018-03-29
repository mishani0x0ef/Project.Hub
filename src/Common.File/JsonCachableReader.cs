using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Common.File
{
    public class JsonCachableReader<T>
    {
        private readonly string _path;

        private DateTime lastReload = DateTime.MinValue;
        private T config;

        public JsonCachableReader(string jsonPath)
        {
            _path = jsonPath;
        }

        protected async Task<T> GetOrResolveIfChanged()
        {
            var configChanged = FileUtil.IsFileChangedSince(lastReload, _path);

            if (configChanged)
            {
                lastReload = DateTime.Now;

                string jsonConfig;

                using (var reader = System.IO.File.OpenText(_path))
                {
                    jsonConfig = await reader.ReadToEndAsync();
                }

                config = JsonConvert.DeserializeObject<T>(jsonConfig);
            }

            return config;
        }
    }
}

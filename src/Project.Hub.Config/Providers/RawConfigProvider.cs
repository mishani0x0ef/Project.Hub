using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System;

namespace Project.Hub.Config.Providers
{
    public class RawConfigProvider : IRawConfigProvider
    {
        private readonly string _configPath;
        private readonly SemaphoreSlim _hubConfigSaveMutex = new SemaphoreSlim(1);

        public RawConfigProvider(IOptionsProvider options)
        {
            _configPath = options.ConfigPath;
        }

        public async Task<RawConfig> GetConfig()
        {
            using (var reader = File.OpenText(_configPath))
            {
                var jsonConfig = await reader.ReadToEndAsync();
                return new RawConfig
                {
                    HubConfigText = jsonConfig
                };
            }
        }

        public async Task UpdateHubConfig(string config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));
 
            using (var writter = new StreamWriter(_configPath))
            {
                await _hubConfigSaveMutex.WaitAsync();

                try
                {
                    await writter.WriteAsync(config);
                }
                finally
                {
                    _hubConfigSaveMutex.Release();
                }
            }            
        }
    }
}

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
        private readonly string _nlogConfigPath;
        private readonly SemaphoreSlim _hubConfigSaveMutex = new SemaphoreSlim(1);
        private readonly SemaphoreSlim _nlogConfigSaveMutex = new SemaphoreSlim(1);

        public RawConfigProvider(IOptionsProvider options)
        {
            _configPath = options.ConfigPath;
            _nlogConfigPath = "nlog.config";
        }

        public async Task<RawConfig> GetConfig()
        {
            var config = new RawConfig
            {
                HubConfigText = await ReadAsync(_configPath),
                NLogConfigText = await ReadAsync(_nlogConfigPath)
            };

            return config;
        }

        public async Task UpdateHubConfig(string config)
        {
            await WriteAsync(_configPath, config, _hubConfigSaveMutex);         
        }

        public async Task UpdateNLogConfig(string config)
        {
            await WriteAsync(_nlogConfigPath, config, _nlogConfigSaveMutex);
        }

        private async Task<string> ReadAsync(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        private async Task WriteAsync(string filePath, string content, SemaphoreSlim mutex)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            using (var writter = new StreamWriter(filePath))
            {
                await mutex.WaitAsync();

                try
                {
                    await writter.WriteAsync(content);
                }
                finally
                {
                    mutex.Release();
                }
            }
        }
    }
}

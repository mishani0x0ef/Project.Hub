﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Project.Hub.Config.Interfaces;
using System.IO;
using System;

namespace Project.Hub.Settings
{
    public class ConfigResolver : IConfigPathResolver, ICacheExpirationProvider
    {
        public string ConfigPath { get; }

        private readonly AppConfiguration _configuration;

        public ConfigResolver(IOptions<AppConfiguration> configuration, IHostingEnvironment hostingEnvironment)
        {
            _configuration = configuration.Value;

            var relativePath = _configuration.ConfigPath;
            ConfigPath = Path.Combine(hostingEnvironment.ContentRootPath, relativePath);
        }

        public DateTimeOffset GetExpiration()
        {
            return DateTimeOffset.Now.AddHours(_configuration.VersionsCacheExpirationInHours);
        }
    }
}

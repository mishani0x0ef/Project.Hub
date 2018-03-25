﻿using System.Threading.Tasks;
using Project.Hub.Config.Entities.Version;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class DefaultVersionResolver : IVersionResolver
    {
        public Task<string> GetVersion(VersionOptions options)
        {
            return Task.FromResult("-");
        }
    }
}

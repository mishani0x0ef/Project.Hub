﻿using System.Threading.Tasks;
using Project.Hub.Config.Entities.Common.Version;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    internal class DefaultVersionResolver : IVersionResolver
    {
        public Task<string> GetVersion(VersionOptions options)
        {
            return Task.FromResult("-");
        }
    }
}

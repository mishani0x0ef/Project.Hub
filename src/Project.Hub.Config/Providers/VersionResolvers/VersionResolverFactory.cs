using Microsoft.Extensions.Logging;
using Project.Hub.Config.Entities;
using Project.Hub.Config.Entities.Version;
using Project.Hub.Config.Interfaces;
using System.Collections.Generic;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class VersionResolverFactory
    {
        protected Dictionary<VersionType, IVersionResolver> Resolvers { get; set; }
        protected IVersionResolver DefaultResolver { get; set; }

        public VersionResolverFactory(IOptionsProvider optionsProvider, ILogger<IVersionResolver> logger)
        {
            DefaultResolver = new DefaultVersionResolver();
            Resolvers = new Dictionary<VersionType, IVersionResolver>
            {
                { VersionType.Assembly, new AssemblyVersionResolver(DefaultResolver, logger) },
                { VersionType.PowerShell, new PowerShellVersionResolver(optionsProvider.PowerShellPath, DefaultResolver, logger) },
                { VersionType.JsonFile, new JsonFileVersionResolver(DefaultResolver, logger, new CacheableFileService()) },
            };
        }

        public IVersionResolver GetResolver(ComponentConfig component)
        {
            if (component == null || !component.IsVersionProvider)
            {
                return DefaultResolver;
            }

            var exist = Resolvers.TryGetValue(component.VersionOptions.Type, out var resolver);
            return exist ? resolver : DefaultResolver;
        }
    }
}

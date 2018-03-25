using Project.Hub.Config.Entities;
using Project.Hub.Config.Entities.Version;
using System;
using System.Collections.Generic;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public class VersionResolverFactory
    {
        public Dictionary<Type, IVersionResolver> Resolvers { get; set; }

        public VersionResolverFactory()
        {
            Resolvers = new Dictionary<Type, IVersionResolver>();
        }

        public IVersionResolver GetResolver(ComponentConfig component)
        {
            if (component == null || !component.IsVersionProvider)
            {
                return GetOrCreate<DefaultVersionResolver>();
            }

            switch (component.VersionOptions.Type)
            {
                case VersionType.Assembly:
                    // todo: create and use other resolver. MR
                    return GetOrCreate<DefaultVersionResolver>();
                default:
                    return GetOrCreate<DefaultVersionResolver>();
            }
        }

        private IVersionResolver GetOrCreate<T>() where T: IVersionResolver, new()
        {
            var type = typeof(T);
            if (Resolvers.ContainsKey(type))
            {
                return Resolvers[type];
            }

            var resolver = new T();
            Resolvers.Add(type, resolver);
            return resolver;
        }
    }
}

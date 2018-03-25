using Project.Hub.Config.Interfaces;
using System;
using Project.Hub.Config.Entities.Version;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Project.Hub.Config.Providers
{
    public class StaticVersionProvider : IVersionProvider
    {
        private readonly VersionsModel _versions;

        public StaticVersionProvider()
        {
            var envs = new[] { "Dev", "Testing", "Evaluate", "Production" };
            var components = new[]
            {
                "Admin Panel",
                "Andoid Widget",
                "iOS app",
                "Angular Portal",
                "Creator win-service",
                "Database",
                "Code improver",
                "Hadoop",
                "Kafka",
                "Kasandra",
                "Echoton",
                "Event Queue"
            };

            _versions = new VersionsModel
            {
                Environments = new HashSet<string>(envs),
                Components = new HashSet<Component>(GenerateComponents(envs, components)),
                LastUpdated = DateTimeOffset.Now
            };
        }

        public Task<VersionsModel> GetVersions()
        {
            return Task.FromResult(_versions);
        }

        private IEnumerable<Component> GenerateComponents(string[] environments, string[] components)
        {
            var random = new Random((int)DateTime.Now.Ticks);

            foreach (var componentName in components)
            {
                var component = new Component
                {
                    Name = componentName,
                    Versions = new HashSet<ComponentVersion>()
                };

                foreach(var env in environments)
                {
                    var version = $"{random.Next(10)}.{random.Next(500)}.0.{random.Next(10000)}";
                    component.Versions.Add(new ComponentVersion(env, version));
                }

                yield return component;
            }
        }
    }
}

using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Entities.ComponentData;
using System.Threading.Tasks;
using Project.Hub.Config.Util;
using System.Collections.Generic;

namespace Project.Hub.Config.Providers
{
    public class ComponentProvider : IComponentProvider
    {
        private readonly IConfigurationProvider _configProvider;

        public ComponentProvider(IConfigurationProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public async Task<ComponentDetails> GetByName(string name)
        {
            var config = await _configProvider.GetConfig();
            foreach (var env in config.Environments)
            {
                var components = env.GetAllComponents();
                foreach (var component in components)
                {
                    if (component.Name == name)
                    {
                        var details = new ComponentDetails()
                        {
                            Name = component.Name,
                            Description = component.Description,
                            Environments = new HashSet<EnvironmentDetails>
                            {
                                new EnvironmentDetails()
                                {
                                    Name = "Test",
                                    Description = "Testing Environment",
                                    Version = "3.0.0",
                                    Link = ""
                                },
                                new EnvironmentDetails()
                                {
                                    Name = "Production",
                                    Description = "Production Environment",
                                    Version = "2.0.0",
                                    Link = ""
                                }
                            }
                        };
                        return details;
                    }
                }
            }

            return null;
        }
    }
}

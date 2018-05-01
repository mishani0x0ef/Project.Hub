using Microsoft.AspNetCore.Mvc;
using Project.Hub.Config.Entities.ComponentData;
using Project.Hub.Config.Interfaces;
using Project.Hub.Config.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Hub.Controllers
{
    public class ComponentController : Controller
    {
        private readonly IConfigurationProvider _provider;

        public ComponentController(IConfigurationProvider provider)
        {
            _provider = provider;
        }

        public async Task<IActionResult> Index(string id)
        {
            var config = await _provider.GetConfig();
            foreach (var env in config.Environments)
            {
                var components = env.GetAllComponents();
                foreach(var component in components)
                {
                    if(component.Name == id)
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
                        return View(details);
                    }
                }
            }

            return View(null);
        }
    }
}

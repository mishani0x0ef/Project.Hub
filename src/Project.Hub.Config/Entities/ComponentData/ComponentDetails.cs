using System.Collections.Generic;

namespace Project.Hub.Config.Entities.ComponentData
{
    public class ComponentDetails : BaseConfig
    {
        public HashSet<EnvironmentDetails> Environments { get; set; }

        public ComponentDetails()
        {
            Environments = new HashSet<EnvironmentDetails>();
        }
    }
}

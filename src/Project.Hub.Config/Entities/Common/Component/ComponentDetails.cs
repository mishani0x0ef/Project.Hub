using Project.Hub.Config.Entities.v2;
using System.Collections.Generic;

namespace Project.Hub.Config.Entities.Common.Component
{
    public class ComponentDetails : BaseConfig, ITagged
    {
        public HashSet<EnvironmentDetails> Environments { get; set; }
        public IEnumerable<string> Tags { get; set; }

        public ComponentDetails()
        {
            Environments = new HashSet<EnvironmentDetails>();
        }
    }
}

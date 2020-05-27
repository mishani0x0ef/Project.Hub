using Project.Hub.Config.Entities;
using Project.Hub.Config.Entities.v1;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    public interface IConfigurationProvider
    {
        Task<Configuration> GetConfig();
    }
}

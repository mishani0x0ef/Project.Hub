using Project.Hub.Config.Entities.Common;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    public interface IRawConfigProvider
    {
        Task<RawConfig> GetConfig();
        Task UpdateHubConfig(string config);
        Task UpdateNLogConfig(string config);
    }
}

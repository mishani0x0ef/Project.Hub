using System.Threading.Tasks;

namespace Version.Hub.Config
{
    public interface IConfigProvider
    {
        Task<Entities.Config> GetConfig();
    }
}

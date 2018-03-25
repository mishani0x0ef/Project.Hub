using Project.Hub.Config.Entities.Version;
using System.Threading.Tasks;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public interface IVersionResolver
    {
        Task<string> GetVersion(VersionOptions options);
    }
}

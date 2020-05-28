using Project.Hub.Config.Entities.Common.Version;
using System.Threading.Tasks;

namespace Project.Hub.Config.Providers.VersionResolvers
{
    public interface IVersionResolver
    {
        Task<string> GetVersion(VersionOptions options);
    }
}

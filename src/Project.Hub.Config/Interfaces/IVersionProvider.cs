using Project.Hub.Config.Entities.Common.Version;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    public interface IVersionProvider
    {
        /// <summary>
        /// Get all versions of components on all environments.
        /// </summary>
        /// <returns></returns>
        Task<VersionsModel> GetVersions();
    }
}

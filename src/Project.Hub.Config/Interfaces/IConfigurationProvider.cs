using Project.Hub.Config.Entities.v1;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide operations to resolve hub configuration.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Get global configuration of the hub.
        /// This configuration describes all data that is displayed on the site.
        /// </summary>
        /// <returns>Configuration.</returns>
        Task<Configuration> GetConfig();
    }
}

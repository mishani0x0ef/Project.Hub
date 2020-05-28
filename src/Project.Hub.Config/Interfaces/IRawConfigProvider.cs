using Project.Hub.Config.Entities.Common;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide proxy to work with main site configuration files.
    /// </summary>
    public interface IRawConfigProvider
    {
        /// <summary>
        /// Get hub configurations raw content.
        /// </summary>
        /// <returns>Configuration.</returns>
        Task<RawConfig> GetConfig();

        /// <summary>
        /// Update hub configuration that contains info about environments and describe all items that displayed on site.
        /// </summary>
        /// <param name="config">Configuration content to save.</param>
        Task UpdateHubConfig(string config);

        /// <summary>
        /// Update logger configuration.
        /// </summary>
        /// <param name="config">Configuration content to save.</param>
        Task UpdateNLogConfig(string config);
    }
}

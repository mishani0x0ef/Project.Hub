using System.Threading.Tasks;
using Version.Hub.Domain;

namespace Version.Hub.Config
{
    /// <summary>
    /// Provide functionality to resolve versions.
    /// </summary>
    public interface IVersionProvider
    {
        /// <summary>
        /// Provide version of specific component.
        /// </summary>
        /// <param name="component">Component to check version for.</param>
        /// <exception cref="KeyNotFoundException">Throws when component not found.</exception>
        /// <returns>Version information.</returns>
        Task<VersionInfo> GetVersion(string component);
    }
}

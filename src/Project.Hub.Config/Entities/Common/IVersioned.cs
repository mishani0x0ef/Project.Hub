using Project.Hub.Config.Entities.Common.Version;

namespace Project.Hub.Config.Entities.Common
{
    /// <summary>
    /// Component that support version resolution based on the specific resolution settings.
    /// </summary>
    public interface IVersioned
    {
        /// <summary>
        /// Settings that describes how component's version could be resolved.
        /// </summary>
        VersionOptions VersionOptions { get; set; }
    }
}

using System;

namespace Project.Hub.Api.Settings
{
    /// <summary>
    /// Represent a set of application settings.
    /// </summary>
    public interface IAppSettings
    {
        /// <summary>
        /// Current version of the application.
        /// </summary>
        Version Version { get; }
    }
}

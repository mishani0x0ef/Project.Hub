using System;

namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide functionality to check cache expiration date.
    /// </summary>
    public interface ICacheExpirationProvider
    {
        /// <summary>
        /// Get expiration data of global cache that contains Hub configuration.
        /// </summary>
        /// <returns>Date and Time when cache will be expired.</returns>
        DateTimeOffset GetExpiration();
    }
}

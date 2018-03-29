using System;

namespace Project.Hub.Config.Interfaces
{
    public interface ICacheExpirationProvider
    {
        DateTimeOffset GetExpiration();
    }
}

using Project.Hub.Config.Entities;

namespace Project.Hub.Config.Interfaces
{
    public interface IConfigurationProvider
    {
        Configuration GetConfig();
    }
}

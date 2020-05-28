using Project.Hub.Config.Entities.Common.Component;
using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide operations to resolve info about the specific component.
    /// </summary>
    public interface IComponentProvider
    {
        /// <summary>
        /// Get component details by name.
        /// </summary>
        /// <param name="name">Name of component to resolve.</param>
        /// <returns></returns>
        Task<ComponentDetails> GetByName(string name);
    }
}

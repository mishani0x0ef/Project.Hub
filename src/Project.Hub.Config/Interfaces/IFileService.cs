using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    internal interface IFileService
    {
        Task<string> ReadAsync(string path);
    }
}

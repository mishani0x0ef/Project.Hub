using System.Threading.Tasks;

namespace Project.Hub.Config.Interfaces
{
    /// <summary>
    /// Provide operations to work with file system.
    /// </summary>
    internal interface IFileService
    {
        /// <summary>
        /// Read all text from the file asynchronously.
        /// </summary>
        /// <param name="path">Relative or absolute path the file to read from.</param>
        /// <returns>File's content.</returns>
        Task<string> ReadAsync(string path);
    }
}

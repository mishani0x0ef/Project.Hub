using System.Reflection;

namespace Common.File
{
    public static class AssemblyUtils
    {
        /// <summary>
        /// Get version from .NET assembly (dll or exe).
        /// </summary>
        /// <param name="pathToAssembly">Full or relative path to the assembly file.</param>
        /// <returns>String representation of the version.</returns>
        public static string GetVersion(string pathToAssembly)
        {
            var assembly = Assembly.LoadFile(pathToAssembly);
            var version = assembly.GetName().Version.ToString();
            return version;
        }

        /// <summary>
        /// Try to get version from .NET assembly (dll or exe).
        /// </summary>
        /// <param name="pathToAssembly">Full or relative path to the assembly file.</param>
        /// <param name="version">Version of assembly.</param>
        /// <returns>True of version was resolved.</returns>
        public static bool TryGetVersion(string pathToAssembly, out string version)
        {
            version = null;

            try
            {
                version = GetVersion(pathToAssembly);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

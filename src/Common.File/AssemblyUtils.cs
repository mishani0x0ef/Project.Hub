using System.Reflection;

namespace Common.File
{
    public static class AssemblyUtils
    {
        /// <summary>
        /// Try to get version from .net assembly (dll or exe).
        /// </summary>
        /// <param name="pathToAssembly">Full or relative path to the assembly file.</param>
        /// <param name="version">Version of assembly.</param>
        /// <returns>True of version was resolved.</returns>
        public static bool TryGetVersion(string pathToAssembly, out string version)
        {
            version = null;

            try
            {
                var assembly = Assembly.LoadFile(pathToAssembly);
                version = assembly.GetName().Version.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

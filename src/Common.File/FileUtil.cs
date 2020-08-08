using System;

namespace Common.File
{
    public  static class FileUtil
    {
        /// <summary>
        /// Check is file was modified since specific date.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <param name="filePath">Path to file.</param>
        /// <returns>True if file was changed after the <paramref name="date"/>.</returns>
        public static bool IsFileChangedSince(DateTime date, string filePath)
        {
            var modifiedTime = System.IO.File.GetLastWriteTime(filePath);
            return modifiedTime >= date;
        }
    }
}

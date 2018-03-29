using System;

namespace Common.File
{
    public  static class FileUtil
    {
        /// <summary>
        /// Check is file was modified since provided date.
        /// </summary>
        /// <param name="date">Date to check.</param>
        /// <param name="filePath">Path to file.</param>
        /// <returns></returns>
        public static bool IsFileChangedSince(DateTime date, string filePath)
        {
            var modifiedTime = System.IO.File.GetLastWriteTime(filePath);
            return modifiedTime >= date;
        }
    }
}

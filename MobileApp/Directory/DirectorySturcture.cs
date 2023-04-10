using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Controls;

namespace TreeView
{
    /// <summary>
    /// A helper class to query information about directories
    /// </summary>
    public static class DirectorySturcture
    {
        /// <summary>
        /// Gets all logical drives on the computer
        /// </summary>
        /// <returns></returns>
        public static List<DirectoryItem> GetLogicalDrives() 
        {
            // Get every logical drive on the machine
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive}).ToList();
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Create empty list
            var items = new List<DirectoryItem>();

            // Try and get files from the folder
            // ignoring any issues going so
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }
            // Try and get files from the folder
            // ignoring any issues going so
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File}));
            }
            catch { }
            return items;
        }
        /// <summary>
        /// Find the file of folder name from full path
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            // If we have no path, return empty
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Make all slash back slashes
            var normalizedPath = path.Replace("/", "\\");

            // Find the last backslash in the path
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // If we don't find a backslash, return the path itself
            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);

        }
    }
}

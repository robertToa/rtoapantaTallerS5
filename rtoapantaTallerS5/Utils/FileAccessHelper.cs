using System;
using System.Collections.Generic;
using System.Text;

namespace rtoapantaTallerS5.Utils
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            return System.IO.Path.Combine(FileSystem.AppDataDirectory, fileName);
        }
    }
}

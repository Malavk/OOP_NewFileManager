﻿using System;
using System.IO;

namespace OOP_FileManager
{
    class Utility
    {
        public static void DirectoryCopy(string sourceName, string destinationName, bool copySubDirs = true)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(sourceName);

            if (!directoryInfo.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceName);
            }

            DirectoryInfo[] dirs = directoryInfo.GetDirectories();

            if (!Directory.Exists(destinationName))
            {
                Directory.CreateDirectory(destinationName);
            }

            FileInfo[] files = directoryInfo.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destinationName, file.Name);
                file.CopyTo(tempPath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destinationName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static string BytesToStringAsNormalizedSize(long bytes) => BytesToStringAsNormalizedSize((ulong)bytes);

        public static string BytesToStringAsNormalizedSize(ulong bytes)
        {
            if (bytes < 1024)
                return $"{bytes} Byte";

            ulong kbytes = bytes / 1024;

            if (kbytes < 1024)
                return $"{kbytes} KB";

            ulong mbytes = kbytes / 1024;

            if (mbytes < 1024)
                return $"{mbytes} MB";

            ulong gbytes = mbytes / 1024;

            if (gbytes < 1024)
                return $"{gbytes} GB";

            ulong tbytes = gbytes / 1024;

            return $"{tbytes} TB";
        }
    }
}
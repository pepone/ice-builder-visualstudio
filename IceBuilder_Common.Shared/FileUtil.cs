// Copyright (c) ZeroC, Inc. All rights reserved.

using System;
using System.IO;

namespace IceBuilder
{
    public class FileUtil
    {
        public static string RelativePath(string mainDirPath, string absoluteFilePath)
        {
            if (string.IsNullOrEmpty(absoluteFilePath))
            {
                return "";
            }

            if (string.IsNullOrEmpty(mainDirPath))
            {
                return absoluteFilePath;
            }

            if (!Path.IsPathRooted(absoluteFilePath))
            {
                return absoluteFilePath;
            }

            mainDirPath = Path.GetFullPath(mainDirPath).Trim(Path.DirectorySeparatorChar);
            absoluteFilePath = Path.GetFullPath(absoluteFilePath).Trim(Path.DirectorySeparatorChar);

            string[] firstPathParts = mainDirPath.Split(Path.DirectorySeparatorChar);
            string[] secondPathParts = absoluteFilePath.Split(Path.DirectorySeparatorChar);

            int sameCounter = 0;
            while (sameCounter < Math.Min(firstPathParts.Length, secondPathParts.Length) &&
                string.Equals(
                    firstPathParts[sameCounter],
                    secondPathParts[sameCounter],
                    StringComparison.CurrentCultureIgnoreCase))
            {
                ++sameCounter;
            }

            // Different volumes, relative path not possible.
            if (sameCounter == 0)
            {
                return absoluteFilePath;
            }

            // Pop back up to the common point.
            string newPath = "";
            for (int i = sameCounter; i < firstPathParts.Length; ++i)
            {
                newPath += ".." + Path.DirectorySeparatorChar;
            }

            // Descend to the target.
            for (int i = sameCounter; i < secondPathParts.Length; ++i)
            {
                newPath += secondPathParts[i] + Path.DirectorySeparatorChar;
            }
            return newPath.TrimEnd(Path.DirectorySeparatorChar);
        }
    }
}

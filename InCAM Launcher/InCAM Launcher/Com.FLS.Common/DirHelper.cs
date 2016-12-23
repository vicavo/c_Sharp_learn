using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Com.FLS.Common
{
    public static class DirHelper
    {
        public static string[] getSubDirNames(string baseDir)
        {
            string[] dirList = new string[] { };

            if (Directory.Exists(baseDir))
            {
                dirList = Directory.GetDirectories(baseDir);

                /* remove base directory from full path */
                for (int i = 0; i < dirList.Count(); i++)
                {
                    dirList[i] = Path.GetFileName(dirList[i]);
                }
            }

            return dirList;
        }

        public static string[] getFilesInDir(string baseDir)
        {
            string[] fileList = new string[] { };

            if (Directory.Exists(baseDir))
            {
                fileList = Directory.GetFiles(baseDir);

                /* remove base directory from full path */
                for (int i = 0; i < fileList.Count(); i++)
                {
                    fileList[i] = Path.GetFileName(fileList[i]);
                }
            }

            return fileList;
        }
    }
}

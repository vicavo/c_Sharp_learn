using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;

namespace Com.FLS.Common
{
    public static class IniParser
    {
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static string readIniData(String Section, String Key, String NoText, String iniFilePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);

            return temp.ToString();
        }

        public static bool writeIniData(string Section, string Key, string Value, string iniFilePath)
        {
            return WritePrivateProfileString(Section, Key, Value, iniFilePath);
        }
    }
}

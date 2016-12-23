using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;


namespace CalcCmdTime
{
    class CReadFile
    {
        public string _FilePath;
        private string _strStart = "(^\\d{2}:\\d{2}:\\d{2}\\.\\d{3}):.*(Action start: COORD)";
        private string _strEnd = "TX :Address:100 Offset:0 MsgType:WRITE_RELAY_BY_BIT";
        private string _strStarTime;
        private string _strEndTime;


        public CReadFile(string strPath)
        {
            _FilePath = strPath;
        }

        public List<KeyValuePair<string, string>> Read()
        {
            StreamReader sr = new StreamReader(_FilePath, Encoding.Default);
            string strLine;
            int FindCounter = 0;
            KeyValuePair<string, string> pairTemp;
            List<KeyValuePair<string, string>> listTimeInfo = new List<KeyValuePair<string, string>>();

            while ((strLine = sr.ReadLine()) != null)
            {

                if(FindStartString(strLine))
                {
                    FindCounter++;
                    _strStarTime = GetTime(strLine);
                }

                if(FindEndString(strLine))
                {
                    FindCounter++;
                    if(FindCounter %2 == 1)
                    {
                        FindCounter = 0;
                        continue;
                    }
                    _strEndTime = GetTime(strLine);

                    pairTemp = new KeyValuePair<string, string>(_strStarTime, _strEndTime);
                    listTimeInfo.Add(pairTemp);
                }
            }
            sr.Close();
            return listTimeInfo;
        }
        public bool FindStartString(string strContent)
        {
            bool bFind = false;
            bFind = Regex.IsMatch(strContent, _strStart);
            return bFind;
        }


        public bool FindEndString(string strContent)
        {
            bool bFind = false;
            bFind = strContent.IndexOf(_strEnd)>=0?true:false;
            return bFind;
        }

        public string GetTime(string strContent)
        {
            return strContent.Substring(0, 12);
        }

    }
}

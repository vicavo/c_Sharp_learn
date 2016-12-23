using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace Com.FLS.Common
{
    /// <summary>
    /// Parse "D:\Genesis\share" for job list, not used
    /// </summary>
    public class GenDB
    {
        private List<IncamJob> _jobs = new List<IncamJob>();

        public GenDB(string dbFile)
        {
            try
            {
                using (StreamReader reader = new StreamReader(dbFile))
                {
                    string content = reader.ReadToEnd();

                    MatchCollection matches = Regex.Matches(content, @"JOBS\s{\n\s{4}NAME=(.*)\n\s{4}DB=(.*)\n\s{4}ACCESS=(.*)\n}");

                    foreach(Match match in matches)
                    {
                        IncamJob job = new IncamJob();

                        string i= match.Groups[1].Value.ToString();
                    }
                }
            }
            catch(System.Exception)
            {
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Text.RegularExpressions;

namespace Com.FLS.Common
{
    public class GenJobList
    {
        private readonly string jobPattern = @"JOBS\s{\n\s{4}NAME=(.*)\n\s{4}DB=(.*)\n\s{4}ACCESS=(.*)\n}";

        private string _jobListFile = "";
        private List<GenJobItem> _jobList = new List<GenJobItem>();

        public string JobListFile
        {
            get
            {
                return this._jobListFile;
            }
        }

        public List<GenJobItem> JobList
        {
            get
            {
                return this._jobList;
            }
        }

        public GenJobList(string jobListFile)
        {
            this._jobListFile = jobListFile;

            this.parseJobListFile(this._jobListFile);
        }

        private void parseJobListFile(string jobListFile)
        {
            if (!File.Exists(jobListFile))
            {
                return;
            }

            using (StreamReader reader = new StreamReader(jobListFile))
            {
                string content = reader.ReadToEnd();

                MatchCollection jobs = Regex.Matches(content, jobPattern);

                foreach (Match job in jobs)
                {
                    GenJobItem item = new GenJobItem();
                    // item.Db = job[0]
                }
            }

        }
    }
}

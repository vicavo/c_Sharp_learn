using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

namespace Com.FLS.Common
{
    public class IncamDB
    {
        private string _dbPath = "";
        private string _incamBase = "";
        private string _filterPattern = "*";
        private bool _isFilterByRegex = false;
        private List<IncamJob> _jobs = new List<IncamJob>();

        public string DBPath
        {
            get
            {
                return this._dbPath;
            }
        }

        public string FilterPattern
        {
            get
            {
                return this._filterPattern;
            }
        }

        public bool IsFilterByRegex
        {
            get
            {
                return this._isFilterByRegex;
            }
        }

        public List<IncamJob> Jobs
        {
            get
            {
                return this._jobs;
            }
        }

        public Int32 JobCount
        {
            get
            {
                return this._jobs.Count();
            }
        }

        public IncamDB(string dbPath)
        {
            this._dbPath = dbPath;

            string[] jobNames = DirHelper.getSubDirNames(dbPath + @"\jobs");

            foreach(string jobName in jobNames)
            {
                this._jobs.Add(new IncamJob(dbPath + @"\jobs", jobName));
            }

            /* apply filter after all job is loaded */
            if( (string.Empty == this._filterPattern) ||
                ("*" == this._filterPattern && !this.IsFilterByRegex) )
            {
                /* do nothing */
            }
            else
            {
                if(!this._isFilterByRegex)
                {
                    this.applyFilterWildCard(this._filterPattern);
                }
                else
                {
                    this.applyFilterRegex(this._filterPattern);
                }
            }
        }

        public IncamDB()
        {

        }

        /// <summary>
        /// Filter by WildCard
        /// </summary>
        /// <param name="pattern"></param>
        public void applyFilterWildCard(string pattern)
        {
            this._filterPattern = pattern;
            this._isFilterByRegex = false;

            /* convert wildcard to regex pattern */
            string regPattern = "^" + Regex.Escape(pattern).Replace(@"\*", ".*").Replace(@"\?", ".") + "$";

            foreach (IncamJob job in this._jobs)
            {
                if (Regex.IsMatch(job.JobName, regPattern, RegexOptions.IgnoreCase))
                {
                    job.IsFiltered = false;
                }
                else
                {
                    job.IsFiltered = true;
                }
            }
        }

        /// <summary>
        /// If the regex is invalid, it takes a lot of time handling the regex exceptions
        /// do we need to check the expression outside the loop 
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="isRegex"></param>
        /// <returns></returns>
        public bool ValidFilterBeforeApply(string pattern, bool isRegex)
        {
            bool result = true;

            if (isRegex)
            {
                try
                {
                    new Regex(pattern);
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// Filter by Regex
        /// </summary>
        /// <param name="pattern"></param>
        public void applyFilterRegex(string pattern)
        {
            this._filterPattern = pattern;
            this._isFilterByRegex = true;

            bool regexValid = this.ValidFilterBeforeApply(pattern, true);

            foreach (IncamJob job in this._jobs)
            {
                if (!regexValid)
                {
                    job.IsFiltered = true;
                    continue;
                }

                if (Regex.IsMatch(job.JobName, pattern, RegexOptions.IgnoreCase))
                {
                    job.IsFiltered = false;
                }
                else
                {
                    job.IsFiltered = true;
                }
            }
        }
          
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobName"></param>
        /// <returns>job found, if job name is empty, it indicated job is not found</returns>
        public IncamJob getJobByName(string jobName)
        {
            IncamJob job = new IncamJob();

            foreach (IncamJob _job in this._jobs)
            {
                if ((false == _job.IsFiltered) && (jobName == _job.JobName))
                {
                    /* Due to performance issue, we do not read any job info on init, so we
                     * should read them here */
                    _job.refreshJobInfo();

                    job = _job;
                    break;
                }
            }

            return job;
        }

        public IncamJob getMostRecentJob()
        {
            string recentjobslist = this._incamBase + "\\server\\users\\recentjobslist.xml";
            if (!System.IO.File.Exists(recentjobslist))
            {
                return new IncamJob();
            }

            using(XmlReader reader = XmlReader.Create(new StringReader(recentjobslist))
            {
                while (reader.Read())
                {
                    switch(reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            string name = reader.Name;
                            break;
                        case XmlNodeType.Text:
                            string value = reader.Value;
                            break;
                    }
                }
            }

        }

    }
}

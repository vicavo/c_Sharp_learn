using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.IO;

namespace Com.FLS.Common
{
    public class IncamJobList
    {
        private string _jobListFile = "";

        private string _jobListVer = "1.0";
        private int _jobCount = 0;
        private List<IncamJobItem> _jobList = new List<IncamJobItem>();

        public string JobListFile
        {
            get
            {
                return this._jobListFile;
            }
        }

        public string JobListVer
        {
            get
            {
                return this._jobListVer;
            }
        }

        public int JobCount
        {
            get
            {
                return this._jobCount;
            }
        }

        public List<IncamJobItem> JobList
        {
            get
            {
                return this._jobList;
            }
        }

        public IncamJobList(string jobListFile)
        {
            this._jobListFile = jobListFile;

            this.parseJobListFile(this._jobListFile);
        }

        private void parseJobListFile(string jobListFile)
        {
            if(!File.Exists(jobListFile))
            {
                return;
            }

            using (XmlReader reader = XmlReader.Create(jobListFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(jobListFile);

                var jobVer = (XmlElement)doc.GetElementsByTagName("JobList")[0];
                this._jobListVer = jobVer.GetAttribute("version");

                var jobs = doc.GetElementsByTagName("job");
                this._jobCount = jobs.Count;

                TimeSpan timeSpan = new TimeSpan();
                foreach(XmlElement job in jobs)
                {
                    IncamJobItem item = new IncamJobItem();

                    timeSpan = TimeSpan.FromSeconds(Double.Parse(string.Empty== job.GetAttribute("updated") ? "0" : job.GetAttribute("updated")));
                    item.Updated += timeSpan;
                    item.Size = Int32.Parse(string.Empty == job.GetAttribute("size") ? "0" : job.GetAttribute("size"));
                    item.Creater = job.GetAttribute("creater");
                    item.DbName = job.GetAttribute("dbName");
                    item.LatinName = job.GetAttribute("latinName"); 
                    item.Comment = job.GetAttribute("comment"); ;
                    timeSpan = TimeSpan.FromSeconds(Double.Parse(string.Empty == job.GetAttribute("created") ? "0" : job.GetAttribute("created")));
                    item.Created += timeSpan;
                    item.Name = job.GetAttribute("name");
                    item.Customer_name = job.GetAttribute("customer_name");
                    item.LastUser = job.GetAttribute("lastUser");
                    item.IdbVer = job.GetAttribute("idbVer");
                    item.Customer = job.GetAttribute("customer");
                    item.NumSignalLyrs = Int32.Parse(string.Empty == job.GetAttribute("numSignalLyrs") ? "0" : job.GetAttribute("numSignalLyrs"));

                    this._jobList.Add(item);
                }
            }
        }

    }
}


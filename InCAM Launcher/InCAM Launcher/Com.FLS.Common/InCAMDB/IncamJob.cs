using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Com.FLS.Common
{
    public class IncamJob
    {
        private string _jobPath = ".";
        private string _jobName = "";
        private bool _isFiltered = false;
        private List<IncamJobStep> _steps = new List<IncamJobStep>();
        private DateTime _createDate = DateTime.MinValue;
        private DateTime _lastModifyDate = DateTime.MinValue;

        public string JobPath
        {
            get
            {
                return this._jobPath;
            }
        }

        public string JobName
        {
            get
            {
                return this._jobName;
            }
        }

        public bool IsFiltered
        {
            get
            {
                return this._isFiltered;
            }
            set
            {
                this._isFiltered = value;
            }
        }

        public List<IncamJobStep> Steps
        {
            get
            {
                this.refreshJobInfo();

                return this._steps;
            }
        } 

        public DateTime CreateDate
        {
            get
            {
                if(DateTime.MinValue == this._createDate)
                {
                    this.parseTimeInfo();
                }

                return this._createDate;
            }
        }

        public DateTime LastModifyDate
        {
            get
            {
                if (DateTime.MinValue == this._lastModifyDate)
                {
                    this.parseTimeInfo();
                }

                return this._lastModifyDate;
            }
        }

        private void parseTimeInfo()
        {
            string infoFile = this._jobPath + @"\" + _jobName + @"\" + "misc" + @"\" + "info";

            if (File.Exists(infoFile))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(infoFile))
                    {
                        while(!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();

                            if(-1 != line.IndexOf("CREATION_DATE"))
                            {
                                string createDate = line.Split(new char[] { '=' })[1].Trim();
                                this._createDate = DateTime.ParseExact(createDate, "yyyyMMdd.HHmmss", null);
                            }
                            else if(-1 != line.IndexOf("SAVE_DATE"))
                            {
                                string saveDate = line.Split(new char[] { '=' })[1].Trim();
                                this._lastModifyDate = DateTime.ParseExact(saveDate, "yyyyMMdd.HHmmss", null);
                            }
                            else
                            {
                                //...
                            }

                            if ((DateTime.MinValue != this._createDate) &&
                                (DateTime.MinValue != this._lastModifyDate) )
                            {
                                break;
                            }
                        } /* end of while */
                    }
                }
                catch(System.Exception)
                {

                }
            }
        }

        public IncamJob(string jobPath, string jobName)
        {
            this._jobPath = jobPath;
            this._jobName = jobName;

            /* Remove these codes in constructor, they are run when getJobByName */
            /*
            string[] stepNames = CommonLib.getSubDirNames(jobPath + @"\" + _jobName + @"\" + "steps");

            foreach(string stepName in stepNames)
            {
                this._steps.Add(new IncamJobStep(jobPath + @"\" + _jobName + @"\" + "steps", stepName));
            }*/
        }
        public IncamJob()
        {

        }

        public void refreshJobInfo()
        {
            if (0 == this._steps.Count)
            {
                string[] stepNames = DirHelper.getSubDirNames(this._jobPath + @"\" + _jobName + @"\" + "steps");

                foreach (string n in stepNames)
                {
                    this._steps.Add(new IncamJobStep(this._jobPath + @"\" + _jobName + @"\" + "steps", n));
                }
            }
        }

        public IncamJobStep getStepByName(string stepName)
        {
            IncamJobStep step = new IncamJobStep();

            foreach (IncamJobStep _step in this._steps)
            {
                if (stepName == _step.StepName)
                {
                    step = _step;
                    break;
                }
            }

            return step;
        }

    }
}

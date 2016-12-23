using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Com.FLS.Common;

namespace InCAM_Launcher
{
    class Session
    {
        private string _sessionDir = System.Windows.Forms.Application.StartupPath + "\\Sessions";
        private string _sessionName = "default";

        private readonly string _lineTemplate = "set {0} = {1}";
       // private readonly string _lineTemplateEnv = "setenv {0} {1}";

        private string _DFMDir = "";
        private string _DbDir = "";
        private string _Filter = "";
        private bool _IsRegexFilter = false;

        private DFMToolEnum _DFMTool = DFMToolEnum.InCAM;
        private string _JobName = "";
        private string _Step = "";
        private string _Layer = "";
        private string _Checklist = "";
        private bool _IsAutoRunChk = false;
        private bool _IsUnitst = false;
        private bool _IsGuiless = false;

        public string SessionDir
        {
            get
            {
                return this._sessionDir;
            }
        }

        public string SessionName
        {
            get
            {
                return this._sessionName;
            }
        }

        public string DFMDir
        {
            get
            {
                return this._DFMDir;
            }
            set
            {
                this._DFMDir = value;
            }
        }

        public string DFMCsh
        {
            get
            {
                /* Genesis */
                if (DFMToolEnum.Genesis == this._DFMTool)
                {
                    return (this._DFMDir + "\\nt\\bin\\csh.exe");
                }
                /* Geflex */
                else if (DFMToolEnum.GenFlex == this._DFMTool)
                {
                    return (this._DFMDir + "\\nt\\bin\\csh.exe");
                }
                /* InCAM */
                else if (DFMToolEnum.InCAM == this._DFMTool || DFMToolEnum.InCAM_Flex == this._DFMTool)
                {
                    return (this._DFMDir + "\\utils\\csh.exe");
                }
                else
                {
                    return this._DFMDir;
                }
            }
        }

        public string DFMExe
        {
            get
            {
                /* Genesis */
                if(DFMToolEnum.Genesis == this._DFMTool)
                {
                    return (this._DFMDir + "\\get\\get.exe");
                }
                /* Geflex */
                else if(DFMToolEnum.GenFlex == this._DFMTool)
                {
                    return this._DFMDir + "\\get\\gfx.exe";
                }
                /* InCAM */
                else if(DFMToolEnum.InCAM == this._DFMTool || DFMToolEnum.InCAM_Flex == this._DFMTool)
                {
                    return this._DFMDir + "\\bin\\InCAM.exe";
                }
                else
                {
                    return this._DFMDir;
                }
            }
        }

        public string DbDir
        {
            get
            {
                return this._DbDir;
            }
            set
            {
                this._DbDir = value;
            }
        }

        public string Filter
        {
            get
            {
                return this._Filter;
            }
            set
            {
                this._Filter = value;
            }
        }

        public bool IsRegexFilter
        {
            get
            {
                return this._IsRegexFilter;
            }
            set
            {
                this._IsRegexFilter = value;
            }
        }

        public DFMToolEnum DFMTool
        {
            get
            {
                return this._DFMTool;
            }
            set
            {
                this._DFMTool = value;
            }
        }

        public string JobName
        {
            get
            {
                return this._JobName;
            }
            set
            {
                this._JobName = value;
            }
        }

        public string Step
        {
            get
            {
                return this._Step;
            }
            set
            {
                this._Step = value;
            }
        }

        public string Layer
        {
            get
            {
                return this._Layer;
            }
            set
            {
                this._Layer = value;
            }
        }

        public string Checklist
        {
            get
            {
                return this._Checklist;
            }
            set
            {
                this._Checklist = value;
            }
        }

        public bool IsAutoRunChk
        {
            get
            {
                return this._IsAutoRunChk;
            }
            set
            {
                this._IsAutoRunChk = value;
            }
        }

        public bool IsUnitst
        {
            get
            {
                return this._IsUnitst;
            }
            set
            {
                this._IsUnitst = value;
            }
        }

        public bool IsGuiless
        {
            get
            {
                return this._IsGuiless;
            }
            set
            {
                this._IsGuiless = value;
            }
        }

        public Session(string sessionDir, string sessionName)
        {
            this._sessionDir = sessionDir;
            this._sessionName = sessionName;

            this.read();         
        }

        private void read()
        {
            string sessionFile = this._sessionDir + @"\" + this._sessionName;

            this._DFMDir = IniParser.readIniData("DIR", "InCAMDir", @"D:\InCAM\release_64", sessionFile);
            this._DbDir = IniParser.readIniData("DIR", "DbDir", @"D:\InCAM\incam_db1", sessionFile);

            this._Filter = IniParser.readIniData("JOB", "Filter", "*", sessionFile);
            this._IsRegexFilter = "1" == IniParser.readIniData("JOB", "IsRegexFilter", "0", sessionFile) ? true : false;

            DFMToolEnum.TryParse(IniParser.readIniData("JOB", "DFMTool", "0", sessionFile), out this._DFMTool);

            this._JobName = IniParser.readIniData("JOB", "JobName", "", sessionFile);
            this._Step = IniParser.readIniData("JOB", "Step", "", sessionFile);
            this._Layer = IniParser.readIniData("JOB", "Layer", "", sessionFile);
            this._Checklist = IniParser.readIniData("JOB", "Checklist", "", sessionFile);
            this._IsAutoRunChk = "1" == IniParser.readIniData("JOB", "IsAutoRunChk", "0", sessionFile) ? true : false;
            this._IsUnitst = "1" == IniParser.readIniData("JOB", "IsUnitst", "0", sessionFile) ? true : false;
            this._IsGuiless = "1" == IniParser.readIniData("JOB", "IsGuiless", "0", sessionFile) ? true : false;
        }

        public bool save()
        {
            bool result = true;

            string sessionFile = this._sessionDir + @"\" + this._sessionName;

            result &= IniParser.writeIniData("DIR", "InCAMDir", this._DFMDir, sessionFile);
            result &= IniParser.writeIniData("DIR", "DbDir", this._DbDir, sessionFile);

            result &= IniParser.writeIniData("JOB", "Filter", this._Filter, sessionFile);
            result &= IniParser.writeIniData("JOB", "IsRegexFilter", this._IsRegexFilter ? "1" : "0", sessionFile);
            result &= IniParser.writeIniData("JOB", "JobName", this._JobName, sessionFile);
            result &= IniParser.writeIniData("JOB", "DFMTool", ((int)this._DFMTool).ToString(), sessionFile);
            result &= IniParser.writeIniData("JOB", "Step", this._Step, sessionFile);
            result &= IniParser.writeIniData("JOB", "Layer", this._Layer, sessionFile);
            result &= IniParser.writeIniData("JOB", "Checklist", this._Checklist, sessionFile);
            result &= IniParser.writeIniData("JOB", "IsAutoRunChk", this._IsAutoRunChk ? "1" : "0", sessionFile);
            result &= IniParser.writeIniData("JOB", "IsUnitst", this._IsUnitst ? "1" : "0", sessionFile);
            result &= IniParser.writeIniData("JOB", "IsGuiless", this._IsGuiless ? "1" : "0", sessionFile);

            return result;
        }

        public bool saveSessionToAutotest(Session session, string fileName)
        {
           /* while(true)
            {
                if (File.Exists(fileName))
                {
                    fileName = Path.GetFileNameWithoutExtension(fileName) + "_1" + Path.GetExtension(fileName);
                }
                else
                {
                    break;
                }
            }*/

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string tempStr = "";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                tempStr = "# Created by DFM Quick Launcher";
                writer.WriteLine(tempStr);

                tempStr = "# " + DateTime.Now.ToString();
                writer.WriteLine(tempStr);

                tempStr = "# Session name: " + session.SessionName;
                writer.WriteLine(tempStr);

                writer.WriteLine(string.Empty);

                tempStr = string.Format(this._lineTemplate, "MyJob", session.JobName);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyStep", session.Step);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyLayer", session.Layer);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyChecklist", session.Checklist);
                writer.WriteLine(tempStr);
            }

            return true;
        }

        public bool saveSessionToScript(Session session, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            string tempStr = "";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                tempStr = string.Format(this._lineTemplate, "DFMTool", session.DFMTool.ToString());
                writer.WriteLine(tempStr);

                /* csh use do not recognize \ in path, use / instead */
                tempStr = string.Format(this._lineTemplate, "MyVerPath", session.DFMDir.Replace('\\', '/'));
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "AutoRun", (session.IsAutoRunChk || (session.IsUnitst && session.IsGuiless) ) ? "yes" : "no");
                writer.WriteLine(tempStr);

                // setting env here will not work 
                // tempStr = string.Format(this._lineTemplateEnv, "FLS_UNIT_TESTS", session.IsUnitst ? "yes" : "no");
                // writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyJob", session.JobName);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyStep", session.Step);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyLayer", session.Layer);
                writer.WriteLine(tempStr);

                tempStr = string.Format(this._lineTemplate, "MyChecklist", session.Checklist);
                writer.WriteLine(tempStr);
            }

            return true;
        }
    }
}

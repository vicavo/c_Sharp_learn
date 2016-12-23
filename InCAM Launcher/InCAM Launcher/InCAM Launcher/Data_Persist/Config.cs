using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Com.FLS.Common;

namespace InCAM_Launcher
{
    class Config
    {
        #region - Singleton -

        private static Config _instance = null;
        private static readonly object syncObject = new object();

        /// <summary>
        /// 
        /// </summary>
        public static Config Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new Config();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        /* [DFM] */
        private readonly string _configFile = System.Windows.Forms.Application.StartupPath + "\\Config";
        private string _xmanager = @"C:\Program Files (x86)\xmanager\XMANAGER.EXE";
        /* For x32 sys, if we can not find xmanager in the default path, try the alternative path */
        private readonly string _xmanagerAlternative = @"C:\Program Files\xmanager\XMANAGER.EXE";
        /* InCAM version base directly */
        private string _inCAMBase = @"D:\InCAM";
        private string _genBase = @"D:\Genesis";
        /* InCAM version directory */
        private string _inCAMVer = @"D:\InCAM\release_64";
        private string _genVer = @"D:\Genesis\e98";
        private string _gfxVer = @"D:\Genesis\e98";

        /* The config file name of autotest, used for auto compare, name only, no path */
        private string _atConfigFilename = "run_params";

        /* [MAIN] */
        /* Auto minimalsize this application after launch */
        private bool _hideAfterLaunch = false;
        /* Auto close the command line windows after user close DFM application */
        private bool _closeCmdAfterRun = true;
        /* When minimized, we can not see it on the taskbar */
        private bool _minimizedToTrayOnly = false;
        /* When close the window, minimize to notify area */
        private bool _hideOnClose = false;

        /* [COMMAND] */
        private string _runBeforeInCAM = "";
        private string _runBeforeGenesis = "";
        private string _runBeforeGeflex = "";

        private string _runStartInsight = "";
        private string _runStopInsight = "";


        public string ConfigFile
        {
            get
            {
                return this._configFile;
            }
        }

        public string XMANAGER
        {
            get
            {
                if(File.Exists(this._xmanager))
                {
                    return this._xmanager;
                }
                else
                {
                    return this._xmanagerAlternative;
                }
            }
            set
            {
                this._xmanager = value;
            }
        }

        public string InCAMBase
        {
            get
            {
                return this._inCAMBase;
            }
            set
            {
                this._inCAMBase = value;
            }
        }

        public List<string> InCAMVerList
        {
            get
            {
                List<string> vers = new List<string>();

                string[] dirs = DirHelper.getSubDirNames(this._inCAMBase);
                foreach (string dir in dirs)
                {
                    if (File.Exists(this._inCAMBase + "\\" + dir + "\\bin\\InCAM.exe"))
                    {
                        vers.Add(this._inCAMBase + "\\" + dir);
                    }
                }

                return vers;
            }
        }

        public string GenBase
        {
            get
            {
                return this._genBase;
            }
            set
            {
                this._genBase = value;
            }
        }

        public List<string> GenVerList
        {
            get
            {
                List<string> vers = new List<string>();

                string[] dirs = DirHelper.getSubDirNames(this._genBase);
                foreach (string dir in dirs)
                {
                    if (Directory.Exists(this._genBase + "\\" + dir + "\\get"))
                    {
                        vers.Add(this._genBase + "\\" + dir);
                    }
                }

                return vers;
            }
        }

        public string InCAMVer
        {
            get
            {
                return this._inCAMVer;
            }
            set
            {
                this._inCAMVer = value;
            }
        }

        public string GenVer
        {
            get
            {
                return this._genVer;
            }
            set
            {
                this._genVer = value;
            }
        }

        public string GfxVer
        {
            get
            {
                return this._gfxVer;
            }
            set
            {
                this._gfxVer = value;
            }
        }

        public string ATConfigFilename
        {
            get
            {
                return this._atConfigFilename;
            }
            set
            {
                this._atConfigFilename = value;
            }
        }

        public bool HideAfterLaunch
        {
            get
            {
                return this._hideAfterLaunch;
            }
        }

        public bool CloseCmdAfterRun
        {
            get
            {
                return this._closeCmdAfterRun;
            }
            set
            {
                this._closeCmdAfterRun = value;
            }
        }

        public bool MinimizedToTrayOnly
        {
            get
            {
                return this._minimizedToTrayOnly;
            }
            set
            {
                this._minimizedToTrayOnly = value;
            }
        }

        public bool HideOnClose
        {
            get
            {
                return this._hideOnClose;
            }
            set
            {
                this._hideOnClose = value;
            }
        }

        public string RunBeforeInCAM
        {
            get
            {
                return this._runBeforeInCAM;
            }
            set
            {
                this._runBeforeInCAM = value;
            }
        }

        public string RunBeforeGenesis
        {
            get
            {
                return this._runBeforeGenesis;
            }
            set
            {
                this._runBeforeGenesis = value;
            }
        }

        public string RunBeforeGeflex
        {
            get
            {
                return this._runBeforeGeflex;
            }
            set
            {
                this._runBeforeGeflex = value;
            }
        }

        public string RunStartInsight
        {
            get
            {
                return this._runStartInsight;
            }
            set
            {
                this._runStartInsight = value;
            }
        }
        public string RunStopInsight
        {
            get
            {
                return this._runStopInsight;
            }
            set
            {
                this._runStopInsight = value;
            }
        }

        private Config()
        {
            this.loadConfig();
        }

        ~Config()
        {
            this.saveConfig();
        }

        private void loadConfig()
        {
            this._hideAfterLaunch = "1" == IniParser.readIniData("MAIN", "HideAfterLaunch", "0", this._configFile) ? true: false;
            this._closeCmdAfterRun = "1" == IniParser.readIniData("MAIN", "CloseCmdAfterRun", "1", this._configFile) ? true : false;
            this._minimizedToTrayOnly = "1" == IniParser.readIniData("MAIN", "MinimizedToTrayOnly", "0", this._configFile) ? true : false;
            this._hideOnClose = "1" == IniParser.readIniData("MAIN", "HideOnClose", "0", this._configFile) ? true : false;

            this._xmanager = IniParser.readIniData("DFM", "XMANAGER", this._xmanager, this._configFile);
            this._inCAMBase = IniParser.readIniData("DFM", "InCAMBase", this._inCAMBase, this._configFile);
            this._genBase = IniParser.readIniData("DFM", "GenBase", this._genBase, this._configFile);
            this._inCAMVer = IniParser.readIniData("DFM", "InCAMVer", this._inCAMVer, this._configFile);
            this._genVer = IniParser.readIniData("DFM", "GenVer", this._genVer, this._configFile);
            this._gfxVer = IniParser.readIniData("DFM", "GfxVer", this._gfxVer, this._configFile);
            this._atConfigFilename = IniParser.readIniData("DFM", "ATConfigFilename", this._atConfigFilename, this._configFile);

            this._runBeforeInCAM = IniParser.readIniData("COMMAND", "RunBeforeInCAM", this._runBeforeInCAM, this._configFile);
            this._runBeforeGenesis = IniParser.readIniData("COMMAND", "RunBeforeGenesis", this._runBeforeGenesis, this._configFile);
            this._runBeforeGeflex = IniParser.readIniData("COMMAND", "RunBeforeGeflex", this._runBeforeGeflex, this._configFile);

            this._runStartInsight = IniParser.readIniData("COMMAND", "RunStartInsight", this._runStartInsight, this._configFile);
            this._runStopInsight = IniParser.readIniData("COMMAND", "RunStopInsight", this._runStopInsight, this._configFile);

        }

        private bool saveConfig()
        {
            bool result = true;

            result &= IniParser.writeIniData("MAIN", "HideAfterLaunch", this._hideAfterLaunch ? "1" : "0", this._configFile);
            result &= IniParser.writeIniData("MAIN", "CloseCmdAfterRun", this._closeCmdAfterRun ? "1" : "0", this._configFile);
            result &= IniParser.writeIniData("MAIN", "MinimizedToTrayOnly", this._minimizedToTrayOnly ? "1" : "0", this._configFile);
            result &= IniParser.writeIniData("MAIN", "HideOnClose", this._hideOnClose ? "1" : "0", this._configFile);

            result &= IniParser.writeIniData("DFM", "XMANAGER", this._xmanager, this._configFile);
            result &= IniParser.writeIniData("DFM", "InCAMBase", this._inCAMBase, this._configFile);
            result &= IniParser.writeIniData("DFM", "GenBase", this._genBase, this._configFile);
            result &= IniParser.writeIniData("DFM", "InCAMVer", this._inCAMVer, this._configFile);
            result &= IniParser.writeIniData("DFM", "GenVer", this._genVer, this._configFile);
            result &= IniParser.writeIniData("DFM", "GfxVer", this._gfxVer, this._configFile);
            result &= IniParser.writeIniData("DFM", "ATConfigFilename", this._atConfigFilename, this._configFile);

            result &= IniParser.writeIniData("COMMAND", "RunBeforeInCAM", this._runBeforeInCAM, this._configFile);
            result &= IniParser.writeIniData("COMMAND", "RunBeforeGenesis", this._runBeforeGenesis, this._configFile);
            result &= IniParser.writeIniData("COMMAND", "RunBeforeGeflex", this._runBeforeGeflex, this._configFile);

            result &= IniParser.writeIniData("COMMAND", "RunStartInsight", this._runStartInsight, this._configFile);
            result &= IniParser.writeIniData("COMMAND", "RunStopInsight", this._runStopInsight, this._configFile);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Com.FLS.Common;

namespace InCAM_Launcher
{
    class SessionManage
    {
        #region - Singleton -

        private static SessionManage _instance = null;
        private static readonly object syncObject = new object();

        /// <summary>
        /// 
        /// </summary>
        public static SessionManage Instance
        {
            get
            {
                if (null == _instance)
                {
                    lock (syncObject)
                    {
                        if (null == _instance)
                        {
                            _instance = new SessionManage();
                        }
                    }
                }

                return _instance;
            }
        }

        #endregion

        private readonly string _sessionDir = System.Windows.Forms.Application.StartupPath + "\\Sessions";
        private readonly string _sessionArchiveDir = System.Windows.Forms.Application.StartupPath + "\\Sessions\\Archive";
        private readonly string _lastSessionFile = System.Windows.Forms.Application.StartupPath + "\\LastSession";

        /* Use session name list instead of session instance
          because read session file on session construction costs time */
        private string[] _sessionNameList = new string[] { };
        /* _curSession is loaded from config file when init, if no such file, default session is loaded */
        private Session _curSession = null;

        public string[] SessionNameList
        {
            get
            {
                return this._sessionNameList;
            }
        }

        public Session CurSession
        {
            get
            {
                return this._curSession;
            }
        }

        public Session EmptySession
        {
            get
            {
                return new Session(this._sessionDir, "default");
            }
        }

        /// <summary>
        /// InCAM autotest compare session
        /// </summary>
        public Session ATInCAMSession
        {
            get
            {
                Session session = new Session(this._sessionDir, "default");
                session.DFMTool = DFMToolEnum.InCAM;
                session.IsUnitst = false;
                session.IsGuiless = false;
                session.IsAutoRunChk = false;
                session.DFMDir = Config.Instance.InCAMVer;

                return session;
            }
        }

        /// <summary>
        /// Procedure:
        /// 1. make sure session directory is exist
        /// 2. read all session file names
        /// 3. try to set last session as current session
        /// </summary>
        private SessionManage()
        {
            try
            {
                if (!Directory.Exists(this._sessionDir))
                {
                    Directory.CreateDirectory(this._sessionDir);
                }

                if (!Directory.Exists(this._sessionArchiveDir))
                {
                    Directory.CreateDirectory(this._sessionArchiveDir);
                }
            }
            catch (System.Exception)
            {
                //...
            }

            this.reloadSessionNameList();

            string lastSessionName = this.getLastSessionName();

            /* last session file may be deleted. in this case, will create new by calling setCurSession */
            if ( (string.Empty != lastSessionName) && (File.Exists(this._sessionDir + "\\" + lastSessionName)) )
            {
                this.setCurSession(lastSessionName);
            }
            else
            {
                this.setCurSession("default");
            }
        }

        ~SessionManage()
        {
            this.remLastSessionName();

           // this._curSession.Save();
        }

        private void reloadSessionNameList()
        {
            this._sessionNameList = DirHelper.getFilesInDir(this._sessionDir);
        }

        /// <summary>
        /// set current session by name
        /// if session not found, create a default session by that name
        /// </summary>
        /// <param name="sessionName"></param>
        public void setCurSession(string sessionName)
        {
            bool result = false;

            sessionName = string.Empty == sessionName ? "default" : sessionName;

            foreach(string _sessionName in this.SessionNameList)
            {
                if (_sessionName == sessionName)
                {
                    this._curSession = new Session(this._sessionDir, sessionName);
                    result = true;
                    break;
                }
            }

            /* Create new session if the session name does not exist 
               This is used when user save a new session */
            if(!result)
            {
                this._curSession = new Session(this._sessionDir, sessionName);
                this._curSession.save();
                this.reloadSessionNameList();
            }
        }

        /// <summary>
        /// session name list will auto reload after this method
        /// </summary>
        /// <param name="sessionName"></param>
        /// <returns></returns>
        public bool removeSession(string sessionName)
        {
            bool result = false;

            string sessionFile = this._sessionDir + "\\" + sessionName;

            if(File.Exists(sessionFile))
            {
                File.Delete(sessionFile);
                result = true;
                this.reloadSessionNameList();
                //note
                this._curSession = new Session(this._sessionDir, "default");
                this.remLastSessionName();
            }

            return result;
         }

        public bool archiveSession(string sessionName)
        {
            bool result = false;

            if(!Directory.Exists(this._sessionArchiveDir))
            {
                return result;
            }

            string sessionFile = this._sessionDir + "\\" + sessionName;
            string archiveFile = this._sessionArchiveDir + "\\" + sessionName;

            /* If file already exists, try to rename, or File.Move will cause error */
            while(File.Exists(archiveFile))
            {
                archiveFile += "_1";
            }

            if (File.Exists(sessionFile))
            {
                File.Move(sessionFile, archiveFile);
                result = true;
                this.reloadSessionNameList();
                //note
                this._curSession = new Session(this._sessionDir, "default");
                this.remLastSessionName();
            }

            return result;
        }

        /// <summary>
        /// read the last session name used
        /// </summary>
        /// <returns></returns>
        private string getLastSessionName()
        {
            return IniParser.readIniData("SESSION", "LastSession", "", this._lastSessionFile);
        }

        /// <summary>
        /// remember the session name selected by user
        /// so we can select this session by default when window is loaded
        /// </summary>
        private bool remLastSessionName()
        {
            bool result = true;

            result &= IniParser.writeIniData("SESSION", "LastSession", this._curSession.SessionName, this._lastSessionFile);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Com.FLS.Common;

namespace InCAM_Launcher
{
    class InCAMInvoker
    {
        private readonly string _sessionScriptFile = "session_config";
        private string currentPath = "";

        public InCAMInvoker()
        {
            currentPath = System.Windows.Forms.Application.StartupPath;
        }

        /// <summary>
        /// run xmanager or other commands before load the DFM script
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="showWindow"></param>
        private void runCmdBeforeDFM(string cmd, bool showWindow = false)
        {
            if(string.Empty == cmd)
            {
                return;
            }
            else
            {
                System.Diagnostics.ProcessStartInfo procStartInfo =
                new System.Diagnostics.ProcessStartInfo("cmd", (Config.Instance.CloseCmdAfterRun ? " /C " : " /K ") + " COLOR 02 & " + cmd);

                // The following commands are needed to redirect the standard output.
                // This means that it will be redirected to the Process.StandardOutput StreamReader.
                // procStartInfo.RedirectStandardOutput = true;
                procStartInfo.UseShellExecute = false;

                // Do not create the black window.
                procStartInfo.CreateNoWindow = !showWindow;

                // Now we create a process, assign its ProcessStartInfo and start it
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo = procStartInfo;

                proc.Start();
                proc.WaitForExit(1500);
            }
        }

        private void startXmanager()
        {
            string runXmanagerCmd = " start \"xmanager\" " + "\"" + Config.Instance.XMANAGER + "\"";

            this.runCmdBeforeDFM(runXmanagerCmd);
        }


        /// <summary>
        /// get environment variable GENESIS_DIR and GENESIS_EDIR
        /// We'll always use the ${GENESIS_EDIR}/prog plugins and ignore what version we're using
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        private string getEnvCmd(Session session)
        {
            if (DFMToolEnum.InCAM == session.DFMTool || DFMToolEnum.InCAM_Flex == session.DFMTool)
            {
                string cmdTemplate = "setenv FLS_UNIT_TESTS  {0}";

                return string.Format(cmdTemplate, session.IsUnitst ? "yes" : "no");
            }
            else if (DFMToolEnum.Genesis == session.DFMTool || DFMToolEnum.GenFlex == session.DFMTool)
            {
                string cmdTemplate = "setenv GENESIS_DIR {0}; setenv GENESIS_EDIR {1}";

                string genesis_edir = session.DFMDir;
                string genesis_dir = "";

                if (Directory.Exists(genesis_edir))
                {
                    DirectoryInfo dir = new DirectoryInfo(genesis_edir);
                    genesis_dir = dir.Parent.Root + dir.Parent.Name;

                    return string.Format(cmdTemplate, genesis_dir, genesis_edir);
                }
                else
                {
                    throw new System.Exception("Invalid Genesis directory!");
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// example: cmd.exe /C /K D:/InCAM/release_64/utils/csh - c "setenv FLS_UNIT_TESTS yes;D:/InCAM/release_64/bin/InCAM -sC:/Launcher/dfm_invoker.csh C:/Launcher/session_config"
        /// </summary>
        /// <param name="session"></param>
        /// <param name="sessionConfig"></param>
        /// <param name="b_setEnv"></param>
        private void invokeDFM(Session session, string sessionConfig, bool isInvokeNeeded, Boolean is_checklist_run=true)
        {
            string invokeCmd = "";
            bool isGuiless = session.IsUnitst && session.IsGuiless;
            if (isInvokeNeeded)
            {
                if (is_checklist_run)
                {
                    invokeCmd = (isGuiless ? " -x " : "") + " -s" + currentPath + "/dfm_invoker.csh " + currentPath + "\\" + new FileInfo(sessionConfig).Name;
                }
                else
                {
                    invokeCmd = (isGuiless ? " -x " : "") + " -s" + currentPath + "/dfm_invoker_compare.csh " + currentPath + "\\" + new FileInfo(sessionConfig).Name;
                }
            }
           
            string cmdParam = (!Config.Instance.CloseCmdAfterRun || isGuiless ? " /K "/*KEEP*/ : " /C "/*CLOSE*/)
                + " COLOR 02 & "
                + " " + session.DFMCsh + " -c "
                + "\x22"
                + getEnvCmd(session)
                + ";"
                + session.DFMExe + (session.DFMTool == DFMToolEnum.InCAM_Flex ? " -flex ": "")
                + invokeCmd
                + "\x22";

            cmdParam = cmdParam.Replace(@"\", "/");

            System.Diagnostics.ProcessStartInfo procStartInfo =
            new System.Diagnostics.ProcessStartInfo("cmd", cmdParam);

            // The following commands are needed to redirect the standard output.
            // This means that it will be redirected to the Process.StandardOutput StreamReader.
            // procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;

            // Do not create the black window.
            procStartInfo.CreateNoWindow = false;

            // Now we create a process, assign its ProcessStartInfo and start it
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;

            proc.Start();          
        }

        public bool runSession(Session session, bool isInvokeNeeded)
        {
            if(!session.saveSessionToScript(session, this._sessionScriptFile))
            {
                return false;
            }

            if(DFMToolEnum.Genesis == session.DFMTool)
            {
                this.runCmdBeforeDFM(Config.Instance.RunBeforeGenesis);
                this.startXmanager();
                this.invokeDFM(session, _sessionScriptFile, isInvokeNeeded);
            }

            else if(DFMToolEnum.GenFlex == session.DFMTool)
            {
                this.runCmdBeforeDFM(Config.Instance.RunBeforeGeflex);
                this.startXmanager();
                this.invokeDFM(session, _sessionScriptFile, isInvokeNeeded);
            }

            else if(DFMToolEnum.InsightPCBStart == session.DFMTool)
            {
                this.runCmdBeforeDFM(Config.Instance.RunStartInsight, true);
            }

            else if(DFMToolEnum.InsightPCBStop == session.DFMTool)
            {
                this.runCmdBeforeDFM(Config.Instance.RunStopInsight, false);
            }

            else 
            {
                this.runCmdBeforeDFM(Config.Instance.RunBeforeInCAM);
                this.invokeDFM(session, _sessionScriptFile, isInvokeNeeded);
            }

            return true;
        }

        public bool runCompare(string at_config, Boolean isFlex)
        {
            Session session = SessionManage.Instance.ATInCAMSession;
            if(isFlex)
            {
                session.DFMTool = DFMToolEnum.InCAM_Flex;
            }

            this.runCmdBeforeDFM(Config.Instance.RunBeforeInCAM);
            this.invokeDFM(session, at_config, true, false);

            return true;
        }

    }
}

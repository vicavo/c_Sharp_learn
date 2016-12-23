using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Com.FLS.Common;
using Com.FLS.Controls;
using System.Text.RegularExpressions;

namespace InCAM_Launcher
{
    public partial class MainForm : Form
    {
        private IncamDB incamDB = new IncamDB();
        private IncamJob curJob = new IncamJob();
        private InCAMInvoker invoker = new InCAMInvoker();
        private bool realExit = false;
        private Timer timer = new Timer();
        private Boolean timerDone = true;
        private readonly int hotKeyLaunch = 999;
        private readonly int hotkeyShowWnd = 998;
        private readonly int hotKeyInCAM = 997;


        #region - Init -
        public MainForm(string[] args)
        {
            if (0 != args.Length)
            {
               this.quickCompare(args[0].ToString());
               // this.quickCompare(@"D:\lance\autotest\slr\DB\12bf43147aa-chx-tmp1-r1.params");

               System.Environment.Exit(0);
            }

            InitializeComponent();
            HotKey.RegisterHotKey(this.Handle, this.hotKeyLaunch, (int)HotKey.CtlKeys.Alt, Keys.S);
            HotKey.RegisterHotKey(this.Handle, this.hotkeyShowWnd, (int)HotKey.CtlKeys.Alt, Keys.D);
            HotKey.RegisterHotKey(this.Handle, this.hotKeyInCAM, (int)HotKey.CtlKeys.Alt, Keys.X);

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.dgJobList.Columns[0].Width = this.dgJobList.Width - this.dgJobList.RowHeadersWidth -
                this.dgJobList.Columns[1].Width - this.dgJobList.Columns[2].Width - 
                SystemInformation.VerticalScrollBarWidth - 2;

            this.Text = this.Text + " v" + Application.ProductVersion + " build-" + TimeStampNS.Timestamp.BuildAt.ToString("yyyyMMdd") + "";

            this.initToolTips();

            this.timer.Tick += new EventHandler(OnTimerFilter);
            timerDone = true;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            HotKey.UnregisterHotKey(this.Handle, this.hotKeyLaunch);
            HotKey.UnregisterHotKey(this.Handle, this.hotkeyShowWnd);
            HotKey.UnregisterHotKey(this.Handle, this.hotKeyInCAM);
        }

        /// <summary>
        /// Call a script to compare two layers of autotest
        /// </summary>
        /// <param name="at_params"></param>
        private void quickCompare(string at_params)
        {
            Boolean isFlex = false;

            if (!File.Exists(at_params))
            {
                throw new System.Exception("No such file: " + at_params);
            }

            /* Simply check the filesize to decide it is a valid cofig file */
            FileInfo fi = new FileInfo(at_params);
            if(fi.Length > 2048)
            {
                throw new System.Exception(at_params + " is not a legel autotest config file!");
            }

            /* This config file is called by invoke script */
            string at_compare_config = System.Windows.Forms.Application.StartupPath + "\\at_compare_config";

            /* Copy the config to current so the path does not contain space */
            File.Copy(at_params, at_compare_config, true);

            /* now we try to find the "run_params" file and append the content to at_config
             * we need the MyVer and MyVerRef to run compare */
            DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(at_params));
            string run_param = string.Empty;
            do
            {
                string fname = dirInfo.FullName + "\\" + Config.Instance.ATConfigFilename;
                if (File.Exists(fname))
                {
                    run_param = fname;
                    break;
                }

                dirInfo = dirInfo.Parent;
            }
            while (dirInfo != null);

            /* Append the content of "run_params" to the config file */
            if (run_param != string.Empty)
            {
                using (StreamReader reader = new StreamReader(run_param))
                {
                    StreamWriter writer = new StreamWriter(at_compare_config, true);

                    while (!reader.EndOfStream)
                    {
                        string content = reader.ReadLine();

                        /* The parameter "IsFlex" is set and it's not a comment line */
                        if(content.IndexOf("IsFlex") !=-1 &&
                            (content.IndexOf("#") == -1 || content.IndexOf("#")!= 0))
                        {
                            isFlex = true;
                        }

                        writer.WriteLine(content);
                    }

                    writer.Close();
                    reader.Close();
                }
            }

            this.invoker.runCompare(at_compare_config, isFlex);
        }

        private void initToolTips()
        {
            /* Quick launch icon  */
            ToolTip btnQuickLchTT = new ToolTip();
            btnQuickLchTT.SetToolTip(btnQuickLaunch, "Launch this version without open any checklists.");

            /* CheckBox regex */
            ToolTip ckRegexTT = new ToolTip();
            ckRegexTT.SetToolTip(ckRegex, "Use wildcard if unchecked, use regular expression if checked.");

            /* Button Save To File*/
            ToolTip btnSaveSessionTT = new ToolTip();
            btnSaveSessionTT.SetToolTip(btnSaveToFile, "Save everything on this page to a session so we can restore it later.");

            /* Button Save To */
            ToolTip btnSaveAutotestTT = new ToolTip();
            btnSaveAutotestTT.SetToolTip(btnSaveToAutotest, "Save everything on this page to autotest config file.");

            /* ComboBox Layer */
            ToolTip cbLayerTT = new ToolTip();
            cbLayerTT.SetToolTip(cbLayer, "Define this layer as affected and display layer.");

            /* ComboBox Checklist */
            ToolTip cbChecklistTT = new ToolTip();
            cbChecklistTT.SetToolTip(cbChecklist, "Leave it empty if you don't want to open a checklist.");

            /* Picturebox delete session */
            ToolTip btnDelSessionTT = new ToolTip();
            btnDelSessionTT.SetToolTip(btnDelSession, "Double click to delete the selected session.");

            /* Picturebox archive session */
            ToolTip btnArchiveSessionTT = new ToolTip();
            btnArchiveSessionTT.SetToolTip(btnArchiveSession, "Double click to archive the selected session if you don't want to see it here.");

            /* Radio DFM tool */
            ToolTip btnDFMTool = new ToolTip();
            btnDFMTool.SetToolTip(rdGroup1b1, "Which software should we launch, InCAM, Genesis or GenFlex?");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Session session = SessionManage.Instance.CurSession;

            this.reloadSessionList();

            if(Application.StartupPath.Contains(" "))
            {
                MessageBox.Show("You are running this application in an invalid directory: " + Application.StartupPath +
                    "\r\n" + ">>The directory contains space or special characters, The application will not work correctly.",
                    "WARNNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region - DB and Tool Select -

        private void btnBrw1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Choose InCAM/Genesis/Geflex root folder";
                dlg.RootFolder = Environment.SpecialFolder.MyComputer;
                /* try to reload last directory */
                if (Directory.Exists(this.tbIncamDir.Text))
                {
                    dlg.SelectedPath = this.tbIncamDir.Text;
                }

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    this.tbIncamDir.Text = dlg.SelectedPath;
                }
            }
        }

        /// <summary>
        /// when version list is dropdown to select, show a list of DFM version for user to select
        /// the list depends on DFM type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbIncamDir_DropDown(object sender, EventArgs e)
        {
            this.tbIncamDir.Items.Clear();
            List<string> inCAMVers = this.rdGroup1b1.Checked ? Config.Instance.InCAMVerList : Config.Instance.GenVerList;

            inCAMVers.Sort();

            foreach (string ver in inCAMVers)
            {
                this.tbIncamDir.Items.Add(ver);
            }
        }

        private void btnBrw2_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dlg = new FolderBrowserDialog())
            {
                dlg.Description = "Choose InCAM/Genesis/Geflex DB folder";
                dlg.RootFolder = Environment.SpecialFolder.MyComputer;
                /* try to reload last directory */
                if (Directory.Exists(this.tbdbDir.Text))
                {
                    dlg.SelectedPath = this.tbdbDir.Text;
                }

                if (DialogResult.OK == dlg.ShowDialog())
                {
                    this.tbdbDir.Text = dlg.SelectedPath;
                }
            }
        }

        private void tbIncamDir_TextChanged(object sender, EventArgs e)
        {
            int result = this.autoDetectDFMTool(this.tbIncamDir.Text);
            
            /* tell user if the path is valid using color */
            if (-1 == result)
            {
                this.tbIncamDir.BackColor = Color.Tomato;
            }
            else
            {
                this.tbIncamDir.BackColor = SystemColors.Window;
            }

            /* auto select DFM tool */
            if ((int)DFMToolEnum.InCAM == result)
            {
                this.rdGroup1b1.Checked = true;
            }
            else if ((int)DFMToolEnum.Genesis == result)
            {
                this.rdGroup1b2.Checked = true;
            }
            else
            {
                this.rdGroup1b1.Checked = true;
            }
        }

        /// <summary>
        /// auto detect the DFM tool type
        /// </summary>
        /// <param name="dfmDir">InCAM Directory user specified</param>
        /// <returns>0 InCAM 1 Genesis 2 GenFlex other invalid path</returns>
        private int autoDetectDFMTool(string dfmDir)
        {
            int result = -1;

            if(File.Exists(dfmDir + "\\bin\\InCAM.exe"))
            {
                result = (int)DFMToolEnum.InCAM;
            }
            /* we don't know genesis or geflex, so return genesis by default */
            else if(File.Exists(dfmDir + "\\get\\get.exe"))
            {
                result = (int)DFMToolEnum.Genesis;
            }

            return result;
        }
     
        private void tbdbDir_DoubleClick(object sender, EventArgs e)
        {
            if (Directory.Exists(this.tbdbDir.Text))
            {
                try
                {
                    System.Diagnostics.Process.Start("explorer.exe", this.tbdbDir.Text);
                }
                catch (System.Exception)
                {

                }
            }
        }

        /// <summary>
        /// when window is loaded, the value will change from empty to a specified value,
        /// this event will be triggered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbdbDir_TextChanged(object sender, EventArgs e)
        {
            if (!Directory.Exists(this.tbdbDir.Text))
            {
                this.tbdbDir.BackColor = Color.Tomato;
            }
            else
            {
                this.tbdbDir.BackColor = SystemColors.Window;
            }

            this.incamDB = new IncamDB(this.tbdbDir.Text);
            this.lbJobCnt.Text = this.incamDB.JobCount.ToString() + " jobs in DB.";
            this.tbFilterPattern_TextChanged(null, null);

            this.reloadDB();
        }

        private void reloadDB()
        {
            this.dgJobList.Rows.Clear();

            foreach (IncamJob job in this.incamDB.Jobs)
            {
                if (!job.IsFiltered)
                {
                    this.dgJobList.Rows.Add(job.JobName, "", "");
                }
            }

            this.seekJobInList(SessionManage.Instance.CurSession.JobName);
        }

        private void seekJobInList(string jobName)
        {
            foreach (DataGridViewRow row in this.dgJobList.Rows)
            {
                if (row.Cells[0].Value.ToString() == jobName)
                {
                    row.Selected = true;
                    this.dgJobList.CurrentCell = row.Cells[0];
                    this.dgJobList.FirstDisplayedScrollingRowIndex = row.Index;

                    /* trigger the system to reload steps and layers */
                    this.dgJobList_SelectionChanged(null, null);
                    break;
                }
            }
        }

        private void OnTimerFilter(Object myObject, EventArgs myEventArgs)
        {
            this.timer.Stop();
            string pattern = this.tbFilterPattern.Text;

            /* If using regex, tell user if the expression is wrong */
            if (this.ckRegex.Checked)
            {
                if (this.incamDB.ValidFilterBeforeApply(pattern, true))
                {
                    this.tbFilterPattern.BackColor = SystemColors.Window;
                    this.incamDB.applyFilterRegex(pattern);
                }
                else
                {
                    this.tbFilterPattern.BackColor = Color.Tomato;
                }
            }
            else
            {
                this.tbFilterPattern.BackColor = SystemColors.Window;
                this.incamDB.applyFilterWildCard(pattern);
            }

            this.reloadDB();

            this.timerDone = true;

        }

        private void tbFilterPattern_TextChanged(object sender, EventArgs e)
        {
            if (this.timerDone)
            {
                this.timer.Stop();
                this.timer.Interval = 200;
                this.timer.Start();
            }
        }

        private void tbFilterPattern_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.timerDone = false;

                this.OnTimerFilter(null, null);
            }
        }

        private void ckRegex_CheckedChanged(object sender, EventArgs e)
        {
            string pattern = this.tbFilterPattern.Text;

            if (this.ckRegex.Checked)
            {
                this.incamDB.applyFilterRegex(pattern);
            }
            else
            {
                this.incamDB.applyFilterWildCard(pattern);
            }

            //this.reloadDB();
            // this.tbFilterPattern_TextChanged(null, null);
            this.OnTimerFilter(null, null);
        }

        #region - Job Context Menu -

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tbdbDir_TextChanged(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgJobList.SelectedRows.Count < 1)
            {
                return;
            }

            DialogResult response = MessageBox.Show("This operation could not be reverted!\r\nare you sure you want to delete [" + this.curJob.JobName + "]?",
                "WARN", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (DialogResult.OK == response)
            {
                /* Since we don't know if the directory is opened already, 
                 * we try to rename the job directory first, if success, we do the real deletion */
                try
                {
                    string oldDir = this.curJob.JobPath + "\\" + this.curJob.JobName;
                    string newDir = oldDir;
                    bool exists = true;

                    while (exists)
                    {
                        newDir = newDir + "_1";
                        exists = Directory.Exists(newDir);
                    }

                    Directory.Move(oldDir, newDir);
                    Directory.Delete(newDir, true);

                    /* reload DB */
                    this.tbdbDir_TextChanged(null, null);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgJobList.SelectedRows.Count < 1)
            {
                return;
            }

            string oldName = this.curJob.JobName.ToLower();
            string newName = oldName;

            DialogResult response = InputBox.Show("Rename", "New name for " + this.curJob.JobName + ":", ref newName);

            if (DialogResult.OK != response)
            {
                return;
            }

            newName = newName.ToLower();

            if (oldName == newName)
            {
                return;
            }

            /* check if name is valid */
            if (!Regex.IsMatch(newName, @"^[\d,a-z,_,+,\-,\.]+$"))
            {
                MessageBox.Show("Illegal job name!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            oldName = this.curJob.JobPath + "\\" + oldName;
            newName = this.curJob.JobPath + "\\" + newName;

            /* check if the lod job exists */
            if (!Directory.Exists(oldName))
            {
                MessageBox.Show("Can not find the source job, maybe it's deleted?", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbdbDir_TextChanged(null, null);
                return;
            }

            /* check if the new job exists */
            if (Directory.Exists(newName))
            {
                MessageBox.Show("There is already a job with the name, please specify another name.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                Directory.Move(oldName, newName);
                this.tbdbDir_TextChanged(null, null);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }
        #endregion
        #endregion

        #region - Options -

        /// <summary>
        /// Enable/Disable InCAM unit test mode when DFM tool changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdDFMTool_CheckChanged(Object sender, EventArgs e)
        {
            // Check of the raiser of the event is a checked Checkbox.
            // Of course we also need to to cast it first.
            if (((RadioButton)sender).Checked)
            {
                RadioButton rb = (RadioButton)sender;
                if (null == rb) return;

                if(rb.Text == this.rdGroup1b1.Text)
                {
                    this.ckUnitst.Enabled = true;
                }
                else
                {
                    this.ckUnitst.Enabled = false;
                    this.ckUnitst.Checked = false;
                }
            }
        }

        private void dgJobList_SelectionChanged(object sender, EventArgs e)
        {
            if(0 == this.dgJobList.SelectedRows.Count)
            {
                return;
            }

            this.curJob = new IncamJob();

            string jobName = this.dgJobList.CurrentRow.Cells[0].Value.ToString();
            this.curJob = this.incamDB.getJobByName(jobName);

            if(DateTime.MinValue != this.curJob.CreateDate)
            {
                this.dgJobList.CurrentRow.Cells[1].Value = this.curJob.CreateDate.ToString("yyyy/MM/dd HH:mm");
            }

            if (DateTime.MinValue != this.curJob.LastModifyDate)
            {
                this.dgJobList.CurrentRow.Cells[2].Value = this.curJob.LastModifyDate.ToString("yyyy/MM/dd HH:mm");
            }

            this.reloadStep(this.curJob);
        }

        private void reloadStep(IncamJob job)
        {
            this.cbStep.Items.Clear();

            this.cbLayer.Items.Clear();
            this.cbChecklist.Items.Clear();

            foreach (IncamJobStep step in job.Steps)
            {
                this.cbStep.Items.Add(step.StepName);
            }

            if(this.cbStep.Items.Count > 0)
            {
                this.cbStep.SelectedIndex = 0;
            }
        }

        private void cbStep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stepName = this.cbStep.Text.ToString();

            IncamJobStep step = this.curJob.getStepByName(stepName);

            this.reloadLayersAndChks(step);
        }

        private void reloadLayersAndChks(IncamJobStep step)
        {
            this.cbLayer.Items.Clear();
            this.cbChecklist.Items.Clear();

            foreach(string layer in step.Layers)
            {
                this.cbLayer.Items.Add(layer);
            }

            foreach (string chk in step.CheckLists)
            {
                this.cbChecklist.Items.Add(chk);
            }

            if (this.cbLayer.Items.Count > 0)
            {
                this.cbLayer.SelectedIndex = 0;
            }

            if (this.cbChecklist.Items.Count > 0)
            {
                this.cbChecklist.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// If not autotest, disable Guiless checkbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckUnitst_CheckedChanged(object sender, EventArgs e)
        {
            this.ckGuiless.Enabled = this.ckUnitst.Checked;
            if (this.ckUnitst.Checked && this.ckGuiless.Checked)
            {
                this.ckAutoRun.Checked = true;
            }
        }

        /// <summary>
        /// If in unit test and Guiless, auto run checklist after launch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckGuiless_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckUnitst.Checked && this.ckGuiless.Checked)
            {
                this.ckAutoRun.Checked = true;
            }
        }

        #endregion

        #region - Session -

        #region - Notify Icon -

        private void reloadSessionListMenu()
        {
            this.menuSessionList.Items.Clear();
            /* Group 1: System menu */
            this.menuSessionList.Items.Add("Show DFMQL Window");
            this.menuSessionList.Items.Add("Exit");
            this.menuSessionList.Items[0].Image = global::InCAM_Launcher.Properties.Resources.show;
            this.menuSessionList.Items[1].Image = global::InCAM_Launcher.Properties.Resources.exit;

            ToolStripSeparator sep0 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSessionList.Items.Add(sep0); /* Item 2 */

            /* Group 2: ShortCut */
            ToolStripMenuItem insightMenu = new ToolStripMenuItem("InsightPCB");
            insightMenu.DropDown.Items.Add("Start");
            insightMenu.DropDown.Items.Add("Stop");
            this.menuSessionList.Items.Add(insightMenu);
            insightMenu.DropDownItemClicked += this.InsightSubmenuItemClick;

            this.menuSessionList.Items.Add("InCAM");
            this.menuSessionList.Items.Add("InCAM_Flex");
            this.menuSessionList.Items.Add("Genesis");
            this.menuSessionList.Items.Add("GenFlex");
            this.menuSessionList.Items[3].Image = global::InCAM_Launcher.Properties.Resources.insight;
            this.menuSessionList.Items[4].Image = global::InCAM_Launcher.Properties.Resources.incam;
            this.menuSessionList.Items[5].Image = global::InCAM_Launcher.Properties.Resources.incam;
            this.menuSessionList.Items[6].Image = global::InCAM_Launcher.Properties.Resources.gen;
            this.menuSessionList.Items[7].Image = global::InCAM_Launcher.Properties.Resources.gfx;

            ToolStripSeparator sep1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSessionList.Items.Add(sep1); /* Item 6*/

            /* Group 3: Quick Launch */
            foreach (string sessionName in SessionManage.Instance.SessionNameList)
            {
                /* add current session to lowest, so user can reach it easier */
                if (sessionName == SessionManage.Instance.CurSession.SessionName)
                    continue;
                this.menuSessionList.Items.Add(sessionName);
            }

            ToolStripSeparator sep2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSessionList.Items.Add(sep2);
            this.menuSessionList.Items.Add(SessionManage.Instance.CurSession.SessionName);
            /* add the icon to the last item */
            this.menuSessionList.Items[this.menuSessionList.Items.Count - 1].Image = global::InCAM_Launcher.Properties.Resources.thunder;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            /* Double click always trigger this event */

            if (e.Button == MouseButtons.Left)
            {
                if (FormWindowState.Minimized == this.WindowState)
                {
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                }
                else
                {
                    this.WindowState = FormWindowState.Minimized;
                }
            }

            else if(e.Button == MouseButtons.Middle)
            {
                this.quickLoad(SessionManage.Instance.CurSession, true);
            }
        }

        /// <summary>
        /// double click for quick launch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           // this.quickLoad();
        }

        private void InsightSubmenuItemClick(object sender, ToolStripItemClickedEventArgs e)
        {
            /* create a empty session to load without invoke */
            Session emptySession = SessionManage.Instance.EmptySession;
            emptySession.DFMDir = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

            /* the menu will not hide automatically */
            this.menuSessionList.Hide();

            if ("Start" == e.ClickedItem.Text)
            {
                emptySession.DFMTool = DFMToolEnum.InsightPCBStart;
                this.quickLoad(emptySession, false);
            }
            else
            {
                emptySession.DFMTool = DFMToolEnum.InsightPCBStop;
                this.quickLoad(emptySession, false);
            }
        }

        private void menuSessionList_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string sessionName = (e.ClickedItem as ToolStripItem).Text;

            /* create a empty session to load without invoke */
            Session emptySession = SessionManage.Instance.EmptySession;

            switch (sessionName)
            {
                case "Exit":
                    this.realExit = true;
                    Application.Exit();
                    break;

                case "Show DFMQL Window":
                    this.Visible = true;
                    this.WindowState = FormWindowState.Normal;
                    this.Activate();
                    break;

                // InsightPCB actions are handled via InsightSubmenuItemClick()
                case "InsightPCB":
                    break;

                case "InCAM":
                    emptySession.DFMDir = Config.Instance.InCAMVer;
                    emptySession.DFMTool = DFMToolEnum.InCAM;
                    this.quickLoad(emptySession, false);
                    break;

                case "InCAM_Flex":
                    emptySession.DFMDir = Config.Instance.InCAMVer;
                    emptySession.DFMTool = DFMToolEnum.InCAM_Flex;
                    this.quickLoad(emptySession, false);
                    break;

                case "Genesis":
                    emptySession.DFMDir = Config.Instance.GenVer;
                    emptySession.DFMTool = DFMToolEnum.Genesis;
                    this.quickLoad(emptySession, false);
                    break;

                case "GenFlex":
                    emptySession.DFMDir = Config.Instance.GfxVer;
                    emptySession.DFMTool = DFMToolEnum.GenFlex;
                    this.quickLoad(emptySession, false);
                    break;

                default:
                    SessionManage.Instance.setCurSession(sessionName);

                    /* If the session is default, we should use the latest information on the UI,
                     * so we should do a update here, what ever user modified on the UI is used here */
                    if (("default" == sessionName) && ("default" == this.cbSession.Text))
                    {
                        this.convUI2Session(SessionManage.Instance.CurSession.SessionName);
                    }

                    this.quickLoad(SessionManage.Instance.CurSession, true);
                    break;
            }
        }
        #endregion

        #region - Buttons -

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            this.convUI2Session(SessionManage.Instance.CurSession.SessionName);

            this.quickLoad(SessionManage.Instance.CurSession, true);
        }

        private void quickLoad(Session session, bool isInvokeNeeded)
        {
            /* re-arrange the sessionlist */
            this.reloadSessionListMenu();

            if (!File.Exists(session.DFMExe) || !File.Exists(session.DFMCsh))
            {
                MessageBox.Show("Can not find DFM exe in the [DFM directory] you specified!\r\nDid you select the wrong DFM application in [Options]?", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                /* run InCAM and hide self */
                if (this.invoker.runSession(session, isInvokeNeeded))
                {
                    if (Config.Instance.HideAfterLaunch)
                    {
                        this.WindowState = FormWindowState.Minimized;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnQuickLaunch_Click(object sender, EventArgs e)
        {
            int result = this.autoDetectDFMTool(this.tbIncamDir.Text);

            Session emptySession = SessionManage.Instance.EmptySession;
            emptySession.DFMDir = this.tbIncamDir.Text;

            if ((int)DFMToolEnum.Genesis == result)
            {
                if (this.ckFlex.Checked)
                {
                    emptySession.DFMTool = DFMToolEnum.GenFlex;
                }
                else
                {
                    emptySession.DFMTool = DFMToolEnum.Genesis;
                }
            }
            else
            {
                if (this.ckFlex.Checked)
                {
                    emptySession.DFMTool = DFMToolEnum.InCAM_Flex;
                }
                else
                {
                    emptySession.DFMTool = DFMToolEnum.InCAM;
                }
            }

            this.quickLoad(emptySession, false);
        }

        private void btnSaveToFile_Click(object sender, EventArgs e)
        {
            string sessionName = this.tbSession.Text.Trim();
            if (string.Empty == sessionName)
            {
                return;
            }

            this.convUI2Session(sessionName);
            SessionManage.Instance.CurSession.save();
            this.reloadSessionList();
        }

        private void btnSaveToSession_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.RestoreDirectory = false;
                dialog.Filter = "Autotest configuration files (*.params)|*.params";
                dialog.Title = "Please specify a file name:";
                dialog.FileName = this.curJob.JobName;

                if (DialogResult.OK == dialog.ShowDialog())
                {
                    string sessionName = this.tbSession.Text.Trim();
                    if (string.Empty == sessionName)
                    {
                        return;
                    }
                    this.convUI2Session(sessionName);
                    SessionManage.Instance.CurSession.saveSessionToAutotest(SessionManage.Instance.CurSession, dialog.FileName);
                }
            }
        }

        private void tbSession_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSaveToFile_Click(null, null);
            }
        }

        private void btnDelSession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (string.Empty == this.cbSession.Text)
            {
                return;
            }

            if (SessionManage.Instance.removeSession(this.cbSession.Text))
            {
                this.reloadSessionList();
            }
        }

        private void btnArchiveSession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((string.Empty == this.cbSession.Text) || ("default" == this.cbSession.Text))
            {
                return;
            }

            if (SessionManage.Instance.archiveSession(this.cbSession.Text))
            {
                this.reloadSessionList();
            }
        }

        private void btnDelSession_MouseEnter(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;
            btn.Left = btn.Left - 4;
            btn.Top = btn.Top - 4;
            btn.Width = btn.Width + 8;
            btn.Height = btn.Height + 8;
        }

        private void btnDelSession_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;

            btn.Left = btn.Left + 4;
            btn.Top = btn.Top + 4;
            btn.Width = btn.Width - 8;
            btn.Height = btn.Height - 8;
        }

        #endregion

        #region - Session Manage - 

        private void reloadSessionList()
        {
            this.reloadSessionListMenu();

            this.cbSession.Items.Clear();

            int lastSessionIdx = -1;

            foreach(string sessionName in SessionManage.Instance.SessionNameList)
            {
                this.cbSession.Items.Add(sessionName);

                /* load last session */
                if(sessionName == SessionManage.Instance.CurSession.SessionName)
                {
                    lastSessionIdx = this.cbSession.Items.Count - 1;
                }
            }

            if(this.cbSession.Items.Count > 0)
            {
                this.cbSession.SelectedIndex = -1 == lastSessionIdx ? 0 : lastSessionIdx;
            }
        }
        
        private void cbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            SessionManage.Instance.setCurSession(this.cbSession.Text);
            this.convSession2UI(SessionManage.Instance.CurSession);

            /* set the "save to" file name */
            this.tbSession.Text = string.Empty == this.cbSession.Text ? "default" : this.cbSession.Text;

            /* set the current at bottom */
            this.reloadSessionListMenu();
        }

        private void convUI2Session(string sessionName)
        {
            SessionManage.Instance.setCurSession(sessionName);

            SessionManage.Instance.CurSession.DFMDir = this.tbIncamDir.Text;
            SessionManage.Instance.CurSession.DbDir = this.tbdbDir.Text;
            SessionManage.Instance.CurSession.Filter = this.tbFilterPattern.Text;
            SessionManage.Instance.CurSession.IsRegexFilter = this.ckRegex.Checked;
            if(this.rdGroup1b2.Checked)
            {
                if (this.ckFlex.Checked)
                {
                    SessionManage.Instance.CurSession.DFMTool = DFMToolEnum.GenFlex;
                }
                else
                {
                    SessionManage.Instance.CurSession.DFMTool = DFMToolEnum.Genesis;
                }
            }
            else if(this.rdGroup1b1.Checked)
            {
                if (this.ckFlex.Checked)
                {
                    SessionManage.Instance.CurSession.DFMTool = DFMToolEnum.InCAM_Flex;
                }
                else
                {
                    SessionManage.Instance.CurSession.DFMTool = DFMToolEnum.InCAM;
                }
            }
            else
            {
                //impossible
            }

            /* When jobname in list changed, the name will set to this.curJob automatically,
             * so we can use the this.curJob.JobName directly here */
            SessionManage.Instance.CurSession.JobName = this.curJob.JobName;
            SessionManage.Instance.CurSession.Step = this.cbStep.Text;
            SessionManage.Instance.CurSession.Layer = this.cbLayer.Text;
            SessionManage.Instance.CurSession.Checklist = this.cbChecklist.Text;
            SessionManage.Instance.CurSession.IsAutoRunChk = this.ckAutoRun.Checked;
            SessionManage.Instance.CurSession.IsUnitst = this.ckUnitst.Checked;
            SessionManage.Instance.CurSession.IsGuiless = this.ckGuiless.Checked;
        }

        private void convSession2UI(Session session)
        {
            this.tbIncamDir.Text = SessionManage.Instance.CurSession.DFMDir;
            this.tbdbDir.Text = SessionManage.Instance.CurSession.DbDir;
            this.tbFilterPattern.Text = SessionManage.Instance.CurSession.Filter;
            this.ckRegex.Checked = SessionManage.Instance.CurSession.IsRegexFilter;

            if(DFMToolEnum.Genesis == SessionManage.Instance.CurSession.DFMTool)
            {
                this.rdGroup1b2.Checked = true;
                this.ckFlex.Checked = false;
            }
            else if (DFMToolEnum.GenFlex == SessionManage.Instance.CurSession.DFMTool)
            {
                this.rdGroup1b2.Checked = true;
                this.ckFlex.Checked = true;
            }
            else if (DFMToolEnum.InCAM == SessionManage.Instance.CurSession.DFMTool)
            {
                this.rdGroup1b1.Checked = true;
                this.ckFlex.Checked = false;
            }
            else if (DFMToolEnum.InCAM_Flex == SessionManage.Instance.CurSession.DFMTool)
            {
                this.rdGroup1b1.Checked = true;
                this.ckFlex.Checked = true;
            }
            else
            {
                //impossible
            }

            /* How to find job in list 
             * When the DB text box is changed on load session, a reloadDB action will be triggered,
             * and we'll seek to the job in the list after DB is reloaded, Filter change will trigger the seek event, too
             * so there is no need to set a job here */
            this.cbStep.Text = SessionManage.Instance.CurSession.Step;
            this.cbLayer.Text = SessionManage.Instance.CurSession.Layer;
            this.cbChecklist.Text = SessionManage.Instance.CurSession.Checklist;
            this.ckAutoRun.Checked = SessionManage.Instance.CurSession.IsAutoRunChk;
            this.ckUnitst.Checked = SessionManage.Instance.CurSession.IsUnitst;  
            this.ckGuiless.Checked = SessionManage.Instance.CurSession.IsGuiless;
        }

        #endregion

        #endregion

        #region - Overrides -
        protected override void WndProc(ref Message m)
        {
           const int WM_NCLBUTTONDBLCLK = 0x00A3;
           const int WM_HOTKEY = 0x0312;

            switch (m.Msg)
            {
                case WM_NCLBUTTONDBLCLK:
                    this.TopMost = !this.TopMost;
                    if (this.TopMost)
                    {
                        this.Opacity = 0.7;
                    }
                    else
                    {
                        this.Opacity = 1.0;
                    }
                    break;

                case WM_HOTKEY:

                    if ((int)m.WParam == this.hotKeyLaunch)
                    {
                        this.quickLoad(SessionManage.Instance.CurSession, true);
                    }
                    else if ((int)m.WParam == this.hotkeyShowWnd)
                    {
                        if (FormWindowState.Minimized == this.WindowState)
                        {
                            this.Visible = true;
                            this.WindowState = FormWindowState.Normal;
                            this.Activate();
                        }
                        else
                        {
                            this.WindowState = FormWindowState.Minimized;
                        }
                    }
                    else if((int)m.WParam == this.hotKeyInCAM)
                    {
                        Session emptySession = SessionManage.Instance.EmptySession;
                        emptySession.DFMDir = Config.Instance.InCAMVer;
                        emptySession.DFMTool = DFMToolEnum.InCAM;
                        this.quickLoad(emptySession, false);
                        break;
                    }
                    break;

                default: break;
            }

            base.WndProc(ref m);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.Instance.HideOnClose)
            {
                this.WindowState = FormWindowState.Minimized;

                /* click the menu to set this value to true */
                if (!realExit)
                {
                    e.Cancel = true;
                }

            }

            if ("default" == SessionManage.Instance.CurSession.SessionName)
            {
                this.convUI2Session(SessionManage.Instance.CurSession.SessionName);
                SessionManage.Instance.CurSession.save();
            }        
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                if (Config.Instance.MinimizedToTrayOnly)
                {
                    this.Hide();
                }
            }
        }
        #endregion
    }
}

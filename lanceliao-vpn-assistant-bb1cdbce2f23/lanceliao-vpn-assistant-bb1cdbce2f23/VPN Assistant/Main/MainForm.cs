using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace Com.Shuyz.VPN_Assistant
{
    public partial class MainForm : Form
    {
        private static MainForm _instance = null;
        public static MainForm Instance
        {
            get { return _instance; }
        }

        private readonly String listCacheFile = "ServerList.tmp";
        private readonly String proxylistFile = "proxy.list";
        private String currentProxy = "";

        #region - Init -

        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            _instance = this;
        }

        /// <summary>
        /// try to load cache file on application start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (File.Exists(this.listCacheFile))
            {
                try
                {
                    ListManager.Instance.ParseList(ref this.dataGridView1, this.listCacheFile);
                }
                catch (System.Exception)
                {
                    this.dataGridView1.Rows.Clear();
                }  
            }

            if (File.Exists(this.proxylistFile))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(this.proxylistFile))
                    {
                        while (!reader.EndOfStream)
                        {
                            String line = reader.ReadLine();

                            if (Regex.IsMatch(line, @"^http[s]{0,1}:\/\/.*\..*", RegexOptions.IgnoreCase))
                            {
                                this.comboBox1.Items.Add(line);
                            }
                        }
                        reader.Close();
                    }
                }
                catch (System.Exception)
                {

                }
            }

            this.comboBox1.SelectedIndex = 0;
        }
        #endregion 

        #region - Refresh List -

        /// <summary>
        /// refresh server list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.currentProxy = this.comboBox1.SelectedItem.ToString();

            Thread getServerThread = new Thread(new ThreadStart(this.ThreadGetServers));
            getServerThread.IsBackground = true;
            getServerThread.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ThreadGetServers()
        {
            try
            {
                StreamReader webContent = SiteFetcher.Instance.GetData(this.currentProxy);
                //StreamReader webContent = new StreamReader("test_data.htm");

                List<ServerInfo> serverList = new List<ServerInfo>();
                ContentParser.Instance.ParseAll(ref serverList, ref webContent);

                this.Invoke(new MethodInvoker(delegate()
                {
                    this.dataGridView1.Rows.Clear();
                    foreach (ServerInfo info in serverList)
                    {
                        this.dataGridView1.Rows.Add(false, this.dataGridView1.Rows.Count + 1, info.location, info.ipAddress, info.sessions, info.uptime, info.ping, info.lineQuality, info.transfers, info.sslVPN, info.l2tp, info.openVPN, info.msSSTP, info.operatorInfo, info.score);
                    }
                    this.button1.Enabled = true;
                }));
            }
            catch (System.Exception ex)
            {
                 this.Invoke(new MethodInvoker(delegate()
                {
                    this.button1.Enabled = true;

                    MessageBox.Show("Refresh failed, " + ex.Message.ToString());
                }));
            }
        }
         
        #endregion

        #region - Overrides -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (Int32)UserMsg.Messages.WM_PING_RESULT:
                    ListManager.Instance.SetPingValue(ref this.dataGridView1, Marshal.PtrToStringAnsi(m.LParam), (Int32)m.WParam);
                    break;

                case (Int32)UserMsg.Messages.WM__LOCATE_RESULT:
                    ListManager.Instance.SetLocateValue(ref this.dataGridView1, Marshal.PtrToStringAnsi(m.LParam), Marshal.PtrToStringAnsi(m.WParam));
                    break;

                default: break;
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// try to save list content to cache file to be read on next launch
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
           try
           {
               ListManager.Instance.SerializeList(ref this.dataGridView1, this.listCacheFile);
           }
           catch (System.Exception)
           {
               if (File.Exists(this.listCacheFile))
               {
                   File.Delete(this.listCacheFile);
                }
           }
        }
        #endregion

        #region - Context Menu -

        /// <summary>
        /// Add to ping task list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = this.dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (null != row.Cells[3].Value)
                {
                    IpHelper.Instance.AddPingItem(row.Cells[3].Value.ToString());
                }
            }
        }

        /// <summary>
        /// Add to locate task list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void locateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = this.dataGridView1.SelectedRows;

            foreach (DataGridViewRow row in selectedRows)
            {
                if (null != row.Cells[3].Value)
                {
                    IpHelper.Instance.AddLocateItem(row.Cells[3].Value.ToString());
                }
            }
        }

        /// <summary>
        /// remove selected item from list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
            {
                this.dataGridView1.Rows.RemoveAt(row.Index);
            }
        }

        /// <summary>
        /// select all
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.SelectAll();
        }

        /// <summary>
        /// select none
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.ClearSelection();
        }
       
        /// <summary>
        /// Export SSL-VPN connection settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sSLVPNConnectionSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewSelectedRowCollection selectedItem = this.dataGridView1.SelectedRows;
                if (selectedItem.Count > 1)
                {
                    throw (new System.Exception("Please select only one row!"));
                }

                String hostname = selectedItem[0].Cells[3].Value.ToString();
                String port = selectedItem[0].Cells[9].Value.ToString();

                Match match = Regex.Match(port, @"\d+");
                if(!match.Success)
                {
                    throw (new System.Exception("This host does not support SSL-VPN over TCP!"));
                }
                else
                {
                    port = match.Value.ToString();
                }

                bool result = ExportHelper.Instance.ExportSSL_VPNSetting(hostname, port, "VPNGATE", "vpn");

                if (result)
                {
                    MessageBox.Show("SSL-VPN connection setting export OK, please confirm the settings after importing into Packetix VPN Manager.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Export failed! " + ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// open help page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", "http://www.shuyz.com");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

    }
}

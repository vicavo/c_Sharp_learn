using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Threading;
using System.Text.RegularExpressions;

namespace LTC_Notify
{
    public partial class Form1 : Form, ThreadListener, FloatBarListener
    {
        private QueryResult queryResult = new QueryResult();
        private QueryThread queryThread = new QueryThread();

        private NotifyWnd notifyWnd = new NotifyWnd();
        private FloatWnd floatWnd = new FloatWnd();

        private float[] latestLastResult = new float[2] { 0f, 0f }; // 根据最后成交价格生成价格上升下降箭头: [0] 上上一次的变动值 [1]上一次的变动值

        public Form1()
        {
            InitializeComponent();

            this.floatWnd.RegisterMouseListener(this);

            this.queryThread.RegisterReceiveListener(this);
            this.queryThread.StartQuery();
        }

        #region - Load -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.loadConfig();

         //   this.Height = 350;
            this.notifyWnd.Show(this);
            this.notifyWnd.Hide();

            this.floatWnd.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        private void loadConfig()
        {
            if (Config.Instance.queryConfig.isBTC)
            {
                this.radioButton1.Checked = true;
                this.Text = "BTC Monitor";
            }
            else
            {
                this.radioButton2.Checked = true;
                this.Text = "LTC Monitor";
            }

            this.CFG_Interval.Text = Config.Instance.queryConfig.Interval.ToString();

            this.CFG_NotifyBuyPrice.Text = Config.Instance.queryConfig.NotifyBuyPrice.ToString();

            this.CFG_NotifySellPrice.Text = Config.Instance.queryConfig.NotifySellPrice.ToString();

            this.CFG_PriceDeviation.Text = Config.Instance.queryConfig.PriceDeviation.ToString();
        }

        #endregion

        #region - Thread Listener -

        /// <summary>
        /// Update last query time
        /// </summary>
        /// <param name="status"></param>
        public void OnStartQuery(DateTime lastQueryTime)
        {
            if (!this.Status_LastTime.InvokeRequired)
            {
                this.Status_LastTime.Text = lastQueryTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                this.Status_LastTime.Invoke(new MethodInvoker(delegate()
                {
                    this.Status_LastTime.Text = lastQueryTime.ToString("yyyy-MM-dd HH:mm:ss");
                }));
            }
        }

        /// <summary>
        /// Update query result
        /// </summary>
        /// <param name="result"></param>
        public void OnDataReceived(QueryResult result)
        {
            if (this.latestLastResult[1] == result.lastPrice)
            {
                // do nothing
            }
            else
            {
                this.latestLastResult[0] = this.latestLastResult[1];
                this.latestLastResult[1] = result.lastPrice;
            }

            string udSign = result.lastPrice > this.latestLastResult[0] ? "↑" : (result.lastPrice < this.latestLastResult[0] ? "↓" : "↔"); // not expect to be equal any more since v1.4

            this.queryResult = result;

            // 目标价提醒
            string notifyMsg = "";
            bool notifyRequired = false;

            if ( (Config.Instance.queryConfig.NotifyBuyPrice+Config.Instance.queryConfig.PriceDeviation) >= result.buyPrice)
            {
                notifyRequired = true;
                notifyMsg += "购买目标价提醒!\r\n"
                                    + "目标购买价: " + Config.Instance.queryConfig.NotifyBuyPrice.ToString() + "\r\n"
                                    + "当前买入价格:" + result.buyPrice.ToString() + "\r\n"
                                    + "目标价 - 当前价 = " + (Config.Instance.queryConfig.NotifyBuyPrice - result.buyPrice).ToString("F2") + "\r\n";
            }

            if ( (result.sellPrice + Config.Instance.queryConfig.PriceDeviation) >= Config.Instance.queryConfig.NotifySellPrice)
            {
                notifyRequired = true;
                notifyMsg += "出售目标价提醒!\r\n"
                                   + "目标卖出价: " + Config.Instance.queryConfig.NotifySellPrice.ToString() + "\r\n"
                                   + "当前卖出价格:" + result.sellPrice.ToString() + "\r\n"
                                   + "当前价 - 目标价 = " + (result.sellPrice - Config.Instance.queryConfig.NotifySellPrice).ToString("F2") + "\r\n";
            }

            // 最后成家价判断(因为okcoin.com的当前卖出价和买入价经常出错，怀疑是故意干扰，所以我们使用最后交易价来做参考)
            if ((Config.Instance.queryConfig.NotifyBuyPrice + Config.Instance.queryConfig.PriceDeviation) >= result.lastPrice)
            {
                notifyRequired = true;
                notifyMsg += "最后成交价接近目标买入价!\r\n"
                                + "设定目标价: " + Config.Instance.queryConfig.NotifyBuyPrice.ToString() + "\r\n"
                                + "最后成交价:" + result.lastPrice.ToString() + "\r\n"
                                + "目标价 - 最后成交价 = " + (Config.Instance.queryConfig.NotifyBuyPrice - result.lastPrice).ToString("F2") + "\r\n";
            }

            if ((result.lastPrice + Config.Instance.queryConfig.PriceDeviation) >= Config.Instance.queryConfig.NotifySellPrice)
            {
                notifyRequired = true;
                notifyMsg += "最后成交价接近目标卖出价!\r\n"
                                   + "目标卖出价: " + Config.Instance.queryConfig.NotifySellPrice.ToString() + "\r\n"
                                   + "最后成交价:" + result.lastPrice.ToString() + "\r\n"
                                   + "最后成交价 - 目标价 = " + (result.lastPrice - Config.Instance.queryConfig.NotifySellPrice).ToString("F2") + "\r\n";
            }
            
            // 更新显示及提示
            if (!this.InvokeRequired)
            {
                this.Result_UpdateTime.Text = this.queryResult.refreshDate.ToString("yyyy-MM-dd HH:mm:ss");
                this.Result_High.Text = this.queryResult.highPrice.ToString();
                this.Result_Low.Text = this.queryResult.lowPrice.ToString();
                this.Result_Last.Text = this.queryResult.lastPrice.ToString();
                this.Result_Vol.Text = this.queryResult.vol.ToString();
                this.Result_Buy.Text = this.queryResult.buyPrice.ToString();
                this.Result_Sell.Text = this.queryResult.sellPrice.ToString();

                if (notifyRequired)
                {
                    this.notifyWnd.NotifyMsg = notifyMsg;
                    this.notifyWnd.SetVisible(true);
                    this.Show();
                }

                this.floatWnd.UpdateData( "B: " + result.buyPrice.ToString("F2"), "S:" +
                result.sellPrice.ToString("F2"), "L: " + result.lastPrice.ToString("F2") + udSign, result.refreshDate.ToString("HH:mm:ss"));
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Result_UpdateTime.Text = this.queryResult.refreshDate.ToString("yyyy-MM-dd HH:mm:ss");
                    this.Result_High.Text = this.queryResult.highPrice.ToString();
                    this.Result_Low.Text = this.queryResult.lowPrice.ToString();
                    this.Result_Last.Text = this.queryResult.lastPrice.ToString();
                    this.Result_Vol.Text = this.queryResult.vol.ToString();
                    this.Result_Buy.Text = this.queryResult.buyPrice.ToString();
                    this.Result_Sell.Text = this.queryResult.sellPrice.ToString();

                    if (notifyRequired)
                    {
                        this.notifyWnd.NotifyMsg = notifyMsg;
                        this.notifyWnd.SetVisible(true);
                        this.Show();
                    }

                    this.floatWnd.UpdateData("B: " + result.buyPrice.ToString("F2"), "S:" +
                    result.sellPrice.ToString("F2"), "L: " + result.lastPrice.ToString("F2") + udSign, result.refreshDate.ToString("HH:mm:ss"));
                }));
            }
        }

        /// <summary>
        /// update time left on heartbeat
        /// </summary>
        /// <param name="timeLeft"></param>
        public void OnHeartBeat(UInt32 timeLeft)
        {
            if (!this.Status_NextTime.InvokeRequired)
            {
                this.Status_NextTime.Text = timeLeft.ToString();
            }
            else
            {
                this.Status_NextTime.Invoke(new MethodInvoker(delegate()
                {
                    this.Status_NextTime.Text = timeLeft.ToString();
                }));
            }
        }

      /// <summary>
      /// update error message on errors
      /// </summary>
      /// <param name="lastErrTime"></param>
      /// <param name="errMsg"></param>
        public void OnErrors(DateTime lastErrTime, string errMsg)
        {
            if (!this.Status_LastErr.InvokeRequired)
            {
                this.Status_LastErr.Text = lastErrTime.ToString() + ": " + errMsg;
            }
            else
            {
                this.Status_LastErr.Invoke(new MethodInvoker(delegate()
                {
                    this.Status_LastErr.Text = lastErrTime.ToString() + ": " + errMsg;
                }));
            }
        }

        #endregion

        #region - FloatBar Listener -

        public void OnRightMouseClick(Point point)
        {
            this.contextMenuStrip1.Show(point);
        }

        public void OnLeftMouseDoubleClick()
        {
            this.Show();
        }

        #endregion

        #region - Log -

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            QueryResult result = this.queryResult;

            Logger.Instance.writeLog(result.refreshDate.ToString("yyyy-MM-dd HH:mm:ss") + "\t"
                + result.buyPrice.ToString() + "\t"
                + result.sellPrice.ToString() + "\t"
                + result.highPrice.ToString() + "\t"
                + result.lowPrice.ToString() + "\t"
                + result.lastPrice.ToString() + "\t"
                + result.vol.ToString());
        }
        #endregion

        #region - NotifyIcon -

        /// <summary>
        /// Minimize form to notify icon
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        /// <summary>
        /// open form on notify icon click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// application exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Log this record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.button2_Click(null, null);
        }

        /// <summary>
        /// Stay on top
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.onTopToolStripMenuItem.Checked)
            {
                this.TopMost = true;
                this.onTopToolStripMenuItem.Checked = true;
            }
            else
            {
                this.TopMost = false;
                this.onTopToolStripMenuItem.Checked = false;
            }
        }

        /// <summary>
        /// Settings Hide/Show
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.setOnToolStripMenuItem.Checked)
            {
                this.Height = 545;
                this.setOnToolStripMenuItem.Checked = true;
            }
            else
            {
                this.Height = 350;
                this.setOnToolStripMenuItem.Checked = false;
            }
        }

        /// <summary>
        /// float window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void floatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.floatToolStripMenuItem.Checked)
            {
                this.floatToolStripMenuItem.Checked = true;
                this.floatWnd.SetVisible(true);
            }
            else
            {
                this.floatToolStripMenuItem.Checked = false;
                this.floatWnd.SetVisible(false);
            }
        }

        /// <summary>
        /// about
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("是否打开浏览器查看软件的在线说明？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                try
                {
                    System.Diagnostics.Process.Start("http://www.shuyz.com/btc-ltc-monitor.html");
                }
                catch (System.Exception)
                {
                	
                }  
            }
        }
        #endregion

        #region - Save CFG -

        /// <summary>
        /// check if user input is OK
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool isNumStr(ref string str)
        {
            Match match = Regex.Match(str, @"[0-9]+[\.]{0,1}[0-9]{0,2}");

            if (match.Success)
            {
                str = match.Value;
                return true;
            }
            else
            {
                return false;
            }
        }    

        /// <summary>
        /// save config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string interval = this.CFG_Interval.Text;
                string notifyBuyPrice = this.CFG_NotifyBuyPrice.Text;
                string notifySellPrice = this.CFG_NotifySellPrice.Text;
                string notifyDeviation = this.CFG_PriceDeviation.Text;

                if ((!this.isNumStr(ref interval)) ||
                    (!this.isNumStr(ref notifyBuyPrice)) ||
                    (!this.isNumStr(ref notifySellPrice)) ||
                    (!this.isNumStr(ref notifyDeviation)))
                {
                    MessageBox.Show("参数含有非法字符，请检查!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
     
                Config.Instance.queryConfig.isBTC = this.radioButton1.Checked ? true : false;
                this.Text = this.radioButton1.Checked ? "BTC Monitor" : "LTC Monitor";
                interval = interval.Trim(new char[] { '.' });
                Config.Instance.queryConfig.Interval = Int32.Parse(interval);
                Config.Instance.queryConfig.NotifyBuyPrice = float.Parse(notifyBuyPrice);
                Config.Instance.queryConfig.NotifySellPrice = float.Parse(notifySellPrice);
                Config.Instance.queryConfig.PriceDeviation = float.Parse(notifyDeviation);

                if (Config.Instance.WriteConfig())
                {
                    this.loadConfig();
                    MessageBox.Show("保存成功，参数已立即更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("保存失败!\r\n" + ex.Message.ToString(), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                this.notifyIcon1.BalloonTipTitle = "LTC Monitor";
                this.notifyIcon1.BalloonTipText = "LTC Monitor is still running......" + "\r\n" + "Double click to resume.";
                this.notifyIcon1.ShowBalloonTip(2000);
            }
        }

    }
}

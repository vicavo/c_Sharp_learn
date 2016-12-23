using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace LTC_Notify
{
    public partial class FloatWnd : Form
    {
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        protected static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        private List<FloatBarListener> listeners = new List<FloatBarListener>();

        public FloatWnd()
        {
            InitializeComponent();

            this.UpdateTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vb"></param>
        public void SetVisible(bool vb)
        {
            if (!this.InvokeRequired)
            {
                this.Visible = vb;
            }
            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Visible = vb;
                }));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buyPrice"></param>
        /// <param name="sellPrice"></param>
        public void UpdateData(string buyPrice, string sellPrice, string lastPrice, string updateTIme)
        {
            if (!this.InvokeRequired)
            {
                this.Price_Buy.Text = buyPrice;
                this.Price_Sell.Text = sellPrice;
                this.Price_Last.Text = lastPrice;
                this.UpdateTime.Text = updateTIme;
            }

            else
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.Price_Buy.Text = buyPrice;
                    this.Price_Sell.Text = sellPrice;
                    this.Price_Last.Text = lastPrice;
                    this.UpdateTime.Text = updateTIme;
                }));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloatWnd_Load(object sender, EventArgs e)
        {
            this.Top = 30;
            this.Left = Screen.PrimaryScreen.Bounds.Width - 200;

            this.Opacity = 0.90f;
            this.ShowInTaskbar = false;
            this.TopMost = true;
        }

        /// <summary>
        /// move window on mouse down
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0201)//鼠标左键按下
            {
                m.Msg = 0x00a1;//改消息为非客户区按下鼠标
                m.LParam = IntPtr.Zero;//默认值
                m.WParam = new IntPtr(2);//鼠标放在标题栏内
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// right click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloatWnd_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point point = new Point();
                point.X = this.Left;
                point.Y = this.Bottom;

                foreach (FloatBarListener listener in this.listeners)
                {
                    listener.OnRightMouseClick(point);
                }
            }
        }

        /// <summary>
        /// double click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FloatWnd_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (FloatBarListener listener in this.listeners)
            {
                listener.OnLeftMouseDoubleClick();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener"></param>
        public void RegisterMouseListener(FloatBarListener listener)
        {
            if (!this.listeners.Contains(listener))
            {
                this.listeners.Add(listener);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listener"></param>
        public void DeRegisterMouseListener(FloatBarListener listener)
        {
            if (this.listeners.Contains(listener))
            {
                this.listeners.Remove(listener);
            }
        }    



    }
}

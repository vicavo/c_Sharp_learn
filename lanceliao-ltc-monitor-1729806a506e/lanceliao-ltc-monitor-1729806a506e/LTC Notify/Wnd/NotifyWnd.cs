using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LTC_Notify
{
    public partial class NotifyWnd : Form
    {
        public NotifyWnd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public string NotifyMsg
        {
            set
            {
                if (!this.richTextBox1.InvokeRequired)
                {
                    this.richTextBox1.Text = value;
                }
                else
                {
                    this.richTextBox1.Invoke(new MethodInvoker(delegate(){
                         this.richTextBox1.Text = value;
                    }));
                }
             }
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyWnd_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Opacity = 0.95f;
            this.TopMost = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// move window
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

    }
}

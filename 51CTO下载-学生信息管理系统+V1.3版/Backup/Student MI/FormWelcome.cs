using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Student_MI
{
    public partial class FormWelcome : Form
    {
        private Graphics gp;
        public FormWelcome()
        {

            InitializeComponent();
            gp = Graphics.FromHwnd(this.pictureBox1.Handle);
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            if (ShowWelcome())
            {
                this.Visible = false;
                FormLogin login = new FormLogin();
               // login.Parent = this;
                if (login.ShowDialog() == DialogResult.OK)
                {

                }
                else
                {

                }
            }
        }

        private bool ShowWelcome()
        {
            for (int i = 0; i < 5; i++)
            {
                this.Refresh();
                Thread.Sleep(1000);                
            }
            return true;
        }

        private void FormWelcome_Paint(object sender, PaintEventArgs e)
        {
            gp.DrawImage(Image.FromFile(@"Resources/WELCOME.jpg"), new Point(0, 0));
        }
    }
}

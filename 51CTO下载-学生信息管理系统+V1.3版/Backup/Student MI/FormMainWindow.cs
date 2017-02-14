using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_MI
{
    public partial class FormMainWindow : Form
    {
        private System.Threading.Timer timer;

        public FormMainWindow()
        {
            InitializeComponent();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void OnTimer(object state)
        {
            this.lbTime.Text = DateTime.Now.ToString();
        }

        private void FormMainWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            timer = new System.Threading.Timer(new System.Threading.TimerCallback(OnTimer), null, 0, 1000);

            this.lbInfo.Text = "登录人:" + UserHelper.user;

            this.lbTime.Text = DateTime.Now.ToString();

            if (UserHelper.userType != UserType.Admin)
            {
                this.lbAccount.Enabled = false;
                this.lbAccount2.Enabled = false;
            }
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbMinSize_Click(object sender, EventArgs e)
        {
            //最小化
            this.WindowState = FormWindowState.Minimized;
        }

        private void lbStudent_Click(object sender, EventArgs e)
        {
            FormStudents fs = new FormStudents();
            fs.ShowDialog();
        }

        private void lbCourse_Click(object sender, EventArgs e)
        {
            FormCourse fc = new FormCourse();
            fc.ShowDialog();
        }

        private void lbScore_Click(object sender, EventArgs e)
        {
            FormSource fs = new FormSource();
            fs.ShowDialog();
        }

        private void lbAccount_Click(object sender, EventArgs e)
        {
            FormAccount fa = new FormAccount();
            fa.ShowDialog();
        }

        private void lbMenu_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            fm.ShowDialog();
        }

        private void lbAbout_Click(object sender, EventArgs e)
        {
            FormAbout fa = new FormAbout();
            fa.ShowDialog();
        }

        private void lbExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbExit.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbMinSize_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbMinSize.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbStudent_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbStudent.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbCourse_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbCourse.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbScore_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbScore.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbAccount_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbAccount.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbMenu_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbMenu.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbAbout_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbAbout.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbStudent2_Click(object sender, EventArgs e)
        {
            FormStudents fs = new FormStudents();
            fs.ShowDialog();
        }

        private void lbCourse2_Click(object sender, EventArgs e)
        {
            FormCourse fc = new FormCourse();
            fc.ShowDialog();
        }

        private void lbScore2_Click(object sender, EventArgs e)
        {
            FormSource fs = new FormSource();
            fs.ShowDialog();
        }

        private void lbAccount2_Click(object sender, EventArgs e)
        {
            FormAccount fa = new FormAccount();
            fa.ShowDialog();
        }

        private void lbStudent2_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbStudent2.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbCourse2_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbCourse2.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbScore2_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbScore2.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lbAccount2_MouseMove(object sender, MouseEventArgs e)
        {
            this.lbAccount2.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private Point mouseOffset;
        private bool isMouseDown = false;
        private void FormMainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            int xOffset;
            int yOffset;
            if (e.Button == MouseButtons.Left)
            {
                xOffset = -e.X - SystemInformation.FrameBorderSize.Width;
                yOffset = -e.Y - SystemInformation.CaptionHeight -
                SystemInformation.FrameBorderSize.Height;
                mouseOffset = new Point(xOffset, yOffset);
                isMouseDown = true;
            }
        }

        private void FormMainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(mouseOffset.X, mouseOffset.Y);
                Location = mousePos;
            }
        }

        private void FormMainWindow_MouseUp(object sender, MouseEventArgs e)
        {
            // 修改鼠标状态isMouseDown的值
            // 确保只有鼠标左键按下并移动时，才移动窗体
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }
    }
}

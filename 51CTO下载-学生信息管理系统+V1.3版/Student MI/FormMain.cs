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
    public partial class FormMain : Form
    {
        private System.Threading.Timer timer;

        public FormMain()
        {
            InitializeComponent();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void OnTimer(object state)
        {
            this.lbTime.Text = DateTime.Now.ToString();
        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            timer = new System.Threading.Timer(new System.Threading.TimerCallback(OnTimer), null, 0, 1000);

            this.lbInfo.Text = "登录人:" + UserHelper.user;

            this.lbTime.Text = DateTime.Now.ToString();

            FormMenu fm = new FormMenu();
            fm.MdiParent = this;
            fm.Show();
        }

        private void tsbStudentInfoManage_Click(object sender, EventArgs e)
        {
            FormStudents fs = new FormStudents();
            fs.ShowDialog();
        }

        private void tsbCourseInfoManage_Click(object sender, EventArgs e)
        {
            FormCourse fc = new FormCourse();
            fc.ShowDialog();
        }

        private void tsbScoreInfoManage_Click(object sender, EventArgs e)
        {
            FormSource fs = new FormSource();
            fs.ShowDialog();
        }

        private void tsbAccountInfoManage_Click(object sender, EventArgs e)
        {
            FormAccount fa = new FormAccount();
            fa.ShowDialog();
        }

        private void tsmiStudentInfoManage_Click(object sender, EventArgs e)
        {
            FormStudents fs = new FormStudents();
            fs.ShowDialog();
        }

        private void tsmiCourseInfoManage_Click(object sender, EventArgs e)
        {
            FormCourse fc = new FormCourse();
            fc.ShowDialog();
        }

        private void tsmiScoreInfoManage_Click(object sender, EventArgs e)
        {
            FormSource fs = new FormSource();
            fs.ShowDialog();
        }

        private void tsmiAccountInfoManage_Click(object sender, EventArgs e)
        {
            FormAccount fa = new FormAccount();
            fa.ShowDialog();
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            FormAbout fa = new FormAbout();
            fa.ShowDialog();
        }
    }
}

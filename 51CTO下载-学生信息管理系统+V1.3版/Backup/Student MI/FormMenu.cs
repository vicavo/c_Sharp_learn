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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void btnStudentInfo_Click(object sender, EventArgs e)
        {
            FormStudents fs = new FormStudents();
            //fs.MdiParent = fm;
            fs.ShowDialog();
        }

        private void btnCourseInfo_Click(object sender, EventArgs e)
        {
            FormCourse fc = new FormCourse();
            //fc.MdiParent = fm;
            fc.ShowDialog();
        }

        private void btnStudentInfoManage_Click(object sender, EventArgs e)
        {
            FormSource fs = new FormSource();
            //fs.MdiParent = fm;
            fs.ShowDialog();
        }

        private void btnCourseInfoManage_Click(object sender, EventArgs e)
        {
            FormAccount fa = new FormAccount();
            //fa.MdiParent = fm;
            fa.ShowDialog();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            FormModify fm = new FormModify();
            //fm.MdiParent = fm;
            fm.ShowDialog();
        }

        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            //this.MdiParent.Visible = false;
            this.TopLevel = false;
            FormMainWindow fm = new FormMainWindow();
            this.Parent = fm;
            Parent.Visible = false;
            this.Visible = false;

            FormLogin login = new FormLogin();
            login.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            if (UserHelper.userType != UserType.Admin)
            {
                this.btnCourseInfoManage.Enabled = false;
            }
        }
    }
}

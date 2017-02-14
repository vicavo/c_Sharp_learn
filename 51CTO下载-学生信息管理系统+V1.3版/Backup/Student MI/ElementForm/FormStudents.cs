using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Student_MI.SearchForm;

namespace Student_MI
{
    public partial class FormStudents : Form
    {
        public FormStudents()
        {
            InitializeComponent();
        }

        private void FormStudents_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void FormStudents_Load(object sender, EventArgs e)
        {
            //UserHelper.userType = UserType.Student;
            if (UserHelper.userType != UserType.Admin)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].GetType().Equals(typeof(Button)))
                    {
                        this.Controls[i].Enabled = false;
                    }
                }
            }
            this.button5.Enabled = true;

            // TODO: 这行代码将数据加载到表“studentManagerDataSet.Student”中。您可以根据需要移动或移除它。
            this.studentTableAdapter1.Fill(this.studentManagerDataSet.Student);
            // TODO: 这行代码将数据加载到表“studentManagerDataSet1.Student”中。您可以根据需要移动或移除它。
            this.studentTableAdapter.Fill(this.studentManagerDataSet1.Student);

            this.lbInfo.Text = "登录人:" + UserHelper.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddStudent fas = new FormAddStudent();
            if (fas.ShowDialog() == DialogResult.OK)
            {
                //刷新
                string sqltr = "select * From Student";
                SqlCommand cmd = DBHelper.con.CreateCommand();
                cmd.CommandText = sqltr;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.studentBindingSource.DataSource = ds.Tables[0];

                int c = this.studentBindingSource.Count;
                this.dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.studentTableAdapter.Update(this.studentManagerDataSet1.Student);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow drw = dataGridView1.SelectedRows[0];
                    DataGridViewCell cell = drw.Cells["sNumberDataGridViewTextBoxColumn"];
                    string sql = "DELETE [Student] Where [SNumber]=" + cell.Value.ToString();
                    new SqlHelper().ExecuteNonQuery(sql, CommandType.Text);
                    dataGridView1.Rows.Remove(drw);
                }
                MessageBox.Show("删除数据成功！");
            }
            catch
            {

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormStudentSearch fas = new FormStudentSearch();
            fas.ShowDialog();
        }

        private void 关于AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout fa = new FormAbout();
            fa.ShowDialog();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

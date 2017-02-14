using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Student_MI.SearchForm;
using System.Data.SqlClient;

namespace Student_MI
{
    public partial class FormCourse : Form
    {
        public FormCourse()
        {
            InitializeComponent();
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {
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
            this.button3.Enabled = true;

            // TODO: 这行代码将数据加载到表“studentManagerDataSet2.Course”中。您可以根据需要移动或移除它。
            this.courseTableAdapter.Fill(this.studentManagerDataSet2.Course);

            this.lbInfo.Text = "登录人:" + UserHelper.user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.courseTableAdapter.Update(this.studentManagerDataSet2.Course);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddCourse fas = new FormAddCourse();
            if (fas.ShowDialog() == DialogResult.OK)
            {
                //刷新
                string sqltr = "select * From Course";
                SqlCommand cmd = DBHelper.con.CreateCommand();
                cmd.CommandText = sqltr;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                this.courseBindingSource.DataSource = ds.Tables[0];

                int c = this.courseBindingSource.Count;
                this.dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow drw = dataGridView1.SelectedRows[0];
                    DataGridViewCell cell = drw.Cells["cNumberDataGridViewTextBoxColumn"];
                    string sql = "DELETE [Course] Where [CNumber]=" + cell.Value.ToString();
                    new SqlHelper().ExecuteNonQuery(sql, CommandType.Text);
                    dataGridView1.Rows.Remove(drw);
                }
                MessageBox.Show("删除数据成功！");
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCourseSearch fas = new FormCourseSearch();
            fas.ShowDialog();
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
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

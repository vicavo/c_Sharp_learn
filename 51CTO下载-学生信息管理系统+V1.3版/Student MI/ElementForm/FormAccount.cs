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
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void FormAccount_Load(object sender, EventArgs e)
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

            // TODO: 这行代码将数据加载到表“studentManagerDataSet4.Admin”中。您可以根据需要移动或移除它。
            //this.adminTableAdapter.Fill(this.studentManagerDataSet4.Admin);

            string sqltr = "select * From Admin";
            SqlCommand cmd = DBHelper.con.CreateCommand();
            cmd.CommandText = sqltr;
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            this.dataGridView1.DataSource = ds.Tables[0];

            this.lbInfo.Text = "登录人:" + UserHelper.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddAccount fas = new FormAddAccount();
            if (fas.ShowDialog() == DialogResult.OK)
            {
                //刷新
                string sqltr = "select * From Admin";
                SqlCommand cmd = DBHelper.con.CreateCommand();
                cmd.CommandText = sqltr;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                //this.adminBindingSource.DataSource = ds.Tables[0];

                this.dataGridView1.DataSource = ds.Tables[0];
                int c = this.adminBindingSource.Count;
                this.dataGridView1.Refresh();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.adminTableAdapter.Update(this.studentManagerDataSet4.Admin);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow drw = dataGridView1.SelectedRows[0];
                    DataGridViewCell cell = drw.Cells["idDataGridViewTextBoxColumn"];
                    string sql = "DELETE [Admin] Where [id]=" + cell.Value.ToString();
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
            FormAccountSearch faa = new FormAccountSearch();
            faa.ShowDialog();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_MI
{
    public partial class FormSource : Form
    {
        public FormSource()
        {
            InitializeComponent();
        }

        private void FormSource_Load(object sender, EventArgs e)
        {
            if (UserHelper.userType == UserType.Student)
            {
                for (int i = 0; i < this.Controls.Count; i++)
                {
                    if (this.Controls[i].GetType().Equals(typeof(Button)))
                    {
                        this.Controls[i].Enabled = false;
                    }
                }
            }
            this.button4.Enabled = true;

            // TODO: 这行代码将数据加载到表“studentManagerDataSet3.Score”中。您可以根据需要移动或移除它。
            this.scoreTableAdapter.Fill(this.studentManagerDataSet3.Score);

            this.lbInfo.Text = "登录人:" + UserHelper.user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAddScore fas = new FormAddScore();
            if (fas.ShowDialog() == DialogResult.OK)
            {
                //刷新
                string sqltr = "select * From [Score]";
                SqlCommand cmd = DBHelper.con.CreateCommand();
                cmd.CommandText = sqltr;
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                this.dataGridView1.DataSource = ds.Tables[0];
                

                int c = this.scoreBindingSource.Count;
                this.dataGridView1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.scoreTableAdapter.Update(this.studentManagerDataSet3.Score);
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormScoreManage fsm = new FormScoreManage();
            fsm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {


                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow drw = dataGridView1.SelectedRows[0];
                    DataGridViewCell cell = drw.Cells["idDataGridViewTextBoxColumn"];
                    string sql = "DELETE [Score] Where [id]=" + cell.Value.ToString();
                    new SqlHelper().ExecuteNonQuery(sql, CommandType.Text);
                    dataGridView1.Rows.Remove(drw);
                }
                MessageBox.Show("删除数据成功！");
            }
            catch
            {

            }
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

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
    public partial class FormAddCourse : Form
    {
        public FormAddCourse()
        {
            InitializeComponent();
        }

        private void FormCourse_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.con.Open();
                string cou = string.Format("INSERT INTO Course (CName) VALUES ('{0}')", this.txtName.Text);
                SqlCommand cmd = new SqlCommand(cou, DBHelper.con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("恭喜,课程添加成功!");
                }
                else
                {
                    MessageBox.Show("不好意思,课程添加失败!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBHelper.con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

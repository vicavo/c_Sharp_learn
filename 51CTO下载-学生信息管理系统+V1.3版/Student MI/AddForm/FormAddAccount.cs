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
    public partial class FormAddAccount : Form
    {
        public FormAddAccount()
        {
            InitializeComponent();
        }

        private void FormAddAccount_Load(object sender, EventArgs e)
        {
            this.cmbType.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DBHelper.con.Open();
                string acc = string.Format("INSERT INTO Admin (username,password,type) VALUES ('{0}','{1}','{2}')", this.txtNumber.Text, this.txtPassword.Text,this.cmbType.Text);
                SqlCommand cmd = new SqlCommand(acc, DBHelper.con);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("恭喜,账户添加成功!");
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


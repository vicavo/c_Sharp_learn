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
    public partial class FormAddStudent : Form
    {
        public FormAddStudent()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (VaildataInput())
            {
                try
                {
                    DBHelper.con.Open();
                    string sql = string.Format("INSERT INTO Student (SName, SSex, SAge, SEmail) VALUES ('{0}','{1}',{2},'{3}')", this.txtName.Text, this.rdoM.Checked ? "男" : "女", this.txtAge.Text, this.txtEmail.Text);
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                    //cmd.ExecuteNonQuery() 适用于insert update dalete 来返回 影响了几行
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("恭喜,学员添加成功!");
                    }
                    else
                    {
                        MessageBox.Show("不好意思,学员添加失败!");
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

               /* try
                {
                    Convert.ToInt32(this.txtAge.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("年龄输入了非数字字符");
                    return;
                }
                MessageBox.Show("年龄正确");*/
            }
        }

        private bool VaildataInput()
        {
            if (this.txtName.Text == "" || this.txtAge.Text == "" || this.txtEmail.Text == "")
            {
                MessageBox.Show("输入内容不完整，请重新输入!");
                return false;
            }
            return true;
        }

        private void txtAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9')||e.KeyChar ==8)
            {

            }
            else
            {
                e.Handled = true;
            }
        }
    }
}

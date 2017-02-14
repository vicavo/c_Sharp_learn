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
    public partial class FormModify : Form
    {
        public FormModify()
        {
            InitializeComponent();
        }

        private void FormModify_Load(object sender, EventArgs e)
        {
            this.lbInfo.Text = "登录人:" + UserHelper.user;
            this.lbOPRight.Hide();
            this.lbNPRight.Hide();
            this.lbRPRight.Hide();
        }

        private bool VaildateInput()
        {
            if (this.txtOldPassword.Text == "" || this.txtNewPassword.Text == "" || this.txtRepeatPassword.Text == "")
            {
                MessageBox.Show("输入内容不完整,请重新输入!");
                return false;
            }
            return true;
        }

        private bool VaildatePassword()
        {
            if (this.txtNewPassword.Text != this.txtRepeatPassword.Text)
            {
                MessageBox.Show("两次输入的新密码不一致,请重新输入!");
                return false;
            }
            return true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((VaildateInput() && VaildatePassword()) && CheckOldPassword())
            {
                try
                {
                    DBHelper.con.Open();
                    string sql = string.Format("UPDATE  [Admin] SET [password] = '" + this.txtNewPassword.Text + "' Where [username]='" + UserHelper.user + "'");
                    SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("恭喜,密码修改成功!");
                    }
                    else
                    {
                        MessageBox.Show("不好意思,密码修改失败");
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
        }

        private bool CheckOldPassword()
        {
            try
            {
                DBHelper.con.Open();
                string sql = string.Format("SELECT [password] FROM [Admin] WHERE [username] = '" + UserHelper.user + "'");
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);

                if (this.txtOldPassword.Text != cmd.ExecuteScalar().ToString().Trim())
                {
                    MessageBox.Show("该用户的密码与您输入的原密码不一致,请重新输入!");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
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

        private void txtOldPassword_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DBHelper.con.Open();
                string sql = string.Format("SELECT [password] FROM [Admin] WHERE [username] = '" + UserHelper.user + "'");
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);
                if ((this.txtOldPassword.Text == cmd.ExecuteScalar().ToString().Trim()))
                {
                    this.lbOPRight.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            finally
            {
                DBHelper.con.Close();
            }
        }

        private void txtRepeatPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNewPassword.Text == this.txtRepeatPassword.Text)
            {
                this.lbNPRight.Visible = true;
                this.lbRPRight.Visible = true;
            }
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            if (this.txtNewPassword.Text == this.txtRepeatPassword.Text)
            {
                this.lbNPRight.Visible = true;
                this.lbRPRight.Visible = true;
            }
        }
    }
}

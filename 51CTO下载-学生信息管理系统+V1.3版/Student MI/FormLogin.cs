using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Student_MI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private bool VaildateUser()
        {
            try
            {
                //验证用户是否存在
                DBHelper.con.Open();//打开数据库

                //找到要操作的数据
                string sql = string.Format("SELECT count(*) FROM admin WHERE username='{0}' AND password='{1}'", this.txtUser.Text, this.txtPassword.Text);

                //数据写入
                SqlCommand cmd = new SqlCommand(sql, DBHelper.con);

                //执行写入
                int result = (int)cmd.ExecuteScalar();

                //
                if (result > 0)
                {
                    MessageBox.Show("恭喜,登陆成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("不好意思,用户名或密码错误!");
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            finally
            {
                //关闭数据库
                DBHelper.con.Close();
            }
            return false;
        }

        private bool VaildateInput()
        {
            //验证输入是否完整
            if (this.txtUser.Text == "")
            {
                MessageBox.Show("用户名不允许为空");
                this.txtUser.Focus();
                return false;
            }
            else if (this.txtPassword.Text == "")
            {
                MessageBox.Show("密码不允许为空");
                this.txtPassword.Focus();
                return false;
            }

            return true;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void lb_btnLogin_Click(object sender, EventArgs e)
        {
            //登录按钮
            if (VaildateInput() && VaildateUser())
            {
                while (this.pbTime.Value <= this.pbTime.Maximum - 5)
                {
                    this.pbTime.Value += 10;
                    Thread.Sleep(200);
                }

                //打开窗体，隐藏本身
                FormMainWindow fmw = new FormMainWindow();
                this.Visible = false;
                UserHelper.user = this.txtUser.Text;
                DBHelper.con.Open();
                string sqltr = "Select [type] From [Admin] Where [username]=@username";
                SqlCommand cmd = new SqlCommand(sqltr, DBHelper.con);
                SqlParameter sp = new SqlParameter("@username", SqlDbType.NChar, 10);
                sp.Value = this.txtUser.Text;
                cmd.Parameters.Add(sp);
                //SqlDataReader dr = cmd.ExecuteReader();
                //string type = "Admin";
                string type = cmd.ExecuteScalar().ToString().Trim();
                UserHelper.userType = (UserType)Enum.Parse(typeof(UserType), type);
                DBHelper.con.Close();
                Common.Login = true;
                fmw.ShowDialog();
            }
        }

        private void lb_brnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lb_btnLogin_MouseMove(object sender, MouseEventArgs e)
        {
            this.lb_btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void lb_brnExit_MouseMove(object sender, MouseEventArgs e)
        {
            this.lb_brnExit.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //登录按钮
            if (VaildateInput() && VaildateUser())
            {
                while (this.pbTime.Value <= this.pbTime.Maximum - 5)
                {
                    this.pbTime.Value += 10;
                    Thread.Sleep(200);
                }

                //打开窗体，隐藏本身
                FormMainWindow fmw = new FormMainWindow();
                this.Visible = false;
                UserHelper.user = this.txtUser.Text;
                DBHelper.con.Open();
                string sqltr = "Select [type] From [Admin] Where [username]=@username";
                SqlCommand cmd = new SqlCommand(sqltr, DBHelper.con);
                SqlParameter sp = new SqlParameter("@username", SqlDbType.NChar, 10);
                sp.Value = this.txtUser.Text;
                cmd.Parameters.Add(sp);
                //SqlDataReader dr = cmd.ExecuteReader();
                //string type = "Admin";
                string type = cmd.ExecuteScalar().ToString().Trim();
                UserHelper.userType = (UserType)Enum.Parse(typeof(UserType), type);
                DBHelper.con.Close();
                Common.Login = true;
                fmw.ShowDialog();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

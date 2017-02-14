using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using qpsmartweb.Public;
using System.IO;
namespace qpoa.MyAffairs
{
    public partial class Emailprv_Pass : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_Emailprv   where id='" + int.Parse(Request.QueryString["id"]) + "' and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    EmailName.Text = NewReader["EmailName"].ToString();

                    EmailAdd.Text = NewReader["EmailAdd"].ToString();
                  
                }
                NewReader.Close();

                BindAttribute();
            }

        }


        public void BindAttribute()
        {

            EmailName.Attributes.Add("readonly", "readonly");
            EmailAdd.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Emailprv.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string hashPassword = Password.Text;
            string hashPassword_new = NewPassword.Text;

            string SQL_GetList = "select * from qp_Emailprv where id='" + int.Parse(Request.QueryString["id"]) + "' and EmailPassword='" + hashPassword + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                string Sql_update = "Update qp_Emailprv Set EmailPassword='" + hashPassword_new + "' where id='" + int.Parse(Request.QueryString["id"]) + "' and EmailPassword='" + hashPassword + "'";
                List.ExeSql(Sql_update);
             
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Emailprv.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('旧密码输入错误！')</Script>");
                return;
            }

            NewReader.Close();

         
            InsertLog("修改邮件参数[" + EmailName.Text + "]", "邮件参数设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Emailprv.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

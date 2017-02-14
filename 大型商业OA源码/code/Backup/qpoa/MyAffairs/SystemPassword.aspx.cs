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
    public partial class SystemPassword : System.Web.UI.Page
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

                Username.Text = Session["username"].ToString();
                BindAttribute();
            }

        }


        public void BindAttribute()
        {

            Username.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("../main_d.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            string hashPassword_new = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword.Text, "MD5");

            string SQL_GetList = "select * from qp_username where Username='" + List.GetFormatStr(Username.Text) + "' and Password='" + hashPassword + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                string Sql_update = "Update qp_username Set Password='" + hashPassword_new + "' where Username='" + List.GetFormatStr(Username.Text) + "' and Password='" + hashPassword + "'";
                List.ExeSql(Sql_update);
              
              
            }
            else
            {
                Response.Write("<script>alert('旧密码输入错误！')</Script>");
                return;
            }

            NewReader.Close();

            InsertLog("修改密码[" + Username.Text + "]", "密码修改");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='../main_d.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

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
namespace qpoa.SystemManage
{
    public partial class username_updateps : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string requestid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            requestid = Request.QueryString["id"];
            if (!IsPostBack)
            {
                BindAttribute();
                string SQL_GetList = "select * from qp_username where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    username.Text = NewReader["username"].ToString();
                    Realname.Text = NewReader["username"].ToString();
                }
                NewReader.Close();
            }
        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
         }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("username.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            string Sql_update = "Update qp_username  Set Password='" + hashPassword + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改用户密码[" + Realname.Text + "]", "用户信息");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");

        }
        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

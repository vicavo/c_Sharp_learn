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

namespace qpoa.WorkFlow
{
    public partial class YinZhang_update : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_YinZhang  where  id='" + Request.QueryString["id"] + "'  ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                }
                BindAttribute();
            }

        }


        public void BindAttribute()
        {

            Name.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("YinZhang.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");
            string hashPassword_new = FormsAuthentication.HashPasswordForStoringInConfigFile(NewPassword.Text, "MD5");

            string SQL_GetList = "select * from qp_YinZhang where Username='" + Session["username"] + "' and Password='" + hashPassword + "'  and  id='" + Request.QueryString["id"] + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                string Sql_update = "Update qp_YinZhang Set Password='" + hashPassword_new + "' where id='" + Request.QueryString["id"] + "' and Password='" + hashPassword + "'";
                List.ExeSql(Sql_update);
            }
            else
            {
                Response.Write("<script>alert('旧密码输入错误！')</Script>");
                return;
            }

            NewReader.Close();



            InsertLog("修改密码[" + Name.Text + "]", "我的印章");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YinZhang.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

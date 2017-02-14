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
    public partial class Emailprv_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_Emailprv   where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    EmailName.Text = NewReader["EmailName"].ToString();

                    EmailAdd.Text = NewReader["EmailAdd"].ToString();
                    EmailUserName.Text = NewReader["EmailUserName"].ToString();
                    //EmailPassword.Text = NewReader["EmailPassword"].ToString();
                    Pop3.Text = NewReader["Pop3"].ToString();
                    Smtp.Text = NewReader["Smtp"].ToString();
                    ServerEmail.SelectedValue = NewReader["ServerEmail"].ToString();
                    //Realname.Text=NewReader["Realname"].ToString();
                    MainNet.Text = NewReader["MainNet"].ToString();
                }
                NewReader.Close();

                BindAttribute();
            }

        }


        public void BindAttribute()
        {


            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Emailprv.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_Emailprv  Set MainNet='" + MainNet.Text + "',ServerEmail='" + ServerEmail.SelectedValue + "',EmailName='" + EmailName.Text + "',EmailAdd='" + EmailAdd.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’") + "',EmailUserName='" + EmailUserName.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’") + "',Pop3='" + Pop3.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’") + "',Smtp='" + Smtp.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’") + "' where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
            List.ExeSql(Sql_update);
            //Response.Write(sql_insert);
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

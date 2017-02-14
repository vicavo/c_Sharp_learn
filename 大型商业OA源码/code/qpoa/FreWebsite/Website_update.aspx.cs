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
namespace qpoa.FreWebsite
{
    public partial class Website_update : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!IsPostBack)
            {
                BindAttribute();

                string SQL_GetList = "select * from qp_Website where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and username='" + this.Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    WebAdd.Text = NewReader["WebAdd"].ToString();
                    Intro.Text = NewReader["Intro"].ToString();
                    IfFree.SelectedValue = NewReader["IfFree"].ToString();



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
            Response.Redirect("Website.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_Website  Set Name='" + List.GetFormatStr(Name.Text) + "',WebAdd='" + List.GetFormatStr(WebAdd.Text) + "',Intro='" + List.GetFormatStr(Intro.Text) + "',IfFree='" + List.GetFormatStr(IfFree.SelectedValue) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + this.Session["username"] + "'";
            List.ExeSql(Sql_update);
            InsertLog("修改网址[" + Name.Text + "]", "常用网址");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Website.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
    public partial class DIYForm_add_add : System.Web.UI.Page
    {

        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                BindAttribute();
            }

            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + rad + "";
            }


        }
        public void BindAttribute()
        {
          
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_FormFile (KeyFile,Number,Name,Type) values ('" + Request.QueryString["Number"] + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + Type.SelectedValue + "')";
            //Response.Write(sql_insert);
            List.ExeSql(sql_insert);
           InsertLog("新增表单字段[" + Name.Text + "]", "表单字段定义");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
    public partial class MyReminded : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_MyReminded  where username='" + Session["username"].ToString() + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    iftx.SelectedValue = NewReader["iftx"].ToString();
                    txtime.SelectedValue = NewReader["txtime"].ToString();

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
            Response.Redirect("../Main.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_MyReminded Set iftx='" + iftx.SelectedValue + "',txtime='" + txtime.SelectedValue + "'  where username='" + Session["username"].ToString() + "'";
            List.ExeSql(Sql_update);


            InsertLog("修改提醒设置", "用户提醒设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.parent.location='../main.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

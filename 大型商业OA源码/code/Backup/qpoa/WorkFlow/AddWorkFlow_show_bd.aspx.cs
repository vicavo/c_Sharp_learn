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
    public partial class AddWorkFlow_show_bd : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_DIYForm where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Type.Text = NewReader["Type"].ToString();
                    FormName.Text = NewReader["FormName"].ToString();
                   // openrealname.Text = NewReader["openrealname"].ToString();
                    //FormContent.Text = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString()).Replace("宏控件-用户姓名", Session["realname"].ToString()).Replace("宏控件-用户部门", Session["Unit"].ToString()).Replace("宏控件-用户角色", Session["Respon"].ToString()).Replace("宏控件-用户职位", Session["Post"].ToString()).Replace("宏控件-当前时间(日期)", System.DateTime.Now.ToShortDateString());
                    FormContent.Text = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString().Replace("id=\"Text1\"", "id=\"Text1\"   readonly ").Replace("id=Text1", "id=Text1   readonly ").Replace("id=\"TextArea1\"", "id=\"TextArea1\"   readonly ").Replace("id=TextArea1", "id=TextArea1   readonly ").Replace("id=\"Checkbox1\"", "id=\"Checkbox1\"    disabled=true ").Replace("id=Checkbox1", "id=Checkbox1    disabled=true "));
                    //FormContent.Text = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString());
                }
                NewReader.Close();
            }
        }








        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }







    }
}

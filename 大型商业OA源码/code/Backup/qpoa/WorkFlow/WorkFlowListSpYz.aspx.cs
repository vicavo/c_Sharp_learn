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
    public partial class WorkFlowListSpYz : System.Web.UI.Page
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
                //string SQL_GetList = "select * from qp_DIYForm where id='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                //SqlDataReader NewReader = List.GetList(SQL_GetList);
                //if (NewReader.Read())
                //{
                   
                 
                //}
                //NewReader.Close();
              
            }

            string sql_down = "select Newname,Name+'('+YxType+')' as Name  from qp_YinZhang where Username='" + Session["Username"] + "' and  State='正常' ";
            if (!IsPostBack)
            {
                list.Bind_DropDownList(DropDownList1, sql_down, "Newname", "Name");
            }

            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");

            string SQL_Check = "select * from qp_YinZhang where Newname='" + DropDownList1.SelectedValue + "' and Password='" + hashPassword + "' ";
            SqlDataReader MyReader = List.GetList(SQL_Check);
            if (MyReader.Read())
            {

                InsertLog("使用印章[" + DropDownList1.SelectedItem.Text + "]", "待办工作");

                string sql_insert_log = "insert into qp_AddWorkFlowSeal (Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('" + Request.QueryString["Number"] + "','" + DropDownList1.SelectedItem.Text + "','" + DropDownList1.SelectedValue + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + Page.Request.UserHostAddress + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert_log);//审批记录


                string sql_insert_log1 = "insert into qp_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('" + DropDownList1.SelectedItem.Text + "','" + DropDownList1.SelectedValue + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + Request.QueryString["Number"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "')";
                List.ExeSql(sql_insert_log1);//印章使用记录


                this.Response.Write("<script language=javascript>window.opener.OpenSealToWeb('" + DropDownList1.SelectedValue + "');window.close();</script>");


            }
            else
            {
                this.Response.Write("<script language=javascript>alert('密码错误');</script>");
            }
            MyReader.Close();

          
        }


    }
}

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
    public partial class MyCalendar_add : System.Web.UI.Page
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
                BindAttribute();
                list.Bind_DropDownList_Hour(StarttimeHour);
                list.Bind_DropDownList_Hour(EndtimeHour);
                list.Bind_DropDownList_Mini(StarttimeMini);
                list.Bind_DropDownList_Mini(EndtimeMini);

                if (Request.QueryString["time"] != null)
                {
                    CalendarTime.Text = Request.QueryString["time"].ToString();
                }
                else
                {
                    CalendarTime.Text = null;
                }

            }



        }
        public void BindAttribute()
        {
            JkRealname.Attributes.Add("readonly", "readonly");
            CalendarTime.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["time"] != null)
            {

                Response.Redirect("MyCalendarList.aspx?time=" + Request.QueryString["time"].ToString() + "");

            }
            else
            {
                Response.Redirect("MyCalendarLb.aspx");
            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_MyCalendar  (JkUsername,JkRealname,CalendarTime,StarttimeHour,StarttimeMini,EndtimeHour,EndtimeMini,CalendarType,Content,Iftx,IfOk,Username,Realname,NowTimes) values ('" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + List.GetFormatStr(CalendarTime.Text) + "','" + List.GetFormatStr(StarttimeHour.SelectedValue) + "','" + List.GetFormatStr(StarttimeMini.SelectedValue) + "','" + List.GetFormatStr(EndtimeHour.SelectedValue) + "','" + List.GetFormatStr(EndtimeMini.SelectedValue) + "','" + List.GetFormatStr(CalendarType.SelectedValue) + "','" + List.GetFormatStr(Content.Text) + "','" + List.GetFormatStr(Iftx.SelectedValue) + "','否','" + Session["username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            if (Request.QueryString["time"] != null)
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyCalendarList.aspx?time=" + Request.QueryString["time"].ToString() + "'</script>");
            }
            else
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyCalendarLb.aspx'</script>");
            }

            InsertLog("新增日程安排", "日程安排");

        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

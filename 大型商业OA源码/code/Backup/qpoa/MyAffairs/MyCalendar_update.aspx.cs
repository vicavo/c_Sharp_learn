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
    public partial class MyCalendar_update : System.Web.UI.Page
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


                string SQL_GetList = "select * from qp_MyCalendar   where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CalendarTime.Text = System.DateTime.Parse(NewReader["CalendarTime"].ToString()).ToShortDateString();
                    StarttimeHour.SelectedValue = NewReader["StarttimeHour"].ToString();
                    StarttimeMini.SelectedValue = NewReader["StarttimeMini"].ToString();
                    EndtimeHour.SelectedValue = NewReader["EndtimeHour"].ToString();
                    EndtimeMini.SelectedValue = NewReader["EndtimeMini"].ToString();
                    CalendarType.SelectedValue = NewReader["CalendarType"].ToString();
                    Content.Text = NewReader["Content"].ToString();
                    Iftx.SelectedValue = NewReader["Iftx"].ToString();

                    JkUsername.Text = NewReader["JkUsername"].ToString();
                    JkRealname.Text = NewReader["JkRealname"].ToString();
                  
                }
                NewReader.Close();


            }





        }
        public void BindAttribute()
        {
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


            string Sql_update = "Update qp_MyCalendar  Set JkUsername='" + JkUsername.Text + "',JkRealname='" + JkRealname.Text + "',Iftx='" + Iftx.SelectedValue + "',CalendarTime='" + CalendarTime.Text + "',StarttimeHour='" + StarttimeHour.SelectedValue + "' ,StarttimeMini='" + StarttimeMini.SelectedValue + "' ,EndtimeHour='" + EndtimeHour.SelectedValue + "' ,EndtimeMini='" + EndtimeMini.SelectedValue + "' ,CalendarType='" + CalendarType.SelectedValue + "' ,Content='" + List.GetFormatStr(Content.Text) + "'   where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
            List.ExeSql(Sql_update);

            if (Request.QueryString["time"] != null)
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyCalendarList.aspx?time=" + Request.QueryString["time"].ToString() + "'</script>");
            }
            else
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyCalendarLb.aspx'</script>");
            }


            InsertLog("修改日程安排", "日程安排");


          


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

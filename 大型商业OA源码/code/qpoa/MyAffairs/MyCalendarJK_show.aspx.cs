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
    public partial class MyCalendarJK_show : System.Web.UI.Page
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


                string SQL_GetList = "select * from qp_MyCalendar   where id='" + int.Parse(Request.QueryString["id"]) + "'  and ((CHARINDEX('," + this.Session["username"] + ",',','+JkUsername+',')   >   0 ))";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CalendarTime.Text = System.DateTime.Parse(NewReader["CalendarTime"].ToString()).ToShortDateString();
                    Starttime.Text = "" + NewReader["StarttimeHour"].ToString() + "：" + NewReader["StarttimeMini"].ToString() + "";
                    Endtime.Text = "" + NewReader["EndtimeHour"].ToString() + "：" + NewReader["EndtimeMini"].ToString() + "";
                    CalendarType.Text = NewReader["CalendarType"].ToString();
                    Content.Text = List.TbToLb(NewReader["Content"].ToString());
                    Iftx.Text = NewReader["Iftx"].ToString();
                    JkRealname.Text = NewReader["JkRealname"].ToString();
                }
                NewReader.Close();
                InsertLog("查看日程安排", "日程安排");

            }





        }
        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyCalendarJK.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

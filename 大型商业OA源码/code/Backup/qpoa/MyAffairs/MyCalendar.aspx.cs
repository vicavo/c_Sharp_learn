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
    public partial class MyCalendar : System.Web.UI.Page
    {
        string[, ,] SpecialDays = new string[3000, 13, 32];
        Db List = new Db();
        public int a, b, c;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!IsPostBack)
            {
                Calendar1.VisibleDate = Calendar1.TodaysDate;
            }
            string SQL_GetList = "select * from qp_MyCalendar where username='"+Session["username"]+"'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            while (NewReader.Read())
            {


                a = int.Parse(System.DateTime.Parse(NewReader["CalendarTime"].ToString()).Year.ToString());
                b = int.Parse(System.DateTime.Parse(NewReader["CalendarTime"].ToString()).Month.ToString());
                c = int.Parse(System.DateTime.Parse(NewReader["CalendarTime"].ToString()).Day.ToString());



                SpecialDays[a, b, c] = "";


            }
            NewReader.Close();
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(ImageButton1, "1111f", Session["perstr"].ToString());
            List.QuanXianVis(IMG1, "1111f", Session["perstr"].ToString());
            List.QuanXianVis(Calendar1, "1111f", Session["perstr"].ToString());

        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("MyCalendar_add.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
                e.Cell.Controls.Clear();
            else
            {

                Style SpecialDayStyle = new Style();
                SpecialDayStyle.BackColor = System.Drawing.Color.Red;
                SpecialDayStyle.ForeColor = System.Drawing.Color.DarkBlue;
                SpecialDayStyle.BorderColor = System.Drawing.Color.DarkGreen;

                SpecialDayStyle.Font.Size = FontUnit.Parse("11pt");

                try
                {
                    string MyDay = SpecialDays[e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day];

                    if (MyDay != null)
                    {

                        e.Cell.ApplyStyle(SpecialDayStyle);
                    }
                }

                catch (Exception exc)
                {
                    Response.Write(exc.ToString());
                }

            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            DisplaySelection();
        }
        private void DisplaySelection()
        {
            Response.Redirect("MyCalendarList.aspx?time=" + Calendar1.SelectedDate.ToShortDateString() + "");
        }

    }
}

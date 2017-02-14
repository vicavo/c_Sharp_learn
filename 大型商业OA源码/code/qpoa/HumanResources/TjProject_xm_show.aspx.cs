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
namespace qpoa.HumanResources
{
    public partial class TjProject_xm_show : System.Web.UI.Page
    {
        Db List = new Db();
        public static string Typename, DiffTimeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Type"] == "1")
                {
                    Typename = "病假登记";
                    DiffTimeName = "请假天数";

                }
                if (Request.QueryString["Type"] == "2")
                {
                    Typename = "事假登记";
                    DiffTimeName = "请假天数";

                }
                if (Request.QueryString["Type"] == "3")
                {
                    Typename = "出差登记";
                    DiffTimeName = "出差天数";

                }
                if (Request.QueryString["Type"] == "4")
                {
                    Typename = "加班登记";
                    DiffTimeName = "加班小时";

                }
                string SQL_GetList = "select * from qp_MyAttendance where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    DiffTime.Text = NewReader["DiffTime"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();

                    Subject.Text = NewReader["Subject"].ToString();
                    StartTime.Text = NewReader["StartTime"].ToString();
                    EndTime.Text = NewReader["EndTime"].ToString();

                    Shenpi.Text = NewReader["Shenpi"].ToString();
                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());
                    SpTimes.Text = NewReader["SpTimes"].ToString();
                }

                NewReader.Close();

                InsertLog("查看" + Typename + "[" + Subject.Text + "]", "" + Typename + "");

                BindAttribute();
            }



        }
        public void BindAttribute()
        {

        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MyAttendance.aspx?type=" + Request.QueryString["Type"] + "");
        //}



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
    public partial class MyAttendance_update : System.Web.UI.Page
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
                    TDiffTime.Text = "请假天数";
                }
                if (Request.QueryString["Type"] == "2")
                {
                    Typename = "事假登记";
                    DiffTimeName = "请假天数";
                    TDiffTime.Text = "请假天数";
                }
                if (Request.QueryString["Type"] == "3")
                {
                    Typename = "出差登记";
                    DiffTimeName = "出差天数";
                    TDiffTime.Text = "出差天数";
                }
                if (Request.QueryString["Type"] == "4")
                {
                    Typename = "加班登记";
                    DiffTimeName = "加班小时";
                    TDiffTime.Text = "加班小时";
                }
                string SQL_GetList = "select * from qp_MyAttendance where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Subject.Text = NewReader["Subject"].ToString();
                    StartTime.Text = NewReader["StartTime"].ToString();
                    EndTime.Text = NewReader["EndTime"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();
                    DiffTime.Text = NewReader["DiffTime"].ToString();

                }
                NewReader.Close();

                BindAttribute();
            }



        }
        public void BindAttribute()
        {

            StartTime.Attributes.Add("readonly", "readonly");
            EndTime.Attributes.Add("readonly", "readonly");
            Realname.Attributes.Add("readonly", "readonly");
           
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MyAttendance.aspx?type=" + Request.QueryString["Type"] + "");
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_MyAttendance  Set DiffTime='" + List.GetFormatStr(DiffTime.Text) + "',Subject='" + List.GetFormatStr(Subject.Text) + "',StartTime='" + StartTime.Text + "',EndTime='" + EndTime.Text + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改" + Typename + "[" + Subject.Text + "]", "" + Typename + "");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + Request.QueryString["Type"] + "'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

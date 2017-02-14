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
    public partial class MyAttendance_add : System.Web.UI.Page
    {
        Db List = new Db();
        public static string Typename,DiffTimeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                Realname.Text = this.Session["realname"].ToString();
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
                BindAttribute();
            }



        }
        public void BindAttribute()
        {

            StartTime.Attributes.Add("readonly", "readonly");
            EndTime.Attributes.Add("readonly", "readonly");
            Realname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAttendance.aspx?type=" + Request.QueryString["Type"] + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insert = "insert into qp_MyAttendance  (DiffTime,Type,Subject,StartTime,EndTime,Shenpi,SpUsername,SpRealname,Remark,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + DiffTime.Text + "','" + Request.QueryString["Type"] + "','" + List.GetFormatStr(Subject.Text) + "','" + List.GetFormatStr(StartTime.Text) + "','" + List.GetFormatStr(EndTime.Text) + "','未审批','未审批','未审批','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);


            InsertLog("新增" + Typename + "[" + Subject.Text + "]", "" + Typename + "");


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

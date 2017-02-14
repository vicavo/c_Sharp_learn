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
    public partial class TrainingLog_add : System.Web.UI.Page
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
            }
        }
        public void BindAttribute()
        {

            StaffName.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_TrainingLog  (StaffId,StaffName,TrainingPro,TrainingContent,TrainingCompany,Starttime,Endtime,Remark,Username,Realname,Unit,UnitId,Respon,ResponId,NowTimes,QxString) values ('" + List.GetFormatStr(StaffId.Text) + "','" + List.GetFormatStr(StaffName.Text) + "','" + List.GetFormatStr(TrainingPro.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + List.GetFormatStr(TrainingCompany.Text) + "','" + List.GetFormatStr(Starttime.Text) + "','" + List.GetFormatStr(Endtime.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insertgly);
            InsertLog("新增培训记录", "培训记录");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='TrainingLog.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("NbMailAccept.aspx");
        }

    }
}

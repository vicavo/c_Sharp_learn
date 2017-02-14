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
    public partial class TrainingLog_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_TrainingLog where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    StaffId.Text = NewReader["StaffId"].ToString();
                    StaffName.Text = NewReader["StaffName"].ToString();
                    TrainingPro.Text = NewReader["TrainingPro"].ToString();
                    d_content.Value = List.GetFormatStrbjq_show(NewReader["TrainingContent"].ToString());
                    TrainingCompany.Text = NewReader["TrainingCompany"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();
                }
                NewReader.Close();
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
            string Sql_update = "Update qp_TrainingLog  Set StaffId='" + List.GetFormatStr(StaffId.Text) + "',  StaffName='" + List.GetFormatStr(StaffName.Text) + "',  TrainingPro='" + List.GetFormatStr(TrainingPro.Text) + "',  TrainingContent='" + List.GetFormatStrbjq(d_content.Value) + "',  TrainingCompany='" + List.GetFormatStr(TrainingCompany.Text) + "',  Starttime='" + List.GetFormatStr(Starttime.Text) + "',  Endtime='" + List.GetFormatStr(Endtime.Text) + "',  Remark='" + List.GetFormatStr(Remark.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改培训记录", "培训记录");
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
            Response.Redirect("TrainingLog.aspx");
        }

    }
}

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
    public partial class IncentiveLog_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_IncentiveLog where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    StaffId.Text = NewReader["StaffId"].ToString();
                    StaffName.Text = NewReader["StaffName"].ToString();
                    Type.SelectedValue = NewReader["Type"].ToString();
                    Unit.Text = NewReader["UnitJc"].ToString();
                    SetTime.Text = System.DateTime.Parse(NewReader["SetTime"].ToString()).ToShortDateString();
                    JcNames.Text = NewReader["JcNames"].ToString();
                    Reasons.Text = NewReader["Reasons"].ToString();
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
            string Sql_update = "Update qp_IncentiveLog  Set StaffId='" + List.GetFormatStr(StaffId.Text) + "',  StaffName='" + List.GetFormatStr(StaffName.Text) + "',  Type='" + List.GetFormatStr(Type.SelectedValue) + "',  UnitJc='" + List.GetFormatStr(Unit.Text) + "',  SetTime='" + List.GetFormatStr(SetTime.Text) + "',  JcNames='" + List.GetFormatStr(JcNames.Text) + "',  Reasons='" + List.GetFormatStr(Reasons.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("修改奖惩记录", "奖惩记录");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='IncentiveLog.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncentiveLog.aspx");
        }

    }
}

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
    public partial class WorkTime_add : System.Web.UI.Page
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
                BindDrop();
                BindAttribute();
            }
        }
        public void BindAttribute()
        {
            SyRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }

        public void BindDrop()
        {
            list.Bind_DropDownList_Hour(h1);
            list.Bind_DropDownList_Hour(h2);
            list.Bind_DropDownList_Hour(h3);
            list.Bind_DropDownList_Hour(h4);
            list.Bind_DropDownList_Hour(h5);
            list.Bind_DropDownList_Hour(h6);

            list.Bind_DropDownList_Mini(m1);
            list.Bind_DropDownList_Mini(m2);
            list.Bind_DropDownList_Mini(m3);
            list.Bind_DropDownList_Mini(m4);
            list.Bind_DropDownList_Mini(m5);
            list.Bind_DropDownList_Mini(m6);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_GetList_sj = "select * from qp_WorkTime  where QyType='" + List.GetFormatStr(PbType.Text) + "' ";
            SqlDataReader NewReader_sj = List.GetList(SQL_GetList_sj);
            if (NewReader_sj.Read())
            {
                this.Response.Write("<script language=javascript>alert('排班类型名重复！');</script>");
                return;
            }
            NewReader_sj.Close();

            string sql_insert = "insert into qp_WorkTime values('" + List.GetFormatStr(PbType.Text) + "','" + DjType_1.SelectedValue + "','" + h1.SelectedValue + ":" + m1.SelectedValue + "','" + DjType_2.SelectedValue + "','" + h2.SelectedValue + ":" + m2.SelectedValue + "','" + DjType_3.SelectedValue + "','" + h3.SelectedValue + ":" + m3.SelectedValue + "','" + DjType_4.SelectedValue + "','" + h4.SelectedValue + ":" + m4.SelectedValue + "','" + DjType_5.SelectedValue + "','" + h5.SelectedValue + ":" + m5.SelectedValue + "','" + DjType_6.SelectedValue + "','" + h6.SelectedValue + ":" + m6.SelectedValue + "','" + QyType.SelectedValue + "','" + SyUsername.Text + "','" + SyRealname.Text + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增上下班时间", "上下班时间");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkTime.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkTime.aspx");
        }

    }
}

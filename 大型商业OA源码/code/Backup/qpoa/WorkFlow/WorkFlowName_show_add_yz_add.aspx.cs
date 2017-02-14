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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowName_show_add_yz_add : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                string SQL_GetList = "select  *  from qp_WorkFlowName where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    FormId.Text = NewReader["FormId"].ToString();
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    FlowId.Text = NewReader["id"].ToString();
                }
                NewReader.Close();

                string sql_down = "select * from qp_FormFile where KeyFile='" + FormNumber.Text + "'and Type='[电子印章]'";
                if (!IsPostBack)
                {
                    list.Bind_DropDownList(yinzhang, sql_down, "Number", "Name");
                }
            }
        }
        public void BindAttribute()
        {
            SyRealname.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_WorkFlowNameYz (FormId,FormNumber,FlowId,FlowNumber,YzNumber,Name,SyUsername,SyRealname) values ('" + List.GetFormatStr(FormId.Text) + "','" + List.GetFormatStr(FormNumber.Text) + "','" + List.GetFormatStr(FlowId.Text) + "','" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "','" + yinzhang.SelectedValue + "','" + yinzhang.SelectedItem.Text + "','" + List.GetFormatStr(SyUsername.Text) + "','" + List.GetFormatStr(SyRealname.Text) + "')";
            List.ExeSql(sql_insert);
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }
    }
}

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
    public partial class SaXzPieces_add : System.Web.UI.Page
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
                string sql_down_bh = "select *  from qp_SalariesSet where IfOk='是' order by id desc";

                if (!IsPostBack)
                {
                    list.Bind_DropDownList_nothing(SaName, sql_down_bh, "Number", "Name");
                }

                BindAttribute();
            }
        }
        public void BindAttribute()
        {
            WorkTime.Attributes.Add("readonly", "readonly");
            DyRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";
            Name.Attributes.Add("readonly", "readonly");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_SaXzJobs  (Name,DjMoney,DyUsername,DyRealname,WorkNum,WorkTime,AllMoney,SaName,SaNumber) values ('" + List.GetFormatStr(Name.Text) + "','" + DjMoney.Text + "','" + DyUsername.Text + "','" + DyRealname.Text + "','" + List.GetFormatStr(WorkNum.Text) + "','" + List.GetFormatStr(WorkTime.Text) + "','" + List.GetFormatStr(AllMoney.Text) + "','" + SaName.SelectedItem.Text + "','" + SaName.SelectedValue + "')";
            List.ExeSql(sql_insertgly);

        

            InsertLog("新增计时工种", "计时工种");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaXzJobs.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaXzJobs.aspx");
        }

    }
}

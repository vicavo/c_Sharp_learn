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
namespace qpoa.KmManage
{
    public partial class KmBbsAllAdd : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string BigName;
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
            Button2.Attributes["onclick"] = "javascript:return chknull();";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_KmBbsAll  (Title,Content,ParentNodesID,PointNum,Username,Realname,Settime) values ('" + List.GetFormatStr(title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','0','0','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insertgly);
            InsertLog("发布讨论" + title.Text + "", "知识互动");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KmBbsAll.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmBbsAll.aspx");
        }

    }
}

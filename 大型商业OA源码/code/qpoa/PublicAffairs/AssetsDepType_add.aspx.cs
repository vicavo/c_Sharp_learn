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
namespace qpoa.PublicAffairs
{
    public partial class AssetsDepType_add : System.Web.UI.Page
    {
        Db List = new Db();
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
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssetsDepType.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_AssetsDepType  (DepType,DepRate,DepCycle,Content,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + List.GetFormatStr(DepType.Text) + "','" + List.GetFormatStr(DepRate.Text) + "','" + List.GetFormatStr(DepCycle.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增折旧类别[" + DepType.Text + "]", "资产折旧类别");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='AssetsDepType.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

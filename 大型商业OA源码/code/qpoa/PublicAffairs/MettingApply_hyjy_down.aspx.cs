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
    public partial class MettingApply_hyjy_down : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
                return;

            }
            string SQL_GetList = "select * from qp_MettingApplyFj   where NewName='" + Server.UrlDecode(Request.QueryString["number"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                InsertLog("下载会议纪要附件[" + NewReader["name"] + "]", "会议纪要");

                Response.Redirect("MettingApplyFj/" + Server.UrlDecode(Request.QueryString["number"]) + "");

            }
            else
            {
                this.Response.Write("<script language=javascript>alert('下载失败！');window.close();</script>");
            }
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

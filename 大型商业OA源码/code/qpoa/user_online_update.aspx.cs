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
namespace qpoa
{
    public partial class user_online_update : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
                return;
            }

            if (this.Session["userName"] == null)
            { Response.Write("notuser"); }

            string Sql_updateonline = "Update qp_username Set lasttime='" + System.DateTime.Now.ToString() + "' where username='" + this.Session["userName"] + "'";
            List.ExeSql(Sql_updateonline);
        }
    }
}

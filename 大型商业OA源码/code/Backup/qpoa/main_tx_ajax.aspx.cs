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
namespace qpoa.sound
{
    public partial class main_tx_ajax : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
                return;
            }

            string SQL_GetList_tx = "select count(*) as counts from qp_Messages where (acceptusername='" + this.Session["userName"] + "')  and sfck='否'";
            int alldelpoint_tx = List.GetCount(SQL_GetList_tx);
            if (alldelpoint_tx > 0)
            {
                Response.Write("1");
            }
            else
            {
                Response.Write("0");
            }

        }
    }
}

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
    public partial class KmShowDel : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Sql_de = " Delete from qp_KmBBS where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_de);
            this.Response.Write("<script language=javascript>alert('删除成功！');window.opener.location.href='KmShow.aspx?id=" + Request.QueryString["Backid"] + "';window.close();</script>");

        }
    }
}

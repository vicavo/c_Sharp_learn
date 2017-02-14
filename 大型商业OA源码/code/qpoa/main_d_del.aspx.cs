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
    public partial class main_d_del : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Sql_d = " Delete from qp_DIYMould where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_d);
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='main_d.aspx';window.close();</script>");

        }
    }
}

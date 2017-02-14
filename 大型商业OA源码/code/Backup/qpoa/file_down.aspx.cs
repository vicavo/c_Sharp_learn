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
    public partial class file_down : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

       
            string SQL_GetList = "select * from qp_fileupload   where NewName='" + Server.UrlDecode(Request.QueryString["number"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                Response.Redirect("" + Server.UrlDecode(Request.QueryString["number"]) + "");
            }
            else
            {
                this.Response.Write("<script language=javascript>alert('下载失败！');window.close();</script>");
            }
            NewReader.Close();
        }

    }
}

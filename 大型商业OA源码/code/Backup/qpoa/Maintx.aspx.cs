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
    public partial class Maintx : System.Web.UI.Page
    {
        public static string txtime, iftx, Sound;
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string SQL_GetListopen = "select * from qp_IfOpen  where username='" + Session["username"] + "'";
            SqlDataReader NewReaderopen = List.GetList(SQL_GetListopen);
            if (NewReaderopen.Read())
            {
                Sound = NewReaderopen["Sound"].ToString();
            }
            NewReaderopen.Close();//提醒声音


            string SQL_GetList_tx = "select * from qp_MyReminded where username='" + Session["username"] + "'";
            SqlDataReader NewReader_tx = List.GetList(SQL_GetList_tx);
            if (NewReader_tx.Read())
            {
                iftx = NewReader_tx["iftx"].ToString();
                txtime = NewReader_tx["txtime"].ToString();
            }
            NewReader_tx.Close();//是否需要提醒
        }
    }
}

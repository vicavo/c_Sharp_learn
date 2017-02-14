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
namespace qpoa.InfoSpeech
{
    public partial class SeadChatPeople : System.Web.UI.Page
    {
        Db List = new Db();
        public static string ChatName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string SQL_GetList = "select * from qp_chatName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    ChatName = NewReader["name"].ToString();
                }
                NewReader.Close();

            }
            Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        }
    }
}

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
    public partial class SeadChatAl : System.Web.UI.Page
    {
        Db List = new Db();
        public static string ChatName;
        protected void Page_Load(object sender, EventArgs e)
        {

            this.Session["chatusername"] = this.Session["username"];
            this.Session["chatrealname"] = this.Session["realname"];

            if (!Page.IsPostBack)
            {

                string SQL_GetList = "select * from qp_chatName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    ChatName = NewReader["name"].ToString();
                }
                NewReader.Close();

                user.Value = "所有人";
                name.Value = "所有人";
            }

            suser.Value = this.Session["chatusername"].ToString();
            sname.Value = this.Session["chatrealname"].ToString();

            Ajax.Utility.RegisterTypeForAjax(typeof(AjaxMethod));
        }
    }
}

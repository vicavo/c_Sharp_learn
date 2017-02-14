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
    public partial class SeadChatRe : System.Web.UI.Page
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

            }


            string SQL_Label = "select * from qp_chatListPeople where username='" + this.Session["chatusername"] + "' and NameId='" + List.GetFormatStr(Request.QueryString["id"]) + "' ";
            SqlDataReader NewReader_Label = List.GetList(SQL_Label);
            if (NewReader_Label.Read())
            {
                string Sql_update = "Update qp_chatListPeople Set firsttime='" + System.DateTime.Now.ToString() + "' where username='" + this.Session["chatusername"] + "' and NameId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);

                string Sql_update_last = "Update qp_chatListPeople Set lasttime='" + System.DateTime.Now.AddSeconds(10) + "' where NameId='" + List.GetFormatStr(Request.QueryString["id"]) + "'  ";
                List.ExeSql(Sql_update_last);
            }
            else
            {

                string Sql_in = "insert into qp_chatListPeople values('" + this.Session["chatusername"] + "','" + this.Session["chatrealname"] + "','" + System.DateTime.Now.ToString() + "','" + System.DateTime.Now.ToString() + "', '" + List.GetFormatStr(Request.QueryString["id"]) + "', '" + ChatName + "')";
                List.ExeSql(Sql_in);

                string Sql_update = "Update qp_chatListPeople Set lasttime='" + System.DateTime.Now.AddSeconds(10) + "'  where  NameId='" + List.GetFormatStr(Request.QueryString["id"]) + "' ";
                List.ExeSql(Sql_update);
            }
            NewReader_Label.Close();

        }
    }
}

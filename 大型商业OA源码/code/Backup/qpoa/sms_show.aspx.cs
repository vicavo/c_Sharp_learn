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
    public partial class sms_show : System.Web.UI.Page
    {
        Db List = new Db();
        public static string acceptrealname, sendrealname, content, itimes, url, id, CountsLabel, sendusername, title;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string SQL_GetCount = "select count(id) from  qp_Messages where sfck='否' and  acceptusername='" + Session["username"] + "' ";
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                string SQL_GetList = "select top 1 * from qp_Messages where sfck='否' and acceptusername='" + Session["username"] + "' order by itimes asc";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    title = NewReader["title"].ToString();
                    acceptrealname = NewReader["acceptrealname"].ToString();
                    sendrealname = NewReader["sendrealname"].ToString();
                    sendusername = NewReader["sendusername"].ToString();
                    itimes = NewReader["itimes"].ToString();
                    url = NewReader["url"].ToString();
                    content = List.TbToLb(NewReader["content"].ToString());
                    id = NewReader["id"].ToString();
                }
                NewReader.Close();
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_Messages Set sfck='是'  where  id='" + id + "'";
            List.ExeSql(Sql_update1);
            this.Response.Write("<script language=javascript>window.opener.send_request('main_tx_ajax.aspx?tmp='+Math.random()+'');window.close();</script>");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_Messages Set sfck='是'  where  id='" + id + "'";
            List.ExeSql(Sql_update1);
            this.Response.Write("<script language=javascript>window.opener.send_request('main_tx_ajax.aspx?tmp='+Math.random()+'');window.opener.xianqing('" + url + "');window.close();</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string Sql_del = "Delete from qp_Messages where id='" + id + "'";
            List.ExeSql(Sql_del);
            this.Response.Write("<script language=javascript>window.opener.send_request('main_tx_ajax.aspx?tmp='+Math.random()+'');window.close();</script>");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_Messages Set sfck='是'  where  id='" + id + "'";
            List.ExeSql(Sql_update1);
            this.Response.Write("<script language=javascript>window.opener.send_request('main_tx_ajax.aspx?tmp='+Math.random()+'');window.opener.hfurl('" + sendusername + "','" + sendrealname + "');window.close();</script>");

        }
    }
}

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
    public partial class WbSendMailList_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_SendEmail where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    EmailFrom.Text = NewReader["EmailFrom"].ToString();
                    Body.Text = NewReader["Body"].ToString();
                    EmailTo.Text = NewReader["EmailTo"].ToString();
                    Subject.Text = NewReader["Subject"].ToString();
                    if (NewReader["Newname"].ToString() == "无附件")
                    {
                        Oldname.Text += " " + NewReader["OldName"].ToString() + "";
                    
                    }
                    else
                    {
                        Oldname.Text += " <a href=\"sendfile/" + NewReader["Newname"].ToString() + "\"  target=_blank>" + NewReader["OldName"].ToString() + "</a>";

                    }





                }

                NewReader.Close();





            }
        }





        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

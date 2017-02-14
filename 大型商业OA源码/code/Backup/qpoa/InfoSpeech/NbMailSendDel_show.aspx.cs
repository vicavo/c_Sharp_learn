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
    public partial class NbMailSendDel_show : System.Web.UI.Page
    {

        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string content;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_NbMailAccept where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and acceptusername='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    title.Text = NewReader["title"].ToString();
                    content = List.GetFormatStrbjq_show(NewReader["content"].ToString());
                    itimes.Text = NewReader["itimes"].ToString();
                    sendrealname.Text = NewReader["sendrealname"].ToString();
                    acceptrealname.Text = NewReader["acceptrealname"].ToString();
                    //sfck.Text = NewReader["sfck"].ToString();



                    string Sql_update1 = "Update qp_NbMailAccept Set sfck='是'  where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and acceptusername='" + Session["username"] + "'";
                    List.ExeSql(Sql_update1);
                }
                NewReader.Close();


                string SQL_rc = "select  * from qp_fileupload where KeyField='" + Number.Text + "' order by id desc";
                SqlDataReader NewReader_rc = List.GetList(SQL_rc);
                this.fujian.Text = null;
                int glTMP2 = 0;
                this.fujian.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this.fujian.Text += "<tr>";
                while (NewReader_rc.Read())
                {
                    this.fujian.Text += " <td width=100% >·<a href=../file_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";
                    glTMP2 = glTMP2 + 1;
                    if (glTMP2 == 1)
                    {
                        fujian.Text += "</tr><TR>";
                        glTMP2 = 0;
                    }
                }
                this.fujian.Text += " </table>";
                NewReader_rc.Close();



                InsertLog("查看内部邮件", "内部邮件管理");

            }





        }







        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NbMailSendDel.aspx");
        }







    }
}

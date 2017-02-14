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
    public partial class WbMailAcceptList_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_Mail where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    txtSender.Text = "" + NewReader["txtSender"].ToString() + "[" + NewReader["txtSendMail"].ToString() + "]";
                    txtSubject.Text = NewReader["txtSubject"].ToString();
                    //txtBody.Text = List.TbToLb(NewReader["txtBody"].ToString());
                    txtBody.Text = NewReader["txtBody"].ToString();
                    number.Text = NewReader["keyfile"].ToString();



                    //string SQL_rc = "select  * from qp_MailFile where keyfile='" + NewReader["keyfile"].ToString() + "' order by id desc";
                    string SQL_rc = "select * from qp_MailFile OldName where id=(SELECT min(id) FROM qp_MailFile txtSize where OldName.OldName =txtSize.OldName and OldName.txtSize=txtSize.txtSize) and txtSize='" + NewReader["txtSize"].ToString().Replace("txtSize", "") + "' and MailName='" + NewReader["txtSubject"].ToString() + "'";
                    //Response.Write(SQL_rc);
                    SqlDataReader NewReader_rc = List.GetList(SQL_rc);

                    this.richeng.Text = null;
                    int glTMP2 = 0;
                    this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                    this.richeng.Text += "<tr>";
                    while (NewReader_rc.Read())
                    {


                        this.richeng.Text += " <td width=100% >·<a href=\"attFile/" + NewReader_rc["NewName"].ToString() + "\"  target=_blank>" + NewReader_rc["OldName"].ToString() + "</a></td>";

                        glTMP2 = glTMP2 + 1;
                        if (glTMP2 == 1)
                        {
                            richeng.Text += "</tr><TR>";
                            glTMP2 = 0;
                        }
                    }
                    this.richeng.Text += " </table>";
                    NewReader_rc.Close();





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

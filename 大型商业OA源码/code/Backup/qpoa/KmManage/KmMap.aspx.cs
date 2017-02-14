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
namespace qpoa.KmManage
{
    public partial class KmMap : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
                return;

            }

            List.QuanXianVis(Label, "jjjj5", Session["perstr"].ToString());

            string SQL_tb = "select   * from qp_KmBigType order by id desc";
            SqlDataReader NewReaderTB = List.GetList(SQL_tb);
            Label.Text = null;
            int glTMP1 = 0,glTMP2 = 0;
            this.Label.Text += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            this.Label.Text += "";
            while (NewReaderTB.Read())
            {
                this.Label.Text += "<tr><td><table align=\"center\" background=\"../images/bg0003.gif\" border=\"0\" cellpadding=\"0\"  cellspacing=\"0\" width=\"100%\"><tr> <td  height=\"26px\"><table  height=\"26\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" > <tr><td  height=\"26px\" width=\"17px\" background=\"../images/KmMap2.gif\"></td> <td valign=\"bottom\" background=\"../images/KmMap4.gif\" ><font color=\"#FFFFFF\">" + NewReaderTB["Name"] + "</font>&nbsp;</td></tr></table></td></tr></table>";
                glTMP2 = 0;
                string SQL_xb = "select   * from qp_KmLittleType where BigId='" + NewReaderTB["id"] + "' and ((CHARINDEX('," + this.Session["username"] + ",',','+SyUsername+',') > 0 ) or SyUsername='全部用户' ) order by id desc";
                SqlDataReader NewReaderXB = List.GetList(SQL_xb);
                this.Label.Text += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"> <tr align=\"left\"> ";
                while (NewReaderXB.Read())
                {
                    this.Label.Text += "<td width=\"25%\"><a href=KmMapList.aspx?LittleId=" + NewReaderXB["id"] + "><img src=\"../images/menu/icon.gif\" width=\"16\" height=\"16\" border=0/>" + NewReaderXB["Name"] + "</td>";
                    glTMP2 = glTMP2 + 1;
                    if (glTMP2 == 4)
                    {
                        Label.Text += "</tr><tr align=\"left\"> ";
                        glTMP2 = 0;
                    }

                }
                NewReaderXB.Close();
                Label.Text += " </table>";

                //glTMP2 = 0;
                //string SQL_xb = "select   * from qp_KmLittleType where BigId='" + NewReaderTB["id"] + "' order by id desc";
                //SqlDataReader NewReaderXB = List.GetList(SQL_xb);
                //this.Label.Text += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\"><tr align=\"center\"> ";
                //while (NewReaderXB.Read())
                //{
                //    this.Label.Text += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<img src=\"../images/menu/icon.gif\" width=\"16\" height=\"16\" />" + NewReaderXB["Name"] + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
                //    glTMP2 = glTMP2 + 1;
                //    if (glTMP2 == 4)
                //    {
                //        Label.Text += "<br>";
                //        glTMP2 = 0;
                //    }

                //}
                //NewReaderXB.Close();
                //Label.Text += " </tr></table>";





                this.Label.Text += "</td>";
                glTMP1 = glTMP1 + 1;
                if (glTMP1 == 1)
                {
                    Label.Text += "</tr>";
                    glTMP1 = 0;
                }
            }
            this.Label.Text += " </table>";
            NewReaderTB.Close();
        }
    }
}

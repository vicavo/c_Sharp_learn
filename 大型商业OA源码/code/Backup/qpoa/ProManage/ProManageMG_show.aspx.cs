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

namespace qpoa.ProManage
{
    public partial class ProManageMG_show : System.Web.UI.Page
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
        
            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_ProManage where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    ConName.Text = NewReader["ConName"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Types.Text = NewReader["Types"].ToString();
                    Jibie.Text = NewReader["Jibie"].ToString();
                    States.Text = NewReader["States"].ToString();
                    Conetent.Text = List.TbToLb(NewReader["Conetent"].ToString());
                    FzUsername.Text = NewReader["FzUsername"].ToString();
                    FzRealname.Text = NewReader["FzRealname"].ToString();
                    CyUsername.Text = NewReader["CyUsername"].ToString();
                    CyRealname.Text = NewReader["CyRealname"].ToString();
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
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProManageMG.aspx");
        }
    }
}

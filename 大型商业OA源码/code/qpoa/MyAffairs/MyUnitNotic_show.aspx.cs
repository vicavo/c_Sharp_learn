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
namespace qpoa.MyAffairs
{
    public partial class MyUnitNotic_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey, d_content;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {


                BindAttribute();

                string SQL_GetList_sta = "select * from qp_UnitNotic where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader = List.GetList(SQL_GetList_sta);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    d_content = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                    Title.Text = NewReader["Title"].ToString();
                    UnitName.Text = NewReader["UnitName"].ToString().Replace("|", "").Replace("-", "");
                    IfShare.Text = NewReader["IfShare"].ToString();
                    GxUnitNameId.Text = NewReader["GxUnitNameId"].ToString();
                    GxUnitName.Text = NewReader["GxUnitName"].ToString();

                }
                NewReader.Close();


                string SQL_GetList_sta1 = "select * from qp_UnitNotic where id='" + Request.QueryString["id"] + "' and  CHARINDEX('," + Session["username"] + ",',','+yduser+',')   >0";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList_sta1);
                if (!NewReader1.Read())
                {
                    string Sql_update = "Update qp_UnitNotic   Set yduser=yduser+'" + Session["username"] + ",',ydrealname=ydrealname+'" + Session["realname"] + ",'  where id='" + int.Parse(Request.QueryString["id"]) + "' ";
                    List.ExeSql(Sql_update);
                }
                NewReader1.Close();


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

        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyUnitNotic.aspx");
        }



        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                            + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }



    }
}

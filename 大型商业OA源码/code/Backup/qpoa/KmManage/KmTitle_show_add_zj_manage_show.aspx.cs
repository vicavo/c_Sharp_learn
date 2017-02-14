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
    public partial class KmTitle_show_add_zj_manage_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string KmTitle, fjkey, d_content;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                //string SQL_GetList_fjkey = "select * from qp_FjKey";
                //SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                //if (NewReader_fjkey.Read())
                //{

                //    fjkey = NewReader_fjkey["content"].ToString();

                //}
                //NewReader_fjkey.Close();
                //BindAttribute();



                string SQL_GetList = "select * from qp_KmTitleList where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    KmTitle = NewReader["KmTitle"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    d_content = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }

                NewReader.Close();






                string SQL_rc = "select  * from qp_KmTitleListFj where KeyField='" + Number.Text + "' order by id desc";

                SqlDataReader NewReader_rc = List.GetList(SQL_rc);

                this.richeng.Text = null;
                int glTMP2 = 0;
                this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this.richeng.Text += "<tr>";
                while (NewReader_rc.Read())
                {


                    this.richeng.Text += " <td width=100% >·<a href=KmTitle_show_add_zj_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";

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

            //BindList();

        }
        //public void BindAttribute()
        //{
        //    //Button1.Attributes["onclick"] = "javascript:return chknull();";
        //    //Button3.Attributes["onclick"] = "javascript:return delfj();";
        //}




        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }


    }
}

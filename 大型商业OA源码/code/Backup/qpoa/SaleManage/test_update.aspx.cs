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
namespace qpoa.SaleManage
{
    public partial class test_update : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }
            if (!IsPostBack)
            {
                string SQL_mx = "select  * from mxadd where keyfile='10'  order by id asc";

                SqlDataReader NewReader_mx = List.GetList(SQL_mx);

                this.mx.Text = null;
                typename = null;
                int glTMP1 = 0;

                while (NewReader_mx.Read())
                {

                    typename += " <tr bgColor=#f3f8fe><td align=right width=15%>" + NewReader_mx["Name"] + "：</td><td width=85% colSpan=3>" + NewReader_mx["s_str"] + "" + NewReader_mx["ivalue"] + "" + NewReader_mx["l_str"] + "</td>";
                    glTMP1 = glTMP1 + 1;
                    if (glTMP1 == 1)
                    {
                        mx.Text += "</tr>";
                        glTMP1 = 0;
                    }
                }

                NewReader_mx.Close();

                BindAttribute();
            }




        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = Label1.Text;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string SqlStr = "  Delete from mxadd ";
            List.ExeSql(SqlStr);

            string SQL_mx = "select  * from mx where keyfile='10'  order by id asc";
            SqlDataReader NewReader_mx = List.GetList(SQL_mx);
            while (NewReader_mx.Read())
            {
                string SQL_i = "insert mxadd  values('" + NewReader_mx["Number"] + "','" + NewReader_mx["Name"] + "','" + NewReader_mx["showBl"] + "','" + NewReader_mx["textbox"] + "','" + NewReader_mx["s_str"] + "','" + NewReader_mx["l_str"] + "','" + NewReader_mx["keyfile"] + "','" + Request.Form["" + NewReader_mx["Number"] + ""] + "','2')";
                List.ExeSql(SQL_i);
                TextBox1.Text += SQL_i;
            }

            string Sql_update = "Update mxt  Set sadassa='" + typename + "',sa='" + Name.Text + "' ";
            List.ExeSql(Sql_update);

            TextBox1.Text = typename;
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string SQL_mx = "select  * from mxadd where keyfile='10'  order by id asc";

            SqlDataReader NewReader_mx = List.GetList(SQL_mx);

            this.mx.Text = null;
            typename = null;
            int glTMP1 = 0;

            while (NewReader_mx.Read())
            {



                typename += " <tr bgColor=#f3f8fe><td align=right width=15%>" + NewReader_mx["Name"] + "：</td><td width=85% colSpan=3>" + NewReader_mx["s_str"] + "" + Request.Form["" + NewReader_mx["Number"] + ""] + "" + NewReader_mx["l_str"] + "</td>";
                glTMP1 = glTMP1 + 1;
                if (glTMP1 == 1)
                {
                    mx.Text += "</tr>";
                    glTMP1 = 0;
                }
            }

            NewReader_mx.Close();


            TextBox1.Text = typename;
        }



    }
}

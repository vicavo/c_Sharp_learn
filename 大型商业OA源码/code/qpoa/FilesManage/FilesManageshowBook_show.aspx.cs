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
namespace qpoa.FilesManage
{
    public partial class FilesManageshowBook_show : System.Web.UI.Page
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

                BindAttribute();
            }
            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_FilesManageBook  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Num.Text = NewReader["Num"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    Title.Text = NewReader["Title"].ToString();
                    OtherTitle.Text = NewReader["OtherTitle"].ToString();
                    FwCompany.Text = NewReader["FwCompany"].ToString();
                    FwTime.Text = NewReader["FwTime"].ToString();
                    Miji.Text = NewReader["Miji"].ToString();
                    Dengji.Text = NewReader["Dengji"].ToString();
                    WjType.Text = NewReader["WjType"].ToString();
                    GwType.Text = NewReader["GwType"].ToString();
                    WjNum.Text = NewReader["WjNum"].ToString();
                    DyNum.Text = NewReader["DyNum"].ToString();
                    FilesName.Text = NewReader["FilesId"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());

                }
                NewReader.Close();









            }




            string SQL_rc = "select  * from qp_FilesManageBookFj where KeyField='" + Number.Text + "' order by id desc";

            SqlDataReader NewReader_rc = List.GetList(SQL_rc);

            this.richeng.Text = null;
            int glTMP2 = 0;
            this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            this.richeng.Text += "<tr>";
            while (NewReader_rc.Read())
            {


                this.richeng.Text += " <td width=100% >·<a href=FilesManageBook_add_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";

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


        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesManageshowBook.aspx?id="+Request.QueryString["backid"]+"");
        }



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }








    }
}

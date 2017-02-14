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
    public partial class ProManageFYGL_sp : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;
            }


            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_ProManageFY where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and SpUsername='" + this.Session["username"] + "' and Jieguo='等待审批'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    XmName.Text = NewReader["XmName"].ToString();
                    Leibie.Text = NewReader["Leibie"].ToString();
                    Zhuti.Text = NewReader["Zhuti"].ToString();
                    Neirong.Text = List.TbToLb(NewReader["Neirong"].ToString());
                    SpUsername.Text = NewReader["SpUsername"].ToString();
                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    Jieguo.Text = NewReader["Jieguo"].ToString();
                }
                NewReader.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_ProManageFY  Set Jieguo='通过申请' where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and SpUsername='" + this.Session["username"] + "' and Jieguo='等待审批'";
            List.ExeSql(Sql_update1);

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProManageFYGL.aspx?XmName=" + Request.QueryString["XmName"] + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_ProManageFY  Set Jieguo='拒绝申请' where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and SpUsername='" + this.Session["username"] + "' and Jieguo='等待审批'";
            List.ExeSql(Sql_update1);

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProManageFYGL.aspx?XmName=" + Request.QueryString["XmName"] + "'</script>");
        }
    }
}
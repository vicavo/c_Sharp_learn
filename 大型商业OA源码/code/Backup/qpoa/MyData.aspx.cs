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
    public partial class MyData : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

          

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_MyData where Username='" + Request.QueryString["user"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Realname.Text = NewReader["Realname"].ToString();
                    Worknum.Text = NewReader["Worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    Bothday.Text = NewReader["Bothday"].ToString();
                    Tel.Text = NewReader["Tel"].ToString();
                    Fax.Text = NewReader["Fax"].ToString();
                    MoveTel.Text = NewReader["MoveTel"].ToString();
                    LittleTel.Text = NewReader["LittleTel"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    QQNum.Text = NewReader["QQNum"].ToString();
                    Msn.Text = NewReader["Msn"].ToString();
                    ICQ.Text = NewReader["ICQ"].ToString();
                    Address.Text = NewReader["Address"].ToString();
                    ZipCode.Text = NewReader["ZipCode"].ToString();
                    HomeTel.Text = NewReader["HomeTel"].ToString();
                }
                NewReader.Close();
            }

        }



    }
}

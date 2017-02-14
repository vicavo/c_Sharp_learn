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
namespace qpoa.OpenWindows
{
    public partial class open_ProData : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
            }

            if (!Page.IsPostBack)
            {
                type = Request.QueryString["type"].ToString();
                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());
                if (type == "1")
                {
                    typename = "评审级别";
                }

                if (type == "2")
                {
                    typename = "公告类别";
                }

                if (type == "3")
                {
                    typename = "预算类别";
                }

                if (type == "4")
                {
                    typename = "资源类别";
                }

                if (type == "5")
                {
                    typename = "报销类别";
                }

                if (type == "6")
                {
                    typename = "任务类别";
                }

                if (type == "7")
                {
                    typename = "外包类别";
                }

                if (type == "8")
                {
                    typename = "项目阶段";
                }

                if (type == "9")
                {
                    typename = "项目类别";
                }

            }
            DataBindToGridview("");
        }

        public void DataBindToGridview(string str)
        {

            string SQL_GetList_xs = "select * from qp_ProData where type='" + Request.QueryString["type"] + "' " + str + "";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();




        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview("");
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            DataBindToGridview("and  name like '%" + name.Text + "%'");
        }
    }
}

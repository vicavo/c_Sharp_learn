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
    public partial class open_PlanCycle : System.Web.UI.Page
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
                    typename = "计划类型";
                }

                if (type == "2")
                {
                    typename = "计划周期";
                }
                if (type == "3")
                {
                    typename = "车辆类型";
                }

                if (type == "4")
                {
                    typename = "资产类别";
                }

                if (type == "5")
                {
                    typename = "通讯录类别";
                }
            }
            DataBindToGridview("and  name like '%" + name.Text + "%'");
        }

        public void DataBindToGridview(string str)
        {
     


            if (type == "1")
            {
                string SQL_GetList_xs = "select * from qp_Planningtype where 1=1 " + str + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (type == "2")
            {
                string SQL_GetList_xs = "select * from qp_Planningcycle where  1=1 " + str + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (type == "3")
            {
                string SQL_GetList_xs = "select * from qp_CarType  where  1=1 " + str + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (type == "4")
            {
                string SQL_GetList_xs = "select * from qp_AssetsType  where  1=1 " + str + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (type == "5")
            {
                string SQL_GetList_xs = "select * from qp_GroupType  where  1=1 " + str + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
          //  DataBindToGridview("");
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            DataBindToGridview("and  name like '%" + name.Text + "%'");
        }
    }
}

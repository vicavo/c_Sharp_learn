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
    public partial class open_SaleData : System.Web.UI.Page
    {
        Db List = new Db();
        public static string  type, typename;
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
                    typename = "区域维护";
                }

                if (type == "2")
                {
                    typename = "行业维护";
                }

                if (type == "3")
                {
                    typename = "客户来源";
                }

                if (type == "4")
                {
                    typename = "重要度";
                }

                if (type == "5")
                {
                    typename = "交往方式";
                }

                if (type == "6")
                {
                    typename = "企业性质";
                }

                if (type == "7")
                {
                    typename = "销售方式";
                }

                if (type == "8")
                {
                    typename = "服务方式";
                }
                if (type == "9")
                {
                    typename = "计量单位";
                }

                if (type == "10")
                {
                    typename = "产品类别";
                }
                if (type == "11")
                {
                    typename = "合同类型";
                }

            }
            DataBindToGridview("");
        }

        public void DataBindToGridview(string str)
        {
            //if (Request.QueryString["str"] != null)
            //{
                string SQL_GetList_xs = "select * from qp_SaleData where type='" + Request.QueryString["type"] + "' "+str+"";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

            //}
            //else
            //{
            //    string SQL_GetList_xs = "select * from qp_SaleData where type='" + Request.QueryString["type"] + "'  ";
            //    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            //    GridView1.DataBind();

            //}


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

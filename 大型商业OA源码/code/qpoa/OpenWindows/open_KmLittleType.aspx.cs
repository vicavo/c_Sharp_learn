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
    public partial class open_KmLittleType : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Name"].ToString() != "")
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
                }

                if (Request.QueryString["BigId"].ToString() != "")
                {
                    MidSql = MidSql + " and BigId = '" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["BigId"])) + "'";
                }
            }
            return MidSql;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());
            }


            string sql_down_bh = "select id,Name  from qp_KmBigType order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_kong(BigId, sql_down_bh, "id", "Name");
            }

            DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            SqlStrStart = "select * from  qp_KmLittleType where 1=1";


            SqlStrMid = string.Empty;
            SqlStrMid = CreateMidSql();
            SqlStr = SqlStrStart + SqlStrMid;//查询


            if (Request.QueryString["key"] != null)
            {


                string SQL_GetList_xs = "" + SqlStr + " ";
                //  Response.Write(SQL_GetList_xs);
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

            }
            else
            {
                string SQL_GetList_xs = "select * from qp_KmLittleType ";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

            }





        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview();
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("open_KmLittleType.aspx?key=1&Name=" + name.Text + "&BigId=" + BigId.SelectedValue + "&requeststr=" + Server.UrlDecode(Request.QueryString["requeststr"].ToString()) + "");
        }
    }
}

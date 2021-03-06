﻿using System;
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
    public partial class open_Employee : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());
            }
            DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            if (Request.QueryString["str"] != null)
            {
                string SQL_GetList_xs = "select * from qp_Employee  where Realname like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }
            else
            {
                string SQL_GetList_xs = "select * from qp_Employee ";
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
            Response.Redirect("open_Employee.aspx?str=" + name.Text + "&requeststr=" + Server.UrlDecode(Request.QueryString["requeststr"].ToString()) + "");
        }
    }
}

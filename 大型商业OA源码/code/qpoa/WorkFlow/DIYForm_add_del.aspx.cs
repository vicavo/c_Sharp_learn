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
namespace qpoa.WorkFlow
{
    public partial class DIYForm_add_del : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Sql_update = " Delete from qp_FormFile where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

        }
    }
}

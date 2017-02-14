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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowJkJS : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_AddWorkFlow  Set State='强制结束',JBRObjectId='强制结束',JBRObjectName='强制结束',UpTimeSet='" + System.DateTime.Now.ToString() + "'  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='WorkFlowJk.aspx';window.close();</script>");
        }
    }
}

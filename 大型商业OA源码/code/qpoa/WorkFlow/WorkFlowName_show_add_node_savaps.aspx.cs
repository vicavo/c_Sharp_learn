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
    public partial class WorkFlowName_show_add_node_savaps : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strlist = null;
            string str1 = null;
            str1 = "" + Request.QueryString["str"].ToString() + "";
            ArrayList myarr = new ArrayList();
            string[] mystr = str1.Split(';');
            for (int s = 0; s < mystr.Length; s++)
            {
                //Response.Write("" + mystr[s] + "<br>");
                strlist = "update qp_WorkFlowNode set " + mystr[s] + "";
                //Response.Write("" + strlist + "<br>");
                List.ExeSql(strlist);
            }
           
           this.Response.Write("<script language=javascript>alert('保存成功！');window.opener.location.reload();window.close();</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}

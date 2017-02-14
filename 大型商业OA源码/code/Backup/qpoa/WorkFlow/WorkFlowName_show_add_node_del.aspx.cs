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
    public partial class WorkFlowName_show_add_node_del : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

            string SQL_GetList = "select * from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                NodeNum.Text = NewReader["NodeNum"].ToString();
                NodeNumber.Text = NewReader["NodeNumber"].ToString();

            }
            NewReader.Close();

            string Sql_del1 = " Delete from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_del1);//删除流程步骤


            string Sql_del2 = " Delete from qp_FlowFormFile where KeyID='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_del2);//删除条件设置

            string Sql_del3 = " Delete from qp_WorkFlowNodeLine where Source='" + NodeNum.Text + "' and NodeNumber='" + NodeNumber.Text + "'";
            List.ExeSql(Sql_del3);//删除线


            string Sql_del4 = " Delete from qp_WorkFlowNodeLine where Object='" + NodeNum.Text + "' and NodeNumber='" + NodeNumber.Text + "'";
            List.ExeSql(Sql_del4);//删除删除线条件设置

            this.Response.Write("<script language=javascript>alert('删除成功！');window.opener.location.reload();window.close();</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}

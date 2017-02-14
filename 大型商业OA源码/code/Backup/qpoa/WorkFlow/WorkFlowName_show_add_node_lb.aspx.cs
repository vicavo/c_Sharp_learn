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
    public partial class WorkFlowName_show_add_node_lb : System.Web.UI.Page
    {

        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                FlowNumber.Text = Request.QueryString["FlowNumber"].ToString();
                DataBindToGridview();
            }
        }

        public void DataBindToGridview()
        {
            string SQL_GetList_xs = "select * from qp_WorkFlowNode where  FlowNumber='" + Request.QueryString["FlowNumber"] + "'  ";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType itemType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label ss = (Label)e.Row.FindControl("NodeSite");
                Label aa = (Label)e.Row.FindControl("UpNodeNum");
                Label ll1 = (Label)e.Row.FindControl("Label1");
                if (ss.Text == "结束")
                {
                    ll1.Text = "结束";
                }
                else
                {
                    ll1.Text = aa.Text;
                }


            }
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        public override void VerifyRenderingInServerForm(Control control)
        { }
    
    }
}

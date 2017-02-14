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
namespace qpoa.PublicAffairs
{
    public partial class MyWorkPlan_dc : System.Web.UI.Page
    {
        Db List = new Db();
        public static string SqlStrStart, SqlStrMid, SqlStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                InsertLog("导出工作计划", "我的计划");
                DataBindToGridview();
                List.ToExcel(GridView1, "MyWorkPlan");

            }

        }
        public void DataBindToGridview()
        {
            SqlStrStart = "select * from qp_WorkPlan where 1=1 and  (CHARINDEX('," + this.Session["username"] + ",',','+SendUsername+',')   >   0  or  CHARINDEX('," + this.Session["UnitId"] + ",',','+SendUnitId+',')   >   0  or HeaderUser='" + this.Session["username"] + "')";



            SqlStrMid = string.Empty;
            SqlStrMid = Server.UrlDecode(Request.QueryString["str"]);
            SqlStr = SqlStrStart + SqlStrMid + "order by id desc";//查询


            if (Request.QueryString["str"] != null)
            {
                string SQL_GetList_xs = "" + SqlStr + " ";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();



            }
            else
            {

                string SQL_GetList_xs = "select * from qp_WorkPlan where (CHARINDEX('," + this.Session["username"] + ",',','+SendUsername+',')   >   0  or  CHARINDEX('," + this.Session["UnitId"] + ",',','+SendUnitId+',')   >   0  or HeaderUser='" + this.Session["username"] + "') ";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                Label ln1 = (Label)e.Row.FindControl("Fjumber");

                Label richeng = (Label)e.Row.FindControl("Label2");

                string SQL_rc = "select  * from qp_WorkPlanFile where KeyField='" + ln1.Text + "' order by id desc";

                SqlDataReader NewReader_rc = List.GetList(SQL_rc);

                richeng.Text = null;
                int glTMP2 = 0;
                richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                richeng.Text += "<tr>";
                while (NewReader_rc.Read())
                {


                    richeng.Text += " <td width=100% >·" + NewReader_rc["Name"].ToString() + "</td>";

                    glTMP2 = glTMP2 + 1;
                    if (glTMP2 == 1)
                    {
                        richeng.Text += "</tr><TR>";
                        glTMP2 = 0;
                    }
                }
                richeng.Text += " </table>";
                NewReader_rc.Close();





            }
        }



    }
}

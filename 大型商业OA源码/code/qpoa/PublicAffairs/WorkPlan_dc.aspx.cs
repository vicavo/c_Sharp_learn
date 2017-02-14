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
    public partial class WorkPlan_dc : System.Web.UI.Page
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
                InsertLog("导出工作计划", "计划管理");
                DataBindToGridview();
                List.ToExcel(GridView1, "WorkPlan");

            }

        }
        public void DataBindToGridview()
        {
            if (List.StrIFInStr("cc2ccc1", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_WorkPlan where Username='" + this.Session["username"] + "' and 1=1";


            }
            if (List.StrIFInStr("cc2ccc2", Session["perstr"].ToString()))
            {



                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {
                    SqlStrStart = "select * from qp_WorkPlan where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0   and 1=1";

                }
                else
                {
                    SqlStrStart = "select * from qp_WorkPlan where UnitId='" + this.Session["UnitId"] + "' and 1=1";

                }


            }
            if (List.StrIFInStr("cc2ccc3", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_WorkPlan where 1=1";

            }



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
                if (List.StrIFInStr("cc2ccc1", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_WorkPlan where Username='" + this.Session["username"] + "'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("cc2ccc2", Session["perstr"].ToString()))
                {



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {

                        string SQL_GetList_xs = "select * from qp_WorkPlan where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {

                        string SQL_GetList_xs = "select * from qp_WorkPlan where UnitId='" + this.Session["UnitId"] + "'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }


                }//部门

                if (List.StrIFInStr("cc2ccc3", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_WorkPlan  ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司


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

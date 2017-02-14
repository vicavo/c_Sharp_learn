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
namespace qpoa.MyAffairs
{
    public partial class MyMetting_dc : System.Web.UI.Page
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
                InsertLog("导出会议申请", "会议申请管理");
                DataBindToGridview();
                List.ToExcel(GridView1, "MyMetting");

            }

        }
        public void DataBindToGridview()
        {
            if (Request.QueryString["key"] == "1")
            {
                SqlStrStart = "select * from qp_MettingApply where  (State='已通过' or State='进行中'  or State='已结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0   and  1=1";
            }

            if (Request.QueryString["key"] == "2")
            {
                SqlStrStart = "select * from qp_MettingApply where (State='已通过' or State='进行中'  or State='已结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+CjUsername+',')   >   0   and  1=1";
            }

          



            SqlStrMid = string.Empty;
            SqlStrMid = Server.UrlDecode(Request.QueryString["str"]);
            SqlStr = SqlStrStart + SqlStrMid;//查询


            if (Request.QueryString["str"] != null)
            {
                string SQL_GetList_xs = "" + SqlStr + " ";
                //Response.Write(SQL_GetList_xs);
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();



            }
            else
            {

                if (Request.QueryString["key"] == "1")
                {
                    string SQL_GetList_xs = "select * from qp_MettingApply where  (State='已通过' or State='进行中'  or State='已结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0  ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }

                if (Request.QueryString["key"] == "2")
                {

                    string SQL_GetList_xs = "select * from qp_MettingApply where (State='已通过' or State='进行中'  or State='已结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+CjUsername+',')   >   0  ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

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

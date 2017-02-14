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
namespace qpoa.SystemManage
{
    public partial class SystemLog_dc : System.Web.UI.Page
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
                InsertLog("导出系统日志列表", "日志管理");
                DataBindToGridview();
                List.ToExcel(GridView1, "Log");

            }

        }
        public void DataBindToGridview()
        {
            if (List.StrIFInStr("ii1aii8", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SystemLog where Username='" + this.Session["username"] + "' and 1=1";
              

            }
            if (List.StrIFInStr("ii2aii8", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SystemLog where UnitId='" + this.Session["UnitId"] + "' and 1=1";
              
            }
            if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SystemLog where 1=1";
              
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
                if (List.StrIFInStr("ii1aii8", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_SystemLog where Username='" + this.Session["username"] + "' order by id desc";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ii2aii8", Session["perstr"].ToString()))
                {


                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                    
                        string SQL_GetList_xs = "select * from qp_SystemLog where CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {
                     
                        string SQL_GetList_xs = "select * from qp_SystemLog where UnitId='" + this.Session["UnitId"] + "' ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }



                }//部门

                if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_SystemLog  order by id desc";
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

 
    }
}

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
namespace qpoa.SaleManage
{
    public partial class ContactsLog_dc : System.Web.UI.Page
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
                InsertLog("导出交往记录", "客户交往记录");
                DataBindToGridview();
                List.ToExcel(GridView1, "CustomerContactsLog");

            }

        }
        public void DataBindToGridview()
        {
            if (List.StrIFInStr("ff1kffb3", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_ContactsLog where Username='" + this.Session["username"] + "' and 1=1";


            }
            if (List.StrIFInStr("ff2kffb3", Session["perstr"].ToString()))
            {



                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {
                    SqlStrStart = "select * from qp_ContactsLog where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0   and 1=1";

                }
                else
                {
                    SqlStrStart = "select * from qp_ContactsLog where UnitId='" + this.Session["UnitId"] + "' and 1=1";

                }


            }
            if (List.StrIFInStr("ff3kffb3", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_ContactsLog where 1=1";

            }

            if (List.StrIFInStr("ff4kffb3", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_ContactsLog where GroupId='" + this.Session["GroupId"] + "'and 1=1";

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
                if (List.StrIFInStr("ff1kffb3", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_ContactsLog where Username='" + this.Session["username"] + "'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ff2kffb3", Session["perstr"].ToString()))
                {



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {

                        string SQL_GetList_xs = "select * from qp_ContactsLog where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {

                        string SQL_GetList_xs = "select * from qp_ContactsLog where UnitId='" + this.Session["UnitId"] + "'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }


                }//部门

                if (List.StrIFInStr("ff3kffb3", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_ContactsLog  ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司
                if (List.StrIFInStr("ff4kffb3", Session["perstr"].ToString()))
                {


                    string SQL_GetList_xs = "select * from qp_ContactsLog  where GroupId='" + this.Session["GroupId"] + "' ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                } //销售组

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

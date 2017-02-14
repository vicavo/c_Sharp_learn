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
    public partial class Supplier_dc : System.Web.UI.Page
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
                InsertLog("导出供应商列表", "供应商信息");
                DataBindToGridview();
                List.ToExcel(GridView1, "Supplier");

            }

        }
        public void DataBindToGridview()
        {
            if (List.StrIFInStr("ff1eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Supplier where Username='" + this.Session["username"] + "' and 1=1";
             

            }
            if (List.StrIFInStr("ff2eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Supplier where UnitId='" + this.Session["UnitId"] + "' and 1=1";

                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {
                    SqlStrStart = "select * from qp_Supplier where  CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 and 1=1";
                  
                }
                else
                {
                    SqlStrStart = "select * from qp_Supplier where UnitId='" + this.Session["UnitId"] + "' and 1=1";
                   
                }
              
            }
            if (List.StrIFInStr("ff3eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Supplier where 1=1";
              
            }

            if (List.StrIFInStr("ff4eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Supplier where GroupId='" + this.Session["GroupId"] + "'and 1=1";
             
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
                if (List.StrIFInStr("ff1eff5", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_Supplier where Username='" + this.Session["username"] + "' order by id desc";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ff2eff5", Session["perstr"].ToString()))
                {

                    //string SQL_GetList_xs = "select * from qp_Supplier where UnitId='" + this.Session["UnitId"] + "' order by id desc";
                    //GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    //GridView1.DataBind();

                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                     
                        string SQL_GetList_xs = "select * from qp_Supplier where  CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {
                       
                        string SQL_GetList_xs = "select * from qp_Supplier where UnitId='" + this.Session["UnitId"] + "' ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }



                }//部门

                if (List.StrIFInStr("ff3eff5", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_Supplier  order by id desc";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司
                if (List.StrIFInStr("ff4eff5", Session["perstr"].ToString()))
                {


                    string SQL_GetList_xs = "select * from qp_Supplier  where GroupId='" + this.Session["GroupId"] + "' order by id desc";
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

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ln = (Label)e.Row.FindControl("Lnumber");

                Label ll = (Label)e.Row.FindControl("Label1");

                string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + ln.Text + "'  order by PaiXun asc";


                SqlDataReader NewReader_yz = List.GetList(SQL_yz);
                if (NewReader_yz.Read())
                {
                    string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + ln.Text + "'  order by PaiXun asc";
                    SqlDataReader NewReader_mx = List.GetList(SQL_mx);
                    ll.Text = null;
                    int glTMP1 = 0;
                    ll.Text += "<table width=400 border=1 cellspacing=0 cellpadding=4>";
                  
                    while (NewReader_mx.Read())
                    {

                        ll.Text += " <tr><td align=right class=cpx12hei height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td  class=cpx12hei height=17 width=33% colspan=3>" + List.TbToLb(NewReader_mx["ivalue"].ToString()) + "</td></tr>";
                        glTMP1 = glTMP1 + 1;
                        if (glTMP1 == 1)
                        {

                            glTMP1 = 0;
                        }
                    }
                    ll.Text += "</table>";
                    NewReader_mx.Close();
                }

              
              
            }
        }


    }
}

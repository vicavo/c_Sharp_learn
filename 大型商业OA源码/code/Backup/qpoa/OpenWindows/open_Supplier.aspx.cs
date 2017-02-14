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
namespace qpoa.OpenWindows
{
    public partial class open_Supplier : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());
            }
            DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            if (Request.QueryString["str"] != null)
            {
         

                if (List.StrIFInStr("ii1aii8", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_Supplier where Username='" + this.Session["username"] + "' and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ii2aii8", Session["perstr"].ToString()))
                {




                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                        string SQL_GetList_xs = "select * from qp_Supplier where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0    and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%' ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {
                        string SQL_GetList_xs = "select * from qp_Supplier where UnitId='" + this.Session["UnitId"] + "' and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%' ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }



                }//部门

                if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
                {

                    string SQL_GetList_xs = "select * from qp_Supplier  where name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司
                if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
                {


                    string SQL_GetList_xs = "select * from qp_Supplier  where GroupId='" + this.Session["GroupId"] + "'  and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                } //销售组



            }
            else
            {


                if (List.StrIFInStr("ii1aii8", Session["perstr"].ToString()))
                {
                 
                    string SQL_GetList_xs = "select * from qp_Supplier where Username='" + this.Session["username"] + "'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ii2aii8", Session["perstr"].ToString()))
                {
               
 



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                        string SQL_GetList_xs = "select * from qp_Supplier where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0    ";
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

                if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
                {
             
                    string SQL_GetList_xs = "select * from qp_Supplier ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司
                if (List.StrIFInStr("ii3aii8", Session["perstr"].ToString()))
                {

             
                    string SQL_GetList_xs = "select * from qp_Supplier  where GroupId='" + this.Session["GroupId"] + "'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                } //销售组


            }





        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview();
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("open_Supplier.aspx?str=" + name.Text + "&requeststr=" + Server.UrlDecode(Request.QueryString["requeststr"].ToString()) + "");
        }
    }
}

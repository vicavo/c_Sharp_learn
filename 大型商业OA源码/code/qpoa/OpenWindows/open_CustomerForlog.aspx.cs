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
    public partial class open_CustomerForLxr : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());
            }
            DataBindToGridview("AllCus");
        }

        public void DataBindToGridview(string CusKey)
        {
            if (CusKey == "AllCus")
            {
                if (Request.QueryString["str"] != null)
                {


                    if (List.StrIFInStr("ff1kffb3", Session["perstr"].ToString()))
                    {

                        string SQL_GetList_xs = "select * from qp_Customer where Username='" + this.Session["username"] + "' and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }//个人

                    if (List.StrIFInStr("ff2kffb3", Session["perstr"].ToString()))
                    {




                        if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                        {
                            string SQL_GetList_xs = "select * from qp_Customer where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0    and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%' ";
                            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                            GridView1.DataBind();
                        }
                        else
                        {
                            string SQL_GetList_xs = "select * from qp_Customer where UnitId='" + this.Session["UnitId"] + "' and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%' ";
                            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                            GridView1.DataBind();
                        }



                    }//部门

                    if (List.StrIFInStr("ff3kffb3", Session["perstr"].ToString()))
                    {

                        string SQL_GetList_xs = "select * from qp_Customer  where name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    } //公司
                    if (List.StrIFInStr("ff4kffb3", Session["perstr"].ToString()))
                    {


                        string SQL_GetList_xs = "select * from qp_Customer  where GroupId='" + this.Session["GroupId"] + "'  and name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();

                    } //销售组



                }
                else
                {


                    if (List.StrIFInStr("ff1kffb3", Session["perstr"].ToString()))
                    {

                        string SQL_GetList_xs = "select * from qp_Customer where Username='" + this.Session["username"] + "'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }//个人

                    if (List.StrIFInStr("ff2kffb3", Session["perstr"].ToString()))
                    {





                        if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                        {
                            string SQL_GetList_xs = "select * from qp_Customer where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0    ";
                            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                            GridView1.DataBind();
                        }
                        else
                        {
                            string SQL_GetList_xs = "select * from qp_Customer where UnitId='" + this.Session["UnitId"] + "' ";
                            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                            GridView1.DataBind();
                        }





                    }//部门

                    if (List.StrIFInStr("ff3kffb3", Session["perstr"].ToString()))
                    {

                        string SQL_GetList_xs = "select * from qp_Customer ";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    } //公司
                    if (List.StrIFInStr("ff4kffb3", Session["perstr"].ToString()))
                    {


                        string SQL_GetList_xs = "select * from qp_Customer  where GroupId='" + this.Session["GroupId"] + "'";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();

                    } //销售组


                }








            }



            if (CusKey == "PublicCus")
            {

                if (Request.QueryString["str"] != null)
                {

                    string SQL_GetList_xs = "select * from qp_Customer  where Sharing='共享' and  CHARINDEX('," + this.Session["username"] + ",',','+SharingUser+',')   >   0  and  name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();




                }
                else
                {




                    string SQL_GetList_xs = "select * from qp_Customer  where Sharing='共享' and  CHARINDEX('," + this.Session["username"] + ",',','+SharingUser+',')   >   0 ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();



                }







            }




            if (CusKey == "OpenCus")
            {

                if (Request.QueryString["str"] != null)
                {

                    string SQL_GetList_xs = "select * from qp_Customer  where Sharing='公开' and  name like '%" + Server.UrlDecode(Request.QueryString["str"]) + "%'";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();




                }
                else
                {




                    string SQL_GetList_xs = "select * from qp_Customer  where Sharing='公开' ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();



                }



            }









        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //DataBindToGridview();
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("open_CustomerForlog.aspx?str=" + name.Text + "&requeststr=" + Server.UrlDecode(Request.QueryString["requeststr"].ToString()) + "");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            DataBindToGridview("AllCus");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            DataBindToGridview("PublicCus");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            DataBindToGridview("OpenCus");
        }
    }
}

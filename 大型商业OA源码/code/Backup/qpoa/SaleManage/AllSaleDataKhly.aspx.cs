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
    public partial class AllSaleDataKhly : System.Web.UI.Page
    {
        Db List = new Db();
        public static string SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, SqlStrStart1, SqlStrMid1, SqlStr1, SqlStrStartCount1, SqlStrCount1;
        // public static string CustomSum1 = "0";
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {

                MidSql = MidSql + " and (NowTimes between '" + Request.QueryString["Startime"] + "'and  '" + Request.QueryString["Endtime"] + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + Request.QueryString["Startime"] + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + Request.QueryString["Endtime"] + "' as datetime),120) ) ";

            }





            return MidSql;

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {



                DataBindToGridview("order by id desc");
                Bindquanxian();
                InsertLog("查看客户来源统计", "客户属性统计");
            }
            // BindSum();
            // Response.Write(BindSum());
        }

        public void Bindquanxian()
        {
            List.QuanXianVis(IMG1, "ffff6d", Session["perstr"].ToString());
        }







        public void DataBindToGridview(string Sqlsort)
        {


            string SQL_GetList_xs = "select * from qp_SaleData  where Type='3' " + Sqlsort + "";
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
                Label b = (Label)e.Row.FindControl("Label2");
                string Temp = b.Text.ToString();

                Label l = (Label)e.Row.FindControl("Label3");
                l.Text = ReturnSum(Temp);

                double BiLi = 100 * ((double.Parse(l.Text.ToString().Trim())) / (double.Parse(BindSum().ToString().Trim())));
                string TempStr = BiLi.ToString();
                if (TempStr.Length > 5)
                {
                    TempStr = TempStr.Remove(5);
                }
                string BiLiStr = TempStr + "%";

                Label ll = (Label)e.Row.FindControl("Label4");
                ll.Text = BiLiStr;
            }

        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



        public string ReturnSum(string ContentStr)
        {
            string CountsLabel = "0";
            if (List.StrIFInStr("ff6dff6d1", Session["perstr"].ToString()))
            {

                SqlStrStartCount = "select count(id) from qp_Customer where CSource='" + ContentStr + "' and Username='" + this.Session["username"] + "' and  1=1";

            }
            if (List.StrIFInStr("ff6dff6d2", Session["perstr"].ToString()))
            {



                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {

                    SqlStrStartCount = "select count(id) from qp_Customer where   CSource='" + ContentStr + "' and    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  and  1=1";
                }
                else
                {

                    SqlStrStartCount = "select count(id) from qp_Customer where  CSource='" + ContentStr + "' and   UnitId='" + this.Session["UnitId"] + "' and  1=1";
                }


            }
            if (List.StrIFInStr("ff6dff6d3", Session["perstr"].ToString()))
            {

                SqlStrStartCount = "select count(id) from qp_Customer where  CSource='" + ContentStr + "' and  1=1";
            }

            if (List.StrIFInStr("ff6dff6d4", Session["perstr"].ToString()))
            {

                SqlStrStartCount = "select count(id) from qp_Customer where  CSource='" + ContentStr + "' and  GroupId='" + this.Session["GroupId"] + "' and 1=1";
            }

            SqlStrMid = string.Empty;
            SqlStrMid = CreateMidSql();
            SqlStr = SqlStrStart + SqlStrMid;//查询
            SqlStrCount = SqlStrStartCount + SqlStrMid;//查询个数

            if (Request.QueryString["key"] != null)
            {


                string SQL_GetCount = SqlStrCount;

                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            }
            else
            {
                if (List.StrIFInStr("ff6dff6d1", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_Customer where  CSource='" + ContentStr + "' and  Username='" + this.Session["username"] + "'";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                }//个人

                if (List.StrIFInStr("ff6dff6d2", Session["perstr"].ToString()))
                {



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                        string SQL_GetCount = "select count(id) from  qp_Customer where   CSource='" + ContentStr + "' and   CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  ";
                        CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    }
                    else
                    {
                        string SQL_GetCount = "select count(id) from  qp_Customer where  CSource='" + ContentStr + "' and  UnitId='" + this.Session["UnitId"] + "'";
                        CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    }


                }//部门

                if (List.StrIFInStr("ff6dff6d3", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_Customer  where  CSource='" + ContentStr + "'  ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                } //公司
                if (List.StrIFInStr("ff6dff6d4", Session["perstr"].ToString()))
                {

                    string SQL_GetCount = "select count(id) from  qp_Customer  where  CSource='" + ContentStr + "' and  GroupId='" + this.Session["GroupId"] + "'";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";


                } //销售组
            }

            return CountsLabel;

        }



        public string BindSum()
        {
            string CustomSum1 = "0";

            if (List.StrIFInStr("ff2abff1", Session["perstr"].ToString()))
            {

                SqlStrStartCount1 = "select count(id) from qp_Customer where Username='" + this.Session["username"] + "' and  1=1";

            }
            if (List.StrIFInStr("ff2abff2", Session["perstr"].ToString()))
            {



                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {

                    SqlStrStartCount1 = "select count(id) from qp_Customer where   CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  and  1=1";
                }
                else
                {

                    SqlStrStartCount1 = "select count(id) from qp_Customer where   UnitId='" + this.Session["UnitId"] + "' and  1=1";
                }


            }
            if (List.StrIFInStr("ff2abff3", Session["perstr"].ToString()))
            {

                SqlStrStartCount1 = "select count(id) from qp_Customer where  1=1";
            }

            if (List.StrIFInStr("ff2abff4", Session["perstr"].ToString()))
            {

                SqlStrStartCount1 = "select count(id) from qp_Customer where GroupId='" + this.Session["GroupId"] + "' and 1=1";
            }

            SqlStrMid1 = string.Empty;
            SqlStrMid1 = CreateMidSql();

            SqlStrCount1 = SqlStrStartCount1 + SqlStrMid1;//查询个数

            if (Request.QueryString["key"] != null)
            {


                string SQL_GetCount1 = SqlStrCount1;
                //  Response.Write(SQL_GetCount1);
                CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";

            }
            else
            {
                if (List.StrIFInStr("ff2abff1", Session["perstr"].ToString()))
                {
                    string SQL_GetCount1 = "select count(id) from  qp_Customer where   Username='" + this.Session["username"] + "'";
                    CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";

                }//个人

                if (List.StrIFInStr("ff2abff2", Session["perstr"].ToString()))
                {



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                        string SQL_GetCount1 = "select count(id) from  qp_Customer where   CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  ";
                        CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";


                    }
                    else
                    {
                        string SQL_GetCount1 = "select count(id) from  qp_Customer where  UnitId='" + this.Session["UnitId"] + "'";
                        CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";

                    }


                }//部门

                if (List.StrIFInStr("ff2abff3", Session["perstr"].ToString()))
                {
                    string SQL_GetCount1 = "select count(id) from  qp_Customer ";
                    CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";

                } //公司
                if (List.StrIFInStr("ff2abff4", Session["perstr"].ToString()))
                {

                    string SQL_GetCount1 = "select count(id) from  qp_Customer  where GroupId='" + this.Session["GroupId"] + "'";
                    CustomSum1 = "" + List.GetCount(SQL_GetCount1) + "";


                } //销售组
            }

            return CustomSum1;

        }//按权限显示全部行业数量







        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
                DataBindToGridview("order by id desc");
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
                return;
            }
        }










    }
}

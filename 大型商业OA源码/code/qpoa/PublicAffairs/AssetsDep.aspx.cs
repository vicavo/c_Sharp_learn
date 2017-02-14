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
    public partial class AssetsDep : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public static string SumLabel, SqlStrStartMoney, SqlStrMoney;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Name"] != null)
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
                }


                if (Request.QueryString["Number"] != null)
                {
                    MidSql = MidSql + " and Number like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Number"])) + "%'";
                }



                if (Request.QueryString["AssetModel"] != null)
                {
                    MidSql = MidSql + " and AssetModel like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["AssetModel"])) + "%'";
                }

                if (Request.QueryString["MadeCompany"] != null)
                {
                    MidSql = MidSql + " and MadeCompany like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["MadeCompany"])) + "%'";
                }


                if (Request.QueryString["AssetType"] != null)
                {
                    MidSql = MidSql + " and AssetType like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["AssetType"])) + "%'";
                }



                if (Request.QueryString["DepType"] != null)
                {
                    MidSql = MidSql + " and DepType like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["DepType"])) + "%'";
                }


                if (Request.QueryString["UnitName"] != null)
                {
                    MidSql = MidSql + " and UnitName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["UnitName"])) + "%'";
                }

                if (Request.QueryString["BgRealname"] != null)
                {
                    MidSql = MidSql + " and BgRealname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["BgRealname"])) + "%'";
                }


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


                BindAttribute();
                DataBindToGridview("order by id desc");
                Bindquanxian();



            }
        }

        public void Bindquanxian()
        {
            List.QuanXianVis(Button2, "cccc6b", Session["perstr"].ToString());

            List.QuanXianVis(IMG1, "cccc6b", Session["perstr"].ToString());

        }

        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";
  
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {



            if (List.StrIFInStr("cc6cc6b1", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Assets  where 1=1";
                SqlStrStartCount = "select count(id) from qp_Assets  where 1=1";

               


            }



            SqlStrMid = string.Empty;
            SqlStrMid = CreateMidSql();
            SqlStr = SqlStrStart + SqlStrMid;//查询
            SqlStrCount = SqlStrStartCount + SqlStrMid;//查询个数
            SqlStrMoney = SqlStrStartMoney + SqlStrMid;//查询金额

            if (Request.QueryString["key"] != null)
            {
                SumLabel = "";

                string SQL_GetList_xs = "" + SqlStr + " " + Sqlsort + "";
                // Response.Write(SQL_GetList_xs);
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

                string SQL_GetCount = SqlStrCount;
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            }
            else
            {




                if (List.StrIFInStr("cc6cc6b1", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_Assets  ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    string SQL_GetList_xs = "select * from qp_Assets   " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                } //公司

            }



            AllPageLabel = Convert.ToString(GridView1.PageCount);
            CurrentlyPageLabel = Convert.ToString(((int)GridView1.PageIndex + 1));


            btnFirst.CommandName = "1";
            btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

            btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
            btnLast.CommandName = GridView1.PageCount.ToString();
        }










        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType itemType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            }



        }


     

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }











        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sql = "";

            if (ViewState["SortDirection"] == null || ViewState["SortDirection"].ToString().CompareTo("") == 0)
            {
                ViewState["SortDirection"] = " desc";
            }
            else
                ViewState["SortDirection"] = "";

            sql = " order by " + e.SortExpression + ViewState["SortDirection"];


            DataBindToGridview(sql);
        }




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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (GoPage.Text.Trim().ToString() == "")
                {
                    Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
                }
                else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GridView1.PageCount)
                {
                    Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
                }
                else if (GoPage.Text.Trim() != "")
                {
                    int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                    if (PageI >= 0 && PageI < (GridView1.PageCount))
                    {
                        GridView1.PageIndex = PageI;
                    }
                }
                DataBindToGridview("order by id desc");
            }
            catch
            {
                DataBindToGridview("order by id desc");
                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //TimeSpan ts = System.DateTime.Parse("2008-02-01") - System.DateTime.Parse("2008-1-23");
         
         
            //TimeSpan sp = DateTime.Parse(DateTime.Now.ToShortDateString()) - DateTime.Parse("3000-2-28");

            //if (sp.TotalDays > 0)
            //{
            //}

            string SQL_GetList = "select * from qp_Assets";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            while (NewReader.Read())
            {
                TimeSpan t1 = System.DateTime.Parse(System.DateTime.Now.ToShortDateString()) - System.DateTime.Parse(NewReader["DepStartDate"].ToString());
                if (t1.TotalDays >= 0)
                {
                    TimeSpan ts = System.DateTime.Parse(System.DateTime.Now.ToShortDateString()) - System.DateTime.Parse(NewReader["LastDepTime"].ToString());
                    double DayNum = ts.TotalDays;//离最后折旧有几天

                    double DayRate = Double.Parse(NewReader["DepRate"].ToString()) / 100 / Double.Parse(NewReader["DepCycle"].ToString());//每天折旧率

                    double ZjMoney = Double.Parse(NewReader["FrontMoney"].ToString()) - Double.Parse(NewReader["ActualMoney"].ToString()) * DayRate * DayNum;//折旧金额

                    if (ZjMoney < Double.Parse(NewReader["MinMoney"].ToString()))//如果折旧金额小于最低限
                    {
                        double ZjLastMoney = Double.Parse(NewReader["MinMoney"].ToString());//折旧金额

                        string sql_insert = "insert into qp_AssetsDepLog  (AssetsId,AssetsName,Starttime,Endtime,DepStartMoney,DepMoney,DepLastMoney,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + NewReader["id"] + "','" + NewReader["Name"] + "','" + NewReader["LastDepTime"] + "','" + System.DateTime.Now.ToShortDateString() + "','" + NewReader["FrontMoney"] + "','" + Double.Parse(NewReader["ActualMoney"].ToString()) * DayRate * DayNum + "','" + ZjLastMoney + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert);

                        string Sql_update = "Update qp_Assets   Set FrontMoney='" + ZjLastMoney + "',LastDepTime='" + System.DateTime.Now.ToShortDateString() + "'  where id='" + NewReader["id"] + "'";
                        List.ExeSql(Sql_update);


                    }
                    else
                    {
                        double ZjLastMoney = ZjMoney;//折旧金额

                        string sql_insert = "insert into qp_AssetsDepLog  (AssetsId,AssetsName,Starttime,Endtime,DepStartMoney,DepMoney,DepLastMoney,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + NewReader["id"] + "','" + NewReader["Name"] + "','" + NewReader["LastDepTime"] + "','" + System.DateTime.Now.ToShortDateString() + "','" + NewReader["FrontMoney"] + "','" + Double.Parse(NewReader["ActualMoney"].ToString()) * DayRate * DayNum + "','" + ZjLastMoney + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert);

                        string Sql_update = "Update qp_Assets   Set FrontMoney='" + ZjLastMoney + "',LastDepTime='" + System.DateTime.Now.ToShortDateString() + "'  where id='" + NewReader["id"] + "'";
                        List.ExeSql(Sql_update);

                    }
                }

            }
            NewReader.Close();
           // Response.Write("<script language='javascript'>alert('折旧成功！');</script>");

            DataBindToGridview("order by id desc");

        }







    }
}

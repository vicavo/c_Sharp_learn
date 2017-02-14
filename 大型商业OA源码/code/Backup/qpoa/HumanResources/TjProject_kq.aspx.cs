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
namespace qpoa.HumanResources
{
    public partial class TjProject_kq : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, SqlUser, SqlKq, SqlPro;

        public static string filename,DjType_1, DjType_2, DjType_3, DjType_4, DjType_5, DjType_6, DjTime_1, DjTime_2, DjTime_3, DjTime_4, DjTime_5, DjTime_6;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }






            if (Request.QueryString["start"] != "" && Request.QueryString["last"] != "")
            {
                SqlKq = " and (Djtime between '" + Request.QueryString["start"].ToString() + "'and  '" + Request.QueryString["last"].ToString() + "' or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["start"].ToString() + "' as datetime),120) or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["last"].ToString() + "' as datetime),120) ) ";

                //SqlPro = " and (StartTime between '" + Request.QueryString["start"].ToString() + "'and  '" + Request.QueryString["last"].ToString() + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + Request.QueryString["start"].ToString() + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + Request.QueryString["last"].ToString() + "' as datetime),120) ) ";
            }
            else
            {
                SqlKq = "";
            }




            if (!Page.IsPostBack)
            {
                BindAttribute();
                Bindquanxian();
                DataBindToGridview("order by id desc");

                string SQL_GetList = "select * from qp_WorkTime   where QyType='启用' and  (CHARINDEX('," + Request.QueryString["user"].ToString() + ",',','+SyUsername+',')   >   0 ) ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    DjType_1 = NewReader["DjType_1"].ToString();


                    DjType_2 = NewReader["DjType_2"].ToString();
                    DjType_3 = NewReader["DjType_3"].ToString();
                    DjType_4 = NewReader["DjType_4"].ToString();

                    DjType_5 = NewReader["DjType_5"].ToString();
                    DjType_6 = NewReader["DjType_6"].ToString();


                    DjTime_1 = NewReader["DjTime_1"].ToString();
                    DjTime_2 = NewReader["DjTime_2"].ToString();
                    DjTime_3 = NewReader["DjTime_3"].ToString();
                    DjTime_4 = NewReader["DjTime_4"].ToString();
                    DjTime_5 = NewReader["DjTime_5"].ToString();
                    DjTime_6 = NewReader["DjTime_6"].ToString();
                }


            }

        }

        public void Bindquanxian()
        {
            List.QuanXianVis(GridView1, "eeee9a", Session["perstr"].ToString());
        }

        public void BindAttribute()
        {
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
          
        }


        public void DataBindToGridview(string Sqlsort)
        {

 

            if (List.StrIFInStr("eeaee9a1", Session["perstr"].ToString()))
            {
                if (Request.QueryString["type"] == "cd")
                {
                    filename = "迟到";
                    string SQL_GetCount = "select count(id) from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and  (DjState_1='迟到' or DjState_2='迟到' or DjState_3='迟到' or DjState_4='迟到' or DjState_5='迟到' or DjState_6='迟到') " + SqlKq + " ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    string SQL_GetList_xs = "select * from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and  (DjState_1='迟到' or DjState_2='迟到' or DjState_3='迟到' or DjState_4='迟到' or DjState_5='迟到' or DjState_6='迟到') " + SqlKq + " " + Sqlsort + "";

                    
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                

                }

                if (Request.QueryString["type"] == "zt")
                {
                    filename = "早退";
                    string SQL_GetCount = "select count(id) from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and  (DjState_1='早退' or DjState_2='早退' or DjState_3='早退' or DjState_4='早退' or DjState_5='早退' or DjState_6='早退') " + SqlKq + " ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    string SQL_GetList_xs = "select * from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and   (DjState_1='早退' or DjState_2='早退' or DjState_3='早退' or DjState_4='早退' or DjState_5='早退' or DjState_6='早退') " + SqlKq + " " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                }


                if (Request.QueryString["type"] == "wkq")
                {
                    filename = "未考勤";
                    string SQL_GetCount = "select count(id)  from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and  (DjState_1='未考勤' or DjState_2='未考勤' or DjState_3='未考勤' or DjState_4='未考勤' or DjState_5='未考勤' or DjState_6='未考勤') " + SqlKq + " ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    string SQL_GetList_xs = "select * from qp_WorkTimeDj where 1=1 and DjUsername='" + Request.QueryString["user"].ToString() + "' and  (DjState_1='未考勤' or DjState_2='未考勤' or DjState_3='未考勤' or DjState_4='未考勤' or DjState_5='未考勤' or DjState_6='未考勤') " + SqlKq + "  " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                }



            } //公司

      





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


            //DataBindToGridview(sql);



            DataBindToGridview(sql);


        }




        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
                //DataBindToGridview("order by id desc");


                DataBindToGridview("order by id desc");


            }
            catch
            {

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
                // DataBindToGridview("order by id desc");

                DataBindToGridview("order by id desc");


            }
            catch
            {


                DataBindToGridview("order by id desc");



                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }



        protected void Button2_Click1(object sender, EventArgs e)
        {
            //Response.Redirect("TjProject.aspx?key=1&Realname=" + Realname.Text + "&Unit=" + Unit.Text + "&start=" + StartTime.Text + "&last=" + EndTime.Text + "");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("TjProject.aspx?realname=&unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + "");
        }





    }
}

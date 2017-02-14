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
    public partial class TjProject : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public  string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, SqlUser, SqlKq, SqlPro;



        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

           
            if (Request.QueryString["Realname"] != "")
            {
                SqlUser += " and Realname like '%" + List.GetFormatStr(Request.QueryString["Realname"]) + "%'";
            }
      

      
            if (Request.QueryString["Unit"] != "")
            {
                SqlUser += " and Unit like '%" + List.GetFormatStr(Request.QueryString["Unit"]) + "%'";
            }
      

      
            if (Request.QueryString["start"] != "" && Request.QueryString["last"] != "")
            {
                SqlKq = " and (Djtime between '" + Request.QueryString["start"].ToString() + "'and  '" + Request.QueryString["last"].ToString() + "' or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["start"].ToString() + "' as datetime),120) or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["last"].ToString() + "' as datetime),120) ) ";

                SqlPro = " and (StartTime between '" + Request.QueryString["start"].ToString() + "'and  '" + Request.QueryString["last"].ToString() + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + Request.QueryString["start"].ToString() + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + Request.QueryString["last"].ToString() + "' as datetime),120) ) ";
            }
          

         

            if (!Page.IsPostBack)
            {
                BindAttribute();
                Bindquanxian();
                DataBindToGridview("order by id desc");
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
            Button2.Attributes["onclick"] = "javascript:return showwait();";

            StartTime.Attributes.Add("readonly", "readonly");
            EndTime.Attributes.Add("readonly", "readonly");
        }


        public void DataBindToGridview(string Sqlsort)
        {

            if (List.StrIFInStr("eeaee9a1", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_Username   where 1=1";
                SqlStrStartCount = "select count(id) from qp_Username   where 1=1";
            }

            SqlStrMid = string.Empty;
            SqlStrMid = SqlUser;
            SqlStr = SqlStrStart + SqlStrMid;//查询
            SqlStrCount = SqlStrStartCount + SqlStrMid;//查询个数


            if (Request.QueryString["key"] != null)
            {
                string SQL_GetList_xs = "" + SqlStr + " " + Sqlsort + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
                string SQL_GetCount = SqlStrCount;
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
            }

            else
            {

                if (List.StrIFInStr("eeaee9a1", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_Username   ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                    string SQL_GetList_xs = "select * from qp_Username    " + Sqlsort + "";
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


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label User_n = (Label)e.Row.FindControl("LUser");

                Label Chidao_n = (Label)e.Row.FindControl("Chidao");
                Label ZaoTui_n = (Label)e.Row.FindControl("ZaoTui");
                Label WeiKaoQin_n = (Label)e.Row.FindControl("WeiKaoQin");
                Label ChuChai_n = (Label)e.Row.FindControl("ChuChai");
                Label JiaBan_n = (Label)e.Row.FindControl("JiaBan");
                Label BingJia_n = (Label)e.Row.FindControl("BingJia");
                Label ShiJia_n = (Label)e.Row.FindControl("ShiJia");



                Chidao_n.Text = null;
                ZaoTui_n.Text = null;
                WeiKaoQin_n.Text = null;
                ChuChai_n.Text = null;
                JiaBan_n.Text = null;
                BingJia_n.Text = null;
                ShiJia_n.Text = null;





                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_1 = List.GetCount(SQL_GetList_cd_1);
                //Response.Write(SQL_GetList_cd_1);

                string SQL_GetList_cd_2 = "select count(*) as counts from qp_WorkTimeDj where DjState_2='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_2 = List.GetCount(SQL_GetList_cd_2);

                string SQL_GetList_cd_3 = "select count(*) as counts from qp_WorkTimeDj where DjState_3='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_3 = List.GetCount(SQL_GetList_cd_3);

                string SQL_GetList_cd_4 = "select count(*) as counts from qp_WorkTimeDj where DjState_4='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_4 = List.GetCount(SQL_GetList_cd_4);

                string SQL_GetList_cd_5 = "select count(*) as counts from qp_WorkTimeDj where DjState_5='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_5 = List.GetCount(SQL_GetList_cd_5);

                string SQL_GetList_cd_6 = "select count(*) as counts from qp_WorkTimeDj where DjState_6='迟到' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_cd_6 = List.GetCount(SQL_GetList_cd_6);

                int alldelpoint_cd = alldelpoint_cd_1 + alldelpoint_cd_2 + alldelpoint_cd_3 + alldelpoint_cd_4 + alldelpoint_cd_5 + alldelpoint_cd_6;


                Chidao_n.Text = "<a href=TjProject_kq.aspx?user=" + User_n.Text + "&type=cd&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + alldelpoint_cd + "</a>";
                //迟到



                string SQL_GetList_zt_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='早退'and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_1 = List.GetCount(SQL_GetList_zt_1);


                string SQL_GetList_zt_2 = "select count(*) as counts from qp_WorkTimeDj where DjState_2='早退' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_2 = List.GetCount(SQL_GetList_zt_2);

                string SQL_GetList_zt_3 = "select count(*) as counts from qp_WorkTimeDj where DjState_3='早退' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_3 = List.GetCount(SQL_GetList_zt_3);

                string SQL_GetList_zt_4 = "select count(*) as counts from qp_WorkTimeDj where DjState_4='早退' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_4 = List.GetCount(SQL_GetList_zt_4);

                string SQL_GetList_zt_5 = "select count(*) as counts from qp_WorkTimeDj where DjState_5='早退'and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_5 = List.GetCount(SQL_GetList_zt_5);

                string SQL_GetList_zt_6 = "select count(*) as counts from qp_WorkTimeDj where DjState_6='早退' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_zt_6 = List.GetCount(SQL_GetList_zt_6);

                int alldelpoint_zt = alldelpoint_zt_1 + alldelpoint_zt_2 + alldelpoint_zt_3 + alldelpoint_zt_4 + alldelpoint_zt_5 + alldelpoint_zt_6;


                ZaoTui_n.Text = "<a href=TjProject_kq.aspx?user=" + User_n.Text + "&type=zt&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + alldelpoint_zt + "</a>";
                //早退



                string SQL_GetList_wkq_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='未考勤' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_1 = List.GetCount(SQL_GetList_wkq_1);

                string SQL_GetList_wkq_2 = "select count(*) as counts from qp_WorkTimeDj where DjState_2='未考勤' and DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_2 = List.GetCount(SQL_GetList_wkq_2);

                string SQL_GetList_wkq_3 = "select count(*) as counts from qp_WorkTimeDj where DjState_3='未考勤' and  DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_3 = List.GetCount(SQL_GetList_wkq_3);

                string SQL_GetList_wkq_4 = "select count(*) as counts from qp_WorkTimeDj where DjState_4='未考勤' and  DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_4 = List.GetCount(SQL_GetList_wkq_4);


                string SQL_GetList_wkq_5 = "select count(*) as counts from qp_WorkTimeDj where DjState_5='未考勤' and  DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_5 = List.GetCount(SQL_GetList_wkq_5);


                string SQL_GetList_wkq_6 = "select count(*) as counts from qp_WorkTimeDj where DjState_6='未考勤' and  DjUsername='" + User_n.Text + "'" + SqlKq + "";
                int alldelpoint_wkq_6 = List.GetCount(SQL_GetList_wkq_6);

                int alldelpoint_wkq = alldelpoint_wkq_1 + alldelpoint_wkq_2 + alldelpoint_wkq_3 + alldelpoint_wkq_4 + alldelpoint_wkq_5 + alldelpoint_wkq_6;
                WeiKaoQin_n.Text = "<a href=TjProject_kq.aspx?user=" + User_n.Text + "&type=wkq&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + alldelpoint_wkq + "</a>";


                //未考勤


                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where Username='" + User_n.Text + "' and  Shenpi='已通过'  and  Type='3'  " + SqlPro + "";
                //int alldelpoint_cc = List.GetCount(SQL_GetList_cc);//出差
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        ChuChai_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=3&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";

                    }
                    else
                    {
                        ChuChai_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=3&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + NewReader_cc["counts"] + "</a>";


                    }

                }
                else
                {
                    ChuChai_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=3&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";
                }
                NewReader_cc.Close();







                string SQL_GetList_jb = "select sum(DiffTime) as counts from qp_MyAttendance where Username='" + User_n.Text + "' and  Shenpi='已通过'  and  Type='4'  " + SqlPro + "";
                SqlDataReader NewReader_jb = List.GetList(SQL_GetList_jb);
                if (NewReader_jb.Read())
                {
                    if (NewReader_jb["counts"].ToString() == "")
                    {
                        JiaBan_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=4&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";

                    }
                    else
                    {
                        JiaBan_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=4&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + NewReader_jb["counts"] + "</a>";

                    }
                }
                else
                {
                    JiaBan_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=4&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";
                }
                NewReader_jb.Close();







                string SQL_GetList_bj = "select sum(DiffTime) as counts from qp_MyAttendance where Username='" + User_n.Text + "' and  Shenpi='已通过'  and  Type='1'  " + SqlPro + "";
                SqlDataReader NewReader_bj = List.GetList(SQL_GetList_bj);
                if (NewReader_bj.Read())
                {
                    if (NewReader_bj["counts"].ToString() == "")
                    {
                        BingJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=1&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";

                    }
                    else
                    {
                        BingJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=1&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + NewReader_bj["counts"] + "</a>";

                    }

                }
                else
                {
                    BingJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=1&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";
                }

                NewReader_bj.Close();



                string SQL_GetList_sj = "select sum(DiffTime) as counts from qp_MyAttendance where Username='" + User_n.Text + "' and  Shenpi='已通过'  and  Type='2'  " + SqlPro + "";
                SqlDataReader NewReader_sj = List.GetList(SQL_GetList_sj);
                if (NewReader_sj.Read())
                {
                    if (NewReader_sj["counts"].ToString() == "")
                    {
                        ShiJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=2&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";

                    }
                    else
                    {
                        
                        ShiJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=2&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">" + NewReader_sj["counts"] + "</a>";
                    }

                }
                else
                {
                    ShiJia_n.Text = "<a href=TjProject_xm.aspx?user=" + User_n.Text + "&type=2&Unit=" + Request.QueryString["unit"].ToString() + "&start=" + Request.QueryString["start"].ToString() + "&last=" + Request.QueryString["last"].ToString() + ">0</a>";
                }
                NewReader_sj.Close();
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
            Response.Redirect("TjProject.aspx?key=1&Realname=" + Realname.Text + "&Unit=" + Unit.Text + "&start=" + StartTime.Text + "&last=" + EndTime.Text + "");
           
        }





    }
}

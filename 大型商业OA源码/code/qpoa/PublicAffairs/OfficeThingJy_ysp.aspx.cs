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
    public partial class OfficeThingJy_ysp : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Name"] != null)
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
                }

                if (Request.QueryString["Shenpi"] != null)
                {
                    MidSql = MidSql + " and Shenpi like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Shenpi"])) + "%'";
                }

                if (Request.QueryString["SpRealname"] != null)
                {
                    MidSql = MidSql + " and SpRealname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["SpRealname"])) + "%'";
                }

                if (Request.QueryString["Startime"] != null && Request.QueryString["Endtime"] != null)
                {
                    MidSql = MidSql + " and (SpTimes between '" + Request.QueryString["Startime"] + "'and  '" + Request.QueryString["Endtime"] + "' or convert(char(10),cast(SpTimes as datetime),120)=convert(char(10),cast('" + Request.QueryString["Startime"] + "' as datetime),120) or convert(char(10),cast(SpTimes as datetime),120)=convert(char(10),cast('" + Request.QueryString["Endtime"] + "' as datetime),120) ) ";

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

            //List.QuanXianVis(ImageButton1, "cccc2b1b", Session["perstr"].ToString());
            //List.QuanXianVis(ImageButton6, "cccc2b1c", Session["perstr"].ToString());
            //List.QuanXianVis(ImageButton2, "cccc2b1d", Session["perstr"].ToString());
            //List.QuanXianVis(ImageButton3, "cccc2b1e", Session["perstr"].ToString());
            //List.QuanXianVis(IMG1, "cccc2b1i", Session["perstr"].ToString());
            //List.QuanXianVis(ImageButton4, "cccc2b1f", Session["perstr"].ToString());


        }

        public void BindAttribute()
        {

            //ImageButton2.Attributes["onclick"] = "javascript:return updatecheck();";
            //ImageButton1.Attributes["onclick"] = "javascript:return showwait();";
            //ImageButton3.Attributes["onclick"] = "javascript:return delcheck();";
            if (Request.QueryString["key"] != null)
            {

                ImageButton4.Attributes["onclick"] = "javascript:return outexcels();";
            }
            else
            {
                ImageButton4.Attributes["onclick"] = "javascript:return outexcel();";
            }

            //ImageButton6.Attributes["onclick"] = "javascript:return updatecheck();";
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {

            SqlStrStart = "select * from qp_OfficeThingJy where 1=1 and  (Shenpi='已通过' or Shenpi='未通过'  or Shenpi='放弃审批')";
            SqlStrStartCount = "select count(id) from qp_OfficeThingJy where 1=1 and  (Shenpi='已通过' or Shenpi='未通过'  or Shenpi='放弃审批')";




            SqlStrMid = string.Empty;
            SqlStrMid = CreateMidSql();
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

                string SQL_GetCount = "select count(id) from  qp_OfficeThingJy where  (Shenpi='已通过' or Shenpi='未通过'  or Shenpi='放弃审批')";
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                string SQL_GetList_xs = "select * from qp_OfficeThingJy where (Shenpi='已通过' or Shenpi='未通过'  or Shenpi='放弃审批') " + Sqlsort + "";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();


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

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return confirm('确认放弃[" + e.Row.Cells[0].Text.ToString() + "]的操作，放弃操作库存将回滚到操作前的状态？')");


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






        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {

                int ID = Convert.ToInt32(e.CommandArgument);




                string SQL_GetList = "select * from qp_OfficeThingJy where id='" + ID + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    if (NewReader["Shenpi"].ToString() == "放弃审批" || NewReader["Shenpi"].ToString() == "未通过")
                    {
                        this.Response.Write("<script language=javascript>alert('操作失败！当前状态已经为[" + NewReader["Shenpi"].ToString() + "]！');</script>");
                        return;
                    }
                    else
                    {
                        string Sql_updatesp = "Update qp_OfficeThingJy  Set Shenpi='放弃审批',SpUsername='" + Session["Username"] + "',SpRealname='" + Session["Realname"] + "',SpTimes='" + System.DateTime.Now.ToString() + "' where ID='" + ID + "'";
                        List.ExeSql(Sql_updatesp);

                        string Sql_update1 = "Update qp_OfficeThing  Set Inventory=Inventory+" + NewReader["ShuLiang"] + " where Id='" + NewReader["NameId"] + "'";
                        List.ExeSql(Sql_update1);

                        DataBindToGridview("order by id desc");

                        InsertLog("放弃办公用品[" + NewReader["Name"] + "]借用，数量[" + NewReader["ShuLiang"] + "]", "审批办公用品借用");

                    }


                }
                NewReader.Close();




            }
        }




    }
}

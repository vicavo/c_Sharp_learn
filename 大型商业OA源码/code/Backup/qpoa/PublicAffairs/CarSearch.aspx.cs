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
    public partial class CarSearch : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["CarNum"] != null)
                {
                    MidSql = MidSql + " and CarNum like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["CarNum"])) + "%'";
                }


                if (Request.QueryString["Drivers"] != null)
                {
                    MidSql = MidSql + " and Drivers like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Drivers"])) + "%'";
                }

                if (Request.QueryString["Carpeople"] != null)
                {
                    MidSql = MidSql + " and Carpeople like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Carpeople"])) + "%'";
                }

                if (Request.QueryString["UnitName"] != null)
                {
                    MidSql = MidSql + " and UnitName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["UnitName"])) + "%'";
                }
                if (Request.QueryString["Destination"] != null)
                {
                    MidSql = MidSql + " and Destination like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Destination"])) + "%'";
                }
                if (Request.QueryString["ManagerName"] != null)
                {
                    MidSql = MidSql + " and ManagerName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["ManagerName"])) + "%'";
                }


                if (Request.QueryString["Startime"] != null)
                {
                    MidSql = MidSql + " and (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + Request.QueryString["Startime"] + "' as datetime),120) ) ";

                }

                if (Request.QueryString["Endtime"] != null)
                {
                    MidSql = MidSql + " and (convert(char(10),cast(Endtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["Endtime"] + "' as datetime),120) ) ";

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

            //List.QuanXianVis(ImageButton1, "cccc5a", Session["perstr"].ToString());

            List.QuanXianVis(IMG1, "cccc5b", Session["perstr"].ToString());
           //List.QuanXianVis(ImageButton4, "cccc5a", Session["perstr"].ToString());


        }

        public void BindAttribute()
        {
            //ImageButton1.Attributes["onclick"] = "javascript:return showwait();";
            //if (Request.QueryString["key"] != null)
            //{

            //    ImageButton4.Attributes["onclick"] = "javascript:return outexcels();";
            //}
            //else
            //{
            //    ImageButton4.Attributes["onclick"] = "javascript:return outexcel();";
            //}


            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {
            if (List.StrIFInStr("cc5cc5b1", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_CarApply  where  State='使用中' and 1=1";
                SqlStrStartCount = "select count(id) from qp_CarApply  where  State='使用中' and  1=1";

            }


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
                if (List.StrIFInStr("cc5cc5a1", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_CarApply  where  State='使用中' ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_CarApply   where  State='使用中'  " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人


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


            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{

            //    LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
            //    l.Attributes.Add("onclick", "javascript:return confirm('确认删除车辆申请[" + e.Row.Cells[0].Text.ToString() + "]吗？')");


            //}
        }





        private string CheckCbxUpdate()
        {
            string str = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                CheckBox Chk = (CheckBox)row.FindControl("CheckSelect");
                Label LabVis = (Label)row.FindControl("LabVisible");
                if (Chk.Checked == true)
                {
                    if (str == "")
                    {
                        str = LabVis.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + LabVis.Text.ToString();
                    }
                }
            }
            return str;
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


        //protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        //{
        //    Response.Redirect("CarApply_add.aspx");
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "ShanChu")
            //{

            //    int ID = Convert.ToInt32(e.CommandArgument);

            //    string SQL_GetList = "select * from qp_CarApply where id='" + ID + "'";
            //    SqlDataReader NewReader = List.GetList(SQL_GetList);
            //    if (NewReader.Read())
            //    {
            //        if (NewReader["State"].ToString() == "已通过" || NewReader["State"].ToString() == "使用中" || NewReader["State"].ToString() == "已结束")
            //        {
            //            this.Response.Write("<script language=javascript>alert('操作失败！当前状态已经为[" + NewReader["State"].ToString() + "]！');</script>");
            //            return;
            //        }
            //        else
            //        {

            //            string SqlStr = "  Delete from qp_CarApply where ID='" + ID + "'";
            //            List.ExeSql(SqlStr);

            //            DataBindToGridview("order by id desc");

            //            InsertLog("删除车辆申请[" + NewReader["CarNum"] + "]", "车辆申请");

            //        }


            //    }
            //    NewReader.Close();


            //}
        }




    }
}

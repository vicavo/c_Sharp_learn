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
namespace qpoa.FilesManage
{
    public partial class FilesManageAjTj : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Number"] != null)
                {
                    MidSql = MidSql + " and Number like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Number"])) + "%'";
                }


                if (Request.QueryString["Name"] != null)
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
                }

                if (Request.QueryString["RoomName"] != null)
                {
                    MidSql = MidSql + " and RoomName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["RoomName"])) + "%'";
                }


                if (Request.QueryString["UnitName"] != null)
                {
                    MidSql = MidSql + " and UnitName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["UnitName"])) + "%'";
                }

                if (Request.QueryString["BzPost"] != null)
                {
                    MidSql = MidSql + " and BzPost like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["BzPost"])) + "%'";
                }


                if (Request.QueryString["BgTime"] != null)
                {
                    MidSql = MidSql + " and BgTime like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["BgTime"])) + "%'";
                }

                if (Request.QueryString["QuanZong"] != null)
                {
                    MidSql = MidSql + " and QuanZong like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["QuanZong"])) + "%'";
                }


                if (Request.QueryString["Mulu"] != null)
                {
                    MidSql = MidSql + " and Mulu like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Mulu"])) + "%'";
                }


                if (Request.QueryString["DaGuan"] != null)
                {
                    MidSql = MidSql + " and DaGuan like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["DaGuan"])) + "%'";
                }


                if (Request.QueryString["BaoXian"] != null)
                {
                    MidSql = MidSql + " and BaoXian like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["BaoXian"])) + "%'";
                }

                if (Request.QueryString["SuoWei"] != null)
                {
                    MidSql = MidSql + " and SuoWei like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["SuoWei"])) + "%'";
                }


                if (Request.QueryString["PinZheng"] != null)
                {
                    MidSql = MidSql + " and PinZheng like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["PinZheng"])) + "%'";
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

            List.QuanXianVis(IMG1, "hhhh5b", Session["perstr"].ToString());
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

            if (List.StrIFInStr("hhhh5b", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_FilesManage  where 1=1 ";
                SqlStrStartCount = "select count(id) from qp_FilesManage  where 1=1 ";
            }



            SqlStrMid = string.Empty;
            SqlStrMid = CreateMidSql();
            SqlStr = SqlStrStart + SqlStrMid;//查询
            SqlStrCount = SqlStrStartCount + SqlStrMid;//查询个数

            if (Request.QueryString["key"] != null)
            {
                string SQL_GetList_xs = "" + SqlStr + " " + Sqlsort + "";
                // Response.Write(SQL_GetList_xs);
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

                string SQL_GetCount = SqlStrCount;
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            }
            else
            {
                if (List.StrIFInStr("hhhh5b", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_FilesManage";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_FilesManage   " + Sqlsort + "";
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
                Label ln = (Label)e.Row.FindControl("HyId");

                Label ll4 = (Label)e.Row.FindControl("Label4");
              

                string SQL_GetCount = "select count(id) from  qp_FilesManageBookLog  where  AJId='" + ln.Text + "'";
                string CountsLabel = "" + List.GetCount(SQL_GetCount) + "";


                string SQL_GetCount1 = "select count(id) from  qp_FilesManageBook  where  FilesId='" + ln.Text + "'";
                string CountsLabel1 = "" + List.GetCount(SQL_GetCount1) + "";



                ll4.Text = "" + CountsLabel1 + "/" + CountsLabel + "";

               



            }

        }
        private string CheckCbxDel()
        {
            string str = "0";
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


        private string CheckCbxNameDel()
        {
            string str = string.Empty;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                CheckBox Chk = (CheckBox)row.FindControl("CheckSelect");
                Label LabVis = (Label)row.FindControl("LabNameVisible");
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

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string CheckStr = CheckCbxDel();

            string SqlStr = "  Delete from qp_FilesManageBook  where ID in (" + CheckStr + ")";
            List.ExeSql(SqlStr);

            InsertLog("删除文件管理[" + CheckCbxNameDel() + "]", "文件管理");

            DataBindToGridview("order by id desc");

        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("FilesManageBook_update.aspx?id=" + CheckCbxUpdate() + "");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FilesManageBook_add.aspx");
        }



        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("FilesManageBook_show.aspx?id=" + CheckCbxUpdate() + "");
        }



    }
}

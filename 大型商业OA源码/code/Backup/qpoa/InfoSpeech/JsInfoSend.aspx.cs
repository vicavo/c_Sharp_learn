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
namespace qpoa.InfoSpeech
{
    public partial class JsInfoSend : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, XMStr;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Title"] != null)
                {
                    MidSql = MidSql + " and Title like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Title"])) + "%'";
                }

                if (Request.QueryString["Content"] != null)
                {
                    MidSql = MidSql + " and Content like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Content"])) + "%'";
                }

                if (Request.QueryString["Settime"] != null)
                {
                    MidSql = MidSql + " and (convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + Request.QueryString["Settime"] + "' as datetime),120) ) ";

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
                DataBindToGridview("order by qp_InfoSend.id desc");
                Bindquanxian();

            }

        }

        public void Bindquanxian()
        {
         
            List.QuanXianVis(IMG1, "dddd8", Session["perstr"].ToString());
            List.QuanXianVis(GridView1, "dddd8", Session["perstr"].ToString());


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

            if (List.StrIFInStr("dddd8", Session["perstr"].ToString()))
            {
                SqlStrStart = "select qp_InfoSend.id as Gid,qp_InfoSend.Title,qp_InfoSend.State as GState,qp_InfoSendJsr.QrUsername,qp_InfoSendJsr.State,qp_InfoSend.Settime as LSettime from qp_InfoSend,qp_InfoSendJsr where qp_InfoSendJsr.QrUsername='" + Session["username"] + "'  and qp_InfoSendJsr.KeyField=qp_InfoSend.Number  and  qp_InfoSend.State='正在传阅'  and  (qp_InfoSendJsr.State='未开封' or qp_InfoSendJsr.State='已开封')  and 1=1";
                SqlStrStartCount = "select count(qp_InfoSend.id) from qp_InfoSend,qp_InfoSendJsr where  qp_InfoSendJsr.Username='" + Session["username"] + "'  and qp_InfoSendJsr.KeyField=qp_InfoSend.Number  and  qp_InfoSend.State='正在传阅'  and  (qp_InfoSendJsr.State='未开封' or qp_InfoSendJsr.State='已开封')   and 1=1";
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

                if (List.StrIFInStr("dddd8", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(qp_InfoSend.id) from  qp_InfoSend,qp_InfoSendJsr where qp_InfoSendJsr.Username='" + Session["username"] + "'  and qp_InfoSendJsr.KeyField=qp_InfoSend.Number  and  qp_InfoSend.State='正在传阅'  and  (qp_InfoSendJsr.State='未开封' or qp_InfoSendJsr.State='已开封')  ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select qp_InfoSend.id as Gid,qp_InfoSend.Title,qp_InfoSend.State as GState,qp_InfoSendJsr.QrUsername,qp_InfoSendJsr.State,qp_InfoSend.Settime as LSettime from qp_InfoSend,qp_InfoSendJsr where qp_InfoSendJsr.QrUsername='" + Session["username"] + "'  and qp_InfoSendJsr.KeyField=qp_InfoSend.Number  and  qp_InfoSend.State='正在传阅'  and  (qp_InfoSendJsr.State='未开封' or qp_InfoSendJsr.State='已开封')  " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }

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

            sql = " order by qp_InfoSend." + e.SortExpression + ViewState["SortDirection"];


            DataBindToGridview(sql);
        }




        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
                DataBindToGridview("order by qp_InfoSend.id desc");
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
                DataBindToGridview("order by qp_InfoSend.id desc");
            }
            catch
            {
                DataBindToGridview("order by qp_InfoSend.id desc");
                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }



    }
}

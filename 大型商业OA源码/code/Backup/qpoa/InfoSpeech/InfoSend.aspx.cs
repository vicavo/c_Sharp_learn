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
    public partial class InfoSend : System.Web.UI.Page
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
                DataBindToGridview("order by id desc");
                Bindquanxian();

            }

        }

        public void Bindquanxian()
        {
            List.QuanXianVis(ImageButton1, "dddd8", Session["perstr"].ToString());
            List.QuanXianVis(IMG1, "dddd8", Session["perstr"].ToString());
            List.QuanXianVis(GridView1, "dddd8", Session["perstr"].ToString());


        }

        public void BindAttribute()
        {

            ImageButton1.Attributes["onclick"] = "javascript:return showwait();";
            

          
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
                SqlStrStart = "select * from qp_InfoSend where Username='" + Session["username"] + "'  and 1=1";
                SqlStrStartCount = "select count(id) from qp_InfoSend where Username='" + Session["username"] + "'  and 1=1";
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
                    string SQL_GetCount = "select count(id) from  qp_InfoSend where Username='" + Session["username"] + "'";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_InfoSend where Username='" + Session["username"] + "'  " + Sqlsort + "";
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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l1 = (LinkButton)e.Row.FindControl("Shanchu");
                LinkButton l2 = (LinkButton)e.Row.FindControl("ZtOrQd");
               
                l1.Attributes.Add("onclick", "javascript:return confirm('确认删除吗？')");



                if (e.Row.Cells[1].Text.ToString() == "正在传阅")
                {
                    l2.Attributes.Add("onclick", "javascript:return confirm('确认暂停传阅吗？如果再重新启动，所有接收人将会重新阅读文件。')");
                    l2.Visible = true;
                }
                else if (e.Row.Cells[1].Text.ToString() == "暂停传阅")
                {
                    l2.Attributes.Add("onclick", "javascript:return confirm('确认重新启动传阅吗？重新启动，所有接收人将会重新阅读文件。')");
                    l2.Visible = true;
                }
                else
                {
                    l2.Visible = false;
                }
              


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




        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InfoSend_add.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "ZtOrQd")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string SQL_GetList = "select * from qp_InfoSend where id='" + ID + "' and  State='正在传阅'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string Sql_update = "Update qp_InfoSend  Set State='暂停传阅'  where id='" + ID + "'";
                    List.ExeSql(Sql_update);

                    this.Response.Write("<script language=javascript>alert('暂停成功！');</script>");
                }
                else
                {

                    string SQL_GetList1 = "select * from qp_InfoSend where id='" + ID + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        string Sql_update = "Update qp_InfoSend  Set State='正在传阅'  where id='" + ID + "'";
                        List.ExeSql(Sql_update);


                        string Sql_update1 = "Update qp_InfoSendJsr  Set QrContent='未开封', QrTime='未开封', State='未开封'  where KeyField='" + NewReader1["Number"] + "'";
                        List.ExeSql(Sql_update1);


                        this.Response.Write("<script language=javascript>alert('启动成功！');</script>");
                    }
                    NewReader1.Close();
                }
             

                DataBindToGridview("order by id desc");
            }


            if (e.CommandName == "Shanchu")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string Sql_del = "delete from qp_InfoSend where id='" + ID + "'";
                List.ExeSql(Sql_del);

                DataBindToGridview("order by id desc");
            }




        }


    }
}

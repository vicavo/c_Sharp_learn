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
namespace qpoa.KmManage
{
    public partial class KmSearch : System.Web.UI.Page
    {
        Db List = new Db();
        public static string KeyStr, TitleStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
                return;

            }

            Button1.Attributes["onclick"] = "javascript:return chknull();";

            if (!Page.IsPostBack)
            {
                Title.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button1.click(); return false;}";

                if (Request.QueryString["Key"].ToString() == "1")
                {
                    KeyStr = "知识标题";
                    TitleStr=""+Server.UrlDecode(Request.QueryString["str"])+"";
                }

                else if (Request.QueryString["Key"].ToString() == "2")
                {
                    KeyStr = "知识描述";
                    TitleStr = "" + Server.UrlDecode(Request.QueryString["str"]) + "";
                }

                else if (Request.QueryString["Key"].ToString() == "3")
                {
                    KeyStr = "作者";
                    TitleStr = "" + Server.UrlDecode(Request.QueryString["str"]) + "";
                }

                else if (Request.QueryString["Key"].ToString() == "4")
                {
                    KeyStr = "关键字";
                    TitleStr = "" + Server.UrlDecode(Request.QueryString["str"]) + "";
                }

                else if (Request.QueryString["Key"].ToString() == "5")
                {
                    KeyStr = "综合搜索";
                    TitleStr = "" + Server.UrlDecode(Request.QueryString["str"]) + "";
                }
                else
                {
                    KeyStr = "无";
                    TitleStr = "无";
                }
                DataBindToGridview(Request.QueryString["Key"]);
            }

          

        }

        public void DataBindToGridview(string key)
        {
            if (key == "1")
            {
                string SQL_GetList_xs = "select * from qp_KmTitle where Title like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  and ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and State='正常' order by id desc";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (key == "2")
            {
                string SQL_GetList_xs = "select * from qp_KmTitle where Content like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  and ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and State='正常' order by id desc";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (key == "3")
            {
                string SQL_GetList_xs = "select * from qp_KmTitle where Realname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  and ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and State='正常' order by id desc";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (key == "4")
            {
                string SQL_GetList_xs = "select * from qp_KmTitle where KeyWord like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  and ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and State='正常' order by id desc";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }

            if (key == "5")
            {
                string SQL_GetList_xs = "select * from qp_KmTitle where (KeyWord like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%' or KeyWord like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  or Realname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'   or Content like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%'  or  Title like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["str"])) + "%')  and ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and State='正常' order by id desc";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmSearch.aspx?Key=" + RadioList.SelectedValue + "&str=" + Title.Text +"");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview(Request.QueryString["Key"]);
        }
    }


}

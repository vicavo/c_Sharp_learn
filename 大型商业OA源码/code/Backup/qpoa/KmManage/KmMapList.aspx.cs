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
    public partial class KmMapList : System.Web.UI.Page
    {

        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, Namefile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_KmLittleType   where  id='" + Request.QueryString["LittleId"] + "'  ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Namefile = NewReader["Name"].ToString();
                }
                NewReader.Close();

                BindAttribute();
                DataBindToGridview("order by LastTime desc");
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(GridView1, "jjjj5", Session["perstr"].ToString());
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

            string SQL_GetCount = "select count(id) from  qp_KmTitle where ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 ) or QxYdUsername='全部用户')  and  LittleId='" + Request.QueryString["LittleId"] + "'";
            CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            string SQL_GetList_xs = "select * from qp_KmTitle where  ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 ) or QxYdUsername='全部用户')   and  LittleId='" + Request.QueryString["LittleId"] + "' " + Sqlsort + "";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();


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

                LinkButton l1 = (LinkButton)e.Row.FindControl("TuiJian");
                LinkButton l2 = (LinkButton)e.Row.FindControl("DingYue");
                LinkButton l3 = (LinkButton)e.Row.FindControl("ShouCang");
                l1.Attributes.Add("onclick", "javascript:return confirm('确认推荐知识[" + e.Row.Cells[1].Text.ToString() + "]吗？每天只能推荐3次')");
                l2.Attributes.Add("onclick", "javascript:return confirm('确认订阅知识[" + e.Row.Cells[1].Text.ToString() + "]吗？')");
                l3.Attributes.Add("onclick", "javascript:return confirm('确认收藏知识[" + e.Row.Cells[1].Text.ToString() + "]吗？')");

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


        protected void b1_Click(object sender, EventArgs e)
        {
            Response.Redirect("gridview_add.aspx");
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
                DataBindToGridview("order by LastTime desc");
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
                DataBindToGridview("order by LastTime desc");
            }
            catch
            {
                DataBindToGridview("order by LastTime desc");
                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TuiJian")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string SQL_GetCount = "select count(KmId) from  qp_KmTjNum where  Username='" + Session["username"] + "' and convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + System.DateTime.Now.ToShortDateString() + "' as datetime),120) ";
                string CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                if (int.Parse(CountsLabel) >= 3)
                {
                    this.Response.Write("<script language=javascript>alert('你今天３次推荐票已使用完，请明天再行推荐');</script>");
                    return;
                }

                string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+TjUsername+',') > 0 ) ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1  where id='" + ID + "'";
                    List.ExeSql(Sql_update);

                    this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
                }

                else
                {
                    string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1 ,TjUsername=TjUsername+'" + Session["username"] + ",',TjRealname=TjRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                    List.ExeSql(Sql_update);

                    this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
                }


                string sql_insert = "insert into qp_KmTjNum (KmId,Username,Realname,Settime) values ('" + ID + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert);

                NewReader.Close();

                DataBindToGridview("order by LastTime desc");

            }



            if (e.CommandName == "DingYue")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+DyUsername+',') > 0 ) ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    this.Response.Write("<script language=javascript>alert('已订阅！');</script>");
                    return;
                }
                else
                {
                    string Sql_update = "Update qp_KmTitle  Set DyNum=DyNum+1 ,DyUsername=DyUsername+'" + Session["username"] + ",',DyRealname=DyRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                    List.ExeSql(Sql_update);

                    this.Response.Write("<script language=javascript>alert('订阅成功！');</script>");
                }
                NewReader.Close();

                DataBindToGridview("order by LastTime desc");
            }


            if (e.CommandName == "ShouCang")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+ScUsername+',') > 0 ) ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    this.Response.Write("<script language=javascript>alert('已收藏！');</script>");
                    return;
                }
                else
                {
                    string Sql_update = "Update qp_KmTitle  Set ScNum=ScNum+1 ,ScUsername=ScUsername+'" + Session["username"] + ",',ScRealname=ScRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                    List.ExeSql(Sql_update);

                    this.Response.Write("<script language=javascript>alert('收藏成功！');</script>");

                }
                NewReader.Close();

                DataBindToGridview("order by LastTime desc");
            }
        }



    }
}

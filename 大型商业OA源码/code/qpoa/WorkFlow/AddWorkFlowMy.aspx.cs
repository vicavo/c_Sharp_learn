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
namespace qpoa.WorkFlow
{
    public partial class AddWorkFlowMy : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;


        public string CreateMidSql()
        {
            string MidSql = string.Empty;

            if (FormName.SelectedValue != "0")
            {
                MidSql = MidSql + " and FormId ='" + FormName.SelectedValue + "'";
            }

            if (Sequence.Text.Trim() != "")
            {
                MidSql = MidSql + " and Sequence = '" + List.GetFormatStr(Sequence.Text) + "'";
            }

            if (State.SelectedValue != "所有类型")
            {
                MidSql = MidSql + " and State= '" + State.SelectedValue + "'";
            }

            if (FqRealname.Text != "")
            {
                MidSql = MidSql + " and FqRealname like '%" + List.GetFormatStr(FqRealname.Text) + "%'";
            }

            if (Name.Text != "")
            {
                MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Name.Text) + "%'";
            }

            if (StartTime.Text != "" && EndTime.Text != "")
            {
                MidSql = MidSql + " and (NowTimes between '" + StartTime.Text + "'and  '" + EndTime.Text + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + StartTime.Text + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + EndTime.Text + "' as datetime),120) ) ";
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

            string Sql_del = " Delete from qp_AddWorkFlow where State='等待送审'";
            List.ExeSql(Sql_del);

            if (!Page.IsPostBack)
            {
                BindAttribute();

                Bindquanxian();
                BindDroList();
                DataBindToGridview("order by id desc", CreateMidSql());
            }

        }

        public void Bindquanxian()
        {
            List.QuanXianVis(GridView1, "bbbb4a", Session["perstr"].ToString());
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
        public void BindDroList()
        {
            string sql_down_bh = "select id,FormName from qp_DIYForm  order by id desc";
            if (!IsPostBack)
            {
                list.Bind_DropDownListFlow(FormName, sql_down_bh, "id", "FormName");
            }
        }

        public void DataBindToGridview(string Sqlsort, string Searchstr)
        {


            SqlStrStart = "select * from qp_AddWorkFlow where  Username='" + this.Session["username"] + "' and  1=1";
            SqlStrStartCount = "select count(id) from qp_AddWorkFlow where Username='" + this.Session["username"] + "' and  1=1";




            SqlStrMid = string.Empty;
            SqlStrMid = Searchstr;
            SqlStr = SqlStrStart + SqlStrMid;//查询
            SqlStrCount = SqlStrStartCount + SqlStrMid;//查询个数


            string SQL_GetList_xs = "" + SqlStr + " " + Sqlsort + "";


            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();

            string SQL_GetCount = SqlStrCount;
            CountsLabel = "" + List.GetCount(SQL_GetCount) + "";


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
                Label ln = (Label)e.Row.FindControl("Lid");

                Label ll = (Label)e.Row.FindControl("Label1");

                ll.Text = null;







                string SQL_yz1 = "select  * from qp_AddWorkFlow where  id='" + ln.Text + "' ";
                SqlDataReader NewReader_yz1 = List.GetList(SQL_yz1);
                if (NewReader_yz1.Read())
                {
                    ll.Text += "<a href='WorkFlowSearchShow.aspx?id=" + NewReader_yz1["id"] + "' onclick=\"showwait();\">查看</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_dc.aspx?id=" + NewReader_yz1["id"] + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>导出</a>&nbsp;&nbsp;";

                }
                NewReader_yz1.Close();


                string SQL_yz2 = "select  * from qp_AddWorkFlow where  id='" + ln.Text + "' and FqUsername='" + Session["username"] + "' and (State='正在办理' or State='等待办理')";
                SqlDataReader NewReader_yz2 = List.GetList(SQL_yz2);
                if (NewReader_yz2.Read())
                {
                    ll.Text += "<a href='javascript:void(0)' onclick='if (!confirm(\"是否确定结束？\")) return false;window.open (\"WorkFlowSearchJs.aspx?id=" + NewReader_yz2["id"] + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=110,left=110\")'>结束</a>&nbsp;&nbsp;<a href='javascript:void(0)' onclick='window.open (\"WorkFlowSearchCb.aspx?id=" + NewReader_yz2["id"] + "\", \"_blank\", \"height=220, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=110,left=110\")'>催办</a>";

                }
                NewReader_yz2.Close();

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



            DataBindToGridview(sql, CreateMidSql());


        }




        public override void VerifyRenderingInServerForm(Control control)
        { }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                GridView1.PageIndex = Convert.ToInt32(((LinkButton)sender).CommandName) - 1;
                //DataBindToGridview("order by id desc");


                DataBindToGridview("order by id desc", CreateMidSql());


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

                DataBindToGridview("order by id desc", CreateMidSql());


            }
            catch
            {


                DataBindToGridview("order by id desc", CreateMidSql());



                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }



        protected void Button2_Click1(object sender, EventArgs e)
        {
            // Response.Write("3：" + CreateMidSql() + "<br>");
            DataBindToGridview("order by id desc", CreateMidSql());
        }





    }
}

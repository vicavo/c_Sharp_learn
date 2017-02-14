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
    public partial class WorkFlowName_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel,Namefile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkFlowName   where  FormId='" + Request.QueryString["FormId"] + "'  ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Namefile = NewReader["FormName"].ToString();
                }
                else
                {
                    Namefile = "没有此流程";
                }
                NewReader.Close();
                Bindquanxian();
                BindAttribute();
                DataBindToGridview("order by id desc");

            }

            string sql_down_bh = "select id,FormName  from qp_DIYForm  order by id desc";

            if (!IsPostBack)
            {
                //将选中流程复制给表单：
                list.Bind_DropDownList_nothing(DIYForm, sql_down_bh, "id", "FormName");
            }
        }

        public void Bindquanxian()
        {
            List.QuanXianVis(LinkButton1, "bbbb3", Session["perstr"].ToString());
            List.QuanXianVis(LinkButton2, "bbbb3", Session["perstr"].ToString());
          
        }

        public void BindAttribute()
        {
            LinkButton1.Attributes["onclick"] = "javascript:return delcheck();";
            LinkButton7.Attributes["onclick"] = "javascript:return FolderMovecheck();";
            LinkButton2.Attributes["onclick"] = "javascript:return addfrom();";
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {



            string SQL_GetCount = "select count(id) from  qp_WorkFlowName where  FormId='" + Request.QueryString["FormId"] + "'  ";
            CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            string SQL_GetList_xs = "select * from qp_WorkFlowName where  FormId='" + Request.QueryString["FormId"] + "' " + Sqlsort + " ";
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
                Label ln = (Label)e.Row.FindControl("WFNId");
                Label ss = (Label)e.Row.FindControl("FlowNumber");
                

                Label ll1 = (Label)e.Row.FindControl("Label1");
                Label ll2 = (Label)e.Row.FindControl("Label2");
                Label ll3 = (Label)e.Row.FindControl("Label3");

                ll1.Text = " <a href=\"javascript:void(0)\" onclick=\"showfrom(" + ln.Text + ");\">查看</a>";
                ll2.Text = " <a href=\"javascript:void(0)\" onclick=\"updatefrom(" + ln.Text + ");\">修改</a>";
                ll3.Text = " <a href=\"javascript:void(0)\" onclick='window.open (\"WorkFlowName_show_add_node.aspx?FlowNumber="+ss.Text+"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>流程设计</a>";




                List.QuanXianVis(ll1, "bbbb3", Session["perstr"].ToString());
                List.QuanXianVis(ll2, "bbbb3", Session["perstr"].ToString());
                List.QuanXianVis(ll3, "bbbb3", Session["perstr"].ToString());
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string CheckStr = CheckCbxDel();


            string SqlStr = "  Delete from qp_WorkFlowName  where ID in (" + CheckStr + ")";
            List.ExeSql(SqlStr);

            InsertLog("删除流程[" + CheckCbxNameDel() + "]", "工作流管理");

            DataBindToGridview("order by id desc");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            //string CheckStr = CheckCbxDel();

            //string SQL_GetList = "select * from qp_WorkFlowName  where id='" + DIYForm.SelectedValue + "'";
            //SqlDataReader NewReader = List.GetList(SQL_GetList);
            //if (NewReader.Read())
            //{
            //    //string Sql_update = "Update qp_ElecBookShow  Set FoldersName='" + NewReader["Name"] + "',FoldersID='" + NewReader["id"] + "' where ID in (" + CheckStr + ")";
            //    //List.ExeSql(Sql_update);
            //}
            //NewReader.Close();


            //InsertLog("复制流程[" + CheckCbxNameDel() + "]", "工作流管理");

            //DataBindToGridview("order by id desc");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }




    }
}

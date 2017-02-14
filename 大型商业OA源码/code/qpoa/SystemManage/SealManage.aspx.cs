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
namespace qpoa.SystemManage
{
    public partial class SealManage : System.Web.UI.Page
    {
        Db List = new Db();

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

                if (Request.QueryString["Realname"] != null)
                {
                    MidSql = MidSql + " and Realname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["ServicesType"])) + "%'";
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
            List.QuanXianVis(IMG1, "iiiia1b", Session["perstr"].ToString());
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
            if (List.StrIFInStr("iiiia1b", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_YinZhang where  YxType='私章'  and 1=1";
                SqlStrStartCount = "select count(id) from qp_YinZhang where  YxType='私章'  and  1=1";

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
                if (List.StrIFInStr("iiiia1b", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_YinZhang where YxType='私章' ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_YinZhang where YxType='私章'  " + Sqlsort + "";
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l1 = (LinkButton)e.Row.FindControl("LinkButton1");
                l1.Attributes.Add("onclick", "javascript:return confirm('确认删除印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");

                LinkButton l2 = (LinkButton)e.Row.FindControl("LinkButton2");
                l2.Attributes.Add("onclick", "javascript:return confirm('确认停止印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");


                LinkButton l3 = (LinkButton)e.Row.FindControl("LinkButton3");
                l3.Attributes.Add("onclick", "javascript:return confirm('确认密码重置印章[" + e.Row.Cells[0].Text.ToString() + "]吗？重置后面密码为：666666')");


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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string SQL_GetList = "select * from qp_YinZhang where id='" + ID + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您的印章[" + NewReader["Name"] + "]被删除，操作人[" + Session["realname"] + "]请注意查看！','您的印章[" + NewReader["Name"] + "]被删除，操作人[" + Session["realname"] + "]请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["Username"] + "','" + NewReader["Realname"] + "','系统消息','系统消息','否','WorkFlow/YinZhang.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    string SqlStr = "  Delete from qp_YinZhang where ID='" + ID + "'";
                    List.ExeSql(SqlStr);
                    DataBindToGridview("order by id desc");
                    InsertLog("删除印章[" + NewReader["Name"] + "]", "私章维护");
                }
                NewReader.Close();
            }


            if (e.CommandName == "Tingzhi")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string SQL_GetList = "select * from qp_YinZhang where id='" + ID + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您的印章[" + NewReader["Name"] + "]被停止使用，操作人[" + Session["realname"] + "]请注意查看！','您的印章[" + NewReader["Name"] + "]被停止使用，操作人[" + Session["realname"] + "]请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["Username"] + "','" + NewReader["Realname"] + "','系统消息','系统消息','否','WorkFlow/YinZhang.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    string Sql_update1 = "Update qp_YinZhang    Set State='停止' where id='" + ID + "'";
                    List.ExeSql(Sql_update1);

                    DataBindToGridview("order by id desc");
                    InsertLog("停止印章[" + NewReader["Name"] + "]", "私章维护");
                }
                NewReader.Close();
            }


            if (e.CommandName == "Chongzhi")
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                string SQL_GetList = "select * from qp_YinZhang where id='" + ID + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您的印章[" + NewReader["Name"] + "]密码被重置，重置后密码为：666666。操作人[" + Session["realname"] + "]请注意查看！','您的印章[" + NewReader["Name"] + "]密码被重置，重置后密码为：666666。操作人[" + Session["realname"] + "]请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["Username"] + "','" + NewReader["Realname"] + "','系统消息','系统消息','否','WorkFlow/YinZhang.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile("666666", "MD5");

                    string Sql_update1 = "Update qp_YinZhang  Set Password='" + hashPassword + "' where id='" + ID + "'";
                    List.ExeSql(Sql_update1);

                    DataBindToGridview("order by id desc");
                    InsertLog("印章密码重置[" + NewReader["Name"] + "]", "私章维护");
                }
                NewReader.Close();
            }






        }




    }
}

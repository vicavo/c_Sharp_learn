﻿using System;
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
    public partial class FilesManageSp : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Title"] != null)
                {
                    MidSql = MidSql + " and Title like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Title"])) + "%'";
                }


                if (Request.QueryString["JyRealname"] != null)
                {
                    MidSql = MidSql + " and JyRealname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["JyRealname"])) + "%'";
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

            //List.QuanXianVis(ImageButton3, "hhhh4b", Session["perstr"].ToString());
            List.QuanXianVis(IMG1, "hhhh4b", Session["perstr"].ToString());
        }

        public void BindAttribute()
        {

            //ImageButton3.Attributes["onclick"] = "javascript:return delcheck();";
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {

            if (List.StrIFInStr("hhhh4b", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_FilesManageBookLog where 1=1 and State='等待审批'";
                SqlStrStartCount = "select count(id) from qp_FilesManageBookLog where 1=1  and State='等待审批'";
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
                if (List.StrIFInStr("hhhh4b", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_FilesManageBookLog  where   State='等待审批' ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_FilesManageBookLog   where   State='等待审批'  " + Sqlsort + "";
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



                LinkButton l3 = (LinkButton)e.Row.FindControl("TongGuo");
                l3.Attributes.Add("onclick", "javascript:return confirm('确认通过此文件审批吗？')");


                LinkButton l4 = (LinkButton)e.Row.FindControl("JuJue");
                l4.Attributes.Add("onclick", "javascript:return confirm('确认拒绝此文件审批吗？')");



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

            InsertLog("删除文件借阅记录管理[" + CheckCbxNameDel() + "]", "文件管理");

            DataBindToGridview("order by id desc");




        }




        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {



            if (e.CommandName == "TongGuo")
            {
                int ID = Convert.ToInt32(e.CommandArgument);


                string SQL_GetList = "select * from qp_FilesManageBookLog   where id='" + ID + "'";
                //Response.Write(SQL_GetList);
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    string Sql_update = "Update qp_FilesManageBook Set JrUsername=JrUsername+'" + NewReader["JyUsername"].ToString() + ",',JrRealname=JrRealname+'" + NewReader["JyRealname"].ToString() + ",'  where  id='" + NewReader["BookId"] + "'";
                    List.ExeSql(Sql_update);

                     //Response.Write(Sql_update);

                    string Sql_updateLog = "Update qp_FilesManageBookLog  Set State='未归还',GhTime='未归还'  where id='" + ID + "'";
                    List.ExeSql(Sql_updateLog);


                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的借阅文件[" + NewReader["Num"] + "]！已经通过审批！','您申请的借阅文件[" + NewReader["Num"] + "]！已经通过审批！','" + System.DateTime.Now.ToString() + "','" + NewReader["JyUsername"] + "','" + NewReader["JyRealname"] + "','系统消息','系统消息','否','FilesManage/FilesManageJy_ytg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    InsertLog("[" + NewReader["Num"] + "]通过审批", "借阅审批");
                    this.Response.Write("<script language=javascript>alert('通过审批！');</script>");

                }
                else
                {
                    Response.Write("aaaaa");
                }
                NewReader.Close();

              
                DataBindToGridview("order by id desc");
            }





            if (e.CommandName == "JuJue")
            {
                int ID = Convert.ToInt32(e.CommandArgument);


                string SQL_GetList = "select * from qp_FilesManageBookLog   where id='" + ID + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    string Sql_updateLog = "Update qp_FilesManageBookLog  Set State='拒绝审批',GhTime='拒绝审批'  where id='" + ID + "'";
                    List.ExeSql(Sql_updateLog);


                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的借阅文件[" + NewReader["Num"] + "]！拒绝审批！','您申请的借阅文件[" + NewReader["Num"] + "]！拒绝审批！','" + System.DateTime.Now.ToString() + "','" + NewReader["JyUsername"] + "','" + NewReader["JyRealname"] + "','系统消息','系统消息','否','FilesManage/FilesManageJy_wtg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    InsertLog("[" + NewReader["Num"] + "]拒绝审批", "借阅审批");
                    this.Response.Write("<script language=javascript>alert('拒绝成功！');</script>");

                }
                NewReader.Close();


                DataBindToGridview("order by id desc");
            }








        }




    }
}

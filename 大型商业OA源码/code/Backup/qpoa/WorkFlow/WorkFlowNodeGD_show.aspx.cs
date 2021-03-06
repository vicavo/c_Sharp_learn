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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowNodeGD_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, Namefile;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Name"] != null)
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
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
                string SQL_GetList = "select * from qp_WorkFlowNodeGD   where id='" + int.Parse(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Namefile = NewReader["name"].ToString();
                }
                else
                {
                    Namefile = "没有此文件夹";
                }
                NewReader.Close();
                BindAttribute();
                DataBindToGridview("order by id desc");


            }

            string sql_down_bh = "select id,Linew+name as aaa  from qp_WorkFlowNodeGD  order by QxString asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(Folder, sql_down_bh, "id", "aaa");
            }
        }

        public void BindAttribute()
        {
            LinkButton1.Attributes["onclick"] = "javascript:return delcheck();";
            LinkButton7.Attributes["onclick"] = "javascript:return FolderMovecheck();";

            LinkButton5.Attributes["onclick"] = "javascript:return delf();";

            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {

            SqlStrStart = "select * from qp_GdWorkFlow  where GdTypeId='" + Request.QueryString["id"] + "'  and 1=1 ";
            SqlStrStartCount = "select count(id) from qp_GdWorkFlow  where   GdTypeId='" + Request.QueryString["id"] + "'  and  1=1 ";

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

                string SQL_GetCount = "select count(id) from  qp_GdWorkFlow where  GdTypeId='" + Request.QueryString["id"] + "'  ";
                CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

                string SQL_GetList_xs = "select * from qp_GdWorkFlow where  GdTypeId='" + Request.QueryString["id"] + "' " + Sqlsort + " ";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();

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


            string SqlStr = "  Delete from qp_GdWorkFlow  where ID in (" + CheckStr + ")";
            List.ExeSql(SqlStr);

            InsertLog("删除归档工作[" + CheckCbxNameDel() + "]", "归档工作");

            DataBindToGridview("order by id desc");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            string CheckStr = CheckCbxDel();

            //string SQL_GetList = "select * from qp_WorkFlowNodeGD  where id='" + Folder.SelectedValue + "'";
            //SqlDataReader NewReader = List.GetList(SQL_GetList);
            //if (NewReader.Read())
            //{
            //    string Sql_update = "Update qp_GdWorkFlow  Set GdTypeName='" + NewReader["Name"] + "',FoldersID='" + NewReader["id"] + "' where ID in (" + CheckStr + ")";
            //    List.ExeSql(Sql_update);
            //    Response.Write(Sql_update);
            //}
            //NewReader.Close();



            string Sql_update = "Update qp_GdWorkFlow  Set GdTypeName='" + Folder.SelectedItem.Text + "',GdTypeId='" + Folder.SelectedValue + "' where ID in (" + CheckStr + ")";
            List.ExeSql(Sql_update);
          
    


            InsertLog("转移归档工作[" + CheckCbxNameDel() + "]", "归档工作管理");

            DataBindToGridview("order by id desc");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            //string SQL_GetList = "select * from qp_WorkFlowNodeGD  where id='" + Request.QueryString["id"] + "'";
            //SqlDataReader NewReader = List.GetList(SQL_GetList);
            //if (NewReader.Read())
            //{
            //    string SqlStr = "  Delete from qp_WorkFlowNodeGD  where id='" + Request.QueryString["id"] + "'";
            //    List.ExeSql(SqlStr);

            //    string SqlStr1 = "  Delete from qp_GdWorkFlow  where GdTypeId='" + Request.QueryString["id"] + "'";
            //    List.ExeSql(SqlStr1);



            //    InsertLog("删除归档工作类别[" + NewReader["name"] + "]", "归档工作管理");
            //}
            //NewReader.Close();

            DelNode(Request.QueryString["id"], Request.QueryString["id"]);

            this.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'WorkFlowNodeGD.aspx'</script>");

        }



        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkFlowNodeGD_add.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkFlowNodeGD_update.aspx?id=" + Request.QueryString["id"] + "");
        }


        private void DelNode(string IDStr, string PID)
        {
            string SqlStr = "  Delete from qp_WorkFlowNodeGD  where id='" + IDStr + "'";
            List.ExeSql(SqlStr);//删除最根节点

            string SQL_GetList = "select * from qp_WorkFlowNodeGD where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                string SqlStr1 = "  Delete from qp_WorkFlowNodeGD  where id='" + MyReader["ID"].ToString() + "'";
                List.ExeSql(SqlStr1);

                string SQL_GetList1 = "select * from qp_WorkFlowNodeGD where ParentNodesID=" + MyReader["id"] + " ";
                SqlDataReader MyReader1 = List.GetList(SQL_GetList1);
                if (MyReader1.Read())
                {

                    string IDStr1 = MyReader["ID"].ToString();
                    string PID1 = MyReader["ParentNodesID"].ToString();
                    DelNode(IDStr1, PID1);

                }
                MyReader1.Close();

            }
            MyReader.Close();

        }















    }
}

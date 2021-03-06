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
namespace qpoa.MyAffairs
{
    public partial class MyNetMetting : System.Web.UI.Page
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


                if (Request.QueryString["Title"] != null)
                {
                    MidSql = MidSql + " and Title like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Title"])) + "%'";
                }

                if (Request.QueryString["WbPeople"] != null)
                {
                    MidSql = MidSql + " and WbPeople like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["WbPeople"])) + "%'";
                }

                if (Request.QueryString["NbPeopleName"] != null)
                {
                    MidSql = MidSql + " and NbPeopleName like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["NbPeopleName"])) + "%'";
                }
                if (Request.QueryString["MettingHeader"] != null)
                {
                    MidSql = MidSql + " and MettingHeader like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["MettingHeader"])) + "%'";
                }

                if (Request.QueryString["Startime"] != null)
                {
                    MidSql = MidSql + " and (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + Request.QueryString["Startime"] + "' as datetime),120) ) ";

                }

                if (Request.QueryString["Endtime"] != null)
                {
                    MidSql = MidSql + " and (convert(char(10),cast(Endtime as datetime),120)=convert(char(10),cast('" + Request.QueryString["Endtime"] + "' as datetime),120) ) ";

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



            List.QuanXianVis(IMG1, "1111h3", Session["perstr"].ToString());
          


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
            if (List.StrIFInStr("1111h3", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_NetMetting  where (State='正常状态' or State='正在进行'  or State='已经结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0   and 1=1";
                SqlStrStartCount = "select count(id) from qp_NetMetting  where   (State='正常状态' or State='正在进行'  or State='已经结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0   and  1=1";

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
                if (List.StrIFInStr("1111h3", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_NetMetting where  (State='正常状态' or State='正在进行'  or State='已经结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0  ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_NetMetting  where   (State='正常状态' or State='正在进行'  or State='已经结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0   " + Sqlsort + "";

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


                LinkButton l1 = (LinkButton)e.Row.FindControl("canyu");
                l1.Attributes.Add("onclick", "javascript:return confirm('确认已参与会议[" + e.Row.Cells[0].Text.ToString() + "]吗？')");

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ln = (Label)e.Row.FindControl("HyCyId");

                Label ll = (Label)e.Row.FindControl("Label1");

                Label ln1 = (Label)e.Row.FindControl("HyId");

                Label ll1 = (Label)e.Row.FindControl("Label2");


                string SQL_yz = "select  * from qp_NetMetting where   CHARINDEX('," + this.Session["Username"] + ",',','+CjUsername+',')   >   0  and  id='" + ln.Text + "' ";
                SqlDataReader NewReader_yz = List.GetList(SQL_yz);
                if (NewReader_yz.Read())
                {
                    ll.Text = "已参与";
                }
                else
                {
                    ll.Text = "未参与";
                }
                NewReader_yz.Close();



                string SQL_jy = "select  * from qp_NetMetting where   CHARINDEX('," + this.Session["Username"] + ",',','+JyUsername+',')   >   0  and  id='" + ln1.Text + "' ";
                SqlDataReader NewReader_jy = List.GetList(SQL_jy);
                if (NewReader_jy.Read())
                {
                    ll1.Text = "<a href='MyNetMetting_Jyshow.aspx?id=" + ln1.Text + "' onclick=\"showwait();\">会议纪要</a>";
                }
                else
                {
                    ll1.Text = "";
                }
                NewReader_jy.Close();

            }


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


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("NetMetting_add.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "canyu")
            {

                int ID = Convert.ToInt32(e.CommandArgument);

                string SQL_GetList = "select  * from qp_NetMetting where id='" + ID + "' ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                
                        string SQL_GetList1 = "select  * from qp_NetMetting where    CHARINDEX('," + this.Session["Username"] + ",',','+CjUsername+',')   >   0  and  id='" + ID + "' ";
                        SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                        if (NewReader1.Read())
                        {
                            return;
                        }
                        else
                        {
                            string Sql_update = "Update qp_NetMetting  Set CjUsername=CjUsername+'" + Session["username"] + ",',  CjRealname=CjRealname+'" + Session["realname"] + ",' where ID='" + ID + "'";
                            List.ExeSql(Sql_update);
                            InsertLog("参与会议[" + NewReader["Name"].ToString() + "]", "我的会议");
                        }
                        NewReader1.Close();


             

                }
                DataBindToGridview("order by id desc");
                NewReader.Close();


            }




        }




    }
}

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
namespace qpoa.SaleManage
{
    public partial class SupplierLxrxg : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, KhRealnameShow;
        public string CreateMidSql()
        {
            string MidSql = string.Empty;
            if (Request.QueryString["key"] != null)
            {
                if (Request.QueryString["Name"] != null)
                {
                    MidSql = MidSql + " and Name like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Name"])) + "%'";
                }


                if (Request.QueryString["KhRealname"] != null)
                {
                    MidSql = MidSql + " and KhRealname like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["KhRealname"])) + "%'";
                }

                if (Request.QueryString["LxrPost"] != null)
                {
                    MidSql = MidSql + " and LxrPost like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["LxrPost"])) + "%'";
                }

                if (Request.QueryString["Sex"] != null)
                {
                    MidSql = MidSql + " and Sex like '%" + List.GetFormatStr(Server.UrlDecode(Request.QueryString["Sex"])) + "%'";
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
                  
                string SQL_GetList = "select * from qp_Supplier where id='" + List.GetFormatStr(Request.QueryString["KeyId"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    KhRealnameShow = NewReader["Name"].ToString();
                }
                NewReader.Close();

                BindAttribute();
                DataBindToGridview("order by id desc");
                Bindquanxian();



            }
        }

        public void Bindquanxian()
        {
            List.QuanXianVis(ImageButton1, "ffff5cb", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton6, "ffff5cc", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton2, "ffff5cd", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton3, "ffff5ce", Session["perstr"].ToString());
            List.QuanXianVis(IMG1, "ffff5ci", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton4, "ffff5cf", Session["perstr"].ToString());


        }

        public void BindAttribute()
        {
            ImageButton2.Attributes["onclick"] = "javascript:return updatecheck();";
            ImageButton1.Attributes["onclick"] = "javascript:return showwait();";
            ImageButton3.Attributes["onclick"] = "javascript:return delcheck();";
            if (Request.QueryString["key"] != null)
            {

                ImageButton4.Attributes["onclick"] = "javascript:return outexcels();";
            }
            else
            {
                ImageButton4.Attributes["onclick"] = "javascript:return outexcel();";
            }

            ImageButton6.Attributes["onclick"] = "javascript:return updatecheck();";
            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {
            if (List.StrIFInStr("ff1eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SupplierLxr where Username='" + this.Session["username"] + "' and KeyId='" + Request.QueryString["KeyId"] + "' and 1=1";
                SqlStrStartCount = "select count(id) from qp_SupplierLxr where  Username='" + this.Session["username"] + "'  and KeyId='" + Request.QueryString["KeyId"] + "'  and  1=1";

            }
            if (List.StrIFInStr("ff2eff5", Session["perstr"].ToString()))
            {

                if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                {
                    SqlStrStart = "select * from qp_SupplierLxr where    CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0   and KeyId='" + Request.QueryString["KeyId"] + "'   and 1=1";
                    SqlStrStartCount = "select count(id) from qp_SupplierLxr where     CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  and KeyId='" + Request.QueryString["KeyId"] + "'  and  1=1";
                }
                else
                {
                    SqlStrStart = "select * from qp_SupplierLxr where UnitId='" + this.Session["UnitId"] + "'   and KeyId='" + Request.QueryString["KeyId"] + "'   and 1=1";
                    SqlStrStartCount = "select count(id) from qp_SupplierLxr where  UnitId='" + this.Session["UnitId"] + "' and KeyId='" + Request.QueryString["KeyId"] + "'  and  1=1";
                }
            
            
            }
            if (List.StrIFInStr("ff3eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SupplierLxr where  KeyId='" + Request.QueryString["KeyId"] + "' and  1=1";
                SqlStrStartCount = "select count(id) from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and   1=1";
            }

            if (List.StrIFInStr("ff4eff5", Session["perstr"].ToString()))
            {
                SqlStrStart = "select * from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and  GroupId='" + this.Session["GroupId"] + "'and 1=1";
                SqlStrStartCount = "select count(id) from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and   GroupId='" + this.Session["GroupId"] + "'and  1=1";
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
                if (List.StrIFInStr("ff1eff5", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and  Username='" + this.Session["username"] + "'";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and  Username='" + this.Session["username"] + "' " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }//个人

                if (List.StrIFInStr("ff2eff5", Session["perstr"].ToString()))
                {



                    if (this.Session["KeyQx"].ToString() == "允许管理子部门数据")
                    {
                        string SQL_GetCount = "select count(id) from  qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and     CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0 ";
                        CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                        string SQL_GetList_xs = "select * from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and     CHARINDEX('" + this.Session["QxString"] + "',QxString) > 0  " + Sqlsort + "";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }
                    else
                    {
                        string SQL_GetCount = "select count(id) from  qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and  UnitId='" + this.Session["UnitId"] + "'";
                        CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                        string SQL_GetList_xs = "select * from qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' and  UnitId='" + this.Session["UnitId"] + "' " + Sqlsort + "";
                        GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                        GridView1.DataBind();
                    }


                }//部门

                if (List.StrIFInStr("ff3eff5", Session["perstr"].ToString()))
                {
                    string SQL_GetCount = "select count(id) from  qp_SupplierLxr where   KeyId='" + Request.QueryString["KeyId"] + "' ";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_SupplierLxr  where   KeyId='" + Request.QueryString["KeyId"] + "' " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();



                } //公司
                if (List.StrIFInStr("ff4eff5", Session["perstr"].ToString()))
                {

                    string SQL_GetCount = "select count(id) from  qp_SupplierLxr  where   KeyId='" + Request.QueryString["KeyId"] + "' and  GroupId='" + this.Session["GroupId"] + "'";
                    CountsLabel = "" + List.GetCount(SQL_GetCount) + "";
                    string SQL_GetList_xs = "select * from qp_SupplierLxr  where   KeyId='" + Request.QueryString["KeyId"] + "' and  GroupId='" + this.Session["GroupId"] + "' " + Sqlsort + "";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();

                } //销售组
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

            string SqlStr = "  Delete from qp_SupplierLxr  where ID in (" + CheckStr + ")";
            List.ExeSql(SqlStr);

            InsertLog("删除供应商联系人[" + CheckCbxNameDel() + "]", "供应商管理");

            DataBindToGridview("order by id desc");




        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("SupplierLxrxg_update.aspx?KeyId=" + Request.QueryString["KeyId"] + "&id=" + CheckCbxUpdate() + "");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SupplierLxrxg_add.aspx?KeyId=" + Request.QueryString["KeyId"] + "");
        }



        protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SupplierLxrxg_show.aspx?KeyId=" + Request.QueryString["KeyId"] + "&id=" + CheckCbxUpdate() + "");
        }


    }
}

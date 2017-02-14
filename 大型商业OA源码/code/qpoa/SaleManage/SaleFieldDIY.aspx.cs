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
namespace qpoa.SaleManage
{
    public partial class SaleFieldDIY : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount, type, typename, ShangYiId, PaiXun;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                type = Request.QueryString["type"].ToString();
                if (type == "1")
                {
                    typename = "客户管理";
                }

                if (type == "2")
                {
                    typename = "客户联系人管理";
                }

                if (type == "3")
                {
                    typename = "客户服务管理";
                }

                if (type == "4")
                {
                    typename = "产品管理";
                }

                if (type == "5")
                {
                    typename = "服务型产品管理";
                }

                if (type == "6")
                {
                    typename = "合同管理";
                }

                if (type == "7")
                {
                    typename = "供应商信息管理";
                }

                if (type == "8")
                {
                    typename = "供应商联系人管理";
                }
                if (type == "9")
                {
                    typename = "产品销售记录";
                }

                if (type == "10")
                {
                    typename = "服务性产品销售记录";
                }

                if (type == "11")
                {
                    typename = "供应商产品信息";
                }
                BindAttribute();
                DataBindToGridview("order by PaiXun asc");
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(ImageButton1, "ffff7cb", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton4, "ffff7cc", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton2, "ffff7cd", Session["perstr"].ToString());
            List.QuanXianVis(ImageButton3, "ffff7ce", Session["perstr"].ToString());
         

        }
        public void BindAttribute()
        {
 

            ImageButton2.Attributes["onclick"] = "javascript:return updatecheck();";
            ImageButton1.Attributes["onclick"] = "javascript:return showwait();";
            ImageButton3.Attributes["onclick"] = "javascript:return delcheck();";


            ImageButton4.Attributes["onclick"] = "javascript:return updatecheck();";

            btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            btnNext.Attributes["onclick"] = "javascript:return showwait();";
            btnLast.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {

            string SQL_GetCount = "select count(id) from  qp_SaleFieldDIY where type='" + Request.QueryString["type"] + "'";
            CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            string SQL_GetList_xs = "select * from qp_SaleFieldDIY where type='" + Request.QueryString["type"] + "' " + Sqlsort + "";
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

                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return showwait();");

                LinkButton l2 = (LinkButton)e.Row.FindControl("LinkButton2");
                l2.Attributes.Add("onclick", "javascript:return showwait();");
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
                DataBindToGridview("order by PaiXun asc");
            }
            catch
            {
                DataBindToGridview("order by PaiXun asc");
                Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            string CheckStr = CheckCbxDel();


            string SqlStr = "  Delete from qp_SaleFieldDIY  where ID in (" + CheckStr + ")";
            List.ExeSql(SqlStr);

            InsertLog("删除自定义字段[" + CheckCbxNameDel() + "]", "销售管理-自定义字段-" + typename + "");

            DataBindToGridview("order by PaiXun asc");




        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {

            Response.Redirect("SaleFieldDIY_update.aspx?type=" + type + "&id=" + CheckCbxUpdate() + "");

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SaleFieldDIY_add.aspx?type=" + type + "");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "shangyi")
            {
                int PaiXunId = Convert.ToInt32(e.CommandArgument);
                

                string SQL_GetList = "select top 1 * from qp_SaleFieldDIY where Paixun<" + PaiXunId.ToString() + "  and type='" + Request.QueryString["type"] + "' order by paixun desc";
               
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

            

                    string Sql_update_n = "Update qp_SaleFieldDIY  Set Paixun='" + NewReader["PaiXun"].ToString() + "'  where Paixun='" + PaiXunId.ToString() + "'";
                    List.ExeSql(Sql_update_n);


                    string Sql_update_s = "Update qp_SaleFieldDIY  Set Paixun='" + PaiXunId.ToString() + "'  where id='" + NewReader["id"].ToString() + "'";
                    List.ExeSql(Sql_update_s);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('已经达到最顶部，移动失败！');</script>");
                }
                NewReader.Close();




            }

            if (e.CommandName == "xiayi")
            {
                int PaiXunId = Convert.ToInt32(e.CommandArgument);

                string SQL_GetList = "select top 1 * from qp_SaleFieldDIY where Paixun>" + PaiXunId.ToString() + "  and type='"+Request.QueryString["type"]+"' order by paixun asc";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    //ShangYiId = NewReader["id"].ToString();
                    //PaiXun = NewReader["PaiXun"].ToString();

                    string Sql_update_n = "Update qp_SaleFieldDIY  Set Paixun='" + NewReader["PaiXun"].ToString() + "'  where Paixun='" + PaiXunId.ToString() + "'";
                    List.ExeSql(Sql_update_n);


                    string Sql_update_s = "Update qp_SaleFieldDIY  Set Paixun='" + PaiXunId.ToString() + "'  where id='" + NewReader["id"].ToString() + "'";
                    List.ExeSql(Sql_update_s);
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('已经达到最底部，移动失败！');</script>");
                }
                NewReader.Close();




            }


            DataBindToGridview("order by PaiXun asc");
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SaleFieldDIY_show.aspx?type=" + type + "&id=" + CheckCbxUpdate() + "");
        }




    }
}

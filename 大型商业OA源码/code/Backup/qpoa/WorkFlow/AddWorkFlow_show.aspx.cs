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
    public partial class AddWorkFlow_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, Namefile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkFlowName   where (CHARINDEX('," + this.Session["UnitId"] + ",',','+FlowUnitId+',')   >   0 ) and  FormId='" + Request.QueryString["FormId"] + "'  ";
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

            //string sql_down_bh = "select id,FormName  from qp_DIYForm  order by id desc";

            //if (!IsPostBack)
            //{
            //    list.Bind_DropDownList_nothing(DIYForm, sql_down_bh, "id", "FormName");
            //}
        }

        public void Bindquanxian()
        {
            //List.QuanXianVis(LinkButton1, "bbbb3", Session["perstr"].ToString());
            //List.QuanXianVis(LinkButton2, "bbbb3", Session["perstr"].ToString());

        }

        public void BindAttribute()
        {
            //LinkButton1.Attributes["onclick"] = "javascript:return delcheck();";
            //LinkButton7.Attributes["onclick"] = "javascript:return FolderMovecheck();";
            //LinkButton2.Attributes["onclick"] = "javascript:return addfrom();";
            //btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            //btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            //btnNext.Attributes["onclick"] = "javascript:return showwait();";
            //btnLast.Attributes["onclick"] = "javascript:return showwait();";
            //Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }
        public void DataBindToGridview(string Sqlsort)
        {



            //string SQL_GetCount = "select count(id) from  qp_WorkFlowName where  FormId='" + Request.QueryString["FormId"] + "'  ";
            //CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            string SQL_GetList_xs = "select * from qp_WorkFlowName where (CHARINDEX('," + this.Session["UnitId"] + ",',','+FlowUnitId+',')   >   0 ) and  FormId='" + Request.QueryString["FormId"] + "' " + Sqlsort + " ";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();




            //AllPageLabel = Convert.ToString(GridView1.PageCount);
            //CurrentlyPageLabel = Convert.ToString(((int)GridView1.PageIndex + 1));


            //btnFirst.CommandName = "1";
            //btnPrev.CommandName = (GridView1.PageIndex == 0 ? "1" : GridView1.PageIndex.ToString());

            //btnNext.CommandName = (GridView1.PageCount == 1 ? GridView1.PageCount.ToString() : (GridView1.PageIndex + 2).ToString());
            //btnLast.CommandName = GridView1.PageCount.ToString();
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






        public override void VerifyRenderingInServerForm(Control control)
        { }


    }
}

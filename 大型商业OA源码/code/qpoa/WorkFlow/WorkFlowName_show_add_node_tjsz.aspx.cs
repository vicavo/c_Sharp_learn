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
    public partial class WorkFlowName_show_add_node_tjsz : System.Web.UI.Page
    {
        Db List = new Db();
        public static string strlist, SqlStr;
        BindDrowDownList list = new BindDrowDownList();
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

                string SQL_GetList = "select  *  from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NodeNum.Text = NewReader["NodeNum"].ToString();
                    NodeName.Text = NewReader["NodeName"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    strlist = ""+NewReader["UpNodeNum"].ToString()+"0";
                
                }

                NewReader.Close();
            }

           
            string SqlStr = "  select  * from qp_WorkFlowNode   where NodeNum in (" + strlist + ") and FlowNumber='" + FlowNumber.Text + "'";
            if (!Page.IsPostBack)
            {
                list.Bind_DropDownList(DropDownList1, SqlStr, "id", "NodeName");
            }

            if (DropDownList1.SelectedValue != "请选择")
            {
                DataBindToGridview("where KeyID='" + DropDownList1.SelectedValue + "' and  NodeId='" + Request.QueryString["id"] + "'");
            }
            else
            {
                DataBindToGridview("where KeyID='0'");
            }


        }



        public void BindAttribute()
        {
            NodeNum.Attributes.Add("readonly", "readonly");
            NodeName.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return adddatefile();";
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string SQL_GetList_xs = "select * from qp_FlowFormFile  " + Sqlsort + " ";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {

                int ID = Convert.ToInt32(e.CommandArgument);

                string SqlStr = "  Delete from qp_FlowFormFile where ID='" + ID + "'";
                List.ExeSql(SqlStr);

                DataBindToGridview("where KeyID='" + DropDownList1.SelectedValue + "' and  NodeId='" + Request.QueryString["id"] + "'");

            }
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
                l.Attributes.Add("onclick", "javascript:return confirm('确认删除此字段的条件[" + e.Row.Cells[0].Text.ToString() + "]吗？')");


                LinkButton l1 = (LinkButton)e.Row.FindControl("LinkButton2");
                l1.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('WorkFlowName_show_add_node_tjsz_update.aspx?tmp=' + num + '&id=" + l1.CommandArgument + "','window','dialogWidth:460px;DialogHeight=280px;status:no;help=no;scroll=no');window.location='#'");
            }
        }







    }
}

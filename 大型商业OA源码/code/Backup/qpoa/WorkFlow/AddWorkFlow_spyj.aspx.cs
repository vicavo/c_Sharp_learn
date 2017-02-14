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
    public partial class AddWorkFlow_spyj : System.Web.UI.Page
    {
        Db List = new Db();
        public static string NodeNumber, NodeName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                //string SQL_GetList2 = "select * from qp_AddWorkFlowMessage where WorkFlowId='" + Request.QueryString["id"] + "'";
                //SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                //if (NewReader2.Read())
                //{
                //    NodeNumber = NewReader2["NodeNumber"].ToString();
                //    NodeName = NewReader2["NodeName"].ToString();
                //}
           
                
               
            }
            DataBindToGridview();
        }

        public void DataBindToGridview()
        {
            string SQL_GetList_xs = "select * from qp_AddWorkFlowMessage  where WorkFlowId='" + Request.QueryString["id"] + "' order by id desc";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string sql_insert_file = "insert into qp_AddWorkFlowspyj   (Content,Username,Realname,NodeNumber,NodeName,SetTime,KeyField) values ('" + List.GetFormatStrbjq(d_content.Value) + "','" + Session["username"].ToString() + "','" + Session["realname"].ToString() + "','" + NodeNumber + "','" + NodeName + "','" + System.DateTime.Now.ToString() + "','" + Request.QueryString["Number"] + "')";
        //    List.ExeSql(sql_insert_file);
        //    this.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        //    DataBindToGridview();
        //}
    }
}

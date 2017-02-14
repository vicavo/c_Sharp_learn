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
    public partial class AddWorkFlow_show_lc_tx : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string ContentLable, LineContent;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                LineContent = "";
                ContentLable = "";

                FlowNumber.Text = Request.QueryString["FlowNumber"].ToString();
                string SQL_GetList = "select * from qp_WorkFlowNode   where  FlowNumber='" + Request.QueryString["FlowNumber"] + "'  ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                while (NewReader.Read())
                {
                    if (NewReader["NodeSite"].ToString() == "开始")
                    {
                        ContentLable += "<vml:roundrect id=" + NewReader["NodeNum"].ToString() + " ondblclick=Edit_Process(" + NewReader["id"].ToString() + "); style=\"Z-INDEX: 1; LEFT: " + NewReader["SETLEFT"].ToString() + "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: " + NewReader["SETTOP"].ToString() + "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：" + NewReader["UpNodeNum"].ToString() + "&#13;&#10;--&#13;&#10;经办人姓名：" + NewReader["JBRObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办部门：" + NewReader["JBBMObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办角色：" + NewReader["JBJSObjectName"].ToString() + "&#13;&#10;--&#13;&#10;可写字段：" + NewReader["WriteFileName"].ToString() + "&#13;&#10;--&#13;&#10;审批人员选择：" + NewReader["SpChoice"].ToString() + "&#13;&#10;--&#13;&#10;评审模式：" + NewReader["SpModle"].ToString() + "&#13;&#10;--&#13;&#10;当前节点，" + NewReader["EndtimeSet"].ToString() + "小时未审批自动结束\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#00EE00\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>" + NewReader["NodeNum"].ToString() + "</b><br>" + NewReader["NodeName"].ToString() + "\" passCount=\"0\" flowType=\"start\" table_id=\"" + NewReader["id"].ToString() + "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>" + NewReader["NodeNum"].ToString() + "</B><BR>" + NewReader["NodeName"].ToString() + "</vml:textbox></vml:roundrect>";

                    }
                    else if (NewReader["NodeSite"].ToString() == "结束")
                    {
                        ContentLable += "<vml:roundrect id=" + NewReader["NodeNum"].ToString() + " ondblclick=Edit_Process(" + NewReader["id"].ToString() + "); style=\"Z-INDEX: 1; LEFT: " + NewReader["SETLEFT"].ToString() + "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: " + NewReader["SETTOP"].ToString() + "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：结束&#13;&#10;--&#13;&#10;经办人姓名：" + NewReader["JBRObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办部门：" + NewReader["JBBMObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办角色：" + NewReader["JBJSObjectName"].ToString() + "&#13;&#10;--&#13;&#10;可写字段：" + NewReader["WriteFileName"].ToString() + "&#13;&#10;--&#13;&#10;审批人员选择：" + NewReader["SpChoice"].ToString() + "&#13;&#10;--&#13;&#10;评审模式：" + NewReader["SpModle"].ToString() + "&#13;&#10;--&#13;&#10;当前节点，" + NewReader["EndtimeSet"].ToString() + "小时未审批自动结束\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#F4A8BD\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>" + NewReader["NodeNum"].ToString() + "</b><br>" + NewReader["NodeName"].ToString() + "\" passCount=\"0\" flowType=\"end\" table_id=\"" + NewReader["id"].ToString() + "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>" + NewReader["NodeNum"].ToString() + "</B><BR>" + NewReader["NodeName"].ToString() + "</vml:textbox></vml:roundrect>";

                    }
                    else
                    {
                        ContentLable += "<vml:roundrect id=" + NewReader["NodeNum"].ToString() + " ondblclick=Edit_Process(" + NewReader["id"].ToString() + "); style=\"Z-INDEX: 1; LEFT: " + NewReader["SETLEFT"].ToString() + "px; VERTICAL-ALIGN: middle; WIDTH: 100px; CURSOR: hand; POSITION: absolute; TOP: " + NewReader["SETTOP"].ToString() + "px; HEIGHT: 50px; TEXT-ALIGN: center\"   title=\"下一步骤：" + NewReader["UpNodeNum"].ToString() + "&#13;&#10;--&#13;&#10;经办人姓名：" + NewReader["JBRObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办部门：" + NewReader["JBBMObjectName"].ToString() + "&#13;&#10;--&#13;&#10;经办角色：" + NewReader["JBJSObjectName"].ToString() + "&#13;&#10;--&#13;&#10;可写字段：" + NewReader["WriteFileName"].ToString() + "&#13;&#10;--&#13;&#10;审批人员选择：" + NewReader["SpChoice"].ToString() + "&#13;&#10;--&#13;&#10;评审模式：" + NewReader["SpModle"].ToString() + "&#13;&#10;--&#13;&#10;当前节点，" + NewReader["EndtimeSet"].ToString() + "小时未审批自动结束\";  coordsize=\"21600,21600\" arcsize=\"4321f\" fillcolor=\"#EEEEEE\" receiverName=\"\" receiverID=\"\" readOnly=\"0\" flowFlag=\"0\" flowTitle=\"<b>" + NewReader["NodeNum"].ToString() + "</b><br>" + NewReader["NodeName"].ToString() + "\" passCount=\"0\" flowType=\"\" table_id=\"" + NewReader["id"].ToString() + "\" inset=\"2pt,2pt,2pt,2pt\"><vml:shadowoffset=\"3px,3px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow><vml:textbox onselectstart=\"return false;\" inset=\"1pt,2pt,1pt,1pt\"><B>" + NewReader["NodeNum"].ToString() + "</B><BR>" + NewReader["NodeName"].ToString() + "</vml:textbox></vml:roundrect>";

                    }

                }
                NewReader.Close();
                string SQL_GetList1 = "select * from qp_WorkFlowNodeLine   where  FlowNumber='" + Request.QueryString["FlowNumber"] + "'  ";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                while (NewReader1.Read())
                {
                    LineContent += NewReader1["LineContent"].ToString();

                }

                NewReader1.Close();



            }
        }
    }
}

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
    public partial class WorkFlowListSp_BhNext : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string Sequence, NodeName, Name, FlowId, FqUsername, FqRealname;
        public static int lshid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {



                string SQL_GetList2 = "select * from qp_AddWorkFlow where  Number='" + Request.QueryString["Number"] + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    NodeName = NewReader2["UpNodeName"].ToString();
                    Sequence = NewReader2["Sequence"].ToString();
                    Name = NewReader2["Name"].ToString();
                    FlowId = NewReader2["FlowId"].ToString();
                    FqUsername = NewReader2["FqUsername"].ToString();
                    FqRealname = NewReader2["FqRealname"].ToString();

                }
                NewReader2.Close();//步骤名称，下一节点，当前节点ID

                BindDroList();
                BindAttribute();
            }



            BindLb(FormName.SelectedValue);

        }
        public void BindDroList()
        {
            string sql_down_bh = "select * from qp_WorkFlowNode where  NodeNum  <'" + int.Parse(Request.QueryString["UpNodeNum"]) + "'  and FlowNumber='" + Request.QueryString["FlowNumber"] + "' and   NodeSite='中间段'  order by id desc";
           
            if (!IsPostBack)
            {
                try
                {
                    list.Bind_DropDownListFlowBh(FormName, sql_down_bh, "id", "NodeName");
                }
                catch 
                {
                    Response.Write(sql_down_bh);
                }
            }//节点
        }
        public void BindLb(string str)
        {

            string SQL_GetList2 = "select * from qp_WorkFlowNode where  NodeNum  <'" + int.Parse(Request.QueryString["UpNodeNum"]) + "'  and FlowNumber='" + Request.QueryString["FlowNumber"] + "' and   NodeSite='中间段'  order by id desc";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }
            NewReader2.Close();

            //JBRObjectName.Text = null;
            //JBRObjectId.Text = null;

            //if (FormName.SelectedValue == "0")
            //{
            //   
            //}
            //else
            //{


            //    string SQL_GetList2 = "select * from qp_WorkFlowNode where id='" + Request.QueryString["UpNodeId"] + "'";
            //    SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            //    if (NewReader2.Read())
            //    {
            //            Panel1.Visible = true;
            //            if (NewReader2["SpChoice"].ToString() == "审批时由当前用户从指定人员中选择人员")
            //            {
            //                Label1.Text = "<a href=\"javascript:void(0)\" onclick=\"openUser()\">[选择审批人员]</a>";
            //                Label2.Text = "<a href=\"javascript:void(0)\" onclick=\"openunit()\">[选择审批人员]</a>";
            //                Label3.Text = "<a href=\"javascript:void(0)\" onclick=\"openRespon()\">[选择审批人员]</a>";
            //                Label4.Text = "请从[经办人]、[经办部门]、[经办角色]中选择";
            //            }
            //            else
            //            {
            //                Label1.Text = "由用户指定审批人员";
            //                Label2.Text = "由用户指定审批人员";
            //                Label3.Text = "由用户指定审批人员";
            //                Label4.Text = "<a href=\"javascript:void(0)\" onclick=\"openuser1()\">[选择审批人员]</a>";
            //            }

            //            FormName.Visible = true;
            //            Label5.Visible = false;
            //            Label5.Text = "中间段";
            //  }


                
            //    NewReader2.Close(); //设置审批人员到底是从哪里来
            //}//如果只驳回开始节点  不选择人员


            if (FormName.SelectedValue == "0")
            {
                Label1.Text = "驳回给发起人";
                Label2.Text = "驳回给发起人";
                Label3.Text = "驳回给发起人";
                Label4.Text = "驳回给发起人";

            }
            else
            {
                Label1.Text = "<a href=\"javascript:void(0)\" onclick=\"openUser()\">[选择审批人员]</a>";
                Label2.Text = "<a href=\"javascript:void(0)\" onclick=\"openunit()\">[选择审批人员]</a>";
                Label3.Text = "<a href=\"javascript:void(0)\" onclick=\"openRespon()\">[选择审批人员]</a>";
                Label4.Text = "<a href=\"javascript:void(0)\" onclick=\"openuser1()\">[选择审批人员]</a>";
            }





            string SQL_GetList1 = "select * from qp_WorkFlowNode where id='" + str + "'";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
            if (NewReader1.Read())
            {
                szJBRObjectId.Text = NewReader1["JBRObjectId"].ToString();
                szJBRObjectName.Text = NewReader1["JBRObjectName"].ToString();

                JBBMObjectId.Text = NewReader1["JBBMObjectId"].ToString();
                JBBMObjectName.Text = NewReader1["JBBMObjectName"].ToString();

                JBJSObjectId.Text = NewReader1["JBJSObjectId"].ToString();
                JBJSObjectName.Text = NewReader1["JBJSObjectName"].ToString();

            }
            else 
            {
                szJBRObjectId.Text = "";
                szJBRObjectName.Text = "";

                JBBMObjectId.Text = "";
                JBBMObjectName.Text = "";

                JBJSObjectId.Text = "";
                JBJSObjectName.Text = "";
            
            }
            NewReader1.Close();//设置经办人等




        }

        public void BindAttribute()
        {
            szJBRObjectName.Attributes.Add("readonly", "readonly");
            JBBMObjectName.Attributes.Add("readonly", "readonly");
            JBJSObjectName.Attributes.Add("readonly", "readonly");
            JBRObjectName.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";
            //Button4.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            if (FormName.SelectedValue == "0")
            {
                string Sql_update = "Update qp_AddWorkFlow  Set State='驳回审批',JBRObjectId='驳回审批',JBRObjectName='驳回审批',UpTimeSet='" + System.DateTime.Now.ToString() + "'  where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                List.ExeSql(Sql_update);


                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('你申请的工作[" + Name + "]被驳回，请主题查看','你申请的工作[" + Name + "]被驳回，请主题查看','" + System.DateTime.Now.ToString() + "','" + FqUsername + "','" + FqRealname + "','系统消息','系统消息','否','WorkFlow/WorkFlowSearch.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);


            }
            else
            {

                if (FormName.SelectedValue == "")
                {
                    this.Response.Write("<script language=javascript>alert('未选择驳回步骤！');</script>");
                    return;
                }
                else
                {
                    string SQL_GetList1 = "select * from qp_WorkFlowNode where id='" + FormName.SelectedValue + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        string Sql_update = "Update qp_AddWorkFlow  Set  SpChoice='" + NewReader1["SpChoice"] + "',JBRObjectId='" + JBRObjectId.Text + "',JBRObjectName='" + JBRObjectName.Text + "',SpModle='" + NewReader1["SpModle"] + "',EndtimeSet='" + NewReader1["EndtimeSet"] + "',UpNodeNumber='" + NewReader1["NodeNumber"] + "',UpNodeId='" + NewReader1["id"] + "',UpNodeNum='" + NewReader1["NodeNum"] + "',UpNodeName='" + NewReader1["NodeName"] + "',UpTimeSet='" + System.DateTime.Now.ToString() + "'  where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                        // Response.Write(Sql_update);
                        List.ExeSql(Sql_update);


                        string sql_insert1 = "insert into qp_AddWorkFlowLog (WorkFlowId,FormName,WorkFlowName,Content,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + FormName + "','" + Name + "','审批工作，驳回步骤[" + NewReader1["NodeName"] + "]'," + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert1);

                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('未选择驳回步骤！');</script>");
                        return;
                    }
                    NewReader1.Close();


                    string strlist = null;
                    string str1 = null;
                    str1 = "" + JBRObjectId.Text + "";
                    ArrayList myarr = new ArrayList();
                    string[] mystr = str1.Split(',');
                    for (int s = 0; s < mystr.Length; s++)
                    {
                        strlist += "'" + mystr[s] + "',";
                    }
                    strlist += "'0'";

                    string SQL_GetList_xs = "select * from qp_Username where  username in (" + strlist + ") ";
                    SqlDataReader NewReader = List.GetList(SQL_GetList_xs);
                    while (NewReader.Read())
                    {
                        string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('[" + Name + "]被，请重新办理','[" + Name + "]被驳回，请重新办理','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','WorkFlow/WorkFlowList.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                        List.ExeSql(sql_insertgly);
                    }
                    NewReader.Close();
                }



            }

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowList.aspx'</script>");
            InsertLog("审批工作[" + Name + "]", "待办工作");

        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{

        //    //InsertLog("新增流程名称[" + FlowName.Text + "]", "流程设置");

        //    Response.Redirect("WorkFlowList.aspx");
        //}







    }
}

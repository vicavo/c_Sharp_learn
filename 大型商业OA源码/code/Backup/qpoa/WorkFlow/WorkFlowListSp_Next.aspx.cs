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
    public partial class WorkFlowListSp_Next : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string Sequence, NodeName, Name, FlowId;
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


                }
                NewReader2.Close();//步骤名称，下一节点，当前节点ID

                BindDroList();
                BindAttribute();


                string SQL_GetList_sms = "select * from Sms_Update where Sms_Update='否'";
                SqlDataReader NewReader_sms = List.GetList(SQL_GetList_sms);
                if (NewReader_sms.Read())
                {
                    IMG1.Visible = false;
                    C2.Visible = false;
                }
                NewReader_sms.Close();
            }



            BindLb(FormName.SelectedValue);

        }
        public void BindDroList()
        {
        
            string sql_down_bh = "select id,NodeName  from qp_WorkFlowNode where  NodeNum  in (" + Request.QueryString["UpNodeNum"] + "0) and FlowNumber='" + Request.QueryString["FlowNumber"] + "' order by id desc";
            //Response.Write(sql_down_bh);
            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(FormName, sql_down_bh, "id", "NodeName");
            }//节点

        }
        public void BindLb(string str)
        {
            //JBRObjectName.Text = null;
            //JBRObjectId.Text = null;

            string SQL_GetList2 = "select * from qp_WorkFlowNode where id='" + Request.QueryString["UpNodeId"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                if (NewReader2["NodeSite"].ToString() == "结束")
                {
                    Panel1.Visible = false;
                    Label1.Text = "当前为结束步骤";
                    Label2.Text = "当前为结束步骤";
                    Label3.Text = "当前为结束步骤";
                    Label4.Text = "当前为结束步骤";
                    FormName.Visible=false;
                    Label5.Visible = true;
                    Label5.Text = "结束";
                  
                }
                else
                {
                    Panel1.Visible = true;
                    if (NewReader2["SpChoice"].ToString() == "审批时由当前用户从指定人员中选择人员")
                    {
                        Label1.Text = "<a href=\"javascript:void(0)\" onclick=\"openUser()\">[选择审批人员]</a>";
                        Label2.Text = "<a href=\"javascript:void(0)\" onclick=\"openunit()\">[选择审批人员]</a>";
                        Label3.Text = "<a href=\"javascript:void(0)\" onclick=\"openRespon()\">[选择审批人员]</a>";
                        Label4.Text = "请从[经办人]、[经办部门]、[经办角色]中选择";
                    }
                    else
                    {
                        Label1.Text = "由用户指定审批人员";
                        Label2.Text = "由用户指定审批人员";
                        Label3.Text = "由用户指定审批人员";
                        Label4.Text = "<a href=\"javascript:void(0)\" onclick=\"openuser1()\">[选择审批人员]</a>";
                    }

                    FormName.Visible = true;
                    Label5.Visible = false;
                    Label5.Text = "中间段";
                }




            }
            NewReader2.Close();//设置审批人员到底是从哪里来




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

            string jbryuser = JBRObjectId.Text;//增加代码------1月19日---取的审批人员的用户名和姓名
            string jbryname = JBRObjectName.Text;//增加代码-----1月19日---取的审批人员的用户名和姓名



            string SQL_GetListwt = "select * from qp_WorkFlowWtUsername where State='启用'";
            SqlDataReader NewReaderwt = List.GetList(SQL_GetListwt);
            while (NewReaderwt.Read())
            {
                jbryuser = jbryuser.Replace("" + NewReaderwt["username"] + "", "" + NewReaderwt["wtusername"] + "");
                jbryname = jbryname.Replace("" + NewReaderwt["realname"] + "", "" + NewReaderwt["wtrealname"] + "");
            }
            NewReaderwt.Close();//替换委托人员///增加代码----1月19日--循环把审批人员替换成他委托的人员。


            if (Label5.Text == "结束")
            {
                string GdTypeId = null, GdTypeName = null;

                string SQL_GetList1 = "select * from qp_WorkFlowName where  id='" + FlowId + "'";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    GdTypeId = NewReader1["OverSetConId"].ToString();
                    GdTypeName = NewReader1["OverSetConName"].ToString();

                }
                NewReader1.Close();



                string SQL_GetList2 = "select * from qp_AddWorkFlow where  Number='" + Request.QueryString["Number"] + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    string sql_insert1 = "insert into qp_GdWorkFlow (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,GdTypeId,GdTypeName,Username,Realname,NowTimes) values ('" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["NodeNumber"] + "','" + NewReader2["NodeNum"] + "','" + NewReader2["NodeName"] + "','" + NewReader2["Number"] + "','" + NewReader2["Sequence"] + "','" + NewReader2["Name"] + "','" + NewReader2["FileContent"] + "','" + NewReader2["FqUsername"] + "','" + NewReader2["FqRealname"] + "','" + NewReader2["YJBObjectId"] + "','" + NewReader2["YJBObjecName"] + "','" + GdTypeId + "','" + GdTypeName + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_insert1);

                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您发起的工作：" + NewReader2["Name"] + "审批完成','您发起的工作：" + NewReader2["Name"] + "审批完成','" + System.DateTime.Now.ToString() + "','" + NewReader2["Fqusername"] + "','" + NewReader2["Fqrealname"] + "','系统消息','系统消息','否','WorkFlow/WorkFlowSearch.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);
                }
                NewReader2.Close();





                string Sql_update = "Update qp_AddWorkFlow  Set State='正常结束',JBRObjectId='正常结束',JBRObjectName='正常结束',UpTimeSet='" + System.DateTime.Now.ToString() + "'  where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                List.ExeSql(Sql_update);


            
            }
            else
            {
                if (JBRObjectName.Text == "")
                {
                    this.Response.Write("<script language=javascript>alert('审批人员不能为空！');</script>");
                    return;
                }

                if (FormName.SelectedValue == "")
                {
                    this.Response.Write("<script language=javascript>alert('未选择下一步骤！');</script>");
                    return;
                }
                else
                {
                    string SQL_GetList1 = "select * from qp_WorkFlowNode where id='" + FormName.SelectedValue + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        string Sql_update = "Update qp_AddWorkFlow  Set SpChoice='" + NewReader1["SpChoice"] + "',JBRObjectId='" + jbryuser + "',JBRObjectName='" + jbryname + "',SpModle='" + NewReader1["SpModle"] + "',EndtimeSet='" + NewReader1["EndtimeSet"] + "',UpNodeNumber='" + NewReader1["NodeNumber"] + "',UpNodeId='" + NewReader1["id"] + "',UpNodeNum='" + NewReader1["NodeNum"] + "',UpNodeName='" + NewReader1["NodeName"] + "',UpTimeSet='" + System.DateTime.Now.ToString() + "'  where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                        // Response.Write(Sql_update);
                        List.ExeSql(Sql_update);


                        string sql_insert1 = "insert into qp_AddWorkFlowLog (WorkFlowId,FormName,WorkFlowName,Content,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + FormName + "','" + Name + "','审批工作，转入下一步骤[" + NewReader1["NodeName"] + "]'," + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert1);

                    }
                    else
                    {
                        this.Response.Write("<script language=javascript>alert('未找到下一步骤！');</script>");
                        return;
                    }
                    NewReader1.Close();


                    string strlist = null;
                    string str1 = null;
                    str1 = "" + jbryuser + "";
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

                        if (C1.Checked == true)
                        {
                            string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新工作：需要办理','有新工作：需要办理','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','WorkFlow/WorkFlowList.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                            List.ExeSql(sql_insertgly);
                        }
                        if (C2.Checked == true)
                        {
                            string sql_insert = "insert into OutBox   (username,Mbno,Msg,SendTime,ComPort,Report,V1,V2,V3,V4,V5) values ('" + Session["realname"] + "(" + Session["username"] + ")','" + NewReader["Shouji"] + "','有新工作：[" + Name + "]需要办理','" + System.DateTime.Now.ToString() + "','0','0','','','','','')";
                            List.ExeSql(sql_insert);
                        }

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

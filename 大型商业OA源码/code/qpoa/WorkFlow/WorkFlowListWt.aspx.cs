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
    public partial class WorkFlowListWt : System.Web.UI.Page
    {
        Db List = new Db();
        public static string NodeName, Name, HyUsername, HyRealname;
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

                string SQL_GetList = "select * from qp_AddWorkFlow where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name = NewReader["Name"].ToString();
                    NodeName = NewReader["UpNodeName"].ToString();
                    HyUsername = NewReader["JBRObjectId"].ToString().Replace("" + Session["username"] + ",", "");
                    HyRealname = NewReader["JBRObjectName"].ToString().Replace("" + Session["realname"] + ",", "");
                }
                NewReader.Close();

            }



        }
        public void BindAttribute()
        {
            WtRealname.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkFlowList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_AddWorkFlow  Set JBRObjectId='" + WtUsername.Text + "," + HyUsername + "',JBRObjectName='" + WtRealname.Text + "," + HyRealname + "'   where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);


            string SQL_GetList2 = "select * from qp_AddWorkFlow where  id='" + Request.QueryString["id"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                string SQL_GetList1 = "select * from qp_WtWorkFlow where  Number='" + NewReader2["Number"] + "' and username='"+Session["username"]+"'";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (!NewReader1.Read())
                {
                    string sql_inserta = "insert into qp_WtWorkFlow (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes,State,WtUsername,WtRealname) values ('" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["UpNodeNumber"] + "','" + NewReader2["UpNodeNum"] + "','" + NewReader2["UpNodeName"] + "','" + NewReader2["Number"] + "','" + NewReader2["Sequence"] + "','" + NewReader2["Name"] + "','" + NewReader2["FileContent"] + "','" + NewReader2["FqUsername"] + "','" + NewReader2["FqRealname"] + "','" + NewReader2["YJBObjectId"] + "','" + NewReader2["YJBObjecName"] + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "','等待办理','" + WtUsername.Text + "','" + WtRealname.Text + "')";
                    List.ExeSql(sql_inserta);
                }
                NewReader1.Close();
            }//保存委托
            NewReader2.Close();

            string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('委托工作：[" + Name + "]需要办理，委托人[" + Session["Realname"] + "]','委托工作：[" + Name + "]需要办理，委托人[" + Session["Realname"] + "]','" + System.DateTime.Now.ToString() + "','" + WtUsername.Text + "','" + WtRealname.Text + "','系统消息','系统消息','否','WorkFlow/WorkFlowList.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
            List.ExeSql(sql_insertgly);//提醒

            InsertLog("工作委托[" + Name+ "]", "待办工作");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowList.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

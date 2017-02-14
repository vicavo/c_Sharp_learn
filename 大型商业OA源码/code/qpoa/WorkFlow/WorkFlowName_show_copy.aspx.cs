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
    public partial class WorkFlowName_show_copy : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }
            if (!IsPostBack)
            {
                string sql_down_1 = "select * from qp_WorkFlowName  where FlowNumber!='" + Request.QueryString["FlowNumber"] + "' order by id desc";
                list.Bind_DropDownList(FlowNumber, sql_down_1, "FlowNumber", "FlowName");
            }

     
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string SQL_GetList1 = "select * from qp_WorkFlowName where FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
            if (NewReader1.Read())
            {

                string SQL_GetList = "select * from qp_WorkFlowNode where FlowNumber='" + FlowNumber.SelectedValue + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                while (NewReader.Read())
                {
                    string sql_insert1 = "insert into qp_WorkFlowNode (AllowFile,AllowDelFile,UpNodeNum,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,JBRObjectId,JBRObjectName,JBBMObjectId,JBBMObjectName,JBJSObjectId,JBJSObjectName,SpModle,SpChoice,EndtimeSet,StopSp,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,NodeSite) values ('" +  NewReader["AllowFile"].ToString() + "','" + NewReader["AllowDelFile"].ToString() + "','" + NewReader["UpNodeNum"].ToString() + "','" + NewReader1["FormId"].ToString() + "','" + NewReader1["FormNumber"].ToString() + "','" + NewReader1["FormName"].ToString() + "','" + NewReader1["id"].ToString() + "','" + NewReader1["FlowNumber"].ToString() + "','" + NewReader1["FlowName"].ToString() + "','" + NewReader["NodeNumber"].ToString() + "','" + NewReader["NodeNum"].ToString() + "','" + NewReader["NodeName"].ToString() + "','" + NewReader["SETLEFT"].ToString() + "','" + NewReader["SETTOP"].ToString() + "','" + NewReader["JBRObjectId"].ToString() + "','" + NewReader["JBRObjectName"].ToString() + "','" + NewReader["JBBMObjectId"].ToString() + "','" + NewReader["JBBMObjectName"].ToString() + "','" + NewReader["JBJSObjectId"].ToString() + "','" + NewReader["JBJSObjectName"].ToString() + "','" + NewReader["SpModle"].ToString() + "','" + NewReader["SpChoice"].ToString() + "','" + NewReader["EndtimeSet"].ToString() + "','" +  NewReader["StopSp"].ToString() + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + NewReader["NodeSite"].ToString() + "')";

                    List.ExeSql(sql_insert1);
                }
                NewReader.Close();


                string SQL_GetList2 = "select * from qp_WorkFlowNodeLine where FlowNumber='" + FlowNumber.SelectedValue + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                while (NewReader2.Read())
                {
                    string sql_insert = "insert into qp_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + NewReader2["Source"].ToString() + "','" + NewReader2["Object"].ToString() + "','" + NewReader2["LineContent"].ToString() + "','" + NewReader2["NodeNumber"].ToString() + "','" + NewReader1["FlowNumber"].ToString() + "')";
                    List.ExeSql(sql_insert);
                }
                NewReader.Close();
            }

            NewReader1.Close();
         this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='WorkFlowName_show.aspx?FormId=" + Request.QueryString["FormId"] + "';window.close();</script>");
        }

    }
}

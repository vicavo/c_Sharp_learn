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
namespace qpoa.KmManage
{
    public partial class KmTitle_show_state : System.Web.UI.Page
    {
        Db List = new Db();
        public static string ShowTitle, State;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_KmTitle  where id='" + Request.QueryString["id"] + "'  ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    ShowTitle = NewReader["Title"].ToString();
                    State = NewReader["State"].ToString();
                }
                NewReader.Close();

                if (State == "等待审批")
                {
                    Panel2.Visible = true;
                }

                if (State == "禁止发布")
                {
                    Panel4.Visible = true;
                }

                if (State == "暂存")
                {
                    Panel1.Visible = true;
                }

                if (State == "正常")
                {
                    Panel5.Visible = true;
                }

                if (State == "用户终止")
                {
                    Panel3.Visible = true;
                }



            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string KmManger = null;

            string SQL_GetList = "select * from qp_KmManger ";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList);
            if (NewReader1.Read())
            {
                KmManger = NewReader1["Username"].ToString();
            }
            NewReader1.Close();

            string strlist = null;
            string str1 = null;
            str1 = "" + KmManger + "";
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
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的知识需要审批，请注意查看！','有新的知识需要审批，请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','KmManage/KmTitleSp.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);
            }
            NewReader.Close();






            string Sql_update = "Update qp_KmTitle  Set State='等待审批'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("知识送审[" + Title + "]", "我的知识");

            this.Response.Write("<script language=javascript>alert('提交成功，请等待审批！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["LittleId"] + "';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_KmTitle  Set State='正常'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("知识开启[" + Title + "]", "我的知识");

            this.Response.Write("<script language=javascript>alert('提交成功，状态改变为［正常］！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["LittleId"] + "';window.close();</script>");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string KmManger = null;

            string SQL_GetList = "select * from qp_KmManger ";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList);
            if (NewReader1.Read())
            {
                KmManger = NewReader1["Username"].ToString();
            }
            NewReader1.Close();

            string strlist = null;
            string str1 = null;
            str1 = "" + KmManger + "";
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
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的知识需要审批，请注意查看！','有新的知识需要审批，请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','KmManage/KmTitleSp.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);
            }
            NewReader.Close();



            string Sql_update = "Update qp_KmTitle  Set State='等待审批'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("知识送审[" + Title + "]", "我的知识");
            this.Response.Write("<script language=javascript>alert('提交成功，请等待审批！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["LittleId"] + "';window.close();</script>");

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_KmTitle  Set State='用户终止'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("知识终止[" + Title + "]", "我的知识");
            this.Response.Write("<script language=javascript>alert('提交成功，状态改变为［用户终止］！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["LittleId"] + "';window.close();</script>");

        }
    }
}

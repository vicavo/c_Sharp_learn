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
namespace qpoa
{
    public partial class _Default : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) values ('访问系统','访问系统','访问系统','访问系统','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','','','')";
                List.ExeSql(sql_insert_log);

                KaoQin();

                //string Sql_update = "Update qp_AddWorkFlow  Set State='自动结束',JBRObjectId='自动结束',JBRObjectName='自动结束',UpTimeSet='" + System.DateTime.Now.ToString() + "'   where datediff(hh,UpTimeSet,getdate())>EndtimeSet  and State='正在办理'";
                //List.ExeSql(Sql_update);//每个步骤限制结束时间，服务器上的版本取消此功能，防止结束时间到了，演示数据丢失。
            }
        }

        public void KaoQin()
        {
            string SQL_GetList_kq = "select * from qp_WorkTimeDj  where convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120) ";
            SqlDataReader NewReader_kq = List.GetList(SQL_GetList_kq);
            if (!NewReader_kq.Read())//首先看数据库是否有了今天的考勤记录，如果没有就开始录入考勤信息
            {

                string SQL_GetList_us = "select * from qp_username ";
                SqlDataReader NewReader_us = List.GetList(SQL_GetList_us);
                while (NewReader_us.Read())
                {
                    string DjType_1 = null, DjType_2 = null, DjType_3 = null, DjType_4 = null, DjType_5 = null, DjType_6 = null, PbType = null;

                    string SQL_GetList_sj = "select * from qp_WorkTime   where QyType='启用'   and  (CHARINDEX('," + NewReader_us["username"] + ",',','+SyUsername+',')   >   0 ) ";
                    SqlDataReader NewReader_sj = List.GetList(SQL_GetList_sj);
                    if (NewReader_sj.Read())
                    {
                        PbType = NewReader_sj["PbType"].ToString();
                        DjType_1 = NewReader_sj["DjType_1"].ToString();
                        DjType_2 = NewReader_sj["DjType_2"].ToString();
                        DjType_3 = NewReader_sj["DjType_3"].ToString();
                        DjType_4 = NewReader_sj["DjType_4"].ToString();
                        DjType_5 = NewReader_sj["DjType_5"].ToString();
                        DjType_6 = NewReader_sj["DjType_6"].ToString();

                        string SQL_i = "insert into qp_WorkTimeDj  values( '" + PbType + "','" + DjType_1 + "','0:0:0','未考勤','" + DjType_2 + "','0:0:0','未考勤','" + DjType_3 + "','0:0:0','未考勤','" + DjType_4 + "','0:0:0','未考勤','" + DjType_5 + "','0:0:0','未考勤','" + DjType_6 + "','0:0:0','未考勤','" + NewReader_us["Unit"] + "','" + NewReader_us["UnitId"] + "','" + System.DateTime.Now.ToShortDateString() + "','" + System.DateTime.Now.ToShortDateString() + " 0:0:0','" + NewReader_us["Username"] + "','" + NewReader_us["Realname"] + "')";
                       
                        List.ExeSql(SQL_i);

                        string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('请注意考勤登记','请注意考勤登记','" + System.DateTime.Now.ToString() + "','" + NewReader_us["username"] + "','" + NewReader_us["realname"] + "','系统消息','系统消息','否','MyAffairs/WorkTimeDj.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                        List.ExeSql(sql_insertgly);


                    }
                    NewReader_sj.Close();
                }
                NewReader_us.Close();

            }
            NewReader_kq.Close();


        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5");

            string SQL_Check_worknum = "select * from qp_Username where Username='" + List.GetFormatStr(Username.Text) + "' and Password='" + hashPassword + "' ";
            SqlDataReader MyReader_worknum = List.GetList(SQL_Check_worknum);
            if (MyReader_worknum.Read())
            {
                string SQL_Check_if = "select * from qp_Username where Username='" + List.GetFormatStr(Username.Text) + "' and Password='" + hashPassword + "'and Iflogin='是'  ";
                SqlDataReader MyReader_if = List.GetList(SQL_Check_if);
                if (MyReader_if.Read())
                {
                    this.Session["userName"] = MyReader_worknum["Username"].ToString();
                    this.Session["realname"] = MyReader_worknum["realname"].ToString();


                    string SQL_GetList2 = "select * from qp_WorkFlowWtUsername where  username='" + Session["username"] + "' and State='启用'";
                    SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                    if (NewReader2.Read())
                    {
                        string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您在工作审批中设置了委托人员，请注意！','您在工作审批中设置了委托人员，请注意！','" + System.DateTime.Now.ToString() + "','" + MyReader_worknum["Username"].ToString() + "','" + MyReader_worknum["realname"].ToString() + "','系统消息','系统消息','否','WorkFlow/WorkFlowWtUsername.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                        List.ExeSql(sql_insertgly);
                    }
                    NewReader2.Close();//判断是否有委托人员。。。。。

                    string Sql_updateonline = "Update qp_username Set lasttime='" + System.DateTime.Now.ToString() + "' where username='" + this.Session["userName"] + "'";
                    List.ExeSql(Sql_updateonline);


                    InsertLog("登陆系统[" + Session["realname"] + "]", "登陆系统");
                    Response.Redirect("main.aspx");

                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('此帐号不允许登陆！');</script>");
                    return;
                }
                MyReader_if.Close();

            }
            else
            {
                this.Response.Write("<script language=javascript>alert('用户名或密码错误！请联系您所交流的客服QQ或电话！');</script>");
                return;

            }

            MyReader_worknum.Close();
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

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
    public partial class testmain : System.Web.UI.Page
    {
        public static string showpost, showrealname, txtime, iftx, Sound, showtime;
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.location.href='Default.aspx'</script>");
                return;

            }
            string Sql_updateonline = "Update qp_username Set lasttime='" + System.DateTime.Now.ToString() + "' where username='" + Session["username"] + "'";
            List.ExeSql(Sql_updateonline);


            //string SQL_GetCount = "select count(id) from  qp_username";
            //int CountsUser = List.GetCount(SQL_GetCount);
            //if (CountsUser > 10)
            //{
            //    Response.Write("<script>alert('试用版，软件使用人数限制为10人！请联系开发商！');window.location.href='Default.aspx'</Script>");
            //    return;
            //}//试用版，软件使用人数受到限制！请联系开发商



            Label1.Text = "使用单位：国际集团";


            //TimeSpan sp = DateTime.Parse(DateTime.Now.ToShortDateString()) - DateTime.Parse("2008-9-1");
            //if (sp.TotalDays > 0)
            //{

            //    Response.Write("<script>alert('您的版本已经过期！');window.location.href='Default.aspx'</Script>");
            //    return;
            //}//试用版过期设置



            string SQL_GetList_key = "select * from qp_FjKey ";
            SqlDataReader NewReader_key = List.GetList(SQL_GetList_key);
            if (NewReader_key.Read())
            {
                this.Session["FjKey"] = NewReader_key["content"];
            }
            NewReader_key.Close();//附件类型




            showtime = "" + System.DateTime.Now.Year.ToString() + "年" + System.DateTime.Now.Month.ToString() + "月" + System.DateTime.Now.Day.ToString() + "日";


            this.ImageButton1.Attributes.Add("onclick", "javascript:return zx();");

            string SQL_GetListus = "select * from qp_username where username='" + Session["username"] + "'";
            SqlDataReader NewReaderUs = List.GetList(SQL_GetListus);
            if (NewReaderUs.Read())
            {

                this.Session["Post"] = NewReaderUs["Post"];
                this.Session["PostId"] = NewReaderUs["PostId"];
                this.Session["Unit"] = NewReaderUs["Unit"];
                this.Session["UnitId"] = NewReaderUs["UnitId"];
                this.Session["Respon"] = NewReaderUs["Respon"];
                this.Session["ResponId"] = NewReaderUs["ResponId"];
                this.Session["QxString"] = NewReaderUs["QxString"];
                this.Session["KeyQx"] = NewReaderUs["KeyQx"];
                this.Session["perstr"] = NewReaderUs["ResponQx"];
            }
            NewReaderUs.Close();//用户参数



            string SQL_GetListtar = "select * from qp_IfOpen where username='" + Session["username"] + "'";
            SqlDataReader NewReaderTar = List.GetList(SQL_GetListtar);
            if (NewReaderTar.Read())
            {
                this.Session["Target"] = NewReaderTar["Name"];

            }
            NewReaderTar.Close();//用户参数



            string SQL_GetList_xs = "select * from qp_MyCalendar   where   datediff(dd,getdate(),CalendarTime)<=0 and IfOk='否' and Iftx='是'";
            SqlDataReader NewReaderxs = List.GetList(SQL_GetList_xs);
            while (NewReaderxs.Read())
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有日程安排需要完成[" + System.DateTime.Parse(NewReaderxs["CalendarTime"].ToString()).ToShortDateString() + "]，请注意查看！','有日程安排需要完成[" + System.DateTime.Parse(NewReaderxs["CalendarTime"].ToString().ToString()).ToShortDateString() + "]，请注意查看！\n开始时间：" + NewReaderxs["StarttimeHour"] + "：" + NewReaderxs["StarttimeMini"] + "\n结束时间：" + NewReaderxs["EndtimeHour"] + "：" + NewReaderxs["EndtimeMini"] + "\n内容：\n" + NewReaderxs["Content"] + "','" + System.DateTime.Now.ToString() + "','" + NewReaderxs["username"] + "','" + NewReaderxs["realname"] + "','系统消息','系统消息','否','MyAffairs/MyCalendar.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);


                string Sql_update1 = "Update qp_MyCalendar  Set IfOk='是'  where id='" + NewReaderxs["id"] + "'";
                List.ExeSql(Sql_update1);
            }
            NewReaderxs.Close();//个人日程提醒







            string SQL_GetList_xsz = "select * from qp_SaleGroup where id='1'";
            SqlDataReader NewReader_xsz = List.GetList(SQL_GetList_xsz);
            if (NewReader_xsz.Read())
            {
                this.Session["GroupName"] = NewReader_xsz["GroupName"];
                this.Session["GroupId"] = NewReader_xsz["id"];
            }
            else
            {
                this.Session["GroupName"] = "0";
                this.Session["GroupId"] = "0";
            }
            NewReader_xsz.Close();//销售组


            showpost = this.Session["Post"].ToString();
            showrealname = this.Session["realname"].ToString();


            string SQL_GetCount_zx = "select count(A.id) from [qp_username] as [A] where datediff(ss,lasttime,getdate())<=10";
            ViewState["zaixian"] = List.GetCount(SQL_GetCount_zx);


            oaurl.Text = null;
            oaurl.Text += "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>";
            string SQL_GetListLeftlittle = "select * from qp_url   where  (CHARINDEX(''+quanxian+'','" + this.Session["perstr"] + "')   >   0 ) order by paixu asc";
            SqlDataReader NewReaderLeftlittle = List.GetList(SQL_GetListLeftlittle);
            while (NewReaderLeftlittle.Read())
            {
                oaurl.Text += "<td style=\"width: 102px; height: 38px;\" align=\"left\"><ul id=\"UL1\"><li class=\"L22\"><a href=\"" + NewReaderLeftlittle["url"] + "\" target=\"lform\"><span><img src=\"images/menu/" + NewReaderLeftlittle["pic"] + "\" width=\"16px\" height=\"16px\" border=\"0\"><b><font color=\"#ffffff\">" + NewReaderLeftlittle["urlname"] + "</font></b></span></a></li></ul></td>";
            }
            NewReaderLeftlittle.Close();
            oaurl.Text += "</tr></table>";
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            InsertLog("注销系统", "注销系统");
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

    }
}

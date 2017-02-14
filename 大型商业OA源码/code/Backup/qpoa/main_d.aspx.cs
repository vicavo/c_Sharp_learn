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
    public partial class main_d : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                //this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = 'default.aspx'</script>");
                Response.Redirect("default.aspx");
                return;

            }

           


            string SQL_tb = "select   * from qp_DIYMould where username='" + this.Session["username"] + "'  order by PaiXun asc";

            SqlDataReader NewReaderTB = List.GetList(SQL_tb);

            this.Label.Text = null;
            int glTMP1 = 0;
            this.Label.Text += "<table width=\"100%\"   border=\"0\" cellspacing=\"0\" cellpadding=\"0\" >";
            this.Label.Text += "<tr>";
            while (NewReaderTB.Read())
            {
                string SQL_tbx=null;
                string lstr = null;

                if (NewReaderTB["Name"].ToString() == "内部消息")
                {
                    SQL_tbx = "select top  " + NewReaderTB["LookMuch"] + "  * from qp_Messages  where  sfck='否' and  acceptusername='" + Session["username"] + "'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=InfoSpeech/Messages_show.aspx?id=" + NewReaderTBx["id"] + "   title=\"发送人：" + NewReaderTBx["sendrealname"] + "&#13;发送时间：" + NewReaderTBx["itimes"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["title"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//内部消息


                if (NewReaderTB["Name"].ToString() == "内部邮件")
                {
                    SQL_tbx = "select top  " + NewReaderTB["LookMuch"] + "  * from qp_NbMailAccept  where  sfck='否' and  acceptusername='" + Session["username"] + "'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=InfoSpeech/NbMailAccept_show.aspx?id=" + NewReaderTBx["id"] + "  title=\"发送人：" + NewReaderTBx["sendrealname"] + "&#13;发送时间：" + NewReaderTBx["itimes"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["title"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//内部邮件




                if (NewReaderTB["Name"].ToString() == "部门通知")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_UnitNotic    where  (UnitNameId='" + Session["UnitId"] + "' or  CHARINDEX('," + this.Session["UnitId"] + ",',','+GxUnitNameId+',')   >   0 )  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"MyAffairs/MyUnitNotic_show.aspx?id=" + NewReaderTBx["id"] + "\" title=\"部门：" + NewReaderTBx["UnitName"].ToString().Replace("|", "").Replace("-", "") + "&#13;时间：" + NewReaderTBx["NowTimes"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["title"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//部门通知


                if (NewReaderTB["Name"].ToString() == "公司通知")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_CompanyNotic    where  (CHARINDEX('," + this.Session["UnitId"] + ",',','+GxUnitNameId+',')   >   0 )  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"MyAffairs/MyCompanyNotic_show.aspx?id=" + NewReaderTBx["id"] + "\" title=\"标题：" + NewReaderTBx["Title"].ToString().Replace("|", "").Replace("-", "") + "&#13;时间：" + NewReaderTBx["NowTimes"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["title"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//公司通知






                if (NewReaderTB["Name"].ToString() == "今日日程")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_MyCalendar    where  Username='" + this.Session["username"] + "'   and (convert(char(10),cast(CalendarTime as datetime),120)=convert(char(10),cast('" + System.DateTime.Now.ToShortDateString() + "' as datetime),120) )   order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"MyAffairs/MyCalendar_show.aspx?id=" + NewReaderTBx["id"] + "&time=" + System.DateTime.Now.ToShortDateString() + "\" title=\"事务时间：" + NewReaderTBx["CalendarTime"].ToString() + "&#13;开始时间：" + NewReaderTBx["StarttimeHour"] + "：" + NewReaderTBx["StarttimeMini"] + "&#13;结束时间：" + NewReaderTBx["EndtimeHour"] + "：" + NewReaderTBx["EndtimeMini"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Content"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//今日日程



                if (NewReaderTB["Name"].ToString() == "我的会议")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_MettingApply    where  (State='已通过' or State='进行中'  or State='已结束' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0    order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"MyAffairs/MyMetting_show.aspx?id=" + NewReaderTBx["id"] + "\" title=\"主题：" + NewReaderTBx["Title"].ToString() + "&#13;会议状态：" + NewReaderTBx["State"] + "&#13;开始时间：" + NewReaderTBx["Starttime"] + "&#13;结束时间：" + NewReaderTBx["Endtime"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Name"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//我的会议



                if (NewReaderTB["Name"].ToString() == "待办工作")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_AddWorkFlow    where  (CHARINDEX('," + this.Session["username"] + ",',','+JBRObjectId+',')   >   0 )    order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"WorkFlow/WorkFlowListSp.aspx?id=" + NewReaderTBx["id"] + "&UpNodeId=" + NewReaderTBx["UpNodeId"] + "&FlowNumber=" + NewReaderTBx["FlowNumber"] + "&FormId=" + NewReaderTBx["FormId"] + "\" title=\"流水号：" + NewReaderTBx["Sequence"].ToString() + "&#13;表单类型：" + NewReaderTBx["FormName"] + "&#13;工作名称/文号：" + NewReaderTBx["Name"] + "&#13;发起人：" + NewReaderTBx["FqRealname"] + "&#13;步骤与流程图：" + NewReaderTBx["NodeName"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Name"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//待办工作


                if (NewReaderTB["Name"].ToString() == "待批会议")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from  qp_MettingApply  where  State='待审批' and  ManagerUser='" + this.Session["username"] + "'   order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"PublicAffairs/MettingApply_sp_sp.aspx?id=" + NewReaderTBx["id"] + "\" title=\"会议名称：" + NewReaderTBx["Name"].ToString() + "&#13;主题：" + NewReaderTBx["Title"] + "&#13;会议室：" + NewReaderTBx["MettingName"] + "&#13;开始时间：" + NewReaderTBx["Starttime"] + "&#13;结束时间：" + NewReaderTBx["Endtime"] + "&#13;申请人：" + NewReaderTBx["Realname"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Name"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//待批会议



                if (NewReaderTB["Name"].ToString() == "待批车辆")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_CarApply  where  State='待审批' and  ManagerUser='" + this.Session["username"] + "'   order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"PublicAffairs/CarApply_sp_sp.aspx?id=" + NewReaderTBx["id"] + "\" title=\"车牌号：" + NewReaderTBx["CarNum"].ToString() + "&#13;用车人：" + NewReaderTBx["Carpeople"] + "&#13;用车部门：" + NewReaderTBx["UnitName"].ToString().Replace("-", "").Replace("|", "") + "&#13;开始时间：" + NewReaderTBx["Starttime"] + "&#13;结束时间：" + NewReaderTBx["Endtime"] + "&#13;申请人：" + NewReaderTBx["Realname"] + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["CarNum"] + "(" + NewReaderTBx["Carpeople"] + ")</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//待批车辆




                if (NewReaderTB["Name"].ToString() == "投票浏览")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_toupiaobt where  ifopen='公开' and  CHARINDEX('," + this.Session["Username"] + ",',','+Gkusername+',')   >   0    order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"InfoSpeech/toupiao_tp.aspx?id=" + NewReaderTBx["id"] + "\" title=\"投票主题：" + NewReaderTBx["title"].ToString() + "&#13;选择类型：" + NewReaderTBx["xuanze"] + "&#13;当前状态：" + NewReaderTBx["type"].ToString()+ "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["title"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//投票浏览


                if (NewReaderTB["Name"].ToString() == "病假审批")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_MyAttendance  where  (Shenpi='未审批') and Type='1'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"HumanResources/MyAttendanceSp_sp.aspx?id=" + NewReaderTBx["id"] + "&type=1\" title=\"事由：" + NewReaderTBx["Subject"].ToString() + "&#13;开始时间：" + NewReaderTBx["StartTime"] + "&#13;结束时间：" + NewReaderTBx["EndTime"].ToString() + "&#13;登记人：" + NewReaderTBx["Realname"].ToString() + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Subject"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//病假审批


                if (NewReaderTB["Name"].ToString() == "事假审批")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_MyAttendance  where  (Shenpi='未审批') and Type='2'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"HumanResources/MyAttendanceSp_sp.aspx?id=" + NewReaderTBx["id"] + "&type=2\" title=\"事由：" + NewReaderTBx["Subject"].ToString() + "&#13;开始时间：" + NewReaderTBx["StartTime"] + "&#13;结束时间：" + NewReaderTBx["EndTime"].ToString() + "&#13;登记人：" + NewReaderTBx["Realname"].ToString() + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Subject"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//事假审批



                if (NewReaderTB["Name"].ToString() == "出差审批")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_MyAttendance  where  (Shenpi='未审批') and Type='3'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"HumanResources/MyAttendanceSp_sp.aspx?id=" + NewReaderTBx["id"] + "&type=3\" title=\"事由：" + NewReaderTBx["Subject"].ToString() + "&#13;开始时间：" + NewReaderTBx["StartTime"] + "&#13;结束时间：" + NewReaderTBx["EndTime"].ToString() + "&#13;登记人：" + NewReaderTBx["Realname"].ToString() + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Subject"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//出差审批



                if (NewReaderTB["Name"].ToString() == "加班审批")
                {
                    SQL_tbx = "select top " + NewReaderTB["LookMuch"] + "  * from   qp_MyAttendance  where  (Shenpi='未审批') and Type='4'  order by id desc";


                    SqlDataReader NewReaderTBx = List.GetList(SQL_tbx);



                    lstr += "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";

                    while (NewReaderTBx.Read())
                    {
                        lstr += "<tr><td>&nbsp;&nbsp;<a href=\"HumanResources/MyAttendanceSp_sp.aspx?id=" + NewReaderTBx["id"] + "&type=4\" title=\"事由：" + NewReaderTBx["Subject"].ToString() + "&#13;开始时间：" + NewReaderTBx["StartTime"] + "&#13;结束时间：" + NewReaderTBx["EndTime"].ToString() + "&#13;登记人：" + NewReaderTBx["Realname"].ToString() + "\"><img src=\"images/news.gif\" width=\"15\" height=\"10\" border=\"0\" />" + NewReaderTBx["Subject"] + "</a></td></tr>";
                    }
                    lstr += "</table>";
                    NewReaderTBx.Close();
                }//加班审批





                this.Label.Text += " <td width=\"49%\" valign=\"top\"> <table width=\"100%\" height=\"12\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td></td> </tr></table><table width=\"100%\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td valign=\"top\" ><table width=\"100%\" height=\"5\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>  <td width=\"142\" background=\"images/body11.jpg\">&nbsp;&nbsp;&nbsp;<a href=\"" + NewReaderTB["UrlMath"] + "\" class=\"write\"><strong>" + NewReaderTB["Name"].ToString() + "...</strong></a></td><td background=\"images/body13.jpg\" align=\"right\"><A href=\"javascript:_update(" + NewReaderTB["id"].ToString() + ");\"><img src=\"images/edit.gif\"  border=\"0\" /></a>&nbsp;<A href=\"javascript:_del(" + NewReaderTB["id"].ToString() + ");\"><img src=\"images/closetab.gif\"  border=\"0\" /></a>&nbsp;</td><td width=\"12\" background=\"images/body12.jpg\">&nbsp;</td></tr></table><table width=\"100%\" height=\"" + int.Parse(NewReaderTB["LookMuch"].ToString())*25+ "px\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr> <td valign=\"top\">" + lstr + "</td></tr></table><table width=\"100%\" height=\"10\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" background=\"images/body15.jpg\" ><tr> <td></td></tr></table>  </td></tr> </table></td><td width=\"2%\">&nbsp;</td>";


                glTMP1 = glTMP1 + 1;
                if (glTMP1 == 2)
                {
                    Label.Text += "</tr><TR>";
                    glTMP1 = 0;
                }
               
            }
            this.Label.Text += " </table><script language=\"javascript\">document.getElementById('show').style.display='none'; </script>";
            NewReaderTB.Close();
        }
    }
}

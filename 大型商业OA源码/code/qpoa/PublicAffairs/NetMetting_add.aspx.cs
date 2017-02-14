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
namespace qpoa.PublicAffairs
{
    public partial class NetMetting_add : System.Web.UI.Page
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
                MettingHeaderUser.Text = Session["username"].ToString();
                MettingHeader.Text = Session["realname"].ToString();

                BindAttribute();
            }
        }

        public void BindAttribute()
        {
            MettingHeader.Attributes.Add("readonly", "readonly");
            NbPeopleName.Attributes.Add("readonly", "readonly");
            Starttime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("NetMetting.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_NetMetting  (CjUsername,CjRealname,Name,Title,Introduction,WbPeople,NbPeopleUser,NbPeopleName,MettingHeaderUser,MettingHeader,MettingIp,Starttime,Endtime,State,JyUsername,JyRealname,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('','','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStr(Introduction.Text) + "','" + List.GetFormatStr(WbPeople.Text) + "','" + List.GetFormatStr(NbPeopleUser.Text) + "','" + List.GetFormatStr(NbPeopleName.Text) + "','" + List.GetFormatStr(MettingHeaderUser.Text) + "','" + List.GetFormatStr(MettingHeader.Text) + "','" + List.GetFormatStr(MettingIp.Text) + "','" + List.GetFormatStr(Starttime.Text) + "','" + List.GetFormatStrbjq(Endtime.Text) + "','正常状态','" + List.GetFormatStr(NbPeopleUser.Text) + "','" + List.GetFormatStr(NbPeopleName.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            if (DL1.SelectedValue == "是")
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的网络会议需要主持，请注意查看！','有新的网络会议需要主持，请注意查看！','" + System.DateTime.Now.ToString() + "','" + List.GetFormatStr(MettingHeaderUser.Text) + "','" + List.GetFormatStr(MettingHeader.Text) + "','系统消息','系统消息','否','MyAffairs/MyNetMettingZc.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);

            }
            if (DL2.SelectedValue == "是")
            {
                string strlist = null;
                string str1 = null;
                str1 = "" + NbPeopleUser.Text + "";
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
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的网络会议需要参加，请注意查看！','有新的网络会议需要参加，请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','MyAffairs/MyNetMetting.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);
                }
                NewReader.Close();

            }

            InsertLog("新增网络会议[" + Name.Text + "]", "网络会议");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NetMetting.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

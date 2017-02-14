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
namespace qpoa.InfoSpeech
{
    public partial class MvTo_add : System.Web.UI.Page
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

           
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["user"] != null)
                {
                    acceptusername.Text = "" + Server.UrlDecode(Request.QueryString["user"]) + ",";
                    acceptrealname.Text = "" + Server.UrlDecode(Request.QueryString["name"]) + ",";
                }
                BindAttribute();
            }
          
        }
        public void BindAttribute()
        {

            acceptrealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strlist = null;
            string str1 = null;
            str1 = "" + acceptusername.Text + "";
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
                string sql_insert = "insert into OutBox   (username,Mbno,Msg,SendTime,ComPort,Report,V1,V2,V3,V4,V5) values ('" + Session["realname"] + "(" + Session["username"] + ")','" + NewReader["ShouJi"] + "','" + List.GetFormatStr(Msg.Text) + "','" + System.DateTime.Now.ToString() + "','0','0','','','','','')";
                List.ExeSql(sql_insert);
            }
            NewReader.Close();

            InsertLog("发送手机短信", "手机短信管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MvTo.aspx'</script>");

        
          
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("MvTo.aspx");
        }



    }
}

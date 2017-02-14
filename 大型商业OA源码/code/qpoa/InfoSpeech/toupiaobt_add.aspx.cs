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
    public partial class toupiaobt_add : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
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
            }
        }
        public void BindAttribute()
        {
            Gkrealname.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insertglya = "insert into qp_toupiaobt  (title,xuanze,username,realname,Gkusername,Gkrealname,type,ifopen) values ('" + List.GetFormatStr(title.Text) + "','" + xuanze.SelectedValue + "','" + Session["username"] + "','" + Session["realname"] + "','" + Gkusername.Text + "','" + Gkrealname.Text + "','进行中','" + ifopen.SelectedValue + "')";
            List.ExeSql(sql_insertglya);





            if (ifopen.SelectedValue == "公开")
            {

                string strlist = null;
                string str1 = null;
                str1 = "" + Gkusername.Text + "";
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
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的投票需要您参与，请注意查看','有新的投票需要您参与，请注意查看','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + Session["username"] + "','" + Session["realname"] + "','否','InfoSpeech/toupiao.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);
                }
                NewReader.Close();

            }



           
            InsertLog("新增投票主题[" + title.Text + "]", "投票管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='toupiaobt.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                              + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

    }
}

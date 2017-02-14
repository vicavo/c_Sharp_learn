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
    public partial class Messages_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_Messages where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and (acceptusername='" + Session["username"] + "' or sendusername='" + Session["username"] + "')";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    title.Text = NewReader["title"].ToString();
                    content.Text = List.TbToLb(NewReader["content"].ToString());
                    itimes.Text = NewReader["itimes"].ToString();
                    sendrealname.Text = NewReader["sendrealname"].ToString();
                    acceptrealname.Text = NewReader["acceptrealname"].ToString();
                    sfck.Text = NewReader["sfck"].ToString();



                    string Sql_update1 = "Update qp_Messages Set sfck='是'  where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and (acceptusername='" + Session["username"] + "' or sendusername='" + Session["username"] + "')";
                    List.ExeSql(Sql_update1);
                }
                NewReader.Close();
                InsertLog("查看内部消息", "内部消息管理");
             
            }





        }







        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

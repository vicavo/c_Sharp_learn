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
    public partial class KmTitle_show_show : System.Web.UI.Page
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


             

                string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    BigId.Text = NewReader["BigId"].ToString();
                    BigName.Text = NewReader["BigName"].ToString();
                    LittleId.Text = NewReader["LittleId"].ToString();
                    LittleName.Text = NewReader["LittleName"].ToString();
                    Title.Text = NewReader["Title"].ToString();
                    Content.Text = List.TbToLb(NewReader["Content"].ToString());
                    AthourSay.Text = NewReader["AthourSay"].ToString();
                    KeyWord.Text = NewReader["KeyWord"].ToString();
                    QxYdUsername.Text = NewReader["QxYdUsername"].ToString();
                    QxYdRealname.Text = NewReader["QxYdRealname"].ToString();
                    //QxXgUsername.Text = NewReader["QxXgUsername"].ToString();
                    //QxXgRealname.Text = NewReader["QxXgRealname"].ToString();
                    LastTime.Text = NewReader["LastTime"].ToString();
                }

                NewReader.Close();


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

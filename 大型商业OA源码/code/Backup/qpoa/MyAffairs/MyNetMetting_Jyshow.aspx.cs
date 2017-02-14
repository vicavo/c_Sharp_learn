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
namespace qpoa.MyAffairs
{
    public partial class MyNetMetting_Jyshow : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;
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
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {
                    fjkey = NewReader_fjkey["content"].ToString();
                }
                NewReader_fjkey.Close();



                string SQL_GetList = "select * from qp_NetMetting where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    d_content.Text = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }
                NewReader.Close();


                BindAttribute();
            }

        }

        public void BindAttribute()
        {
         
            //Button2.Attributes["onclick"] = "javascript:return showwait();";
           

        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MyNetMetting.aspx");
        //}

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }






    }
}

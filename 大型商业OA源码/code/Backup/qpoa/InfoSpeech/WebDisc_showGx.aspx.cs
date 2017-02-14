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
    public partial class WebDisc_showGx : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_WebDisc   where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();

                    Sharing.SelectedValue = NewReader["IfShare"].ToString();
                    GxUsername.Text = NewReader["GxUsername"].ToString();
                    GxRealname.Text = NewReader["GxRealname"].ToString();
                }
                NewReader.Close();



                BindAttribute();
            }





        }

        public void BindAttribute()
        {

            GxRealname.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";

        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Sharing.SelectedValue == "否")
            {
                string Sql_update = "Update qp_WebDisc   Set IfShare='" + Sharing.SelectedValue + "',GxUsername='未共享',GxRealname='未共享' where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
                List.ExeSql(Sql_update);
            }
            else
            {
                string Sql_update = "Update qp_WebDisc   Set IfShare='" + Sharing.SelectedValue + "',GxUsername='" + GxUsername.Text + "',GxRealname='" + GxRealname.Text + "' where id='" + int.Parse(Request.QueryString["id"]) + "'  and username='" + Session["username"] + "'";
                List.ExeSql(Sql_update);
            }
            InsertLog("共享设置[" + Name.Text + "]", "网络硬盘");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WebDisc_show.aspx?id=" + Request.QueryString["id"] + "'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

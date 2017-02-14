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
namespace qpoa.SystemManage
{
    public partial class username_show : System.Web.UI.Page
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

         
            if (!IsPostBack)
            {
                BindAttribute();
                string SQL_GetList = "select * from qp_username where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    username.Text = NewReader["username"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();
                    worknum.Text = NewReader["worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    UnitId.Text = NewReader["UnitId"].ToString();
                    Respon.Text = NewReader["Respon"].ToString();
                    ResponId.Text = NewReader["ResponId"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    PostId.Text = NewReader["PostId"].ToString();
                    StardType.Text = NewReader["StardType"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    Iflogin.Text = NewReader["Iflogin"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    ShouJi.Text = NewReader["ShouJi"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());


                }
                NewReader.Close();
                InsertLog("查看用户信息[" + Realname.Text + "]", "用户信息");
            }
        }
        public void BindAttribute()
        {

            ImageButton5.Attributes["onclick"] = "javascript:return printpage();";
            Button2.Attributes["onclick"] = "javascript:return showwait();";
         




        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("username.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
        {
            InsertLog("打印用户信息[" + Realname.Text + "]", "用户信息");
        }
    }
}

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
   
    public partial class username_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string requestid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            requestid = Request.QueryString["id"];
            if (!IsPostBack)
            {
                BindAttribute();
                string SQL_GetList = "select * from qp_username where id='"+List.GetFormatStr(Request.QueryString["id"])+"'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    username.Text = NewReader["username"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();
                    worknum.Text  = NewReader["worknum"].ToString();
                    Unit.Text     = NewReader["Unit"].ToString();
                    UnitId.Text   = NewReader["UnitId"].ToString();
                    QxString.Text = NewReader["QxString"].ToString();
                    KeyQx.Text = NewReader["KeyQx"].ToString();
                    Respon.Text   = NewReader["Respon"].ToString();
                    ResponId.Text = NewReader["ResponId"].ToString();
                    Post.Text     = NewReader["Post"].ToString();
                    PostId.Text   = NewReader["PostId"].ToString();
                    StardType.Text= NewReader["StardType"].ToString();
                    Email.Text    = NewReader["Email"].ToString();
                    Iflogin.SelectedValue = NewReader["Iflogin"].ToString();
                    Sex.SelectedValue     = NewReader["Sex"].ToString();
                    Remark.Text           = NewReader["Remark"].ToString();
                    ShouJi.Text = NewReader["ShouJi"].ToString();
             

                }
                NewReader.Close();
                Unit.Attributes.Add("onkeydown", "return false");
                Post.Attributes.Add("onkeydown", "return false");
                Respon.Attributes.Add("onkeydown", "return false");
            }
        }
        public void BindAttribute()
        {
            Unit.Attributes.Add("readonly", "readonly");
            Post.Attributes.Add("readonly", "readonly");
           
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
         
       


        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("username.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_username  Set ShouJi='" + List.GetFormatStr(ShouJi.Text) + "', Realname='" + List.GetFormatStr(Realname.Text) + "',worknum='" + List.GetFormatStr(worknum.Text) + "',Unit='" + List.GetFormatStr(Request.Form["Unit"]) + "',UnitId='" + List.GetFormatStr(UnitId.Text) + "',Respon='" + List.GetFormatStr(Request.Form["Respon"]) + "',ResponId='" + List.GetFormatStr(ResponId.Text) + "',Post='" + List.GetFormatStr(Request.Form["Post"]) + "',PostId='" + List.GetFormatStr(PostId.Text) + "',StardType='" + List.GetFormatStr(StardType.Text) + "',Email='" + List.GetFormatStr(Email.Text) + "',Iflogin='" + List.GetFormatStr(Iflogin.SelectedValue) + "',Sex='" + List.GetFormatStr(Sex.SelectedValue) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' ,QxString='" + QxString.Text + "',KeyQx='" + KeyQx.Text + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改用户信息[" + Realname.Text + "]", "用户信息");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");
        }
        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

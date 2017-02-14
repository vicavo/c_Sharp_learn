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
    public partial class chatName_update : System.Web.UI.Page
    {
        Db List = new Db();
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

                string SQL_GetList = "select * from qp_chatName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    remark.Text = NewReader["remark"].ToString();
                    GxUsername.Text = NewReader["GxUsername"].ToString();
                    GxRealname.Text = NewReader["GxRealname"].ToString();
                    State.SelectedValue = NewReader["State"].ToString();
                  
                }
                NewReader.Close();
            }



        }
        public void BindAttribute()
        {
            GxRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("chatName.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_chatName  Set Name='" + List.GetFormatStr(Name.Text) + "',remark='" + List.GetFormatStr(remark.Text) + "',GxUsername='" + List.GetFormatStr(GxUsername.Text) + "',GxRealname='" + List.GetFormatStr(GxRealname.Text) + "',State='" + List.GetFormatStr(State.SelectedValue) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("修改聊天室[" + Name.Text + "]", "聊天室管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='chatName.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

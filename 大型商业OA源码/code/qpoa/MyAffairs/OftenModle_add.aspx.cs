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
    public partial class OftenModle_add : System.Web.UI.Page
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
         
            SharingRealname.Attributes.Add("readonly", "readonly");



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OftenModle.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Sharing.SelectedValue == "否")
            {
                string sql_insert = "insert into qp_OftenModle   (Name,Content,Sharing,SharingUsername,SharingRealname,Username,Realname) values ('" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStrmb(ContractContent.Text) + "','" + Sharing.SelectedValue + "','未共享','未共享','" + this.Session["Username"] + "','" + this.Session["Realname"] + "')";
                List.ExeSql(sql_insert);
            }
            else
            {
                string sql_insert = "insert into qp_OftenModle   (Name,Content,Sharing,SharingUsername,SharingRealname,Username,Realname) values ('" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStrmb(ContractContent.Text) + "','" + Sharing.SelectedValue + "','" + List.GetFormatStr(SharingUsername.Text) + "','" + List.GetFormatStr(SharingRealname.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "')";
                List.ExeSql(sql_insert);
            }

   

            InsertLog("新增常用模版[" + Name.Text + "]", "常用模版设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OftenModle.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

      





    }
}

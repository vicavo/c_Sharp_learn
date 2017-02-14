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
namespace qpoa.SaleManage
{
    public partial class ContactsLog_add : System.Web.UI.Page
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
            }



        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
           // KhRealname.Attributes.Add("readonly", "readonly");
            Startime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactsLog.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insert = "insert into qp_ContactsLog (KeyId,Name,KhId,KhRealname,Startime,Endtime,Content,Remark,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,GroupName,GroupId,NowTimes) values ('" + List.GetFormatStr(KeyId.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(KhId.Text) + "','" + List.GetFormatStr(KhRealname.Text) + "','" + Startime.Text + "','" + Endtime.Text + "','" + List.GetFormatStr(Content.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + this.Session["GroupName"] + "','" + this.Session["GroupId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
          

            InsertLog("新增交往记录[" + Name.Text + "]", "交往记录管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ContactsLog.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

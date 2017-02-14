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
    public partial class KmLittleType_add : System.Web.UI.Page
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
                BindList();
            }



        }
        public void BindAttribute()
        {
            SyRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }
        public void BindList()
        {
            string sql_down_bh1 = "select * from qp_KmBigType order by id desc";
            list.Bind_DropDownList(BigId, sql_down_bh1, "id", "Name");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmLittleType.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_KmLittleType (BigId,BigName,Name,SyUsername,SyRealname,Username,Realname,Settime) "
                              + "values ('" + BigId.SelectedValue + "','" + BigId.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(SyUsername.Text) + "','" + List.GetFormatStr(SyRealname.Text) + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增知识小类[" + Name.Text + "]", "知识小类维护");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KmLittleType.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

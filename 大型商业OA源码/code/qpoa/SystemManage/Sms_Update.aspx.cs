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
    public partial class Sms_Update : System.Web.UI.Page
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
                string SQL_GetList_sms = "select * from Sms_Update ";
                SqlDataReader NewReader_sms = List.GetList(SQL_GetList_sms);
                if (NewReader_sms.Read())
                {
                    Sms_UpdateDrp.SelectedValue = NewReader_sms["Sms_Update"].ToString();
                }
                NewReader_sms.Close();

            }



        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return showwait();";

        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update Sms_Update  Set Sms_Update='" + Sms_UpdateDrp.SelectedValue + "'";
            List.ExeSql(Sql_update);


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Sms_Update.aspx'</script>");
        }



    }
}

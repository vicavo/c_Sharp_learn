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
namespace qpoa.HumanResources
{
    public partial class SalariesSet_add_jjgx_add : System.Web.UI.Page
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


                BindAttribute();


            }



        }

        public void BindAttribute()
        {

            Button1.Attributes["onclick"] = "javascript:return chknull();";

        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_SaPiecesPro    (Name,Number,DjMoney,SaNumber) values ('" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + DjMoney.Text + "','" + Request.QueryString["number"] + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增计件工序[" + Name.Text + "]", "帐套管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesSet_add_jjgx.aspx?number=" + Request.QueryString["number"] + "';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }








    }
}

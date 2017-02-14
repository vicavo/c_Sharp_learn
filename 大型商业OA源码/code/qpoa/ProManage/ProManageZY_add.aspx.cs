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
namespace qpoa.ProManage
{
    public partial class ProManageZY_add : System.Web.UI.Page
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
                string sql_down_1 = "select Name from qp_ProManage where Username='" + this.Session["username"] + "' or   FzUsername='" + this.Session["username"] + "' or  (CHARINDEX('," + this.Session["username"] + ",',','+CyUsername+',')   >   0 )";
                list.Bind_DropDownList_nothing(XmName, sql_down_1, "Name", "Name");

                XmName.SelectedValue = Request.QueryString["XmName"];
            }
        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_ProManageZY    (XmName,Leibie,Mingcheng,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + XmName.SelectedValue + "','" + List.GetFormatStr(Leibie.Text) + "','" + List.GetFormatStr(Mingcheng.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProManageZY.aspx?XmName=" + Request.QueryString["XmName"] + "'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }
    }
}

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
    public partial class ProManageLR_update : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_ProManageLR where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    XmName.SelectedValue = NewReader["XmName"].ToString();
                    Leibie.Text = NewReader["Leibie"].ToString();
                    Zhuti.Text = NewReader["Zhuti"].ToString();
                    Lirun.Text = NewReader["Lirun"].ToString();
                }
                NewReader.Close();
            }
        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_ProManageLR  Set XmName='" + XmName.SelectedValue + "',Leibie='" + Leibie.Text + "',Zhuti='" + List.GetFormatStr(Zhuti.Text) + "',Lirun='" + List.GetFormatStr(Lirun.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProManageLR.aspx?XmName=" + Request.QueryString["XmName"] + "'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }
    }
}

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
    public partial class toupiaobt_update : System.Web.UI.Page
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
                string SQL_GetList_sta = "select * from qp_toupiaobt where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader_sta = List.GetList(SQL_GetList_sta);
                if (NewReader_sta.Read())
                {
                    title.Text = NewReader_sta["title"].ToString();
                    xuanze.Text = NewReader_sta["xuanze"].ToString();
                    Gkusername.Text = NewReader_sta["Gkusername"].ToString();

                    Gkrealname.Text = NewReader_sta["Gkrealname"].ToString();
                    type.SelectedValue = NewReader_sta["type"].ToString();
                    ifopen.SelectedValue = NewReader_sta["ifopen"].ToString();
                }
                NewReader_sta.Close();
                BindAttribute();
            }
        }
        public void BindAttribute()
        {
            Gkrealname.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_toupiaobt  Set title='" + List.GetFormatStr(title.Text) + "',xuanze='" + xuanze.SelectedValue + "',Gkusername='" + List.GetFormatStr(Gkusername.Text) + "',Gkrealname='" + Gkrealname.Text + "',type='" + type.SelectedValue + "',ifopen='" + ifopen.SelectedValue + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'  ";
            List.ExeSql(Sql_update);

            InsertLog("修改投票主题[" + title.Text + "]", "投票管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='toupiaobt.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

    }
}

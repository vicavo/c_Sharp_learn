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
    public partial class toupiaobtmanage_update : System.Web.UI.Page
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

            string sql_title = "select * from qp_toupiaobt order by id desc";
            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(bigtitle, sql_title, "id", "title");
            }//绑定主题


            if (!Page.IsPostBack)
            {
                string SQL_GetList_sta = "select * from qp_toupiao where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader_sta = List.GetList(SQL_GetList_sta);
                if (NewReader_sta.Read())
                {
                    title.Text = NewReader_sta["title"].ToString();
                    color.Text = NewReader_sta["color"].ToString();
                    piaoshu.Text = NewReader_sta["piaoshu"].ToString();
                   // shuoming.Text = NewReader_sta["shuoming"].ToString();
                    TpRealname.Text = NewReader_sta["TpRealname"].ToString();

                    bigtitle.SelectedValue = NewReader_sta["bigId"].ToString();
                }
                NewReader_sta.Close();
              
                BindAttribute();
            }






        }
        public void BindAttribute()
        {
            color.Attributes.Add("readonly", "readonly");
            TpRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_toupiao  Set title='" + List.GetFormatStr(title.Text) + "',color='" + List.GetFormatStr(color.Text) + "',piaoshu='" + List.GetFormatStr(piaoshu.Text) + "',bigId='" + bigtitle.SelectedValue + "',bigtitle='" + bigtitle.SelectedItem.Text + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'  ";
            List.ExeSql(Sql_update);

            InsertLog("修改投票选项[" + title.Text + "]", "投票管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='toupiaobtmanage.aspx?id=" + Request.QueryString["bigid"] + "'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

    }
}

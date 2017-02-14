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
namespace qpoa.FilesManage
{
    public partial class FilesData_add : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                type = Request.QueryString["type"].ToString();
                if (type == "1")
                {
                    typename = "案卷密级";
                }

                if (type == "2")
                {
                    typename = "凭证类别";
                }

                if (type == "3")
                {
                    typename = "紧急等级";
                }

                if (type == "4")
                {
                    typename = "文件分类";
                }

                if (type == "5")
                {
                    typename = "公文类别";
                }
                if (type == "6")
                {
                    typename = "密级";
                }
                BindAttribute();
            }



        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesData.aspx?type=" + type + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_FilesData (Name,Type) "
                              + "values ('" + List.GetFormatStr(Name.Text) + "','" + Request.QueryString["type"].ToString() + "')";
            List.ExeSql(sql_insert);

            InsertLog("基础数据设置[" + List.GetFormatStr(Name.Text) + "]", "档案管理-基础数据设置-" + typename + "");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FilesData.aspx?type=" + Request.QueryString["type"].ToString() + "'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

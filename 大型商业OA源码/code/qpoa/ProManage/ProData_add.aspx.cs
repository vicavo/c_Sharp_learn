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
    public partial class ProData_add : System.Web.UI.Page
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
                    typename = "评审级别";
                }

                if (type == "2")
                {
                    typename = "公告类别";
                }

                if (type == "3")
                {
                    typename = "预算类别";
                }

                if (type == "4")
                {
                    typename = "资源类别";
                }

                if (type == "5")
                {
                    typename = "报销类别";
                }

                if (type == "6")
                {
                    typename = "任务类别";
                }

                if (type == "7")
                {
                    typename = "外包类别";
                }

                if (type == "8")
                {
                    typename = "项目阶段";
                }

                if (type == "9")
                {
                    typename = "项目类别";
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
            Response.Redirect("ProData.aspx?type=" + type + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_ProData (Name,Type) "
                              + "values ('" + List.GetFormatStr(Name.Text) + "','" + Request.QueryString["type"].ToString() + "')";
            List.ExeSql(sql_insert);

            InsertLog("新增数据字典[" + List.GetFormatStr(Name.Text) + "]", "项目管理-基础数据字典-" + typename + "");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProData.aspx?type=" + Request.QueryString["type"].ToString() + "'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
namespace qpoa.WorkFlow
{
    public partial class DIYForm_add_update : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_FormFile where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["name"].ToString();
                   // QxRealname.Text = NewReader["QxRealname"].ToString();
                   // QxUsername.Text = NewReader["QxUsername"].ToString();
                    Type.SelectedValue = NewReader["Type"].ToString();
                }
                NewReader.Close();
            }
        }
        public void BindAttribute()
        {
           // QxRealname.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_FormFile  Set Name='" + List.GetFormatStr(Name.Text) + "',Type='" + Type.SelectedValue + "'  where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            List.ExeSql(Sql_update);
          
            InsertLog("修改表单字段[" + Name.Text + "]", "表单字段定义");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

        }

        public void InsertLog(string Name, string MkName)
        {

            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

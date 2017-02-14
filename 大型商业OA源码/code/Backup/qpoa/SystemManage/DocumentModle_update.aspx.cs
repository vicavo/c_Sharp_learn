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
    public partial class DocumentModle_update : System.Web.UI.Page
    {
        Db List = new Db();
        public static string newname;
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
                string SQL_GetList = "select * from qp_DocumentModle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    newname = NewReader["Newname"].ToString();
                    Name.Text = NewReader["Name"].ToString();

                    QxUsername.Text = NewReader["QxUsername"].ToString();
                    QxRealname.Text = NewReader["QxRealname"].ToString();


                }
                NewReader.Close();
                
            }
        }
        public void BindAttribute()
        {

            QxRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return checkForm();";




        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentModle.aspx");
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_DocumentModle  Set Name='" + List.GetFormatStr(Name.Text) + "', QxUsername='" + List.GetFormatStr(QxUsername.Text) + "' , QxRealname='" + List.GetFormatStr(QxRealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改红头文件[" + Name.Text + "]", "红头文件管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DocumentModle.aspx'</script>");
        }
        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

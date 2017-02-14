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
namespace qpoa.SaleManage
{
    public partial class SaleGroup_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_SaleGroup where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    GroupName.Text = NewReader["GroupName"].ToString();
                    Username.Text = NewReader["Username"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();
                    GroupRealname.Text = NewReader["GroupRealname"].ToString();
                    GroupUsername.Text = NewReader["GroupUsername"].ToString();
                   


                }
                NewReader.Close();


            }



        }
        public void BindAttribute()
        {
            Realname.Attributes.Add("readonly", "readonly");
            GroupRealname.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleGroup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_SaleGroup  Set GroupName='" + List.GetFormatStr(GroupName.Text) + "',Username='" + Username.Text + "',Realname='" + Realname.Text + "',GroupRealname='" + GroupRealname.Text + "',GroupUsername='" + GroupUsername.Text + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);


            InsertLog("修改销售组[" + GroupName.Text + "]", "销售组维护");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaleGroup.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

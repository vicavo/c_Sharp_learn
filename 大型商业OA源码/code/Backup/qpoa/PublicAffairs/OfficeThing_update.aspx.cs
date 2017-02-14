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
namespace qpoa.PublicAffairs
{
    public partial class OfficeThing_update : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_OfficeThing where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    Content.Text = NewReader["Content"].ToString();
                    Measurement.Text = NewReader["Measurement"].ToString();
                    CompanyName.Text = NewReader["CompanyName"].ToString();
                    Limits.Text = NewReader["Limits"].ToString();
                    Inventory.Text = NewReader["Inventory"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();
                   

                }

                NewReader.Close();

                BindAttribute();
            }



        }
        public void BindAttribute()
        {
            //Name.Attributes.Add("readonly", "readonly");
            // KhRealname.Attributes.Add("readonly", "readonly");


            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficeThing.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_OfficeThing   Set Name='" + List.GetFormatStr(Name.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "',Measurement='" + List.GetFormatStr(Measurement.Text) + "',CompanyName='" + List.GetFormatStr(CompanyName.Text) + "',Limits='" + List.GetFormatStr(Limits.Text) + "',Inventory='" + List.GetFormatStr(Inventory.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);


            InsertLog("修改办公用品[" + Name.Text + "]", "办公用品管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OfficeThing.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

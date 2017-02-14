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
    public partial class AssetsDepType_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_AssetsDepType  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    DepType.Text = NewReader["DepType"].ToString();
                    DepRate.Text = NewReader["DepRate"].ToString();
                    DepCycle.Text = NewReader["DepCycle"].ToString();
                    Content.Text = NewReader["Content"].ToString();
              



                }

                NewReader.Close();
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
            Response.Redirect("AssetsDepType.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_AssetsDepType   Set DepType='" + List.GetFormatStr(DepType.Text) + "',DepRate='" + List.GetFormatStr(DepRate.Text) + "',DepCycle='" + List.GetFormatStr(DepCycle.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);


            string Sql_update1 = "Update qp_Assets    Set DepRate='" + List.GetFormatStr(DepRate.Text) + "',DepCycle='" + List.GetFormatStr(DepCycle.Text) + "'  where DepTypeID='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);


            InsertLog("修改折旧类别[" + DepType.Text + "]", "资产折旧类别");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='AssetsDepType.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

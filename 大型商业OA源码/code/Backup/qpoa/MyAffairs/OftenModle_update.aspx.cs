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
namespace qpoa.MyAffairs
{
    public partial class OftenModle_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_OftenModle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    Sharing.SelectedValue = NewReader["Sharing"].ToString();
                    SharingUsername.Text = NewReader["SharingUsername"].ToString();
                    SharingRealname.Text = NewReader["SharingRealname"].ToString();
                    ContractContentupdate.Text = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }
                NewReader.Close();

                BindAttribute();
            }





        }

        public void BindAttribute()
        {

            SharingRealname.Attributes.Add("readonly", "readonly");



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OftenModle.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Sharing.SelectedValue == "否")
            {
                string Sql_update1 = "Update qp_OftenModle    Set Name='" + Name.Text + "',Sharing='" + Sharing.SelectedValue + "',SharingUsername='未共享',SharingRealname='未共享',Content='" + List.GetFormatStrmb(ContractContent.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update1);
            }
            else
            {
                string Sql_update1 = "Update qp_OftenModle    Set Name='" + Name.Text + "',Sharing='" + Sharing.SelectedValue + "',SharingUsername='" + SharingUsername.Text + "',SharingRealname='" + SharingRealname.Text + "',Content='" + List.GetFormatStrmb(ContractContent.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update1);
            }


            InsertLog("修改常用模版[" + Name.Text + "]", "常用模版设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OftenModle.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

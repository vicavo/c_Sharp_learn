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
namespace qpoa.KmManage
{
    public partial class KmLittleType_update : System.Web.UI.Page
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
                BindAttribute();
                BindList();

                string SQL_GetList = "select * from qp_KmLittleType where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    BigId.SelectedValue = NewReader["BigId"].ToString();
                    SyUsername.Text = NewReader["SyUsername"].ToString();
                    SyRealname.Text = NewReader["SyRealname"].ToString();

                }

                NewReader.Close();



            }



        }
        public void BindAttribute()
        {
            SyRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }
        public void BindList()
        {
            string sql_down_bh1 = "select * from qp_KmBigType order by id desc";
            list.Bind_DropDownList(BigId, sql_down_bh1, "id", "Name");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmLittleType.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_KmLittleType    Set BigId='" + BigId.SelectedValue + "',BigName='" + BigId.SelectedItem.Text + "',Name='" + List.GetFormatStr(Name.Text) + "',SyUsername='" + List.GetFormatStr(SyUsername.Text) + "',SyRealname='" + List.GetFormatStr(SyRealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
         
            InsertLog("修改知识小类[" + Name.Text + "]", "知识小类维护");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='KmLittleType.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

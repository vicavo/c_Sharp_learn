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
    public partial class DIYForm_update : System.Web.UI.Page
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
            
            string sql_down_bh = "select * from qp_FormType order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(FormType, sql_down_bh, "id", "name");
            }

            if (!IsPostBack)
            {
                string SQL_GetList_sta = "select * from qp_DIYForm where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader = List.GetList(SQL_GetList_sta);
                if (NewReader.Read())
                {

                    d_content.Value = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString());

                    FormType.SelectedValue = NewReader["TypeId"].ToString();

                    FormName.Text = NewReader["FormName"].ToString();
                    openusername.Text = NewReader["openusername"].ToString();
                    openrealname.Text = NewReader["openrealname"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                }
                NewReader.Close();

                BindAttribute();
            }
            BindList();
        }

        public void BindAttribute()
        {
            openrealname.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";
            LinkButton1.Attributes["onclick"] = "javascript:return addfile();";
            LinkButton2.Attributes["onclick"] = "javascript:return updatefile();";
            //LinkButton3.Attributes["onclick"] = "javascript:return delfile();";
            LinkButton4.Attributes["onclick"] = "javascript:return delfile();";
        }

        public void BindList()
        {
            string sql_down_bh1 = "select Number,Name+Type as aaa from qp_FormFile where KeyFile='" + Number.Text + "' order by id asc";
            list.Bind_DropDownListForm(FormFile, sql_down_bh1, "Number", "aaa");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_DIYForm   Set TypeId='" + FormType.SelectedValue + "',Type='" + FormType.SelectedItem.Text + "',FormName='" + List.GetFormatStr(FormName.Text) + "',FormContent='" + List.GetFormatStrbjq(d_content.Value) + "' ,openusername='" + List.GetFormatStr(openusername.Text) + "' ,openrealname='" + List.GetFormatStr(openrealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "' ";
            List.ExeSql(Sql_update);

            InsertLog("修改表单[" + FormName.Text + "]", "表单设计");
            //this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='DIYForm.aspx';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }









    }
}

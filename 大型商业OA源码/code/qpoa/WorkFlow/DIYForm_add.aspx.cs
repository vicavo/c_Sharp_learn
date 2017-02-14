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
    public partial class Form_add : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                BindAttribute();
            }
            string sql_down_bh = "select * from qp_FormType order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(FormType, sql_down_bh, "id", "name");
            }

            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
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
            string sql_down_bh1 = "select Number,Name+Type as aaa from qp_FormFile where KeyFile='"+Number.Text+"' order by id asc";
            list.Bind_DropDownListForm(FormFile, sql_down_bh1, "Number", "aaa");
        }

 

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_DIYForm (Number,TypeId,Type,FormName,openusername,openrealname,FormContent,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + Number.Text+ "','" + FormType.SelectedValue + "','" + FormType.SelectedItem.Text + "','" + List.GetFormatStr(FormName.Text) + "','" + List.GetFormatStr(openusername.Text) + "','" + List.GetFormatStr(openrealname.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增表单[" + FormName.Text + "]", "表单设计");
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

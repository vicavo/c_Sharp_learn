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
namespace qpoa.HumanResources
{
    public partial class SalariesSet_add : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {

                BindDroList();
                BindAttribute();


            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }


        }
        public void BindDroList()
        {
            list.Bind_DropDownList_Kq(Startime);
            list.Bind_DropDownList_Kq(Endtime);
        }
        public void BindAttribute()
        {

            Button1.Attributes["onclick"] = "javascript:return chknull();";
            Button4.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_SalariesSet    (Number,Name,Content,IfOk,Startime,Endtime,Username,Realname,NowTimes) values ('" + Number.Text + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + IfOk.SelectedValue + "','" + Startime.SelectedValue + "','" + Endtime.SelectedValue + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增帐套[" + Name.Text + "]", "帐套管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesSet.aspx';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_SalariesSet    (Number,Name,Content,IfOk,Startime,Endtime,Username,Realname,NowTimes) values ('" + Number.Text + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + IfOk.SelectedValue + "','" + Startime.SelectedValue + "','" + Endtime.SelectedValue + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            InsertLog("新增帐套[" + Name.Text + "]", "帐套管理");

            Response.Redirect("SalariesSet_add_xzxm.aspx?Number=" + Number.Text + "");
        }







    }
}

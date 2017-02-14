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
    public partial class CompanyGroup_add : System.Web.UI.Page
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
            }





        }

        public void BindAttribute()
        {

            BothDay.Attributes.Add("readonly", "readonly");



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyGroup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insert = "insert into qp_CompanyGroup   (Name,Worknum,Unit,Respon,Post,Sex,BothDay,Officetel,Fax,MoveTel,HomeTel,Email,QQNum,MsnNum,NbNum,Address,ZipCode,Remark,Username,Realname,NowTimes) values ('" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Worknum.Text) + "','" + List.GetFormatStr(Unit.Text) + "','" + List.GetFormatStr(Respon.Text) + "','" + List.GetFormatStr(Post.Text) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(BothDay.Text) + "','" + List.GetFormatStr(Officetel.Text) + "','" + List.GetFormatStr(Fax.Text) + "','" + List.GetFormatStr(MoveTel.Text) + "','" + List.GetFormatStr(HomeTel.Text) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(QQNum.Text) + "','" + List.GetFormatStr(MsnNum.Text) + "','" + List.GetFormatStr(NbNum.Text) + "','" + List.GetFormatStr(Address.Text) + "','" + List.GetFormatStr(ZipCode.Text) + "','" + List.GetFormatStrmb(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);



            InsertLog("新增公司通讯录[" + Name.Text + "]", "公司通讯录");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CompanyGroup.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

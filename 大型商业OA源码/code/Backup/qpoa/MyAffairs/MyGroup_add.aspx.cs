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
    public partial class MyGroup_add : System.Web.UI.Page
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
            Response.Redirect("MyGroup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insert = "insert into qp_MyGroup (GroupName,Name,Sex,BothDay,OtherName,Post,Spouses,Children,CName,CAddress,CZipCode,CTel,CFax,HAddress,HZipCode,HTel,HMoveTel,HXiaoTel,Email,QQNum,MsnNum,Remark,IfOpen,Username,Realname,NowTimes) values ('" + List.GetFormatStr(GroupName.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(BothDay.Text) + "','" + List.GetFormatStr(OtherName.Text) + "','" + List.GetFormatStr(Post.Text) + "','" + List.GetFormatStr(Spouses.Text) + "','" + List.GetFormatStr(Children.Text) + "','" + List.GetFormatStr(CName.Text) + "','" + List.GetFormatStr(CAddress.Text) + "','" + List.GetFormatStr(CZipCode.Text) + "','" + List.GetFormatStr(CTel.Text) + "','" + List.GetFormatStr(CFax.Text) + "','" + List.GetFormatStr(HAddress.Text) + "','" + List.GetFormatStr(HZipCode.Text) + "','" + List.GetFormatStr(HTel.Text) + "','" + List.GetFormatStr(HMoveTel.Text) + "','" + List.GetFormatStr(HXiaoTel.Text) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(QQNum.Text) + "','" + List.GetFormatStr(MsnNum.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + IfOpen.SelectedValue+ "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);



            InsertLog("新增个人通讯录[" + Name.Text + "]", "个人通讯录");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyGroup.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

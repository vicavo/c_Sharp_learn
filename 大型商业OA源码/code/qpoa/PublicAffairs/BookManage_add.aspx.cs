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
    public partial class BookManage_add : System.Web.UI.Page
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
        }
        public void BindDroList()
        {
            //附件列表
            string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");
          
        }
        public void BindAttribute()
        {


            LendingName.Attributes.Add("readonly", "readonly");




            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("BookManage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_BookManage  (Name,UnitNameId,UnitName,Type,Author,ISBN,Publisher,PublisherDate,Storage,Number,Price,Introduction,LendingID,LendingName,Status,Borrowers,Remark,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + List.GetFormatStr(Name.Text) + "','" + UnitName.SelectedValue + "','" + UnitName.SelectedItem.Text + "','" + List.GetFormatStr(Type.Text) + "','" + List.GetFormatStr(Author.Text) + "','" + List.GetFormatStr(ISBN.Text) + "','" + List.GetFormatStr(Publisher.Text) + "','" + List.GetFormatStr(PublisherDate.Text) + "','" + List.GetFormatStr(Storage.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Price.Text) + "','" + List.GetFormatStrbjq(Introduction.Text) + "','" + List.GetFormatStr(LendingID.Text) + "','" + List.GetFormatStr(LendingName.Text) + "','" + List.GetFormatStr(Status.SelectedValue) + "','" + List.GetFormatStr(Borrowers.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            // Response.Write(sql_insert);
            InsertLog("新增图书信息[" + Name.Text + "]", "图书信息管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BookManage.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

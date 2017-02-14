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
    public partial class BookManage_update : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_BookManage where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    UnitName.SelectedValue = NewReader["UnitNameId"].ToString();
                  
                    Type.Text = NewReader["Type"].ToString();
                    Author.Text = NewReader["Author"].ToString();
                    ISBN.Text = NewReader["ISBN"].ToString();
                    Publisher.Text = NewReader["Publisher"].ToString();
                    PublisherDate.Text = NewReader["PublisherDate"].ToString();
                    Storage.Text = NewReader["Storage"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Price.Text = NewReader["Price"].ToString();
                    Introduction.Text = NewReader["Introduction"].ToString();
                    LendingID.Text = NewReader["LendingID"].ToString();
                    LendingName.Text = NewReader["LendingName"].ToString();
                    Status.SelectedValue = NewReader["Status"].ToString();
                    Borrowers.Text = NewReader["Borrowers"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();



                }

                NewReader.Close();
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


            string Sql_update1 = "Update qp_BookManage    Set Name='" + List.GetFormatStr(Name.Text) + "',UnitNameId='" + List.GetFormatStr(UnitName.SelectedValue) + "',UnitName='" + List.GetFormatStr(UnitName.SelectedItem.Text) + "',Type='" + List.GetFormatStr(Type.Text) + "',Author='" + List.GetFormatStr(Author.Text) + "',ISBN='" + List.GetFormatStr(ISBN.Text) + "',Publisher='" + List.GetFormatStr(Publisher.Text) + "',PublisherDate='" + List.GetFormatStr(PublisherDate.Text) + "',Storage='" + List.GetFormatStr(Storage.Text) + "',Number='" + List.GetFormatStr(Number.Text) + "',Price='" + List.GetFormatStr(Price.Text) + "',Introduction='" + List.GetFormatStr(Introduction.Text) + "',LendingID='" + List.GetFormatStr(LendingID.Text) + "',LendingName='" + List.GetFormatStr(LendingName.Text) + "',Status='" + List.GetFormatStr(Status.SelectedValue) + "',Borrowers='" + List.GetFormatStr(Borrowers.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
           


            InsertLog("修改图书信息[" + Name.Text + "]", "图书信息管理");


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

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
    public partial class BookManageSearch_show : System.Web.UI.Page
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

             

                string SQL_GetList = "select * from qp_BookManage where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    UnitName.Text = NewReader["UnitName"].ToString().Replace("-", "").Replace("|", "");
                    Type.Text = NewReader["Type"].ToString();
                    Author.Text = NewReader["Author"].ToString();
                    ISBN.Text = NewReader["ISBN"].ToString();
                    Publisher.Text = NewReader["Publisher"].ToString();
                    PublisherDate.Text = NewReader["PublisherDate"].ToString();
                    Storage.Text = NewReader["Storage"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Price.Text = NewReader["Price"].ToString();
                    Introduction.Text = List.TbToLb(NewReader["Introduction"].ToString());
                    LendingID.Text = NewReader["LendingID"].ToString();
                    LendingName.Text = NewReader["LendingName"].ToString();
                    Status.Text = NewReader["Status"].ToString();
                    Borrowers.Text = NewReader["Borrowers"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());



                }

                NewReader.Close();
                InsertLog("查看图书信息[" + Name.Text + "]", "图书查询");
            }


        }







        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

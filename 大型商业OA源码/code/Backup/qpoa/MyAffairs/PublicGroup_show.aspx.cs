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
    public partial class PublicGroup_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_MyGroup where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and IfOpen='是'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    GroupName.Text = NewReader["GroupName"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    BothDay.Text = NewReader["BothDay"].ToString();
                    OtherName.Text = NewReader["OtherName"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    Spouses.Text = NewReader["Spouses"].ToString();
                    Children.Text = NewReader["Children"].ToString();
                    CName.Text = NewReader["CName"].ToString();
                    CAddress.Text = NewReader["CAddress"].ToString();
                    CZipCode.Text = NewReader["CZipCode"].ToString();
                    CTel.Text = NewReader["CTel"].ToString();
                    CFax.Text = NewReader["CFax"].ToString();
                    HAddress.Text = NewReader["HAddress"].ToString();
                    HZipCode.Text = NewReader["HZipCode"].ToString();
                    HTel.Text = NewReader["HTel"].ToString();
                    HMoveTel.Text = NewReader["HMoveTel"].ToString();
                    HXiaoTel.Text = NewReader["HXiaoTel"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    QQNum.Text = NewReader["QQNum"].ToString();
                    MsnNum.Text = NewReader["MsnNum"].ToString();
                    IfOpen.Text = NewReader["IfOpen"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());






                }
                NewReader.Close();
                InsertLog("查看公共通讯录[" + Name.Text + "]", "公共通讯录");
                BindAttribute();
            }





        }

        public void BindAttribute()
        {



            Button2.Attributes["onclick"] = "javascript:return showwait();";





        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("PublicGroup.aspx");
        }



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

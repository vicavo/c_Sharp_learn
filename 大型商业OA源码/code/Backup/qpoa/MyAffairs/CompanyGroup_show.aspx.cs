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
    public partial class CompanyGroup_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CompanyGroup where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    Worknum.Text = NewReader["Worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    Respon.Text = NewReader["Respon"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    Officetel.Text = NewReader["Officetel"].ToString();
                    Fax.Text = NewReader["Fax"].ToString();
                    MoveTel.Text = NewReader["MoveTel"].ToString();
                    HomeTel.Text = NewReader["HomeTel"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    QQNum.Text = NewReader["QQNum"].ToString();
                    MsnNum.Text = NewReader["MsnNum"].ToString();
                    NbNum.Text = NewReader["NbNum"].ToString();
                    Address.Text = NewReader["Address"].ToString();
                    ZipCode.Text = NewReader["ZipCode"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());
                    BothDay.Text = NewReader["BothDay"].ToString();

                }
                NewReader.Close();
                InsertLog("查看公司通讯录[" + Name.Text + "]", "公司通讯录");
                BindAttribute();
            }





        }

        public void BindAttribute()
        {

            BothDay.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
       




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyGroup.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

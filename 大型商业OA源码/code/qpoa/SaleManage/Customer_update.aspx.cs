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
namespace qpoa.SaleManage
{
    public partial class Customer_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;


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
                string SQL_GetList = "select * from qp_Customer where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    YwRealname.Text = NewReader["YwRealname"].ToString();
                    YwUsername.Text = NewReader["YwUsername"].ToString();
                    Sharing.SelectedValue = NewReader["Sharing"].ToString();
                    SharingName.Text = NewReader["SharingName"].ToString();
                    SharingUser.Text = NewReader["SharingUser"].ToString();
                    CustomerNumber.Text = NewReader["CustomerNumber"].ToString();
                    Tel.Text = NewReader["Tel"].ToString();
                    Fax.Text = NewReader["Fax"].ToString();
                    Website.Text = NewReader["Website"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    Regional.Text = NewReader["Regional"].ToString();
                    Postcode.Text = NewReader["Postcode"].ToString();
                    Address.Text = NewReader["Address"].ToString();
                    CSource.Text = NewReader["CSource"].ToString();
                    CImportant.Text = NewReader["CImportant"].ToString();
                    Sales.Text = NewReader["Sales"].ToString();
                    Industry.Text = NewReader["Industry"].ToString();
                    Nature.Text = NewReader["Nature"].ToString();
                    Scale.Text = NewReader["Scale"].ToString();
                    Annual.Text = NewReader["Annual"].ToString();
                    Description.Text = NewReader["Description"].ToString();
                    Bank.Text = NewReader["Bank"].ToString();
                    BankAccount.Text = NewReader["BankAccount"].ToString();
                    Paragraphs.Text = NewReader["Paragraphs"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();
                 
                 }
                NewReader.Close();


                string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";


                SqlDataReader NewReader_yz = List.GetList(SQL_yz);
                showjg = null;
                if (NewReader_yz.Read())
                {
                    string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";
                    SqlDataReader NewReader_mx = List.GetList(SQL_mx);

                    int glTMP1 = 0;

                    showjg += "<tr> <td align=center class=newtd2 colspan=4 height=26 width=33%><div align=center><strong>用户自定义字段</strong></div> </td> </tr>";

                    while (NewReader_mx.Read())
                    {

                        showjg += " <tr> <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + NewReader_mx["s_str"] + "" + NewReader_mx["ivalue"] + "" + NewReader_mx["l_str"] + "</td></tr>";
                        glTMP1 = glTMP1 + 1;
                        if (glTMP1 == 1)
                        {

                            glTMP1 = 0;
                        }
                    }

                    NewReader_mx.Close();
                }


            }


            if (!Page.IsPostBack)
            {
                BindAttribute();

            }



            if (this.Sharing.SelectedValue == "共享")
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
            }


        }
        public void BindAttribute()
        {
            YwRealname.Attributes.Add("readonly", "readonly");
            SharingName.Attributes.Add("readonly", "readonly");

            //Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";

            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            if (NewReader_yz.Read())
            {
                string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";
                SqlDataReader NewReader_mx = List.GetList(SQL_mx);
                while (NewReader_mx.Read())
                {
                    string Sql_update = "Update qp_SaleFieldDIYAdd  Set ivalue='" + Request.Form["" + NewReader_mx["Number"] + ""] + "'  where Number='" + NewReader_mx["Number"] + "' and  keyfile='" + Number.Text + "' ";
                    List.ExeSql(Sql_update);


                }
            }


            string Sql_update1 = "Update qp_Customer  Set Name='" + List.GetFormatStr(Name.Text) + "',YwRealname='" + List.GetFormatStr(YwRealname.Text) + "',YwUsername='" + List.GetFormatStr(YwUsername.Text) + "',Sharing='" + List.GetFormatStr(Sharing.SelectedValue) + "',SharingName='" + List.GetFormatStr(SharingName.Text) + "',SharingUser='" + List.GetFormatStr(SharingUser.Text) + "',CustomerNumber='" + List.GetFormatStr(CustomerNumber.Text) + "',Tel='" + List.GetFormatStr(Tel.Text) + "',Fax='" + List.GetFormatStr(Fax.Text) + "',Website='" + List.GetFormatStr(Website.Text) + "',Email='" + List.GetFormatStr(Email.Text) + "',Regional='" + List.GetFormatStr(Regional.Text) + "',Postcode='" + List.GetFormatStr(Postcode.Text) + "',Address='" + List.GetFormatStr(Address.Text) + "',CSource='" + List.GetFormatStr(CSource.Text) + "',CImportant='" + List.GetFormatStr(CImportant.Text) + "',Sales='" + List.GetFormatStr(Sales.Text) + "',Industry='" + List.GetFormatStr(Industry.Text) + "',Nature='" + List.GetFormatStr(Nature.Text) + "',Scale='" + List.GetFormatStr(Scale.Text) + "',Annual='" + List.GetFormatStr(Annual.Text) + "',Description='" + List.GetFormatStr(Description.Text) + "',Bank='" + List.GetFormatStr(Bank.Text) + "',BankAccount='" + List.GetFormatStr(BankAccount.Text) + "',Paragraphs='" + List.GetFormatStr(Paragraphs.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            string Sql_update_jw = "Update qp_ContactsLog   Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_jw);//交往记录

            string Sql_update_lxr = "Update qp_CustomerLxr   Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_lxr);//客户联系人

            string Sql_update_fw = "Update qp_ServicesLog  Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_fw);//客户服务



            string Sql_update_gh = "Update qp_ContactsCare  Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_gh);//关怀

            string Sql_update_hf = "Update qp_ContactsVisit    Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_hf);//回访

            string Sql_update_ts = "Update qp_ContactsComp   Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_ts);//投诉

            string Sql_update_myd = "Update qp_ContactsSurvey   Set Name='" + List.GetFormatStr(Name.Text) + "' where KeyId='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update_myd);//满意度



        


         
            InsertLog("修改客户信息[" + Name.Text + "]", "客户信息管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Customer.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

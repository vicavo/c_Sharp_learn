﻿using System;
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
    public partial class CustomerOpen_show : System.Web.UI.Page
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
                    Sharing.Text = NewReader["Sharing"].ToString();
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

                        showjg += " <tr> <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + List.TbToLb(NewReader_mx["ivalue"].ToString()) + "</td></tr>";
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



            if (this.Sharing.Text == "共享")
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


            //Button2.Attributes["onclick"] = "javascript:return showwait();";




        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("CustomerOpen.aspx");
        //}



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

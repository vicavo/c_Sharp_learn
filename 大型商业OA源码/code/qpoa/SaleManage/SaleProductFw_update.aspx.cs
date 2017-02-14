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
    public partial class SaleProductFw_update : System.Web.UI.Page
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


                string SQL_GetList = "select * from qp_SaleProductFw where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    CpId.Text = NewReader["CpId"].ToString();
                    ProductName.Text = NewReader["ProductName"].ToString();
                  
                    AllMoney.Text = NewReader["AllMoney"].ToString();
                    KeyId.Text = NewReader["KeyId"].ToString();
                    CustomerName.Text = NewReader["CustomerName"].ToString();
                    SaleTime.Text = System.DateTime.Parse(NewReader["SaleTime"].ToString()).ToShortDateString();
                    SaleUsername.Text = NewReader["SaleUsername"].ToString();
                    SaleRealname.Text = NewReader["SaleRealname"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();

                }

                NewReader.Close();

                BindAttribute();
            }


            string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";



            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            showjg = null;
            if (NewReader_yz.Read())
            {
                string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";
                SqlDataReader NewReader_mx = List.GetList(SQL_mx);
                showjg = null;
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
        public void BindAttribute()
        {
            CustomerName.Attributes.Add("readonly", "readonly");
            ProductName.Attributes.Add("readonly", "readonly");
            SaleRealname.Attributes.Add("readonly", "readonly");
            SaleTime.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleProductFw.aspx");
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


            string Sql_update1 = "Update qp_SaleProductFw  Set CpId='" + CpId.Text + "',ProductName='" + ProductName.Text + "',AllMoney='" + List.GetFormatStr(AllMoney.Text) + "',KeyId='" + List.GetFormatStr(KeyId.Text) + "',CustomerName='" + List.GetFormatStr(CustomerName.Text) + "',SaleTime='" + List.GetFormatStr(SaleTime.Text) + "',SaleUsername='" + List.GetFormatStr(SaleUsername.Text) + "',SaleRealname='" + List.GetFormatStr(SaleRealname.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);



            InsertLog("修改销售记录－服务型产品[" + ProductName.Text + "]", "销售记录－服务型产品");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaleProductFw.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

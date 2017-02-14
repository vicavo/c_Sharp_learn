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
    public partial class SaleProduct_add : System.Web.UI.Page
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


                SaleRealname.Text = Session["Realname"].ToString();
                SaleUsername.Text = Session["Username"].ToString();
                SaleTime.Text = System.DateTime.Now.ToShortDateString();
          
                BindAttribute();
            }


            string SQL_yz = "select  * from qp_SaleFieldDIY where type='9'  order by PaiXun asc";


            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            showjg = null;
            if (NewReader_yz.Read())
            {
                string SQL_mx = "select  * from qp_SaleFieldDIY where type='9'  order by PaiXun asc";

                SqlDataReader NewReader_mx = List.GetList(SQL_mx);

                int glTMP1 = 0;

                showjg += "<tr> <td align=center class=newtd2 colspan=4 height=26 width=33%><div align=center><strong>用户自定义字段</strong></div> </td> </tr>";
                // showjg += "<tr> ";
                while (NewReader_mx.Read())
                {

                    showjg += " <tr> <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + NewReader_mx["s_str"] + "" + Request.Form["" + NewReader_mx["Number"] + ""] + "" + NewReader_mx["l_str"] + "</td></tr>";
                    glTMP1 = glTMP1 + 1;
                    if (glTMP1 == 1)
                    {
                        // showjg += "</tr><tr>";
                        glTMP1 = 0;
                    }
                }

                NewReader_mx.Close();
            }

            if (!IsPostBack)
            {

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
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
            Response.Redirect("SaleProduct.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_yz = "select  * from qp_SaleFieldDIY where type='9'  order by PaiXun asc";
            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            if (NewReader_yz.Read())
            {
                string SQL_mx = "select  * from qp_SaleFieldDIY where type='9'  order by PaiXun asc";
                SqlDataReader NewReader_mx = List.GetList(SQL_mx);
                while (NewReader_mx.Read())
                {
                    string SQL_i = "insert qp_SaleFieldDIYAdd (Number,Name,showBl,textbox,s_str,l_str,PaiXun,type,ivalue,keyfile) values('" + NewReader_mx["Number"] + "','" + NewReader_mx["Name"] + "','" + NewReader_mx["showBl"] + "','" + NewReader_mx["textbox"] + "','" + NewReader_mx["s_str"] + "','" + NewReader_mx["l_str"] + "','" + NewReader_mx["PaiXun"] + "','" + NewReader_mx["type"] + "','" + Request.Form["" + NewReader_mx["Number"] + ""] + "','" + Number.Text + "')";
                    List.ExeSql(SQL_i);

                }
            }

            string sql_insert = "insert into qp_SaleProduct    (Number,CpId,ProductName,UnitMoney,ManyNum,AllMoney,KeyId,CustomerName,SaleTime,SaleUsername,SaleRealname,Remark,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,GroupName,GroupId,NowTimes) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(CpId.Text) + "','" + List.GetFormatStr(ProductName.Text) + "','" + List.GetFormatStr(UnitMoney.Text) + "','" + List.GetFormatStr(ManyNum.Text) + "','" + List.GetFormatStr(AllMoney.Text) + "','" + List.GetFormatStr(KeyId.Text) + "','" + List.GetFormatStr(CustomerName.Text) + "','" + List.GetFormatStr(SaleTime.Text) + "','" + List.GetFormatStr(SaleUsername.Text) + "','" + List.GetFormatStr(SaleRealname.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + this.Session["GroupName"] + "','" + this.Session["GroupId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增销售记录－常规产品[" + ProductName.Text + "]", "销售记录－常规产品");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaleProduct.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

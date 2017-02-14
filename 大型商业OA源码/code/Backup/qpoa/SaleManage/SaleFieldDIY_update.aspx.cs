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
    public partial class SaleFieldDIY_update : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename, showjg;
        public static int PaixunAdd;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                type = Request.QueryString["type"].ToString();
                if (type == "1")
                {
                    typename = "客户管理";
                }

                if (type == "2")
                {
                    typename = "客户联系人管理";
                }

                if (type == "3")
                {
                    typename = "客户服务管理";
                }

                if (type == "4")
                {
                    typename = "产品管理";
                }

                if (type == "5")
                {
                    typename = "服务型产品管理";
                }

                if (type == "6")
                {
                    typename = "合同管理";
                }

                if (type == "7")
                {
                    typename = "供应商信息管理";
                }

                if (type == "8")
                {
                    typename = "供应商联系人管理";
                }
                if (type == "9")
                {
                    typename = "产品销售记录";
                }

                if (type == "10")
                {
                    typename = "服务性产品销售记录";
                }
                if (type == "11")
                {
                    typename = "供应商产品信息";
                }
                string SQL_GetList = "select * from qp_SaleFieldDIY where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["name"].ToString();
                    showBl.SelectedValue = NewReader["showBl"].ToString();
                    Number.Text = NewReader["Number"].ToString();




                }
                NewReader.Close();

                BindAttribute();


                string SQL_mx = "select  * from qp_SaleFieldDIY where type='" + int.Parse(Request.QueryString["type"]) + "'  order by PaiXun asc";

                SqlDataReader NewReader_mx = List.GetList(SQL_mx);

               
                showjg = null;
                int glTMP1 = 0;
                showjg += "<tr> <td align=center class=newtd2 colspan=4 height=26 width=33%><div align=center><strong>自定义字段预览</strong></div> </td> </tr>";
                showjg += "<tr> ";
                while (NewReader_mx.Read())
                {

                    showjg += " <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + NewReader_mx["s_str"] + "" + Request.Form["" + NewReader_mx["Number"] + ""] + "" + NewReader_mx["l_str"] + "</td>";
                    glTMP1 = glTMP1 + 1;
                    if (glTMP1 == 1)
                    {
                        showjg += "</tr><tr>";
                        glTMP1 = 0;
                    }
                }

                NewReader_mx.Close();	


            }



        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleFieldDIY.aspx?type=" + type + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_SaleFieldDIY  Set Name='" + List.GetFormatStr(Name.Text) + "',showBl='" + showBl.SelectedValue + "',textbox='<TEXTAREA rows=" + showBl.SelectedValue + " id=" + Number.Text + " name=" + Number.Text + " cols=95></TEXTAREA>',s_str='<TEXTAREA rows=" + showBl.SelectedValue + " id=" + Number.Text + " name=" + Number.Text + " cols=95>'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改自定义字段[" + List.GetFormatStr(Name.Text) + "]", "销售管理-自定义字段-" + typename + "");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaleFieldDIY.aspx?type=" + Request.QueryString["type"].ToString() + "'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

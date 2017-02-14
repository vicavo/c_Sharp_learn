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
    public partial class SaleFieldDIY_add : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename;
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

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
                BindAttribute();
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
            string SQL_GetList = "select top 1 PaiXun from qp_SaleFieldDIY  order by paixun desc";

            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                PaixunAdd = int.Parse(NewReader["PaiXun"].ToString());
            }
            else
            {
                PaixunAdd = 0;
            }
            NewReader.Close();
            int PaixunAdd_1 = PaixunAdd + 1;

            string sql_insert = "insert into qp_SaleFieldDIY (Number,Name,showBl,textbox,s_str,l_str,PaiXun,Type) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(showBl.SelectedValue) + "','<TEXTAREA rows=" + showBl.SelectedValue + " id=" + Number.Text + " name=" + Number.Text + " cols=95></TEXTAREA>','<TEXTAREA rows=" + showBl.SelectedValue + " id=" + Number.Text + " name=" + Number.Text + " cols=95>','</TEXTAREA>','" + PaixunAdd_1 + "','" + Request.QueryString["type"].ToString() + "')";
            List.ExeSql(sql_insert);

            InsertLog("新增自定义字段[" + List.GetFormatStr(Name.Text) + "]", "销售管理-自定义字段-" + typename + "");


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

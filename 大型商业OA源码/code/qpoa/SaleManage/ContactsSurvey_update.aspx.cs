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
    public partial class ContactsSurvey_update : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_ContactsSurvey where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    KeyId.Text = NewReader["KeyId"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    KhId.Text = NewReader["KhId"].ToString();
                    KhRealname.Text = NewReader["KhRealname"].ToString();
                    Feedback.Text = NewReader["Feedback"].ToString();
                    Content.Text = NewReader["Content"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();

                }

                NewReader.Close();

                BindAttribute();
            }



        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
            // KhRealname.Attributes.Add("readonly", "readonly");


            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContactsSurvey.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_ContactsSurvey   Set KeyId='" + KeyId.Text + "',Name='" + Name.Text + "',KhId='" + List.GetFormatStr(KhId.Text) + "',KhRealname='" + List.GetFormatStr(KhRealname.Text) + "',Feedback='" + List.GetFormatStr(Feedback.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);


            InsertLog("修改满意度调查记录[" + Name.Text + "]", "满意度调查");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ContactsSurvey.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

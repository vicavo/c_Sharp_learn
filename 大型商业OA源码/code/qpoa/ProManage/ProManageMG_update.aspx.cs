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
namespace qpoa.ProManage
{
    public partial class ProManageMG_update : System.Web.UI.Page
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
            fjkey = Session["FjKey"].ToString();
            if (!Page.IsPostBack)
            {
                BindAttribute();


                string SQL_GetList = "select * from qp_ProManage where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    ConName.Text = NewReader["ConName"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Types.Text = NewReader["Types"].ToString();
                    Jibie.Text = NewReader["Jibie"].ToString();
                    States.SelectedValue = NewReader["States"].ToString();
                    Conetent.Text = NewReader["Conetent"].ToString();
                    FzUsername.Text = NewReader["FzUsername"].ToString();
                    FzRealname.Text = NewReader["FzRealname"].ToString();
                    CyUsername.Text = NewReader["CyUsername"].ToString();
                    CyRealname.Text = NewReader["CyRealname"].ToString();
                }
                NewReader.Close();
            }
            BindFjlbList();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("ProFile/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名

                string sql_insert_file = "insert into qp_fileupload   (Name,NewName,KeyField) values ('" + fileName + "','ProManage/ProFile/" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传附件[" + fileName + "]", "项目创建");
                BindFjlbList();
            }
        }


        public void BindFjlbList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_fileupload where KeyField='" + Number.Text + "'";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }

        public void BindAttribute()
        {
            FzRealname.Attributes.Add("readonly", "readonly");
            CyRealname.Attributes.Add("readonly", "readonly");


            Starttime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";

            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProManageMG.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_ProManage  Set Name='" + Name.Text + "',ConName='" + ConName.Text + "',Starttime='" + List.GetFormatStr(Starttime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "',Types='" + List.GetFormatStr(Types.Text) + "',Jibie='" + List.GetFormatStr(Jibie.Text) + "',States='" + States.SelectedValue + "',Conetent='" + List.GetFormatStr(Conetent.Text) + "',FzUsername='" + List.GetFormatStr(FzUsername.Text) + "',FzRealname='" + List.GetFormatStr(FzRealname.Text) + "',CyUsername='" + List.GetFormatStr(CyUsername.Text) + "',CyRealname='" + List.GetFormatStr(CyRealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            InsertLog("修改项目创建[" + Name.Text + "]", "项目创建");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ProManageMG.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }
    }
}

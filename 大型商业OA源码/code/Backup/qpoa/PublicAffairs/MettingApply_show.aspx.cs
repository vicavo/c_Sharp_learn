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
namespace qpoa.PublicAffairs
{
    public partial class MettingApply_show : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_MettingApply where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    Title.Text = NewReader["Title"].ToString();
                    Introduction.Text = List.TbToLb(NewReader["Introduction"].ToString());
                    WbPeople.Text = List.TbToLb(NewReader["WbPeople"].ToString());
                    NbPeopleUser.Text = NewReader["NbPeopleUser"].ToString();

                    NbPeopleName.Text = NewReader["NbPeopleName"].ToString();
                    MettingId.Text = NewReader["MettingId"].ToString();
                    MettingName.Text = NewReader["MettingName"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();

                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());

                    CjRealname.Text = NewReader["CjRealname"].ToString();

                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                    State.Text = NewReader["State"].ToString();
                    SpTimes.Text = NewReader["SpTimes"].ToString();

                }

                NewReader.Close();
                InsertLog("查看会议申请[" + Name.Text + "]", "会议申请");
                BindAttribute();
            }
        }

        public void BindAttribute()
        {
            //ManagerName.Attributes.Add("readonly", "readonly");

            //NbPeopleName.Attributes.Add("readonly", "readonly");
            //MettingName.Attributes.Add("readonly", "readonly");

            //Starttime.Attributes.Add("readonly", "readonly");
            //Endtime.Attributes.Add("readonly", "readonly");

            //Button2.Attributes["onclick"] = "javascript:return showwait();";
         




        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MettingApply.aspx");
        //}



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

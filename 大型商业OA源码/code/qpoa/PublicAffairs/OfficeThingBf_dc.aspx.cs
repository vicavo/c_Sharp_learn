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
    public partial class OfficeThingBf_dc : System.Web.UI.Page
    {
        Db List = new Db();
        public static string SqlStrStart, SqlStrMid, SqlStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                InsertLog("导出办公用品报废审批", "审批办公用品报废");
                DataBindToGridview();
                List.ToExcel(GridView1, "OfficeThing");

            }

        }
        public void DataBindToGridview()
        {
            if (Request.QueryString["outkey"] == "1")
            {
                SqlStrStart = "select * from qp_OfficeThingBf where 1=1 and  ( Username='" + this.Session["username"] + "')";
            }
            if (Request.QueryString["outkey"] == "2")
            {
                SqlStrStart = "select * from qp_OfficeThingBf where 1=1 and Shenpi='已通过' and  ( Username='" + this.Session["username"] + "')";
            }
            if (Request.QueryString["outkey"] == "3")
            {
                SqlStrStart = "select * from qp_OfficeThingBf where 1=1 and ( Shenpi='未通过'  or Shenpi='放弃审批')  and  ( Username='" + this.Session["username"] + "')";
            }




            SqlStrMid = string.Empty;
            SqlStrMid = Server.UrlDecode(Request.QueryString["str"]);
            SqlStr = SqlStrStart + SqlStrMid + "order by id desc";//查询


            if (Request.QueryString["str"] != null)
            {
                string SQL_GetList_xs = "" + SqlStr + " ";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                GridView1.DataBind();



            }
            else
            {
                if (Request.QueryString["outkey"] == "1")
                {
                    string SQL_GetList_xs = "select * from qp_OfficeThingBf where (Username='" + this.Session["username"] + "') ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }
                if (Request.QueryString["outkey"] == "2")
                {


                    string SQL_GetList_xs = "select * from qp_OfficeThingBf where Shenpi='已通过' and  (Username='" + this.Session["username"] + "') ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }
                if (Request.QueryString["outkey"] == "3")
                {
                    string SQL_GetList_xs = "select * from qp_OfficeThingBf where ( Shenpi='未通过'  or Shenpi='放弃审批')  and  (Username='" + this.Session["username"] + "') ";
                    GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
                    GridView1.DataBind();
                }




            }

        }
        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        public override void VerifyRenderingInServerForm(Control control)
        { }





    }
}

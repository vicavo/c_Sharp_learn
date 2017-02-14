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
namespace qpoa.PublicAffairs
{
    public partial class CarInfo_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CarInfo  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CarNum.Text = NewReader["CarNum"].ToString();


                    CarModel.Text = NewReader["CarModel"].ToString();
                    CarType.Text = NewReader["CarType"].ToString();
                    Driver.Text = NewReader["Driver"].ToString();
                    CarPrice.Text = NewReader["CarPrice"].ToString();
                    CarTime.Text = NewReader["CarTime"].ToString();
                    EngineNum.Text = NewReader["EngineNum"].ToString();
                    Status.SelectedValue = NewReader["Status"].ToString();
             
                    Remark.Text = NewReader["Remark"].ToString();



                }

                NewReader.Close();
                BindAttribute();
            }
        }

        public void BindAttribute()
        {


            CarTime.Attributes.Add("readonly", "readonly");




            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["keys"] == "1")
            {
                Response.Redirect("CarInfo.aspx");
            }

            if (Request.QueryString["keys"] == "2")
            {
                Response.Redirect("CarInfo_ysh.aspx");
            }


            if (Request.QueryString["keys"] == "3")
            {
                Response.Redirect("CarInfo_wxz.aspx");
            }

            if (Request.QueryString["keys"] == "4")
            {
                Response.Redirect("CarInfo_ybf.aspx");
            }
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update1 = "Update qp_CarInfo     Set CarNum='" + List.GetFormatStr(CarNum.Text) + "',CarModel='" + List.GetFormatStr(CarModel.Text) + "',Driver='" + List.GetFormatStr(Driver.Text) + "',CarPrice='" + List.GetFormatStr(CarPrice.Text) + "',CarTime='" + List.GetFormatStr(CarTime.Text) + "',EngineNum='" + List.GetFormatStr(EngineNum.Text) + "',Status='" + List.GetFormatStr(Status.SelectedValue) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            InsertLog("修改车辆[" + CarNum.Text + "]", "车辆信息管理");


            if (Request.QueryString["keys"] == "1")
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarInfo.aspx'</script>");
            }

            if (Request.QueryString["keys"] == "2")
            {

                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarInfo_ysh.aspx'</script>");
            }


            if (Request.QueryString["keys"] == "3")
            {
              
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarInfo_wxz.aspx'</script>");
            }

            if (Request.QueryString["keys"] == "4")
            {
               
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarInfo_ybf.aspx'</script>");
            }

          


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

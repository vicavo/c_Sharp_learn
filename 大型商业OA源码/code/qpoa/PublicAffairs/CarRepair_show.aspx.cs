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
    public partial class CarRepair_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CarRepair where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CarId.Text = NewReader["CarId"].ToString();
                    CarNum.Text = NewReader["CarNum"].ToString();

                    RepairTime.Text = System.DateTime.Parse(NewReader["RepairTime"].ToString()).ToShortDateString();
                    RepairType.Text = NewReader["RepairType"].ToString();
                    Reasons.Text = NewReader["Reasons"].ToString();
                    People.Text = NewReader["People"].ToString();
                    RepairMoney.Text = NewReader["RepairMoney"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());

                   

                }
                InsertLog("查看车辆维护[" + CarNum.Text + "]", "车辆维护管理");
                BindAttribute();
            }
        }

        public void BindAttribute()
        {


           


            Button2.Attributes["onclick"] = "javascript:return showwait();";
       




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarRepair.aspx");
        }



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

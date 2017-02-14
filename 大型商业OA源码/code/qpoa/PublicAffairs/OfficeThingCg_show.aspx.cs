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
    public partial class OfficeThingCg_show : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_OfficeThingCg where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NameId.Text = NewReader["NameId"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    DanJia.Text = NewReader["DanJia"].ToString();
                    ShuLiang.Text = NewReader["ShuLiang"].ToString();
                    Shenpi.Text = NewReader["Shenpi"].ToString();
                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                    Remark.Text =  List.TbToLb(NewReader["Remark"].ToString());
                    SpTimes.Text = NewReader["SpTimes"].ToString();

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
           
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficeThingCg.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

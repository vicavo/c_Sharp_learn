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
namespace qpoa.HumanResources
{
    public partial class WorkTime_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkTime   where id='" + int.Parse(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    SyRealname.Text = NewReader["SyRealname"].ToString();
                    PbType.Text = NewReader["PbType"].ToString();
                    QyType.Text = NewReader["QyType"].ToString();

                    DjType_1.Text = NewReader["DjType_1"].ToString();

                    DjType_2.Text = NewReader["DjType_2"].ToString();
                    DjType_3.Text = NewReader["DjType_3"].ToString();
                    DjType_4.Text = NewReader["DjType_4"].ToString();

                    DjType_5.Text = NewReader["DjType_5"].ToString();
                    DjType_6.Text = NewReader["DjType_6"].ToString();


                    DjTime_1.Text = NewReader["DjTime_1"].ToString();
                    DjTime_2.Text = NewReader["DjTime_2"].ToString();
                    DjTime_3.Text = NewReader["DjTime_3"].ToString();
                    DjTime_4.Text = NewReader["DjTime_4"].ToString();
                    DjTime_5.Text = NewReader["DjTime_5"].ToString();
                    DjTime_6.Text = NewReader["DjTime_6"].ToString();
                }

            }
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkTime.aspx");
        }

    }
}

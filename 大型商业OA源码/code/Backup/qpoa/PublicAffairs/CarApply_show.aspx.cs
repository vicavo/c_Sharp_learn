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
    public partial class CarApply_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CarApply  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CarId.Text = NewReader["CarId"].ToString();
                    CarNum.Text = NewReader["CarNum"].ToString();
                    UnitName.Text = NewReader["UnitName"].ToString().Replace("|", "").Replace("-", "");

                    Drivers.Text = NewReader["Drivers"].ToString();
                    Carpeople.Text = NewReader["Carpeople"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Destination.Text = NewReader["Destination"].ToString();
                    Miles.Text = NewReader["Miles"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Subject.Text = List.TbToLb(NewReader["Subject"].ToString());

                    Remark.Text =  List.TbToLb(NewReader["Remark"].ToString());

                    Realname.Text = NewReader["Realname"].ToString();


                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                    State.Text = NewReader["State"].ToString();
                    SpTimes.Text = NewReader["SpTimes"].ToString();


                }

                NewReader.Close();

                InsertLog("查看车辆使用申请[" + CarNum.Text + "]", "车辆使用申请");
                BindAttribute();

            }
        }



        public void BindAttribute()
        {


        
       




        }






        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

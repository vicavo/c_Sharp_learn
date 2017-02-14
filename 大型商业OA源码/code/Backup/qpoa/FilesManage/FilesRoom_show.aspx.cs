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
namespace qpoa.FilesManage
{
    public partial class FilesRoom_show : System.Web.UI.Page
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
                BindDroList();
                BindAttribute();



                string SQL_GetList = "select * from qp_FilesRoom where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    QxUnitId.Text = NewReader["QxUnitId"].ToString();
                    QxUnitName.Text = NewReader["QxUnitName"].ToString();
                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());
                    UnitName.Text = NewReader["UnitId"].ToString();

                }
                NewReader.Close();





            }
        }
        public void BindDroList()
        {
            ////附件列表
            //string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            //list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");

        }
        public void BindAttribute()
        {

            //QxUnitName.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            //Button1.Attributes["onclick"] = "javascript:return chknull();";


        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesRoom.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

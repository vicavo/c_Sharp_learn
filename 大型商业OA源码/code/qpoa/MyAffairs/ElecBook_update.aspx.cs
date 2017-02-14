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
namespace qpoa.MyAffairs
{
    public partial class ElecBook_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string LineW, QxString, QxStringSta, LineWSta;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList_sta = "select * from qp_ElecBook where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader_sta = List.GetList(SQL_GetList_sta);
                if (NewReader_sta.Read())
                {
                    Name.Text = NewReader_sta["Name"].ToString();
                    PxNum.Text = NewReader_sta["PxNum"].ToString();
                }
                NewReader_sta.Close();

                BindAttribute();
            }





        }
        public void BindAttribute()
        {

            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }



        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_ElecBook  Set Name='" + List.GetFormatStr(Name.Text) + "',PxNum='" + List.GetFormatStr(PxNum.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'  ";
            List.ExeSql(Sql_update);

            string Sql_update1 = "Update qp_ElecBookShow  Set FoldersName='" + List.GetFormatStr(Name.Text) + "'  where FoldersID='" + int.Parse(Request.QueryString["id"]) + "' ";
            List.ExeSql(Sql_update1);


            InsertLog("修改书架名[" + Name.Text + "]", "电子刊物");

            this.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'ElecBook.aspx'</script>");



        }

        public void InsertLog(string Name, string MkName)
        {

            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
namespace qpoa.SystemManage
{
    public partial class qp_OpenNotice : System.Web.UI.Page
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
                BindAttribute();
                string SQL_GetList = "select * from qp_OpenNotice ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    d_content.Value = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                    IfOpen.SelectedValue = NewReader["IfOpen"].ToString();
                 



                }
                NewReader.Close();

            }



        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return showwait();";
        
        }



        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update = "Update qp_OpenNotice  Set Content='" + List.GetFormatStrbjq(d_content.Value) + "',IfOpen='" + IfOpen .SelectedValue+ "'";
            List.ExeSql(Sql_update);

            InsertLog("修改弹出公告", "弹出公告设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OpenNotice.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
    public partial class smsmodle : System.Web.UI.Page
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

            string SQL_GetList_sms = "select * from Sms_Update where Sms_Update='否'";
            SqlDataReader NewReader_sms = List.GetList(SQL_GetList_sms);
            if (NewReader_sms.Read())
            {
                this.Response.Write("<script language=javascript>alert('软件未启动手机短信功能！');window.close()</script>");
                return;
            }
            NewReader_sms.Close();



            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_CompanyGroup where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    MoveTel.Text = NewReader["MoveTel"].ToString();
                }
                NewReader.Close();
                BindAttribute();
            }





        }

        public void BindAttribute()
        {

            Name.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>window.close()</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into OutBox   (username,Mbno,Msg,SendTime,ComPort,Report,V1,V2,V3,V4,V5) values ('" + Session["realname"] + "(" + Session["username"] + ")','" + List.GetFormatStr(MoveTel.Text) + "','" + List.GetFormatStr(Msg.Text) + "','" + System.DateTime.Now.ToString() + "','0','0','','','','','')";
            List.ExeSql(sql_insert);


            InsertLog("发送手机短信[" + Name.Text + "]", "单位通讯录");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");


        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }






    }
}

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
namespace qpoa
{
    public partial class MyDataUpdate : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }



            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_MyData where Username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Realname.Text = NewReader["Realname"].ToString();
                    Worknum.Text = NewReader["Worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    Bothday.Text = NewReader["Bothday"].ToString();
                    Tel.Text = NewReader["Tel"].ToString();
                    Fax.Text = NewReader["Fax"].ToString();
                    MoveTel.Text = NewReader["MoveTel"].ToString();
                    LittleTel.Text = NewReader["LittleTel"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    QQNum.Text = NewReader["QQNum"].ToString();
                    Msn.Text = NewReader["Msn"].ToString();
                    ICQ.Text = NewReader["ICQ"].ToString();
                    Address.Text = NewReader["Address"].ToString();
                    ZipCode.Text = NewReader["ZipCode"].ToString();
                    HomeTel.Text = NewReader["HomeTel"].ToString();
                }
                NewReader.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_MyData  Set Realname='" + List.GetFormatStr(Realname.Text) + "',Worknum='" + List.GetFormatStr(Worknum.Text) + "',Unit='" + List.GetFormatStr(Unit.Text) + "',Post='" + List.GetFormatStr(Post.Text) + "',Sex='" + List.GetFormatStr(Sex.Text) + "',Bothday='" + List.GetFormatStr(Bothday.Text) + "',Tel='" + List.GetFormatStr(Tel.Text) + "',Fax='" + List.GetFormatStr(Fax.Text) + "',MoveTel='" + List.GetFormatStr(MoveTel.Text) + "',LittleTel='" + List.GetFormatStr(LittleTel.Text) + "',Email='" + List.GetFormatStr(Email.Text) + "',QQNum='" + List.GetFormatStr(QQNum.Text) + "',Msn='" + List.GetFormatStr(Msn.Text) + "',ICQ='" + List.GetFormatStr(ICQ.Text) + "',Address='" + List.GetFormatStr(Address.Text) + "',ZipCode='" + List.GetFormatStr(ZipCode.Text) + "',HomeTel='" + List.GetFormatStr(HomeTel.Text) + "' where  Username='" + Session["username"] + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改了个人资料", "个人资料");
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

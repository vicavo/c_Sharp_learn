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
namespace qpoa.KmManage
{
    public partial class KmTitle_show_update : System.Web.UI.Page
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


                BindAttribute();

                string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    BigId.Text = NewReader["BigId"].ToString();
                    BigName.Text = NewReader["BigName"].ToString();
                    LittleId.Text = NewReader["LittleId"].ToString();
                    LittleName.Text = NewReader["LittleName"].ToString();
                    Title.Text = NewReader["Title"].ToString();
                    Content.Text = NewReader["Content"].ToString();
                    AthourSay.Text = NewReader["AthourSay"].ToString();
                    KeyWord.Text = NewReader["KeyWord"].ToString();
                    QxYdUsername.Text = NewReader["QxYdUsername"].ToString();
                    QxYdRealname.Text = NewReader["QxYdRealname"].ToString();
                    //QxXgUsername.Text = NewReader["QxXgUsername"].ToString();
                    //QxXgRealname.Text = NewReader["QxXgRealname"].ToString();
                }
            
                NewReader.Close();


            }



        }

        public void BindAttribute()
        {
            LittleName.Attributes.Add("readonly", "readonly");
            QxYdRealname.Attributes.Add("readonly", "readonly");
            //QxXgRealname.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";
            Button4.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_KmTitle  Set BigId='" + List.GetFormatStr(BigId.Text) + "',BigName='" + List.GetFormatStr(BigName.Text) + "',LittleId='" + List.GetFormatStr(LittleId.Text) + "',LittleName='" + List.GetFormatStr(LittleName.Text) + "',Title='" + List.GetFormatStr(Title.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "',AthourSay='" + List.GetFormatStr(AthourSay.Text) + "',KeyWord='" + List.GetFormatStr(KeyWord.Text) + "',QxYdUsername='" + List.GetFormatStr(QxYdUsername.Text) + "',QxYdRealname='" + List.GetFormatStr(QxYdRealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改知识[" + Title.Text + "]", "我的知识");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["LittleId"] + "';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_KmTitle  Set BigId='" + List.GetFormatStr(BigId.Text) + "',BigName='" + List.GetFormatStr(BigName.Text) + "',LittleId='" + List.GetFormatStr(LittleId.Text) + "',LittleName='" + List.GetFormatStr(LittleName.Text) + "',Title='" + List.GetFormatStr(Title.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "',AthourSay='" + List.GetFormatStr(AthourSay.Text) + "',KeyWord='" + List.GetFormatStr(KeyWord.Text) + "',QxYdUsername='" + List.GetFormatStr(QxYdUsername.Text) + "',QxYdRealname='" + List.GetFormatStr(QxYdRealname.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
         
            InsertLog("修改知识[" + Title.Text + "]", "我的知识");

            Response.Redirect("KmTitle_show_add_zj_manage.aspx?Number=" + Number.Text + "&LittleId=" + Request.QueryString["LittleId"] + "");
        }







    }
}

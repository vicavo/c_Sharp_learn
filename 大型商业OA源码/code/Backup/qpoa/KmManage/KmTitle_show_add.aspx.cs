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
    public partial class KmTitle_show_add : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_KmLittleType where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    BigId.Text = NewReader["BigId"].ToString();
                    BigName.Text = NewReader["BigName"].ToString();
                    LittleId.Text = NewReader["id"].ToString();
                    LittleName.Text = NewReader["Name"].ToString();
                }
                else
                {
                    BigId.Text = "";
                    BigName.Text = "";
                    LittleId.Text = "";
                    LittleName.Text = "";
                }
                NewReader.Close();


            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
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
            string sql_insert = "insert into qp_KmTitle    (Number,BigId,BigName,LittleId,LittleName,Title,Content,AthourSay,KeyWord,YdUsername,YdRealname,TjUsername,TjRealname,ScUsername,ScRealname,DyUsername,DyRealname,PointNum,ScNum,DyNum,TjNum,LastTime,QxYdUsername,QxYdRealname,IfTj,State,KeyKmId,Username,Realname,Settime) values ('" + Number.Text + "','" + BigId.Text + "','" + BigName.Text + "','" + LittleId.Text + "','" + List.GetFormatStr(LittleName.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + List.GetFormatStr(AthourSay.Text) + "','" + List.GetFormatStr(KeyWord.Text) + "','','','','','','','','','0','0','0','0','" + System.DateTime.Now.ToString() + "','" + List.GetFormatStr(QxYdUsername.Text) + "','" + List.GetFormatStr(QxYdRealname.Text) + "','否','暂存','0','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增知识[" + Title.Text + "]", "我的知识");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='KmTitle_show.aspx?LittleId=" + Request.QueryString["id"] + "';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_KmTitle    (Number,BigId,BigName,LittleId,LittleName,Title,Content,AthourSay,KeyWord,YdUsername,YdRealname,TjUsername,TjRealname,ScUsername,ScRealname,DyUsername,DyRealname,PointNum,ScNum,DyNum,TjNum,LastTime,QxYdUsername,QxYdRealname,IfTj,State,KeyKmId,Username,Realname,Settime) values ('" + Number.Text + "','" + BigId.Text + "','" + BigName.Text + "','" + LittleId.Text + "','" + List.GetFormatStr(LittleName.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + List.GetFormatStr(AthourSay.Text) + "','" + List.GetFormatStr(KeyWord.Text) + "','','','','','','','','','0','0','0','0','" + System.DateTime.Now.ToString() + "','" + List.GetFormatStr(QxYdUsername.Text) + "','" + List.GetFormatStr(QxYdRealname.Text) + "','否','暂存','0','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增知识[" + Title.Text + "]", "我的知识");

            Response.Redirect("KmTitle_show_add_zj.aspx?Number=" + Number.Text + "&LittleId=" + Request.QueryString["id"] + "");
        }







    }
}

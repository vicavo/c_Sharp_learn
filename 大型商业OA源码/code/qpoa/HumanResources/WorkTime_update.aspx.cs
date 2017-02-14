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
    public partial class WorkTime_update : System.Web.UI.Page
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
                BindDrop();
                BindAttribute();

                string SQL_GetList = "select * from qp_WorkTime   where id='" + int.Parse(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    SyUsername.Text = NewReader["SyUsername"].ToString();
                    SyRealname.Text = NewReader["SyRealname"].ToString();
                    PbType.Text = NewReader["PbType"].ToString();
                    QyType.SelectedValue = NewReader["QyType"].ToString();

                    DjType_1.SelectedValue = NewReader["DjType_1"].ToString();

                    DjType_2.SelectedValue = NewReader["DjType_2"].ToString();
                    DjType_3.SelectedValue = NewReader["DjType_3"].ToString();
                    DjType_4.SelectedValue = NewReader["DjType_4"].ToString();

                    DjType_5.SelectedValue = NewReader["DjType_5"].ToString();
                    DjType_6.SelectedValue = NewReader["DjType_6"].ToString();

                    h1.SelectedValue = System.DateTime.Parse(NewReader["DjTime_1"].ToString()).Hour.ToString();
                    h2.SelectedValue = System.DateTime.Parse(NewReader["DjTime_2"].ToString()).Hour.ToString();
                    h3.SelectedValue = System.DateTime.Parse(NewReader["DjTime_3"].ToString()).Hour.ToString();
                    h4.SelectedValue = System.DateTime.Parse(NewReader["DjTime_4"].ToString()).Hour.ToString();
                    h5.SelectedValue = System.DateTime.Parse(NewReader["DjTime_5"].ToString()).Hour.ToString();
                    h6.SelectedValue = System.DateTime.Parse(NewReader["DjTime_6"].ToString()).Hour.ToString();

                    m1.SelectedValue = System.DateTime.Parse(NewReader["DjTime_1"].ToString()).Minute.ToString();
                    m2.SelectedValue = System.DateTime.Parse(NewReader["DjTime_2"].ToString()).Minute.ToString();
                    m3.SelectedValue = System.DateTime.Parse(NewReader["DjTime_3"].ToString()).Minute.ToString();
                    m4.SelectedValue = System.DateTime.Parse(NewReader["DjTime_4"].ToString()).Minute.ToString();
                    m5.SelectedValue = System.DateTime.Parse(NewReader["DjTime_5"].ToString()).Minute.ToString();
                    m6.SelectedValue = System.DateTime.Parse(NewReader["DjTime_6"].ToString()).Minute.ToString();
                }

            }
        }
        public void BindAttribute()
        {
            SyRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }

        public void BindDrop()
        {

            list.Bind_DropDownList_Hour(h1);
            list.Bind_DropDownList_Hour(h2);
            list.Bind_DropDownList_Hour(h3);
            list.Bind_DropDownList_Hour(h4);
            list.Bind_DropDownList_Hour(h5);
            list.Bind_DropDownList_Hour(h6);

            list.Bind_DropDownList_Mini(m1);
            list.Bind_DropDownList_Mini(m2);
            list.Bind_DropDownList_Mini(m3);
            list.Bind_DropDownList_Mini(m4);
            list.Bind_DropDownList_Mini(m5);
            list.Bind_DropDownList_Mini(m6);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update = "Update qp_WorkTime Set SyUsername='" + SyUsername.Text + "', SyRealname='" + SyRealname.Text + "',PbType='" + List.GetFormatStr(PbType.Text) + "',QyType='" + QyType.SelectedValue + "',DjType_1='" + DjType_1.SelectedValue + "',DjType_2='" + DjType_2.SelectedValue + "',DjType_3='" + DjType_3.SelectedValue + "',DjType_4='" + DjType_4.SelectedValue + "',DjType_5='" + DjType_5.SelectedValue + "',DjType_6='" + DjType_6.SelectedValue + "',DjTime_1='" + h1.SelectedValue + ":" + m1.SelectedValue + "',DjTime_2='" + h2.SelectedValue + ":" + m2.SelectedValue + "',DjTime_3='" + h3.SelectedValue + ":" + m3.SelectedValue + "',DjTime_4='" + h4.SelectedValue + ":" + m4.SelectedValue + "',DjTime_5='" + h5.SelectedValue + ":" + m5.SelectedValue + "',DjTime_6='" + h6.SelectedValue + ":" + m6.SelectedValue + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("修改上下班时间", "上下班时间");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkTime.aspx'</script>");
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

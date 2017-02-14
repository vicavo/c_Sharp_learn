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
    public partial class MyGroup_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_MyGroup where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and username='"+Session["username"]+"'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Name.Text = NewReader["Name"].ToString();
                    GroupName.Text = NewReader["GroupName"].ToString();
                    Sex.SelectedValue = NewReader["Sex"].ToString();
                    BothDay.Text = NewReader["BothDay"].ToString();
                    OtherName.Text = NewReader["OtherName"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    Spouses.Text = NewReader["Spouses"].ToString();
                    Children.Text = NewReader["Children"].ToString();
                    CName.Text = NewReader["CName"].ToString();
                    CAddress.Text = NewReader["CAddress"].ToString();
                    CZipCode.Text = NewReader["CZipCode"].ToString();
                    CTel.Text = NewReader["CTel"].ToString();
                    CFax.Text = NewReader["CFax"].ToString();
                    HAddress.Text = NewReader["HAddress"].ToString();
                    HZipCode.Text = NewReader["HZipCode"].ToString();
                    HTel.Text = NewReader["HTel"].ToString();
                    HMoveTel.Text = NewReader["HMoveTel"].ToString();
                    HXiaoTel.Text = NewReader["HXiaoTel"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    QQNum.Text = NewReader["QQNum"].ToString();
                    MsnNum.Text = NewReader["MsnNum"].ToString();
                    IfOpen.SelectedValue = NewReader["IfOpen"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();
                  





                }
                NewReader.Close();
                BindAttribute();
            }





        }

        public void BindAttribute()
        {

            BothDay.Attributes.Add("readonly", "readonly");



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyGroup.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_MyGroup     Set GroupName='" + List.GetFormatStr(GroupName.Text) + "',Name='" + List.GetFormatStr(Name.Text) + "',Sex='" + List.GetFormatStr(Sex.SelectedValue) + "',BothDay='" + List.GetFormatStr(BothDay.Text) + "',OtherName='" + List.GetFormatStr(OtherName.Text) + "',Post='" + List.GetFormatStr(Post.Text) + "',Spouses='" + List.GetFormatStr(Spouses.Text) + "',Children='" + List.GetFormatStr(Children.Text) + "',CName='" + List.GetFormatStr(CName.Text) + "',CAddress='" + List.GetFormatStr(CAddress.Text) + "',CZipCode='" + List.GetFormatStr(CZipCode.Text) + "',CTel='" + List.GetFormatStr(CTel.Text) + "',CFax='" + List.GetFormatStr(CFax.Text) + "',HAddress='" + List.GetFormatStr(HAddress.Text) + "',HZipCode='" + List.GetFormatStr(HZipCode.Text) + "',HTel='" + List.GetFormatStr(HTel.Text) + "',HMoveTel='" + List.GetFormatStr(HMoveTel.Text) + "',HXiaoTel='" + List.GetFormatStr(HXiaoTel.Text) + "',Email='" + List.GetFormatStr(Email.Text) + "',QQNum='" + List.GetFormatStr(QQNum.Text) + "',MsnNum='" + List.GetFormatStr(MsnNum.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "',IfOpen='" + IfOpen.SelectedValue + "' where   id='" + int.Parse(Request.QueryString["id"]) + "' and username='" + Session["username"] + "'";
            List.ExeSql(Sql_update1);



            InsertLog("修改个人通讯录[" + Name.Text + "]", "个人通讯录");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyGroup.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

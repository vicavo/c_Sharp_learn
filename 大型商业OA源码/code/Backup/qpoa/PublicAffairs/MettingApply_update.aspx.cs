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
    public partial class MettingApply_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_MettingApply where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    txtTitle.Text = NewReader["Title"].ToString();
                    Introduction.Text = NewReader["Introduction"].ToString();
                    WbPeople.Text = NewReader["WbPeople"].ToString();
                    NbPeopleUser.Text = NewReader["NbPeopleUser"].ToString();

                    NbPeopleName.Text = NewReader["NbPeopleName"].ToString();
                    MettingId.Text = NewReader["MettingId"].ToString();
                    MettingName.Text = NewReader["MettingName"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    State.Text = NewReader["State"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();



                }

                NewReader.Close();
                if (State.Text != "待审批")
                {
                    this.Response.Write("<script language=javascript>alert('此单据已经审批，不能再修改！');window.location.href = 'MettingApply.aspx'</script>");
                    return;
                }
                BindAttribute();
            }
        }

        public void BindAttribute()
        {
            ManagerName.Attributes.Add("readonly", "readonly");

            NbPeopleName.Attributes.Add("readonly", "readonly");
            MettingName.Attributes.Add("readonly", "readonly");

            Starttime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MettingApply.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_MettingApply    Set Name='" + List.GetFormatStr(Name.Text) + "',Title='" + List.GetFormatStr(txtTitle.Text) + "',Introduction='" + List.GetFormatStr(Introduction.Text) + "',WbPeople='" + List.GetFormatStr(WbPeople.Text) + "',NbPeopleUser='" + List.GetFormatStr(NbPeopleUser.Text) + "',NbPeopleName='" + List.GetFormatStr(NbPeopleName.Text) + "',MettingId='" + List.GetFormatStr(MettingId.Text) + "',MettingName='" + List.GetFormatStr(MettingName.Text) + "',ManagerUser='" + List.GetFormatStr(ManagerUser.Text) + "',ManagerName='" + List.GetFormatStr(ManagerName.Text) + "',Starttime='" + List.GetFormatStr(Starttime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);



            InsertLog("修改会议申请[" + Name.Text + "]", "会议申请");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

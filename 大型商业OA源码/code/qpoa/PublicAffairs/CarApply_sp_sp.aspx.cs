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
    public partial class CarApply_sp_sp : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CarApply  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CarId.Text = NewReader["CarId"].ToString();
                    CarNum.Text = NewReader["CarNum"].ToString();
                    UnitName.Text = NewReader["UnitName"].ToString().Replace("|", "").Replace("-", "");

                    Drivers.Text = NewReader["Drivers"].ToString();
                    Carpeople.Text = NewReader["Carpeople"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Destination.Text = NewReader["Destination"].ToString();
                    Miles.Text = NewReader["Miles"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Subject.Text = List.TbToLb(NewReader["Subject"].ToString());

                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());

                    Realname.Text = NewReader["Realname"].ToString();
                    Username.Text = NewReader["Username"].ToString();

                    SpRealname.Text = Session["realname"].ToString();


                }

                NewReader.Close();

               
                BindAttribute();

            }

            string sql_down_bh = "select Title from qp_UseSpRemark where Username='" + Session["username"].ToString() + "' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList(normalcontent, sql_down_bh, "Title", "Title");
            }

        }



        public void BindAttribute()
        {








        }






        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Shenpi.SelectedValue == "已通过")
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的车辆已经审批，审批结果为[已通过]！','您申请的车辆已经审批，审批结果为[已通过]！','" + System.DateTime.Now.ToString() + "','" + Username.Text + "','" + Realname.Text + "','系统消息','系统消息','否','PublicAffairs/CarApply_ytg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);


            }
            else
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的车辆已经审批，审批结果为[未通过]！','您申请的车辆已经审批，审批结果为[未通过]！','" + System.DateTime.Now.ToString() + "','" + Username.Text + "','" + Realname.Text + "','系统消息','系统消息','否','PublicAffairs/CarApply_wtg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);
            }

            string Sql_update1 = "Update qp_CarApply    Set SpRemark='" + List.GetFormatStr(SpRemark.Text) + "',State='" + Shenpi.SelectedValue + "',SpUsername='" + Session["username"] + "',SpRealname='" + Session["realname"] + "',SpTimes='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
            InsertLog("审批车辆[" + CarNum.Text + "]，[" + Shenpi.SelectedValue + "]", "车辆使用管理");



            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply_sp.aspx'</script>");
        }







    }
}

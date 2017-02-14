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
    public partial class CarApply_add : System.Web.UI.Page
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
                BindDroList();
                BindAttribute();
                Realname.Text = this.Session["realname"].ToString();
            }
        }

        public void BindDroList()
        {
            //附件列表
            string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");

        }

        public void BindAttribute()
        {
            CarNum.Attributes.Add("readonly", "readonly");

            ManagerName.Attributes.Add("readonly", "readonly");
            Realname.Attributes.Add("readonly", "readonly");

            Starttime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CarApply.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_CarApply   (CarId,CarNum,Drivers,Carpeople,UnitNameId,UnitName,Starttime,Endtime,Destination,Miles,ManagerUser,ManagerName,Subject,State,Remark,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + List.GetFormatStr(CarId.Text) + "','" + List.GetFormatStr(CarNum.Text) + "','" + List.GetFormatStr(Drivers.Text) + "','" + List.GetFormatStr(Carpeople.Text) + "','" + List.GetFormatStr(UnitName.SelectedValue) + "','" + List.GetFormatStr(UnitName.SelectedItem.Text) + "','" + List.GetFormatStr(Starttime.Text) + "','" + List.GetFormatStr(Endtime.Text) + "','" + List.GetFormatStr(Destination.Text) + "','" + List.GetFormatStr(Miles.Text) + "','" + List.GetFormatStr(ManagerUser.Text) + "','" + List.GetFormatStrbjq(ManagerName.Text) + "','" + List.GetFormatStrbjq(Subject.Text) + "','待审批','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
           // Response.Write(sql_insert);
            if (DL1.SelectedValue == "是")
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的车辆申请需要审批，请注意查看！','有新的车辆申请需要审批，请注意查看！','" + System.DateTime.Now.ToString() + "','" + List.GetFormatStr(ManagerUser.Text) + "','" + List.GetFormatStr(ManagerName.Text) + "','系统消息','系统消息','否','PublicAffairs/CarApply_sp.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);

            }


            InsertLog("新增车辆使用申请[" + CarNum.Text + "]", "车辆使用申请");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

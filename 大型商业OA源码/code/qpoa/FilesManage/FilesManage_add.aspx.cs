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
namespace qpoa.FilesManage
{
    public partial class FilesManage_add : System.Web.UI.Page
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
            }
        }
        public void BindDroList()
        {
            
            string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");


            string sql_down_1 = "select * from qp_FilesData where type=1 order by id desc";
            list.Bind_DropDownList_nothing(DengJi, sql_down_1, "name", "name");

            string sql_down_2 = "select * from qp_FilesData where type=2 order by id desc";
            list.Bind_DropDownList_nothing(PinZheng, sql_down_2, "name", "name");

            string sql_down_3 = "select * from qp_FilesRoom   where (CHARINDEX('," + this.Session["UnitId"] + ",',','+QxUnitId+',')   >   0 )   order by id desc";
            list.Bind_DropDownList_nothing(RoomName, sql_down_3, "id", "name");



        }
        public void BindAttribute()
        {


            QxUnitName.Attributes.Add("readonly", "readonly");


            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesManage.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string sql_insert = "insert into qp_FilesManage  (State,Number,Name,RoomName,RoomId,BackYear,Starttime,Endtime,UnitId,UnitName,BzPost,BgTime,DengJi,QuanZong,Mulu,DaGuan,BaoXian,SuoWei,PinZheng,PzStartNum,PzEndNum,YeShu,QxUnitId,QxUnitName,Remark,Username,Realname) values ('" + State.SelectedValue + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + RoomName.SelectedItem.Text + "','" + RoomName.SelectedValue + "','" + List.GetFormatStr(BackYear.Text) + "','" + List.GetFormatStr(Starttime.Text) + "','" + List.GetFormatStr(Endtime.Text) + "','" + List.GetFormatStr(UnitName.SelectedValue) + "','" + List.GetFormatStr(UnitName.SelectedItem.Text) + "','" + List.GetFormatStr(BzPost.Text) + "','" + List.GetFormatStr(BgTime.Text) + "','" + List.GetFormatStr(DengJi.Text) + "','" + List.GetFormatStr(QuanZong.Text) + "','" + List.GetFormatStr(Mulu.Text) + "','" + List.GetFormatStr(DaGuan.Text) + "','" + List.GetFormatStr(BaoXian.Text) + "','" + List.GetFormatStr(SuoWei.Text) + "','" + List.GetFormatStr(PinZheng.Text) + "','" + List.GetFormatStr(PzStartNum.Text) + "','" + List.GetFormatStr(PzEndNum.Text) + "','" + List.GetFormatStr(YeShu.Text) + "','" + List.GetFormatStr(QxUnitId.Text) + "','" + List.GetFormatStr(QxUnitName.Text) + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "')";
            List.ExeSql(sql_insert);
            // Response.Write(sql_insert);
            InsertLog("新增案卷[" + Name.Text + "]", "案卷管理");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FilesManage.aspx'</script>");

        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

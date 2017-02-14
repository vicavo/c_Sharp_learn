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
    public partial class FilesManage_update : System.Web.UI.Page
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


                string SQL_GetList = "select * from qp_FilesManage  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    RoomName.SelectedValue = NewReader["RoomId"].ToString();
                    RoomName.SelectedItem.Text = NewReader["RoomName"].ToString();
                    BackYear.Text = NewReader["BackYear"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    UnitName.SelectedValue = NewReader["UnitId"].ToString();
                    UnitName.SelectedItem.Text = NewReader["UnitName"].ToString();
                    BzPost.Text = NewReader["BzPost"].ToString();
                    BgTime.Text = NewReader["BgTime"].ToString();
                    DengJi.SelectedValue = NewReader["DengJi"].ToString();
                    QuanZong.Text = NewReader["QuanZong"].ToString();
                    Mulu.Text = NewReader["Mulu"].ToString();
                    DaGuan.Text = NewReader["DaGuan"].ToString();
                    BaoXian.Text = NewReader["BaoXian"].ToString();
                    SuoWei.Text = NewReader["SuoWei"].ToString();
                    PinZheng.SelectedValue = NewReader["PinZheng"].ToString();
                    PzStartNum.Text = NewReader["PzStartNum"].ToString();
                    PzEndNum.Text = NewReader["PzEndNum"].ToString();
                    YeShu.Text = NewReader["YeShu"].ToString();
                    QxUnitId.Text = NewReader["QxUnitId"].ToString();
                    QxUnitName.Text = NewReader["QxUnitName"].ToString();
                    State.SelectedValue = NewReader["State"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();

                }
                NewReader.Close();




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

            string sql_down_3 = "select * from qp_FilesRoom  where (CHARINDEX('," + this.Session["UnitId"] + ",',','+QxUnitId+',')   >   0 )  order by id desc";
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
            string Sql_update = "Update qp_FilesManage  Set Number='" + List.GetFormatStr(Number.Text) + "',Name='" + List.GetFormatStr(Name.Text) + "',RoomId='" + RoomName.SelectedValue + "',RoomName='" + RoomName.SelectedItem.Text + "' ,BackYear='" + List.GetFormatStr(BackYear.Text) + "',Starttime='" + List.GetFormatStr(Starttime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "' ,UnitId='" + UnitName.SelectedValue + "',UnitName='" + UnitName.SelectedItem.Text + "' ,BzPost='" + List.GetFormatStr(BzPost.Text) + "',BgTime='" + List.GetFormatStr(BgTime.Text) + "',DengJi='" + List.GetFormatStr(DengJi.SelectedValue) + "' ,QuanZong='" + List.GetFormatStr(QuanZong.Text) + "',Mulu='" + List.GetFormatStr(Mulu.Text) + "',DaGuan='" + List.GetFormatStr(DaGuan.Text) + "',BaoXian='" + List.GetFormatStr(BaoXian.Text) + "' ,SuoWei='" + List.GetFormatStr(SuoWei.Text) + "',PinZheng='" + PinZheng.SelectedValue + "' ,PzStartNum='" + List.GetFormatStr(PzStartNum.Text) + "',PzEndNum='" + List.GetFormatStr(PzEndNum.Text) + "',YeShu='" + List.GetFormatStr(YeShu.Text) + "' ,QxUnitId='" + List.GetFormatStr(QxUnitId.Text) + "',QxUnitName='" + QxUnitName.Text + "' ,State='" + List.GetFormatStr(State.SelectedValue) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "' ";
            List.ExeSql(Sql_update);
    
            InsertLog("修改案卷[" + Name.Text + "]", "案卷管理");

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

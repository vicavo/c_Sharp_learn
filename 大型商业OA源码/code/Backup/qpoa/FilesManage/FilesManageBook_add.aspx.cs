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
    public partial class FilesManageBook_add : System.Web.UI.Page
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
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {

                    fjkey = NewReader_fjkey["content"].ToString();

                }
                NewReader_fjkey.Close();
                BindDroList();
                BindAttribute();
            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }

            BindList();


        }
        public void BindDroList()
        {

            string sql_down_1 = "select * from qp_FilesData where type=6 order by id desc";
            list.Bind_DropDownList_nothing(Miji, sql_down_1, "name", "name");

            string sql_down_2 = "select * from qp_FilesData where type=3 order by id desc";
            list.Bind_DropDownList_nothing(Dengji, sql_down_2, "name", "name");


            string sql_down_4 = "select * from qp_FilesData where type=4 order by id desc";
            list.Bind_DropDownList_nothing(WjType, sql_down_4, "name", "name");


            string sql_down_5 = "select * from qp_FilesData where type=5 order by id desc";
            list.Bind_DropDownList_nothing(GwType, sql_down_5, "name", "name");



            string sql_down_3 = "select * from qp_FilesManage  where (CHARINDEX('," + this.Session["UnitId"] + ",',','+QxUnitId+',')   >   0 )   order by id desc";
            list.Bind_DropDownList_nothing(FilesName, sql_down_3, "id", "name");



        }
        public void BindList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_FilesManageBookFj where KeyField='" + Number.Text + "' order by id desc";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("FilesManageBook.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_FilesManageBook  (Number,Num,Name,Title,OtherTitle,FwCompany,FwTime,Miji,Dengji,WjType,GwType,WjNum,DyNum,FilesName,FilesId,State,JrUsername,JrRealname,Remark,Username,Realname) values ('" + Number.Text + "','" + List.GetFormatStr(Num.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStr(OtherTitle.Text) + "','" + List.GetFormatStr(FwCompany.Text) + "','" + List.GetFormatStr(FwTime.Text) + "','" + Miji.SelectedValue + "','" + List.GetFormatStr(Dengji.SelectedValue) + "','" + List.GetFormatStr(WjType.SelectedValue) + "','" + List.GetFormatStr(GwType.SelectedValue) + "','" + List.GetFormatStr(WjNum.Text) + "','" + List.GetFormatStr(DyNum.Text) + "','" + FilesName.SelectedItem.Text + "','" + FilesName.SelectedValue + "','未借出','','','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "')";
            List.ExeSql(sql_insert);

            InsertLog("新增文件[" + Name.Text + "]", "文件管理");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='FilesManageBook.aspx'</script>");

        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("FilesManageBookFj/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名

                string sql_insert_file = "insert into qp_FilesManageBookFj    (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传文件附件[" + fileName + "]", "文件管理");
                BindList();
            }
        }







    }
}

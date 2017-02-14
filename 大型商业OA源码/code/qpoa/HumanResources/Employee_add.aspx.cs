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
namespace qpoa.InfoSpeech
{
    public partial class Employee_add : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                BindAttribute();
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
     
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }


            BindDroList();

        }
        public void BindAttribute()
        {
            Unit.Attributes.Add("readonly", "readonly");
            Post.Attributes.Add("readonly", "readonly");
            Respon.Attributes.Add("readonly", "readonly");
            Bothday.Attributes.Add("readonly", "readonly");
            Worktime.Attributes.Add("readonly", "readonly");
            Companytime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
           
            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";


        }

        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_EmployeeFile where KeyField='" + Number.Text + "'";


            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_Check_worknum_rs = "select * from qp_Employee where worknum='" + List.GetFormatStr(worknum.Text) + "'";
            SqlDataReader MyReader_worknum_rs = List.GetList(SQL_Check_worknum_rs);
            if (MyReader_worknum_rs.Read())
            {
                this.Response.Write("<script language=javascript>alert('工号与人事信息库重复！');</script>");
                return;
            }

                string sql_insertrs = "insert into qp_Employee (Realname,worknum,Unit,UnittId,Respon,ResponId,Post,PostId,StardType,Email,Sex,Bothday,Nationality,IDnumber,Marriage,Politics,Nativeplace,Permanents,Schoolrecord,TitleRank,School,Specialized,Worktime,Companytime,Tel,Address,Postchange,Educational,Wxperience,Social,Rewards,Dutysituation,Trains,Guarantees,Laborcontract,Society,Physical,Remark1,KeyFile,settime) "
              + "values ('" + List.GetFormatStr(Realname.Text) + "','" + List.GetFormatStr(worknum.Text) + "','" + List.GetFormatStr(Request.Form["Unit"]) + "','" + List.GetFormatStr(UnitId.Text) + "','" + List.GetFormatStr(Request.Form["Respon"]) + "','" + List.GetFormatStr(ResponId.Text) + "','" + List.GetFormatStr(Request.Form["Post"]) + "','" + List.GetFormatStr(PostId.Text) + "','" + List.GetFormatStr(StardType.SelectedValue) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(Request.Form["Bothday"]) + "','" + List.GetFormatStr(Nationality.Text) + "','" + List.GetFormatStr(IDnumber.Text) + "','" + List.GetFormatStr(Marriage.SelectedValue) + "','" + List.GetFormatStr(Politics.SelectedValue) + "','" + List.GetFormatStr(Nativeplace.Text) + "','" + List.GetFormatStr(Permanents.Text) + "','" + List.GetFormatStr(Schoolrecord.Text) + "','" + List.GetFormatStr(TitleRank.Text) + "','" + List.GetFormatStr(School.Text) + "','" + List.GetFormatStr(Specialized.Text) + "','" + List.GetFormatStr(Request.Form["Worktime"]) + "','" + List.GetFormatStr(Request.Form["Companytime"]) + "','" + List.GetFormatStr(Tel.Text) + "','" + List.GetFormatStr(Address.Text) + "','" + List.GetFormatStr(Postchange.Text) + "','" + List.GetFormatStr(Educational.Text) + "','" + List.GetFormatStr(Wxperience.Text) + "','" + List.GetFormatStr(Social.Text) + "','" + List.GetFormatStr(Rewards.Text) + "','" + List.GetFormatStr(Dutysituation.Text) + "','" + List.GetFormatStr(Trains.Text) + "','" + List.GetFormatStr(Guarantees.Text) + "','" + List.GetFormatStr(Laborcontract.Text) + "','" + List.GetFormatStr(Society.Text) + "','" + List.GetFormatStr(Physical.Text) + "','" + List.GetFormatStr(Remark1.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insertrs);

                InsertLog("新增人事信息[" + Realname.Text + "]", "档案管理");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Employee.aspx'</script>");


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
            string strBaseLocation = Server.MapPath("../SystemManage/EmployeeFile/");
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


                string sql_insert_file = "insert into qp_EmployeeFile (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + List.GetFormatStr(Number.Text) + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传人事信息附件[" + fileName + "]", "档案管理");
                BindDroList();
            }

        }
        private bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf("|" + Str1 + "|") <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}

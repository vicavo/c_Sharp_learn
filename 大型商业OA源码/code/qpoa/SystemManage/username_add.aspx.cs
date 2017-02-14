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
namespace qpoa.SystemManage
{
    public partial class username_add : System.Web.UI.Page
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
                //Unit.Attributes.Add("onkeydown", "return false");
                //Post.Attributes.Add("onkeydown", "return false");
                //Respon.Attributes.Add("onkeydown", "return false");
                //Bothday.Attributes.Add("onkeydown", "return false");
                //Worktime.Attributes.Add("onkeydown", "return false");
                //Companytime.Attributes.Add("onkeydown", "return false");




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
            shownext.Attributes["onclick"] = "javascript:return shownextdiv();";
            shownext1.Attributes["onclick"] = "javascript:return shownextdiv();";
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
            Response.Redirect("username.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string SQL_GetCount = "select count(id) from  qp_username";
            //int CountsUser = List.GetCount(SQL_GetCount);
            //if (CountsUser > 10)
            //{
            //    Response.Write("<script>alert('试用版，软件使用人数限制为10人！请联系开发商！');window.location.href='username.aspx'</Script>");
            //    return;
            //}//试用版，软件使用人数受到限制！请联系开发商


            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text,"MD5");

            string SQL_Check_worknum = "select * from qp_Username where Username='" + List.GetFormatStr(Username.Text) + "' or worknum='" + List.GetFormatStr(worknum.Text) + "'";
			SqlDataReader MyReader_worknum = List.GetList(SQL_Check_worknum);
            if (MyReader_worknum.Read())
            {
                this.Response.Write("<script language=javascript>alert('用户名或工号与用户信息库能重复！');</script>");
                return;
            }
            MyReader_worknum.Close();


            string SQL_Check_worknum_rs = "select * from qp_Employee where worknum='" + List.GetFormatStr(worknum.Text) + "'";
            SqlDataReader MyReader_worknum_rs = List.GetList(SQL_Check_worknum_rs);
            if (MyReader_worknum_rs.Read())
            {
                this.Response.Write("<script language=javascript>alert('工号与人事信息库重复！');</script>");
                return;
            }
            MyReader_worknum_rs.Close();


            string ResponQx = null;
            string SQL_Check_worknum_qx = "select * from qp_Respon where id='" + ResponId.Text + "'";
            SqlDataReader MyReader_worknum_qx = List.GetList(SQL_Check_worknum_qx);
            if (MyReader_worknum_qx.Read())
            {
                ResponQx = MyReader_worknum_qx["Perstr"].ToString();
            }
            MyReader_worknum_qx.Close();//对应权限字符串


            string sql_insert_open = "insert into qp_IfOpen (Name,Sound,Username,Realname) values ('rform','1.swf','" + List.GetFormatStr(Username.Text) + "','" + List.GetFormatStr(Realname.Text) + "')";
            List.ExeSql(sql_insert_open);


            string sql_insert_my = "insert into qp_MyData (username,Realname,Worknum,Unit,Post,Sex,Bothday) values ('" + List.GetFormatStr(Username.Text) + "','" + List.GetFormatStr(Realname.Text) + "','" + List.GetFormatStr(worknum.Text) + "','" + List.GetFormatStr(Unit.Text) + "','" + List.GetFormatStr(Post.Text) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(Bothday.Text) + "')";
            List.ExeSql(sql_insert_my);


            if (shownext.Checked == true)
            {

                string sql_insert = "insert into qp_username (lasttime,ShouJi,Username,Password,Realname,worknum,Unit,UnitId,Respon,ResponId,Post,PostId,StardType,Email,Iflogin,Sex,Remark,settime,QxString,KeyQx,ResponQx) "
                + "values ('" + System.DateTime.Now.AddDays(-1).ToString() + "','" + List.GetFormatStr(ShouJi.Text) + "','" + List.GetFormatStr(Username.Text) + "','" + hashPassword + "','" + List.GetFormatStr(Realname.Text) + "','" + List.GetFormatStr(worknum.Text) + "','" + List.GetFormatStr(Request.Form["Unit"]) + "','" + List.GetFormatStr(UnitId.Text) + "','" + List.GetFormatStr(Request.Form["Respon"]) + "','" + List.GetFormatStr(ResponId.Text) + "','" + List.GetFormatStr(Request.Form["Post"]) + "','" + List.GetFormatStr(PostId.Text) + "','" + List.GetFormatStr(StardType.Text) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(Iflogin.SelectedValue) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(Remark.Text) + "','" + System.DateTime.Now.ToString() + "','" + QxString.Text + "','" + KeyQx.Text + "','" + ResponQx + "')";
                List.ExeSql(sql_insert);

                string sql_insertrs = "insert into qp_Employee (Username,Realname,worknum,Unit,UnittId,Respon,ResponId,Post,PostId,StardType,Email,Sex,Bothday,Nationality,IDnumber,Marriage,Politics,Nativeplace,Permanents,Schoolrecord,TitleRank,School,Specialized,Worktime,Companytime,Tel,Address,Postchange,Educational,Wxperience,Social,Rewards,Dutysituation,Trains,Guarantees,Laborcontract,Society,Physical,Remark1,KeyFile,settime) "
              + "values ('" + List.GetFormatStr(Username.Text) + "','" + List.GetFormatStr(Realname.Text) + "','" + List.GetFormatStr(worknum.Text) + "','" + List.GetFormatStr(Request.Form["Unit"]) + "','" + List.GetFormatStr(UnitId.Text) + "','" + List.GetFormatStr(Request.Form["Respon"]) + "','" + List.GetFormatStr(ResponId.Text) + "','" + List.GetFormatStr(Request.Form["Post"]) + "','" + List.GetFormatStr(PostId.Text) + "','" + List.GetFormatStr(StardType.SelectedValue) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(Request.Form["Bothday"]) + "','" + List.GetFormatStr(Nationality.Text) + "','" + List.GetFormatStr(IDnumber.Text) + "','" + List.GetFormatStr(Marriage.SelectedValue) + "','" + List.GetFormatStr(Politics.SelectedValue) + "','" + List.GetFormatStr(Nativeplace.Text) + "','" + List.GetFormatStr(Permanents.Text) + "','" + List.GetFormatStr(Schoolrecord.Text) + "','" + List.GetFormatStr(TitleRank.Text) + "','" + List.GetFormatStr(School.Text) + "','" + List.GetFormatStr(Specialized.Text) + "','" + List.GetFormatStr(Request.Form["Worktime"]) + "','" + List.GetFormatStr(Request.Form["Companytime"]) + "','" + List.GetFormatStr(Tel.Text) + "','" + List.GetFormatStr(Address.Text) + "','" + List.GetFormatStr(Postchange.Text) + "','" + List.GetFormatStr(Educational.Text) + "','" + List.GetFormatStr(Wxperience.Text) + "','" + List.GetFormatStr(Social.Text) + "','" + List.GetFormatStr(Rewards.Text) + "','" + List.GetFormatStr(Dutysituation.Text) + "','" + List.GetFormatStr(Trains.Text) + "','" + List.GetFormatStr(Guarantees.Text) + "','" + List.GetFormatStr(Laborcontract.Text) + "','" + List.GetFormatStr(Society.Text) + "','" + List.GetFormatStr(Physical.Text) + "','" + List.GetFormatStr(Remark1.Text) + "','"+ List.GetFormatStr(Number.Text) + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insertrs);


                string sql_insert1 = "insert into qp_MyReminded (iftx,txtime,Username,Realname) "
                  + "values ('是','300000','" + List.GetFormatStr(Username.Text) + "','" + List.GetFormatStr(Realname.Text) + "')";
                List.ExeSql(sql_insert1);


                InsertLog("新增系统用户[" + Realname.Text + "]", "用户信息");
                InsertLog("新增人事信息[" + Realname.Text + "]", "用户信息");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");

            }
            else
            {

                string sql_insert1 = "insert into qp_MyReminded (iftx,txtime,Username,Realname) "
  + "values ('是','300000','" + List.GetFormatStr(Username.Text) + "','" + List.GetFormatStr(Realname.Text) + "')";
                List.ExeSql(sql_insert1);


                string sql_insert = "insert into qp_username (lasttime,ShouJi,Username,Password,Realname,worknum,Unit,UnitId,Respon,ResponId,Post,PostId,StardType,Email,Iflogin,Sex,Remark,settime,QxString,KeyQx,ResponQx) "
                + "values ('" + System.DateTime.Now.AddDays(-1).ToString() + "','" + List.GetFormatStr(ShouJi.Text) + "','" + List.GetFormatStr(Username.Text) + "','" + hashPassword + "','" + List.GetFormatStr(Realname.Text) + "','" + List.GetFormatStr(worknum.Text) + "','" + List.GetFormatStr(Request.Form["Unit"]) + "','" + List.GetFormatStr(UnitId.Text) + "','" + List.GetFormatStr(Request.Form["Respon"]) + "','" + List.GetFormatStr(ResponId.Text) + "','" + List.GetFormatStr(Request.Form["Post"]) + "','" + List.GetFormatStr(PostId.Text) + "','" + List.GetFormatStr(StardType.Text) + "','" + List.GetFormatStr(Email.Text) + "','" + List.GetFormatStr(Iflogin.SelectedValue) + "','" + List.GetFormatStr(Sex.SelectedValue) + "','" + List.GetFormatStr(Remark.Text) + "','" + System.DateTime.Now.ToString() + "','" + QxString.Text + "','" + KeyQx.Text + "','" + ResponQx + "')";
                List.ExeSql(sql_insert);


                InsertLog("新增用户" + Realname.Text + "", "用户信息");


                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");

            }
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
            string strBaseLocation = Server.MapPath("EmployeeFile/");
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

            
                    InsertLog("上传人事信息附件[" + fileName + "]", "用户信息");
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

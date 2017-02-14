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
    public partial class Employee_update : System.Web.UI.Page
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


                string SQL_GetList = "select * from qp_Employee where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Realname.Text = NewReader["Realname"].ToString();
                    worknum.Text = NewReader["worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    UnitId.Text = NewReader["UnittId"].ToString();
                    Respon.Text = NewReader["Respon"].ToString();
                    ResponId.Text = NewReader["ResponId"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    PostId.Text = NewReader["PostId"].ToString();
                    StardType.SelectedValue = NewReader["StardType"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    Sex.SelectedValue = NewReader["Sex"].ToString();
                    Bothday.Text = NewReader["Bothday"].ToString();
                    Nationality.Text = NewReader["Nationality"].ToString();
                    IDnumber.Text = NewReader["IDnumber"].ToString();
                    Marriage.Text = NewReader["Marriage"].ToString();
                    Politics.SelectedValue = NewReader["Politics"].ToString();
                    Nativeplace.Text = NewReader["Nativeplace"].ToString();
                    Permanents.Text = NewReader["Permanents"].ToString();
                    Schoolrecord.SelectedValue = NewReader["Schoolrecord"].ToString();
                    TitleRank.Text = NewReader["TitleRank"].ToString();
                    School.Text = NewReader["School"].ToString();
                    Specialized.Text = NewReader["Specialized"].ToString();
                    Worktime.Text = NewReader["Worktime"].ToString();
                    Companytime.Text = NewReader["Companytime"].ToString();
                    Tel.Text = NewReader["Tel"].ToString();
                    Address.Text = NewReader["Address"].ToString();
                    Postchange.Text = NewReader["Postchange"].ToString();
                    Educational.Text = NewReader["Educational"].ToString();
                    Wxperience.Text = NewReader["Wxperience"].ToString();
                    Social.Text = NewReader["Social"].ToString();
                    Rewards.Text = NewReader["Rewards"].ToString();
                    Dutysituation.Text = NewReader["Dutysituation"].ToString();
                    Trains.Text = NewReader["Trains"].ToString();
                    Guarantees.Text = NewReader["Guarantees"].ToString();
                    Laborcontract.Text = NewReader["Laborcontract"].ToString();
                    Society.Text = NewReader["Society"].ToString();
                    Physical.Text = NewReader["Physical"].ToString();
                    Remark1.Text = NewReader["Remark1"].ToString();
                    Number.Text = NewReader["KeyFile"].ToString();
                 
                }
                NewReader.Close();
            


            
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
            string Sql_update = "Update qp_Employee  Set Realname='" + List.GetFormatStr(Realname.Text) + "',  worknum='" + List.GetFormatStr(worknum.Text) + "',  Unit='" + List.GetFormatStr(Unit.Text) + "',  UnittId='" + List.GetFormatStr(UnitId.Text) + "',  Respon='" + List.GetFormatStr(Respon.Text) + "',  ResponId='" + List.GetFormatStr(ResponId.Text) + "',  Post='" + List.GetFormatStr(Post.Text) + "',  PostId='" + List.GetFormatStr(PostId.Text) + "',  StardType='" + List.GetFormatStr(StardType.SelectedValue) + "',  Email='" + List.GetFormatStr(Email.Text) + "',  Sex='" + List.GetFormatStr(Sex.SelectedValue) + "',  Bothday='" + List.GetFormatStr(Bothday.Text) + "',  Nationality='" + List.GetFormatStr(Nationality.Text) + "',  IDnumber='" + List.GetFormatStr(IDnumber.Text) + "',  Marriage='" + List.GetFormatStr(Marriage.SelectedValue) + "',  Politics='" + List.GetFormatStr(Politics.SelectedValue) + "',  Nativeplace='" + List.GetFormatStr(Nativeplace.Text) + "',  Permanents='" + List.GetFormatStr(Permanents.Text) + "',  Schoolrecord='" + List.GetFormatStr(Schoolrecord.SelectedValue) + "',  TitleRank='" + List.GetFormatStr(TitleRank.Text) + "',  School='" + List.GetFormatStr(School.Text) + "',  Specialized='" + List.GetFormatStr(Specialized.Text) + "',  Worktime='" + List.GetFormatStr(Worktime.Text) + "',  Companytime='" + List.GetFormatStr(Companytime.Text) + "',  Tel='" + List.GetFormatStr(Tel.Text) + "',  Address='" + List.GetFormatStr(Address.Text) + "',  Postchange='" + List.GetFormatStr(Postchange.Text) + "',  Educational='" + List.GetFormatStr(Educational.Text) + "',  Wxperience='" + List.GetFormatStr(Wxperience.Text) + "',  Social='" + List.GetFormatStr(Social.Text) + "',  Rewards='" + List.GetFormatStr(Rewards.Text) + "',  Dutysituation='" + List.GetFormatStr(Dutysituation.Text) + "',  Trains='" + List.GetFormatStr(Trains.Text) + "',  Guarantees='" + List.GetFormatStr(Guarantees.Text) + "',  Laborcontract='" + List.GetFormatStr(Laborcontract.Text) + "',  Society='" + List.GetFormatStr(Society.Text) + "',  Physical='" + List.GetFormatStr(Physical.Text) + "',  Remark1='" + List.GetFormatStr(Remark1.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            InsertLog("修改人事信息[" + Realname.Text + "]", "档案管理");
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

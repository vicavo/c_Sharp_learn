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
    public partial class WorkPlan_update : System.Web.UI.Page
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
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {

                    fjkey = NewReader_fjkey["content"].ToString();

                }
                NewReader_fjkey.Close();

                BindAttribute();
            }

            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkPlan where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    Content.Text = NewReader["Content"].ToString();
                    PlanCycle.Text = NewReader["PlanCycle"].ToString();
                    PlanType.Text = NewReader["PlanType"].ToString();
                    Startime.Text = NewReader["Startime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    SendUnit.Text = NewReader["SendUnit"].ToString();
                    SendUnitId.Text = NewReader["SendUnitId"].ToString();
                    SendRealname.Text = NewReader["SendRealname"].ToString();
                    SendUsername.Text = NewReader["SendUsername"].ToString();
                    Header.Text = NewReader["Header"].ToString();
                    HeaderUser.Text = NewReader["HeaderUser"].ToString();
                    FjRemark.Text = NewReader["FjRemark"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();

                }

                NewReader.Close();
              
            }

            BindDroList();
        }
        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_WorkPlanFile where KeyField='" + Number.Text + "'";


            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void BindAttribute()
        {

            Startime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");
            SendRealname.Attributes.Add("readonly", "readonly");
            SendUnit.Attributes.Add("readonly", "readonly");




            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkPlan.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update1 = "Update qp_WorkPlan   Set Name='" + List.GetFormatStr(Name.Text) + "',Content='" + List.GetFormatStr(Content.Text) + "',PlanCycle='" + List.GetFormatStr(PlanCycle.Text) + "',PlanType='" + List.GetFormatStr(PlanType.Text) + "',Startime='" + List.GetFormatStr(Startime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "',SendUnit='" + List.GetFormatStr(SendUnit.Text) + "',SendUnitId='" + List.GetFormatStr(SendUnitId.Text) + "',SendRealname='" + List.GetFormatStr(SendRealname.Text) + "',SendUsername='" + List.GetFormatStr(SendUsername.Text) + "',Header='" + List.GetFormatStr(Header.Text) + "',HeaderUser='" + List.GetFormatStr(HeaderUser.Text) + "',FjRemark='" + List.GetFormatStr(FjRemark.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            InsertLog("修改工作计划[" + Name.Text + "]", "计划管理");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkPlan.aspx'</script>");


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
            string strBaseLocation = Server.MapPath("WorkPlanFile/");
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


                string sql_insert_file = "insert into qp_WorkPlanFile (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + List.GetFormatStr(Number.Text) + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传工作计划附件[" + fileName + "]", "计划管理");
                BindDroList();
            }
        }





    }
}

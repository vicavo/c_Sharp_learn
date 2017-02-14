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
namespace qpoa.MyAffairs
{
    public partial class CompanyNotic_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                BindAttribute();

                string SQL_GetList_sta = "select * from qp_CompanyNotic where id='" + Request.QueryString["id"] + "' ";
                SqlDataReader NewReader = List.GetList(SQL_GetList_sta);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    d_content.Value = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                    Title.Text = NewReader["Title"].ToString();
                  
                    GxUnitNameId.Text = NewReader["GxUnitNameId"].ToString();
                    GxUnitName.Text = NewReader["GxUnitName"].ToString();

                }
                NewReader.Close();
            }

            BindFjlbList();

        }

        public void BindAttribute()
        {
            GxUnitName.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("CompanyNotic.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
    
                string Sql_update = "Update qp_CompanyNotic   Set Title='" + List.GetFormatStr(Title.Text) + "',Content='" + List.GetFormatStrbjq(d_content.Value) + "' ,GxUnitNameId='" + List.GetFormatStr(GxUnitNameId.Text) + "' ,GxUnitName='" + List.GetFormatStr(GxUnitName.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "' ";
                List.ExeSql(Sql_update);
          

            InsertLog("修改公司通知[" + Title.Text + "]", "公司通知管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CompanyNotic.aspx'</script>");
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
            string strBaseLocation = Server.MapPath("CompanyNotic/");
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


                string sql_insert_file = "insert into qp_fileupload   (Name,NewName,KeyField) values ('" + fileName + "','MyAffairs/CompanyNotic/" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


               
                BindFjlbList();
            }
        }


        public void BindFjlbList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_fileupload where KeyField='" + Number.Text + "'";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }



    }
}

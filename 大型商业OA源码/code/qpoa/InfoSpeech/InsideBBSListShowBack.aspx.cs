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
    public partial class InsideBBSListShowBack : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string BigName;
        public static string fjkey;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }
            fjkey = Session["FjKey"].ToString();
            if (!Page.IsPostBack)
            {

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
  


                string SQL_GetList = "select * from qp_InsideBBSBig where id='" + Request.QueryString["id"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    BigName = NewReader["Name"].ToString();
                }
                NewReader.Close();

                BindAttribute();
            }

            BindFjlbList();
        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return chknull();";

            Button1.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_InsideBBS  (Number,Title,Content,BigId,BigName,ParentNodesID,PointNum,Username,Realname,Settime) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + Request.QueryString["BigId"] + "','" + BigName + "','" + Request.QueryString["id"] + "','0','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insertgly);

            InsertLog("回帖" + title.Text + "", "内部讨论区");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='InsideBBSListShow.aspx?id=" + Request.QueryString["id"] + "&BigId=" + Request.QueryString["BigId"] + "'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("InsideBBSListShow.aspx?id=" + Request.QueryString["id"] + "&BigId=" + Request.QueryString["BigId"] + "");
        }


 


        public void BindFjlbList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_fileupload where KeyField='" + Number.Text + "'";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("InsideBBS/");
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


                string sql_insert_file = "insert into qp_fileupload   (Name,NewName,KeyField) values ('" + fileName + "','InfoSpeech/InsideBBS/" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传附件[" + fileName + "]", "内部讨论区");
                BindFjlbList();
            }
        }
    }
}

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
    public partial class NbMailAccept_add : System.Web.UI.Page
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

            fjkey = Session["FjKey"].ToString();
            if (!Page.IsPostBack)
            {

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";




                if (Request.QueryString["user"] != null)
                {
                    acceptusername.Text = "" + Server.UrlDecode(Request.QueryString["user"]) + ",";
                    acceptrealname.Text = "" + Server.UrlDecode(Request.QueryString["name"]) + ",";
                }
                BindAttribute();
            }
            BindFjlbList();
        }
        public void BindAttribute()
        {

            acceptrealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return chknull();";


            Button6.Attributes["onclick"] = "javascript:return checkForm();";
            Button1.Attributes["onclick"] = "javascript:return delfj();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string strlist = null;
            string str1 = null;
            str1 = "" + acceptusername.Text + "";
            ArrayList myarr = new ArrayList();
            string[] mystr = str1.Split(',');
            for (int s = 0; s < mystr.Length; s++)
            {
                strlist += "'" + mystr[s] + "',";
            }
            strlist += "'0'";

            string SQL_GetList_xs = "select * from qp_Username where  username in (" + strlist + ") ";
            SqlDataReader NewReader = List.GetList(SQL_GetList_xs);
            while (NewReader.Read())
            {
                string sql_insertgly = "insert into qp_NbMailAccept  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,delbj,number) values ('" + List.GetFormatStr(title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + Session["username"] + "','" + Session["realname"] + "','否','否','" + List.GetFormatStr(Number.Text) + "')";
                List.ExeSql(sql_insertgly);

                string sql_insertgly1 = "insert into qp_NbMailSend  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,cgbj,number) values ('" + List.GetFormatStr(title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + Session["username"] + "','" + Session["realname"] + "','否','否','" + List.GetFormatStr(Number.Text) + "')";
                List.ExeSql(sql_insertgly1);

            }
            NewReader.Close();

            InsertLog("发送内部邮件", "内部邮件管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NbMailSend.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_NbMailSend  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,cgbj,number) values ('" + List.GetFormatStr(title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','" + System.DateTime.Now.ToString() + "','" + acceptusername.Text + "','" + acceptrealname.Text + "','" + Session["username"] + "','" + Session["realname"] + "','否','是','" + List.GetFormatStr(Number.Text) + "')";
            List.ExeSql(sql_insertgly);
            InsertLog("保存内部邮件", "内部邮件管理");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NbMailSendCg.aspx'</script>");

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("NbMailAccept.aspx");
        }

 


        public void BindFjlbList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_fileupload where KeyField='" + Number.Text + "'";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("NbMailAccept/");
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


                string sql_insert_file = "insert into qp_fileupload   (Name,NewName,KeyField) values ('" + fileName + "','InfoSpeech/NbMailAccept/" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传附件[" + fileName + "]", "内部邮件");
                BindFjlbList();
            }
        }


    }
}

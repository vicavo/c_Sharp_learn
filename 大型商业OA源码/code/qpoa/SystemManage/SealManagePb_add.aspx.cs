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
    public partial class SealManagepPb_add : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";

                BindAttribute();
            }



        }
        public void BindAttribute()
        {

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return checkForm();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SealManagePb.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile("666666", "MD5");

            //上传文件
            string strBaseLocation = Server.MapPath("../WorkFlow/CompanySeal/");
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


                string sql_insert = "insert into qp_YinZhangPb  (Number,Name,Oldname,Newname,Password,Username,Realname,Nowtimes) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + fileName + "','" + TruePath + "','" + hashPassword + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert);





                string strlist = null;
                string str1 = null;
                str1 = "" + QxUsername.Text + "";
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
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的公章[" + Name.Text + "]发布，请注意查看！默认密码为：666666，请注意修改密码！','有新的公章[" + Name.Text + "]发布，请注意查看！默认密码为：666666，请注意修改密码！','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','WorkFlow/YinZhang.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);

                    string sql_insert1 = "insert into qp_YinZhang  (Number,Name,Oldname,Newname,Password,YxType,State,Username,Realname,Nowtimes) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + fileName + "','" + TruePath + "','" + hashPassword + "','公章','正常','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_insert1);

                }
                NewReader.Close();

                InsertLog("新增公章维护[" + Name.Text + "]", "公章维护");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SealManagePb.aspx'</script>");



            }
            else
            {
                this.Response.Write("<script language=javascript>alert('上传文件为空！');</script>");
            }








        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

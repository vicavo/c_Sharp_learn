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
using System.Net.Mail;
//using System.Web.Mail;
//using jmail;
namespace qpoa.InfoSpeech
{
    public partial class WbSendMail_fs : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string EmailAdd, EmailUserName, EmailPassword, Smtp;
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

                number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
                BindAttribute();


                string SQL_xl = "select * from qp_Emailprv  where Id='" + int.Parse(Request.QueryString["id"]) + "' and username='" + Session["Username"].ToString() + "'";
                SqlDataReader MyReader_xl = List.GetList(SQL_xl);
                if (MyReader_xl.Read())
                {

                    EmailAdd = MyReader_xl["EmailAdd"].ToString();
                    EmailUserName = MyReader_xl["EmailAdd"].ToString();
                    EmailPassword = MyReader_xl["EmailPassword"].ToString();
                    Smtp = MyReader_xl["Smtp"].ToString();

                }
                MyReader_xl.Close();


            }



        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return chknull();";

        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = "" + Smtp + "";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("" + EmailUserName + "", "" + EmailPassword + "");
            //星号改成自己邮箱的密码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage("" + EmailAdd + "", "" + EmailTo.Text+ "");
            message.Subject = "" + Subject.Text + "";
            message.Body = "" + ContractContent.Text + "";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;//优先级
            message.IsBodyHtml = true;
            //添加附件


            string strBaseLocation = Server.MapPath("sendfile/");
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
                //Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                Temp1 = fileName.Replace(rightName, "") + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名



                Attachment data = new Attachment("" + Server.MapPath(".") + "\\sendfile\\" + TruePath + "", System.Net.Mime.MediaTypeNames.Application.Octet);
                message.Attachments.Add(data);

                string sql_insert = "insert into qp_SendEmail (EmailFrom,EmailTo,Subject,Body,Newname,Oldname,username,realname,Settime) values('" + EmailAdd + "','" + EmailTo.Text + "','" + Subject.Text + "','" + List.GetFormatStrbjq(ContractContent.Text) + "','" + fileName + "','" + TruePath + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert);
            }
            else
            {
                string sql_insert1 = "insert into qp_SendEmail (EmailFrom,EmailTo,Subject,Body,Newname,Oldname,username,realname,Settime) values('" + EmailAdd + "','" + EmailTo.Text + "','" + Subject.Text + "','" + List.GetFormatStrbjq(ContractContent.Text) + "','无附件','无附件','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert1);
            }
         
          

            try
            {
              

                client.Send(message);
                //Response.Write("Email successfully send1111.");
                this.Response.Write("<script language=javascript>alert('发送成功！');window.location.href='WbSendMailList.aspx?id=" + int.Parse(Request.QueryString["id"]) + "'</script>");  


            }
            catch 
           //catch (Exception ex)
            {
               //Response.Write("Send Email Failed." + ex.ToString());
                this.Response.Write("<script language=javascript>alert('发送失败！错误原因可能有：\\n1) 服务器繁忙，稍后再试\\n2) 用户名或密码错误\\n3) 网络连接失败\\n4) 邮件服务器站点工作不正常\\n5) 邮件服务器参数设置有误\\n6) 超时连接\\n如果长时间不能发送请联系管理员或登陆外部邮箱发送');window.location.href='WbSendMailList.aspx?id=" + int.Parse(Request.QueryString["id"]) + "'</script>");  
            } 
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = "smtp.sohu.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("qp19830612", "666666");
            //星号改成自己邮箱的密码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage("qp19830612@sohu.com", "qpsmartweb@126.com");
            message.Subject = "你好，查收";
            message.Body = "你好，查收附件！";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;//优先级
            message.IsBodyHtml = false;
           //添加附件

            string fileName = "222.xls";
            Attachment data = new Attachment("" + Server.MapPath(".") + "\\sendfile\\" + fileName + "", System.Net.Mime.MediaTypeNames.Application.Octet);

            //Attachment data = new Attachment(@"f:\111.xls", System.Net.Mime.MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);
            try
            {
                client.Send(message);
                Response.Write("Email successfully send2222.");
            }
            catch (Exception ex)
            {
                Response.Write("Send Email Failed." + ex.ToString());
            } 
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = "smtp.sohu.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("qp19830612", "666666");
            //星号改成自己邮箱的密码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage("qp19830612@sohu.com", "qpsmartweb@126.com");
            message.Subject = "你好，查收";
            message.Body = "你好，查收附件！";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;//优先级
            message.IsBodyHtml = true;
            //添加附件


            string strBaseLocation = Server.MapPath("sendfile/");
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
                //Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                Temp1 = fileName.Replace(rightName, "") + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名


                //string fileName = "222.xls";
                Attachment data = new Attachment("" + Server.MapPath(".") + "\\sendfile\\" + TruePath + "", System.Net.Mime.MediaTypeNames.Application.Octet);
                message.Attachments.Add(data);
            }

           

            //Attachment data = new Attachment(@"f:\111.xls", System.Net.Mime.MediaTypeNames.Application.Octet);
       
            try
            {
                client.Send(message);
                Response.Write("Email successfully send1111.");
            }
            catch (Exception ex)
            {
                Response.Write("Send Email Failed." + ex.ToString());
            } 



        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            System.Net.Mail.SmtpClient client = new SmtpClient();
            client.Host = "smtp.sohu.com";
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("qp19830612", "666666");
            //星号改成自己邮箱的密码
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            System.Net.Mail.MailMessage message = new MailMessage("qp19830612@sohu.com", "qpsmartweb@126.com");
            message.Subject = "你好，查收";
            message.Body = "你好，查收附件！";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.Priority = MailPriority.High;//优先级
            message.IsBodyHtml = true;
         

            try
            {
                client.Send(message);
                Response.Write("Email successfully send2222.");
            }
            catch (Exception ex)
            {
                Response.Write("Send Email Failed." + ex.ToString());
            } 
        }

    }
}

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
using jmail;
using qpsmartweb.Public;
using System.Data.SqlClient;
namespace qpoa.InfoSpeech
{
    public partial class WbMailAccept : System.Web.UI.Page
    {
        Db List = new Db();
        public static string showbody, TxtPopServer1, TxtPopUser1, TxtPopPwd1, ServerEmail, EmailAdd;
        protected void Page_Load(object sender, EventArgs e)
        {
            string SQL_xl = "select * from qp_Emailprv  where Id='" + int.Parse(Request.QueryString["id"]) + "' and username='" + Session["Username"].ToString() + "'";
            SqlDataReader MyReader_xl = List.GetList(SQL_xl);
            if (MyReader_xl.Read())
            {
                TxtPopServer1 = MyReader_xl["Pop3"].ToString();
                TxtPopUser1 = MyReader_xl["EmailUserName"].ToString();
                TxtPopPwd1 = MyReader_xl["EmailPassword"].ToString();
                ServerEmail = MyReader_xl["ServerEmail"].ToString();
                EmailAdd = MyReader_xl["EmailAdd"].ToString();
            }
            MyReader_xl.Close();

            jmail.POP3Class popMail = new POP3Class();//建立收邮件对象
            jmail.Message mailMessage;  //建立邮件信息接口
            jmail.Attachments atts;//建立附件集接口
            jmail.Attachment att;//建立附件接口

            try
            {
                popMail.Connect(TxtPopUser1.Trim(), TxtPopPwd1.Trim(), TxtPopServer1.Trim(), Convert.ToInt32(110));

                if (0 < popMail.Count)                                                                          //如果收到邮件
                {
                    Random g1 = new Random();
                    string rad1 = g1.Next(10000).ToString();

                    string keyfile = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad1 + "";

                    for (int i = 1; i <= popMail.Count; i++)                                                         //根据取到的邮件数量依次取得每封邮件
                    {
                        mailMessage = popMail.Messages[i];                                                        //取得一条邮件信息
                        atts = mailMessage.Attachments;                                                           //取得该邮件的附件集合
                        mailMessage.Charset = "GB2312";                                                           //设置邮件的编码方式
                        mailMessage.Encoding = "Base64";                                                          //设置邮件的附件编码方式
                        mailMessage.ISOEncodeHeaders = false;                                                     //是否将信头编码成iso-8859-1字符集
                        //						txtpriority.Text = mailMessage.Priority.ToString();                                       //邮件的优先级                 
                        //						txtSendMail.Text = mailMessage.From;                                                      //邮件的发送人的信箱地址
                        //						txtSender.Text = mailMessage.FromName;                                                    //邮件的发送人
                        //						txtSubject.Text = mailMessage.Subject;                                                    //邮件主题
                        //						txtBody.Text = mailMessage.Body;														 //邮件内容
                        //						sendtime.Text=mailMessage.Date.ToString();
                        //						showbody= mailMessage.Body;		
                        //						txtSize.Text = mailMessage.Size.ToString();                                               //邮件大小

                        for (int j = 0; j < atts.Count; j++)
                        {
                            att = atts[j];                                                                        //取得附件
                            string attname = att.Name;															  //附件名称




                            Random g = new Random();
                            string rad = g.Next(10000).ToString();

                            string attnamenew = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";


                            string result = attnamenew + attname.Remove(0, attname.LastIndexOf("."));           //得到附件新名称


                            att.SaveToFile("" + Server.MapPath(".") + "\\attFile\\" + result);              //上传到服务器





                            //							string SQL_fj = "select * from MailFile  where MailName='"+popMail.Messages[i].Subject+"' and txtSize='"+popMail.Messages[i].Size.ToString()+"'";
                            //							//Response.Write(SQL_fj);
                            //							SqlDataReader MyReader_fj  = List.GetList(SQL_fj);
                            //							if (MyReader_fj.Read())
                            //							{
                            ////Response.Write("abc");
                            //
                            //							}
                            //							else
                            //							{
                            string sql_insert_file = "insert into qp_MailFile (MailName,sendtime,txtSize,NewName,OldName,keyfile) values('" + popMail.Messages[i].Subject + "','" + popMail.Messages[i].Date.ToString() + "','" + popMail.Messages[i].Size.ToString() + "','" + result + "','" + attname + "','" + keyfile + "')";
                            List.ExeSql(sql_insert_file);//将附件信息保存进数据库
                            //							}








                        }

                        string SQL_bl = "select * from qp_Mail  where txtSendMail='" + popMail.Messages[i].From + "' and txtpriority='" + popMail.Messages[i].Priority.ToString() + "' and txtSize='" + popMail.Messages[i].Size.ToString() + "'";
                        SqlDataReader MyReader_bl = List.GetList(SQL_bl);
                        if (MyReader_bl.Read())
                        {


                        }
                        else
                        {
                            string sql_insert = "insert into qp_Mail (txtSender,txtSendMail,txtSubject,txtpriority,txtSize,sendtime,txtBody,TxtPopUser,username,realname,EmailAdd,keyfile) values('" + popMail.Messages[i].FromName + "','" + popMail.Messages[i].From + "','" + popMail.Messages[i].Subject + "','" + popMail.Messages[i].Priority.ToString() + "','" + popMail.Messages[i].Size.ToString() + "','" + popMail.Messages[i].Date.ToString() + "','" + popMail.Messages[i].Body + "','" + TxtPopUser1 + "','" + Session["username"] + "','" + Session["realname"] + "','" + EmailAdd + "','" + keyfile + "')";
                            List.ExeSql(sql_insert);//将邮件信息保存进数据库
                            //TextBox1.Text+=sql_insert;
                        }

                        MyReader_bl.Close();



                    }
                    //panMailInfo.Visible = true;
                    att = null;
                    atts = null;
                }
                else
                {
                    Response.Write("没有新邮件!");
                }

                if (ServerEmail == "否")
                {
                    popMail.DeleteMessages();
                }
                popMail.Disconnect();
                popMail = null;
            }
            catch (Exception err)
            {

                Response.Write(err.Message.ToString());
            }
            //catch
            //{
            //    this.Response.Write("<script language=javascript>alert('发送失败！错误原因可能有：\\n1) 用户名或密码错误\\n2) 网络连接失败\\n3) 邮件服务器站点工作不正常\\n4) 邮件服务器参数设置有误\\n5) 超时连接\\n请联系管理员');window.location.href='AcceptEmail.aspx'</script>");
            //}



           Response.Redirect("WbMailAcceptList.aspx?Id=" + int.Parse(Request.QueryString["id"]) + "");
        }
    }
}

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
    public partial class DocumentModle_add : System.Web.UI.Page
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
                BindAttribute();
            }



        }
        public void BindAttribute()
        {
            QxRealname.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return checkForm();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DocumentModle.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("DocumentModle/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);

     

                //if (List.StrIFInStr(rightName, "|.doc|") == true)
                //{
                    Random g = new Random();
                    string rad = g.Next(10000).ToString();
                    Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                    uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                    TruePath = Temp1 + rightName;  //获得随即文件名


                    string sql_insert = "insert into qp_DocumentModle (Name,Oldname,Newname,Type,QxUsername,QxRealname) values ('" + List.GetFormatStr(Name.Text) + "','" + fileName + "','" + TruePath + "','" + rightName + "','" + QxUsername.Text + "','" + QxRealname.Text + "')";
                    List.ExeSql(sql_insert);
                    InsertLog("新增红头文件[" + Name.Text + "]", "红头文件管理");
                    this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DocumentModle.aspx'</script>");

                //}
                
                //else
                //{
                //    this.Response.Write("<script language=javascript>alert('禁止上传此格式文件！');</script>");
                //}

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

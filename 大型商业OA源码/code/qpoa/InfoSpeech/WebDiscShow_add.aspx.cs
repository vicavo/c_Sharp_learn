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
    public partial class WebDiscShow_add : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;
        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }
            string sql_down_bh = "select id,Linew+name as aaa  from qp_WebDisc order by QxString asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(Folder, sql_down_bh, "id", "aaa");
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


                Folder.SelectedValue = Request.QueryString["id"].ToString();


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
            Response.Redirect("WebDisc_show.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {



            //上传文件
            string strBaseLocation = Server.MapPath("WebDisc/");
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

                string sql_insert_file = "insert into qp_WebDiscFile   (OldName,NewName,PxNum,FoldersName,FoldersID,Username,Realname) values ('" + fileName + "','" + TruePath + "','" + PxNum.Text + "','" + Folder.SelectedItem.Text + "','" + Folder.SelectedValue + "','" + Session["username"] + "','" + Session["Realname"] + "')";
                List.ExeSql(sql_insert_file);

                InsertLog("新增网络硬盘[" + fileName + "]", "网络硬盘");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WebDisc_show.aspx?id=" + Request.QueryString["id"] + "'</script>");


            }
            else
            {
                this.Response.Write("<script language=javascript>alert('请勿上传空文件！');</script>");
                return;
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

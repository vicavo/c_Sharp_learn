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
namespace qpoa.KmManage
{
    public partial class KmTitle_show_add_zj_manage_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string KmTitle, fjkey;
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



                string SQL_GetList = "select * from qp_KmTitleList where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    KmTitle = NewReader["KmTitle"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    d_content.Value = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }

                NewReader.Close();







            }

            BindList();

        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return chknull();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }
        public void BindList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_KmTitleListFj where KeyField='" + Number.Text + "' order by id desc";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_KmTitleList  Set  Name='" + List.GetFormatStr(Name.Text) + "',Content='" + List.GetFormatStrbjq(d_content.Value) + "' where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);


            InsertLog("修改知识章节[" + Name.Text + "]", "我的知识");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='KmTitle_show_add_zj_manage.aspx?Number=" + Request.QueryString["Number"] + "';window.close();</script>");
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
            string strBaseLocation = Server.MapPath("KmTitleListFj/");
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

                string sql_insert_file = "insert into qp_KmTitleListFj    (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传章节附件[" + fileName + "]", "我的知识");
                BindList();
            }
        }



    }
}

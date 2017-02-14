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
    public partial class Paper_update : System.Web.UI.Page
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


            string sql_down_bh = "select id,Linew+name as aaa  from qp_Folders  where username='" + Session["username"] + "' order by QxString asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(Folder, sql_down_bh, "id", "aaa");
            }

            if (!IsPostBack)
            {

                string SQL_GetList = "select * from qp_Paper where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and Username='"+Session["username"]+"'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    PxNum.Text = NewReader["PxNum"].ToString();
                    Folder.SelectedValue = NewReader["FoldersID"].ToString();

                    ContractContentupdate.Text = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }
                NewReader.Close();


             
            }

            BindDroList();
        }
        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_PaperFj where KeyField='" + Number.Text + "'";


            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void BindAttribute()
        {
          



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Folders_show.aspx?id=" + Request.QueryString["keyid"] + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Sql_update1 = "Update qp_Paper     Set Number='" + Number.Text + "',Name='" + Name.Text + "',PxNum='" + PxNum.Text + "',Content='" + List.GetFormatStrbjq(ContractContent.Text) + "',FoldersName='" + Folder.SelectedItem.Text.Replace("|", "").Replace("-", "") + "',FoldersID='" + Folder.SelectedValue + "' where id='" + int.Parse(Request.QueryString["id"]) + "' and username='"+Session["username"]+"'";
            List.ExeSql(Sql_update1);


            InsertLog("修改个人文件[" + Name.Text + "]", "个人文件柜");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Folders_show.aspx?id=" + Request.QueryString["keyid"] + "'</script>");


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
            string strBaseLocation = Server.MapPath("PaperFj/");
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


                string sql_insert_file = "insert into qp_PaperFj   (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传个人文件[" + fileName + "]", "个人文件柜");
                BindDroList();
            }
        }





    }
}

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
namespace qpoa.PublicAffairs
{
    public partial class NetMetting_Hyjy : System.Web.UI.Page
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



                string SQL_GetList = "select * from qp_NetMetting where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    JyUsername.Text = NewReader["JyUsername"].ToString();
                    JyRealname.Text = NewReader["JyRealname"].ToString();
                    d_content.Value = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                }
                NewReader.Close();


                BindAttribute();
            }




            BindDroList();
        }
        public void BindDroList()
        {
            ////附件列表
            //string sql_down_1 = "select * from qp_NetMettingFj where KeyField='" + int.Parse(Request.QueryString["id"]) + "'";


            //list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
            JyRealname.Attributes.Add("readonly", "readonly");



            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return showwait();";



            //Button4.Attributes["onclick"] = "javascript:return checkForm();";
            //Button3.Attributes["onclick"] = "javascript:return delfj();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("NetMettingJx.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_NetMetting    Set JyUsername='" + JyUsername.Text + "',JyRealname='" + JyRealname.Text + "',Content='" + List.GetFormatStrbjq(d_content.Value) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);

            InsertLog("修改会议纪要[" + Name.Text + "]", "网络会议");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NetMettingJx.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

     




    }
}

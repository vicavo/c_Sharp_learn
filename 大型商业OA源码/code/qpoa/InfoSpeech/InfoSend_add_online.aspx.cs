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
    public partial class InfoSend_add_online : System.Web.UI.Page
    {
        Db List = new Db();
        public static string updatefilname, realname;
        public static string forname, forfile, number;
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            realname = this.Session["realname"].ToString();
            this.Button1.Attributes.Add("onclick", "javascript: SaveToWeb();");

            if (!IsPostBack)
            {
                forfile = Request.QueryString["file"].ToString();
                number = Request.QueryString["number"].ToString();
                string SQL_GetList = "select * from qp_InfoSendFj  where Newname='" + Request.QueryString["file"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    forname = NewReader["Name"].ToString();
                }
                NewReader.Close();

                //Response.Write(Request.QueryString["filetype"].ToString());
                if (Request.QueryString["filetype"].ToString() == ".doc" || Request.QueryString["filetype"].ToString() == ".DOC")
                {

                    Button6.Visible = true;
                    Button7.Visible = true;
                    Button8.Visible = true;
                    Button9.Visible = true;

                }

                if (Request.QueryString["filetype"].ToString() == ".xls" || Request.QueryString["filetype"].ToString() == ".XLS")
                {

                    Button6.Visible = false;
                    Button7.Visible = false;
                    Button8.Visible = false;
                    Button9.Visible = false;

                }


                if (Request.QueryString["filetype"].ToString() == ".ppt" || Request.QueryString["filetype"].ToString() == ".PPT")
                {

                    Button6.Visible = true;
                    Button7.Visible = false;
                    Button8.Visible = false;
                    Button9.Visible = false;

                }



            }


            string fileName = System.IO.Path.GetFileName(Request.QueryString["file"].ToString());
            //获得扩展名
            updatefilname = System.IO.Path.GetExtension(fileName);



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }
    }
}

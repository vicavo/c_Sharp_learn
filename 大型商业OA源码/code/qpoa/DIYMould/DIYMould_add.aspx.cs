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
namespace qpoa.DIYMould
{
    public partial class DIYMould_add : System.Web.UI.Page
    {
        Db List = new Db();
        public static int PaixunAdd;
        BindDrowDownList list = new BindDrowDownList();
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
                BindDroList();

                string SQL_GetList = "select * from qp_DIYMould where username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    LookMuch.Text = NewReader["LookMuch"].ToString();
                }
                else
                {
                    LookMuch.Text = "4";
                }
                NewReader.Close();
            }



        }
        public void BindAttribute()
        {
            LookMuch.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {

            string sql_down_bh = "select * from qp_DeskMould where  (CHARINDEX(''+QxStr+'','" + this.Session["perstr"] + "')   >   0 )  order by id asc";

            list.Bind_DropDownList_nothing(Name, sql_down_bh, "UrlMath", "Name");

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DIYMould.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select top 1 PaiXun from qp_DIYMould   order by paixun desc";

            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                PaixunAdd = int.Parse(NewReader["PaiXun"].ToString());
            }
            else
            {
                PaixunAdd = 0;
            }
            NewReader.Close();

            int PaixunAdd_1 = PaixunAdd + 1;





            string sql_insert = "insert into qp_DIYMould  (Name,UrlMath,PaiXun,Username,Realname,LookMuch) values ('" + Name.SelectedItem.Text + "','" + Name.SelectedValue + "','" + PaixunAdd_1 + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + LookMuch.Text + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增工作台模块[" + Name.Text + "]", "工作台模块");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DIYMould.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

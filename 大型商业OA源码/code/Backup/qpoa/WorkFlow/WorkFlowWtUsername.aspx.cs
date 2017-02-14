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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowWtUsername : System.Web.UI.Page
    {
        Db List = new Db();
        public static string Name;
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
                Name = Session["Realname"].ToString();
                string SQL_GetList = "select * from qp_WorkFlowWtUsername  where  username='" + Session["username"] + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    WtUsername.Text = NewReader["WtUsername"].ToString();
                    WtRealname.Text = NewReader["WtRealname"].ToString();
                    State.SelectedValue = NewReader["State"].ToString();

                }
                NewReader.Close();

            }



        }
        public void BindAttribute()
        {
            WtRealname.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("WorkFlowList.aspx");
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {



            string SQL_GetList2 = "select * from qp_WorkFlowWtUsername where  username='" + Session["username"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                string Sql_update = "Update qp_WorkFlowWtUsername  Set WtUsername='" + WtUsername.Text + "',WtRealname='" + WtRealname.Text + "',State='" + State.SelectedValue + "'   where  username='" + Session["username"] + "'";
                List.ExeSql(Sql_update);


            }
            else
            {


                string sql_inserta = "insert into qp_WorkFlowWtUsername (Username,Realname,WtUsername,WtRealname,State) values ('" + Session["username"] + "','" + Session["Realname"] + "','" + WtUsername.Text + "','" + WtRealname.Text + "','" + State.SelectedValue + "')";
                List.ExeSql(sql_inserta);




            }//保存委托数据
            NewReader2.Close();



            InsertLog("设置委托人员", "委托设置");

            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkFlowWtUsername.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

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
    public partial class WorkFlowName_show_add_node_tjsz_update : System.Web.UI.Page
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

            if (!IsPostBack)
            {

                string SQL_GetList = "select  *  from qp_FlowFormFile  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    FormId.Text = NewReader["FormId"].ToString();
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    FormName.Text = NewReader["FormName"].ToString();
                    FlowId.Text = NewReader["FlowId"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    FlowName.Text = NewReader["FlowName"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    Type.Text = NewReader["Type"].ToString();
                    Conditions.SelectedValue = NewReader["Conditions"].ToString();
                    JudgeBasis.Text = NewReader["JudgeBasis"].ToString();

                }
              
                NewReader.Close();


            }


        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
            Type.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_FlowFormFile    Set Number='" + Number.Text + "',Name='" + Name.Text + "',Type='" + List.GetFormatStr(Type.Text) + "',Conditions='" + Conditions.SelectedValue + "' ,JudgeBasis='" + List.GetFormatStr(JudgeBasis.Text) + "'   where id='" + int.Parse(Request.QueryString["id"]) + "' ";
            List.ExeSql(Sql_update);
           
            InsertLog("修改条件设置[" + Name.Text + "]", "工作流设置");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

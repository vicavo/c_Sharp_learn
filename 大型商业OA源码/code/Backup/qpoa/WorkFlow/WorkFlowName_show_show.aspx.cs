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
    public partial class WorkFlowName_show_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {

                BindDroList();
                BindAttribute();




            }
            if (!IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkFlowName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    FormName.Text = NewReader["FormName"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    FlowType.Text = NewReader["FlowType"].ToString();
                    FlowName.Text = NewReader["FlowName"].ToString();
                    JkUsername.Text = NewReader["JkUsername"].ToString();
                    JkRealname.Text = NewReader["JkRealname"].ToString();
                    FlowUnitId.Text = NewReader["FlowUnitId"].ToString();
                    FlowUnitName.Text = NewReader["FlowUnitName"].ToString();
                    OverSetCon.Text = NewReader["OverSetConName"].ToString();


                    Wenhao.Text = NewReader["Wenhao"].ToString();
                    BianhaoJs.Text = NewReader["BianhaoJs"].ToString();
                    BianhaoWs.Text = NewReader["BianhaoWs"].ToString();
                    xgwenhao.Text = NewReader["xgwenhao"].ToString();
                }
                NewReader.Close();


            }


        }
        public void BindDroList()
        {
            //附件列表
            //string sql_down_bh = "select id,FormName  from qp_DIYForm order by id desc";
            //list.Bind_DropDownList_nothing(FormName, sql_down_bh, "id", "FormName");



            //string sql_down1 = "select id,Linew+name as aaa  from qp_WorkFlowNodeGD  order by QxString asc";

            //if (!IsPostBack)
            //{
            //    list.Bind_DropDownList_gd(OverSetCon, sql_down1, "id", "aaa");
            //}

        }
        public void BindAttribute()
        {
          

           
         
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }









    }
}

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
    public partial class WorkFlowName_show_update : System.Web.UI.Page
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
                    FormName.SelectedValue = NewReader["FormId"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    FlowType.SelectedValue = NewReader["FlowType"].ToString();
                    FlowName.Text = NewReader["FlowName"].ToString();
                    JkUsername.Text = NewReader["JkUsername"].ToString();
                    JkRealname.Text = NewReader["JkRealname"].ToString();
                    FlowUnitId.Text = NewReader["FlowUnitId"].ToString();
                    FlowUnitName.Text = NewReader["FlowUnitName"].ToString();
                    OverSetCon.SelectedValue = NewReader["OverSetConId"].ToString();

                    Wenhao.Text = NewReader["Wenhao"].ToString();
                    BianhaoJs.Text = NewReader["BianhaoJs"].ToString();
                    BianhaoWs.Text = NewReader["BianhaoWs"].ToString();
                    xgwenhao.SelectedValue = NewReader["xgwenhao"].ToString();
                }
                NewReader.Close();


            }


        }
        public void BindDroList()
        {
            //附件列表
            string sql_down_bh = "select id,FormName  from qp_DIYForm order by id desc";
            list.Bind_DropDownList_nothing(FormName, sql_down_bh, "id", "FormName");



            string sql_down1 = "select id,Linew+name as aaa  from qp_WorkFlowNodeGD  order by QxString asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_gd(OverSetCon, sql_down1, "id", "aaa");
            }

        }
        public void BindAttribute()
        {
            JkRealname.Attributes.Add("readonly", "readonly");
            FlowUnitName.Attributes.Add("readonly", "readonly");

            Button1.Attributes["onclick"] = "javascript:return chknull();";
           // Button4.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update = "Update qp_WorkFlowName    Set Wenhao='" + Wenhao.Text + "',BianhaoJs='" + BianhaoJs.Text + "',BianhaoWs='" + BianhaoWs.Text + "',xgwenhao='" + xgwenhao.SelectedValue + "',FlowType='" + FlowType.SelectedValue + "',FlowName='" + FlowName.Text + "',JkUsername='" + List.GetFormatStr(JkUsername.Text) + "',JkRealname='" + List.GetFormatStr(JkRealname.Text) + "',FlowUnitId='" + List.GetFormatStr(FlowUnitId.Text) + "',FlowUnitName='" + List.GetFormatStr(FlowUnitName.Text) + "',OverSetConId='" + List.GetFormatStr(OverSetCon.SelectedValue) + "',OverSetConName='" + List.GetFormatStr(OverSetCon.SelectedItem.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "' ";
            List.ExeSql(Sql_update);

            string Sql_update1 = "Update qp_AddWorkFlow  Set JkUsername='" + List.GetFormatStr(JkUsername.Text) + "',JkRealname='" + List.GetFormatStr(JkRealname.Text) + "'  where FlowId='" + int.Parse(Request.QueryString["id"]) + "'  ";
            List.ExeSql(Sql_update1);


            InsertLog("修改流程名称[" + FlowName.Text + "]", "流程设置");
            //this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='WorkFlowName_show.aspx?FormId=" + Request.QueryString["id"] + "';window.close();</script>");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    string sql_insert = "insert into qp_WorkFlowName    (FormId,FormNumber,FormName,FlowNumber,FlowName,JkUsername,JkRealname,FlowUnitId,FlowUnitName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,OverSetConId,OverSetConName) values ('" + FormName.SelectedValue + "','" + FormNumber.Text + "','" + FormName.SelectedItem.Text + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + FlowUnitId.Text + "','" + FlowUnitName.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "')";
        //    List.ExeSql(sql_insert);
        //    InsertLog("新增流程名称[" + FlowName.Text + "]", "流程设置");

        //    Response.Redirect("WorkFlowName_show_add_node.aspx?FlowNumber=" + FlowNumber.Text + "");
        //}







    }
}

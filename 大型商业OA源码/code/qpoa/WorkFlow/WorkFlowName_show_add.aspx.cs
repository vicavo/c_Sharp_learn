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
    public partial class WorkFlowName_show_add : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_DIYForm where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    FormNumber.Text = NewReader["Number"].ToString();
                    FormName.SelectedValue = Request.QueryString["id"].ToString();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('未找到对应表单，请选择左边的表单，再点新建工作流！');window.close();</script>");
                    return;
                }
                NewReader.Close();

              
            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                FlowNumber.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
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
            Button4.Attributes["onclick"] = "javascript:return chknull();";
        }


 

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string sql_insert = "insert into qp_WorkFlowName    (FlowType,FormId,FormNumber,FormName,FlowNumber,FlowName,JkUsername,JkRealname,FlowUnitId,FlowUnitName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes) values ('" + FlowType .SelectedValue+ "','" + FormName.SelectedValue + "','" + FormNumber.Text + "','" + FormName.SelectedItem.Text + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + FlowUnitId.Text + "','" + FlowUnitName.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "')";
            string sql_insert = "insert into qp_WorkFlowName    (FlowType,FormId,FormNumber,FormName,FlowNumber,FlowName,JkUsername,JkRealname,FlowUnitId,FlowUnitName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,OverSetConId,OverSetConName,Wenhao,BianhaoJs,BianhaoWs,xgwenhao) values ('" + FlowType.SelectedValue + "','" + FormName.SelectedValue + "','" + FormNumber.Text + "','" + FormName.SelectedItem.Text + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + FlowUnitId.Text + "','" + FlowUnitName.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "','" + Wenhao.Text + "','" + BianhaoJs.Text + "','" + BianhaoWs.Text + "','" + xgwenhao.SelectedValue + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增流程名称[" + FlowName.Text + "]", "流程设置");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='WorkFlowName_show.aspx?FormId=" + Request.QueryString["id"] + "';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_WorkFlowName    (FlowType,FormId,FormNumber,FormName,FlowNumber,FlowName,JkUsername,JkRealname,FlowUnitId,FlowUnitName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,OverSetConId,OverSetConName,Wenhao,BianhaoJs,BianhaoWs,xgwenhao) values ('" + FlowType.SelectedValue + "','" + FormName.SelectedValue + "','" + FormNumber.Text + "','" + FormName.SelectedItem.Text + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + FlowUnitId.Text + "','" + FlowUnitName.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "','" + Wenhao.Text + "','" + BianhaoJs.Text + "','" + BianhaoWs.Text + "','" + xgwenhao.SelectedValue + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增流程名称[" + FlowName.Text + "]", "流程设置");

            Response.Redirect("WorkFlowName_show_add_node.aspx?FlowNumber=" + FlowNumber.Text + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_WorkFlowName    (FlowType,FormId,FormNumber,FormName,FlowNumber,FlowName,JkUsername,JkRealname,FlowUnitId,FlowUnitName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,OverSetConId,OverSetConName,Wenhao,BianhaoJs,BianhaoWs,xgwenhao) values ('" + FlowType.SelectedValue + "','" + FormName.SelectedValue + "','" + FormNumber.Text + "','" + FormName.SelectedItem.Text + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(JkUsername.Text) + "','" + List.GetFormatStr(JkRealname.Text) + "','" + FlowUnitId.Text + "','" + FlowUnitName.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "','" + Wenhao.Text + "','" + BianhaoJs.Text + "','" + BianhaoWs.Text + "','" + xgwenhao.SelectedValue + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增流程名称[" + FlowName.Text + "]", "流程设置");

            Response.Redirect("WorkFlowName_show_copy.aspx?FlowNumber=" + FlowNumber.Text + "&FormId=" + Request.QueryString["id"] + "");
        }







    }
}

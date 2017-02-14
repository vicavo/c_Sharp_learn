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
namespace qpoa.SystemManage
{
    public partial class UnitName_show : System.Web.UI.Page
    {
        Db List = new Db();
        public static string showtitle;
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
               
                string SQL_GetList = "select * from qp_UnitName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    showtitle="部门信息";
                    Name.Text = NewReader["name"].ToString();
                    remark.Text = List.TbToLb(NewReader["remark"].ToString());
                    KeyQx.Text = NewReader["KeyQx"].ToString();
                    InsertLog("查看部门[" + Name.Text + "]", "部门管理");
                    Button3.Visible = true;
                    Button1.Visible = true;
                    Button2.Visible = true;

                }
                else
                {
                    showtitle = "<font color=red>无部门信息，请点击左边树型菜单或点击［<a href=UnitName_add.aspx>增加</a>］</font>";
                    Button3.Visible=false;
                    Button1.Visible = false;
                    Button2.Visible = false;

                }
                NewReader.Close();
               
                Bindquanxian();

            }



        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return deltree();";
           
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(Button3, "iiii6d", Session["perstr"].ToString());
            List.QuanXianVis(Button1, "iiii6e", Session["perstr"].ToString());
            List.QuanXianVis(Button2, "iiii6b", Session["perstr"].ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnitName_add.aspx?id=" + List.GetFormatStr(Request.QueryString["id"]) + "");
        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnitName_update.aspx?id=" + List.GetFormatStr(Request.QueryString["id"]) + "");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_GetList_check = "select * from qp_username  where   UnitId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";

            SqlDataReader NewReader = List.GetList(SQL_GetList_check);
            if (NewReader.Read())
            {
                this.Response.Write("<script language=javascript>alert('删除失败，其中存在正在使用的部门，请在用户管理中查看！');</script>");
                return;

            }

            NewReader.Close();

            DelNode(Request.QueryString["id"], Request.QueryString["id"]);

            //string SQL_Del = "Delete from qp_UnitName where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";

            //List.ExeSql(SQL_Del);

            //string SQL_DelP = "Delete from qp_UnitName where ParentNodesID='" + List.GetFormatStr(Request.QueryString["id"]) + "'";

            //List.ExeSql(SQL_DelP);

            this.Response.Write("<script language=javascript>alert('删除成功！'); window.parent.location = 'UnitName.aspx'</script>");

        }

        private void DelNode(string IDStr, string PID)
        {
            string SqlStr = "  Delete from qp_UnitName  where id='" + IDStr + "'";
            List.ExeSql(SqlStr);//删除最根节点

            string SQL_GetList = "select * from qp_UnitName where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                string SqlStr1 = "  Delete from qp_UnitName  where id='" + MyReader["ID"].ToString() + "'";
                List.ExeSql(SqlStr1);
                string SQL_GetList1 = "select * from qp_UnitName where ParentNodesID=" + MyReader["id"] + " ";
                SqlDataReader MyReader1 = List.GetList(SQL_GetList1);
                if (MyReader1.Read())
                {

                    string IDStr1 = MyReader["ID"].ToString();
                    string PID1 = MyReader["ParentNodesID"].ToString();
                    DelNode(IDStr1, PID1);

                }
                MyReader1.Close();

            }
            MyReader.Close();

        }



    }
}

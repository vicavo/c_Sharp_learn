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
namespace qpoa.SaleManage
{
    public partial class CustomerMoveXsz : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            string sql_down_bh = "select id,GroupName  from qp_SaleGroup order by id asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "GroupName");
            }

            Realname.Attributes.Add("readonly", "readonly");
            List.QuanXianVis(Button2, "ffff1d", Session["perstr"].ToString());
            Button2.Attributes["onclick"] = "javascript:return RyMove();";

        }









        protected void Button2_Click(object sender, EventArgs e)
        {
            //string Sql_update_jw = "Update qp_Customer   Set Username='" + List.GetFormatStr(Username.Text) + "',Realname='" + Realname.Text + "' where Username='" + OldUsername.Text + "'";
            //List.ExeSql(Sql_update_jw);
            string SqlStr = "update qp_Customer set Realname='" + Realname.Text + "',Username='" + Username.Text + "',Unit='" + Unit.Text + "',UnitId='" + UnitId.Text + "',QxString='" + QxString.Text + "',Respon='" + Respon.Text + "',ResponId='" + ResponId.Text + "',GroupId=(select top 1  id from qp_SaleGroup where   CHARINDEX('," + Username.Text + ",',','+GroupUsername+',')   >   0),GroupName=(select  top 1  GroupName from qp_SaleGroup where   CHARINDEX('," + Username.Text + ",',','+GroupUsername+',')   >   0 ) where GroupId='" + UnitName.SelectedValue + "'";
            List.ExeSql(SqlStr);
            //Response.Write(SqlStr);
            this.Response.Write("<script language=javascript>alert('转移成功！');</script>");
        }
    }
}

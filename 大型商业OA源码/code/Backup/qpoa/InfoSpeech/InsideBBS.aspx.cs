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
    public partial class InsideBBS : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;

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
                DataBindToGridview("order by id desc");
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(GridView1, "dd4dd4b1", Session["perstr"].ToString());
        }
        public void BindAttribute()
        {
         
        }
        public void DataBindToGridview(string Sqlsort)
        {
            string SQL_GetList_xs = "select * from qp_InsideBBSBig where (CHARINDEX('," + this.Session["UnitId"] + ",',','+UnitId+',')   >   0 ) and  State='正常' " + Sqlsort + "";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
        }


        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType itemType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            }


            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ln1 = (Label)e.Row.FindControl("Lid1");
                Label ln2 = (Label)e.Row.FindControl("Lid2");

                Label ll1 = (Label)e.Row.FindControl("Label1");
                Label ll2 = (Label)e.Row.FindControl("Label2");

                ll1.Text = null; ll2.Text = null;

                string ll1_count = "select count(id) from qp_InsideBBS where  BigId='" + ln1.Text + "' and ParentNodesID='0'";
                ll1.Text = "" + List.GetCount(ll1_count) + "";

                string ll2_count = "select count(id) from qp_InsideBBS where  BigId='" + ln1.Text + "' and ParentNodesID!='0'";
                ll2.Text = "" + List.GetCount(ll2_count) + "";

            }
        }
     
        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        public override void VerifyRenderingInServerForm(Control control)
        { }


    }
}

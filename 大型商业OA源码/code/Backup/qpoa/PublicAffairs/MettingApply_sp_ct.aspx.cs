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
namespace qpoa.PublicAffairs
{
    public partial class MettingApply_sp_ct : System.Web.UI.Page
    {
        Db List = new Db();
        public static string type, typename;
        protected void Page_Load(object sender, EventArgs e)
        {
  
          
            DataBindToGridview("");
        }

        public void DataBindToGridview(string str)
        {
            string SQL_yz = "select  * from qp_MettingApply where id='" + Request.QueryString["id"] + "'  ";


            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            if (NewReader_yz.Read())
            {
               // string SQL_mx = "select  * from qp_MettingApply where id!='" + Request.QueryString["id"] + "' and (State!='已结束' and State!='未通过' ) and  ((Starttime between '" + NewReader_yz["Starttime"] + "'and  '" + NewReader_yz["Endtime"] + "' or convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + NewReader_yz["Starttime"] + "' as datetime),120) or convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + NewReader_yz["Endtime"] + "' as datetime),120)) or (Endtime between '" + NewReader_yz["Starttime"] + "'and  '" + NewReader_yz["Endtime"] + "' or convert(char(10),cast(Endtime as datetime),120)=convert(char(10),cast('" + NewReader_yz["Starttime"] + "' as datetime),120) or convert(char(10),cast(Endtime as datetime),120)=convert(char(10),cast('" + NewReader_yz["Endtime"] + "' as datetime),120))  )";
                string SQL_mx = "select  * from qp_MettingApply where id!='" + Request.QueryString["id"] + "' and (State!='已结束' and State!='未通过' ) and  (MettingId='" + NewReader_yz["MettingId"] + "')  and   ((Starttime >= '" + NewReader_yz["Starttime"] + "' and Endtime < '" + NewReader_yz["Endtime"] + "') or (Endtime > '" + NewReader_yz["Starttime"] + "' and Starttime <= '" + NewReader_yz["Endtime"] + "'))";
                GridView1.DataSource = List.GetGrid_Pages_not(SQL_mx);
                GridView1.DataBind();
            }

            NewReader_yz.Close();


        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            //  DataBindToGridview("");
            this.GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            DataBindToGridview("");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType itemType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            }
        }
    }
}

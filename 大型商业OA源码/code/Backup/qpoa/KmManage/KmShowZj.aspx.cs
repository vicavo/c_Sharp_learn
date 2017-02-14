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
namespace qpoa.KmManage
{
    public partial class KmShowZj : System.Web.UI.Page
    {

        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, Namefile;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_KmTitle   where  Number='" + Request.QueryString["KmNumber"] + "' ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Namefile = NewReader["Title"].ToString();
                }

                NewReader.Close();
           
                DataBindToGridview("order by id desc");

            }


        }

        public void DataBindToGridview(string Sqlsort)
        {
            string SQL_GetList_xs = "select * from qp_KmTitleList where  KmNumber='" + Request.QueryString["KmNumber"] + "' " + Sqlsort + " ";
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
                Label ln = (Label)e.Row.FindControl("WFNId");
                Label ll1 = (Label)e.Row.FindControl("Label1");
                ll1.Text = " <a href=\"javascript:void(0)\" onclick=\"showfrom(" + ln.Text + ");\">查看</a>";
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmShow.aspx?id=" + Request.QueryString["backid"] + "");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            int ID = 0;
            string SQL_GetListId = "select * from qp_KmTitle   where  Number='" + Request.QueryString["KmNumber"] + "' ";
            SqlDataReader NewReaderId = List.GetList(SQL_GetListId);
            if (NewReaderId.Read())
            {
                ID = int.Parse(NewReaderId["id"].ToString());
            }

            NewReaderId.Close();



            string SQL_GetCount = "select count(KmId) from  qp_KmTjNum where  Username='" + Session["username"] + "' and convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + System.DateTime.Now.ToShortDateString() + "' as datetime),120) ";
            string CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            if (int.Parse(CountsLabel) >= 3)
            {
                this.Response.Write("<script language=javascript>alert('你今天３次推荐票已使用完，请明天再行推荐');</script>");
                return;
            }


            string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+TjUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1  where id='" + ID + "'";
                List.ExeSql(Sql_update);

                this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
            }

            else
            {
                string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1 ,TjUsername=TjUsername+'" + Session["username"] + ",',TjRealname=TjRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                List.ExeSql(Sql_update);

                this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
            }


            string sql_insert = "insert into qp_KmTjNum (KmId,Username,Realname,Settime) values ('" + ID + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            NewReader.Close();
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            int ID = 0;
            string SQL_GetListId = "select * from qp_KmTitle   where  Number='" + Request.QueryString["KmNumber"] + "' ";
            SqlDataReader NewReaderId = List.GetList(SQL_GetListId);
            if (NewReaderId.Read())
            {
                ID = int.Parse(NewReaderId["id"].ToString());
            }

            NewReaderId.Close();


            string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+DyUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                this.Response.Write("<script language=javascript>alert('已订阅！');</script>");
                return;
            }
            else
            {
                string Sql_update = "Update qp_KmTitle  Set DyNum=DyNum+1 ,DyUsername=DyUsername+'" + Session["username"] + ",',DyRealname=DyRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                List.ExeSql(Sql_update);

                this.Response.Write("<script language=javascript>alert('订阅成功！');</script>");
            }
            NewReader.Close();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            int ID = 0;
            string SQL_GetListId = "select * from qp_KmTitle   where  Number='" + Request.QueryString["KmNumber"] + "' ";
            SqlDataReader NewReaderId = List.GetList(SQL_GetListId);
            if (NewReaderId.Read())
            {
                ID = int.Parse(NewReaderId["id"].ToString());
            }

            NewReaderId.Close();

            string SQL_GetList = "select * from qp_KmTitle where id='" + ID + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+ScUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                this.Response.Write("<script language=javascript>alert('已收藏！');</script>");
                return;
            }
            else
            {
                string Sql_update = "Update qp_KmTitle  Set ScNum=ScNum+1 ,ScUsername=ScUsername+'" + Session["username"] + ",',ScRealname=ScRealname+'" + Session["realname"] + ",'  where id='" + ID + "'";
                List.ExeSql(Sql_update);

                this.Response.Write("<script language=javascript>alert('收藏成功！');</script>");

            }
            NewReader.Close();
        }

      

     

      







    }
}

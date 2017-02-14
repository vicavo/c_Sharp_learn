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
namespace qpoa
{
    public partial class KmTitlePh : System.Web.UI.Page
    {
        Db List = new Db();
        public static string  SqlStrCount;
     
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
         
            List.QuanXianVis(GridView1, "jjjj4", Session["perstr"].ToString());
        }

        public void BindAttribute()
        {
        }
        public void DataBindToGridview(string Sqlsort)
        {


            string SQL_GetList_xs = "select top 20 * from qp_KmTitle  where State='正常' order by PointNum desc";
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

                LinkButton l1 = (LinkButton)e.Row.FindControl("TuiJian");
                LinkButton l2 = (LinkButton)e.Row.FindControl("DingYue");
                LinkButton l3 = (LinkButton)e.Row.FindControl("ShouCang");
                l1.Attributes.Add("onclick", "javascript:return confirm('确认推荐知识[" + e.Row.Cells[1].Text.ToString() + "]吗？每天只能推荐3次')");
                l2.Attributes.Add("onclick", "javascript:return confirm('确认订阅知识[" + e.Row.Cells[1].Text.ToString() + "]吗？')");
                l3.Attributes.Add("onclick", "javascript:return confirm('确认收藏知识[" + e.Row.Cells[1].Text.ToString() + "]吗？')");

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

       

      


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "TuiJian")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

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

                DataBindToGridview("order by id desc");

            }



            if (e.CommandName == "DingYue")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

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

                DataBindToGridview("order by id desc");
            }


            if (e.CommandName == "ShouCang")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

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

                DataBindToGridview("order by id desc");
            }



        }




    }
}

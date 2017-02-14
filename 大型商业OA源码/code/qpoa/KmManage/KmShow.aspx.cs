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
    public partial class KmShow : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey, LittleName, ShowTitle, Realname,KeyWord, Content, AthourSay, PointNum, ScNum, DyNum, TjNum, LastTime, Username, IfTj;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }



            if (!IsPostBack)
            {
                Title.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button3.click(); return false;}";

                string SQL_GetListGLY = "select * from qp_KmManger where  (CHARINDEX('," + this.Session["username"] + ",',','+Username+',') > 0 ) ";
                SqlDataReader NewReaderGLY = List.GetList(SQL_GetListGLY);
                if (!NewReaderGLY.Read())
                {
                    string SQL_GetListqx = "select * from qp_KmTitle where  ((CHARINDEX('," + this.Session["username"] + ",',','+QxYdUsername+',') > 0 )  or QxYdUsername='全部用户') and id='" + int.Parse(Request.QueryString["id"]) + "'";
                    SqlDataReader NewReaderqx = List.GetList(SQL_GetListqx);
                    if (!NewReaderqx.Read())
                    {
                        this.Response.Write("<script language=javascript>alert('对不起，你没有阅读权限！');window.close();</script>");
                        return;
                    }
                    NewReaderqx.Close();


                    string SQL_GetListzc = "select * from qp_KmTitle where  State='正常' and id='" + int.Parse(Request.QueryString["id"]) + "'";
                    SqlDataReader NewReaderzc = List.GetList(SQL_GetListzc);
                    if (!NewReaderzc.Read())
                    {
                        this.Response.Write("<script language=javascript>alert('该知识的当前状态不允许查看！');window.close();</script>");
                        return;
                    }
                    NewReaderzc.Close();

                }
                NewReaderGLY.Close();//如果不是管理员，则检查是否有阅读权限和状态。








                string Sql_update = "Update qp_KmTitle  Set PointNum=PointNum+1 where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);

                BindLb();
                InsertLog("查看知识[" + Title + "]", "知识管理");
                DataBindToGridview();
                Button3.Attributes["onclick"] = "javascript:return chknull();";


                if (IfTj == "是")
                {
                    Button7.Text = "取消推荐";
                }
                else
                {
                    Button7.Text = "推荐";
                }



            }



        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }
        public void BindLb()
        {

            string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                Number.Text = NewReader["Number"].ToString();
                LittleName = NewReader["LittleName"].ToString();
                ShowTitle = NewReader["Title"].ToString();
                Content = List.TbToLb(NewReader["Content"].ToString());
                AthourSay = NewReader["AthourSay"].ToString();
                PointNum = NewReader["PointNum"].ToString();
                ScNum = NewReader["ScNum"].ToString();
                DyNum = NewReader["DyNum"].ToString();
                TjNum = NewReader["TjNum"].ToString();
                LastTime = NewReader["LastTime"].ToString();
                Realname = NewReader["Realname"].ToString();
                Username = NewReader["Username"].ToString();
                IfTj = NewReader["IfTj"].ToString();
                KeyWord = NewReader["KeyWord"].ToString();
                
            }

            NewReader.Close();


            string SQL_GetList1 = "select * from qp_KmManger where  (CHARINDEX('," + this.Session["username"] + ",',','+Username+',') > 0 ) ";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
            if (NewReader1.Read())
            {
                Button6.Visible = true;
                Button7.Visible = true;
            }//是否为管理员
            else
            {
                Button6.Visible = false;
                Button7.Visible = false;
            }
            NewReader1.Close();


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            string SQL_GetCount = "select count(KmId) from  qp_KmTjNum where  Username='" + Session["username"] + "' and convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + System.DateTime.Now.ToShortDateString() + "' as datetime),120) ";
            string  CountsLabel = "" + List.GetCount(SQL_GetCount) + "";

            if (int.Parse(CountsLabel) >= 3)
            {
                this.Response.Write("<script language=javascript>alert('你今天３次推荐票已使用完，请明天再行推荐');</script>");
                return;
            }


            string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+TjUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("推荐知识[" + ShowTitle + "]", "知识管理");
                this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
            }

            else
            {
                string Sql_update = "Update qp_KmTitle  Set TjNum=TjNum+1 ,TjUsername=TjUsername+'" + Session["username"] + ",',TjRealname=TjRealname+'" + Session["realname"] + ",'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("推荐知识[" + ShowTitle + "]", "知识管理");
                this.Response.Write("<script language=javascript>alert('推荐成功！');</script>");
            }


            string sql_insert = "insert into qp_KmTjNum (KmId,Username,Realname,Settime) values ('" + int.Parse(Request.QueryString["id"]) + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            
            NewReader.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+DyUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                this.Response.Write("<script language=javascript>alert('已订阅！');</script>");
                return;
            }
            else
            {
                string Sql_update = "Update qp_KmTitle  Set DyNum=DyNum+1 ,DyUsername=DyUsername+'" + Session["username"] + ",',DyRealname=DyRealname+'" + Session["realname"] + ",'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("订阅知识[" + ShowTitle + "]", "知识管理");
                this.Response.Write("<script language=javascript>alert('订阅成功！');</script>");
            }
            NewReader.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_KmTitle where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and  (CHARINDEX('," + this.Session["username"] + ",',','+ScUsername+',') > 0 ) ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                this.Response.Write("<script language=javascript>alert('已收藏！');</script>");
                return;
            }
            else
            {
                string Sql_update = "Update qp_KmTitle  Set ScNum=ScNum+1 ,ScUsername=ScUsername+'" + Session["username"] + ",',ScRealname=ScRealname+'" + Session["realname"] + ",'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("收藏知识[" + ShowTitle + "]", "知识管理");
                this.Response.Write("<script language=javascript>alert('收藏成功！');</script>");
              
            }
            NewReader.Close();
        }

        public void DataBindToGridview()
        {
            string SQL_GetList_xs = "select * from qp_KmBBS where KmId='" + List.GetFormatStr(Request.QueryString["id"]) + "' order by id desc";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sql_insert = "insert into qp_KmBBS (KmId,Title,Username,Realname,UnitId,UnitName,Settime) values ('" + List.GetFormatStr(Request.QueryString["id"]) + "','" + Title.Text + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["UnitId"] + "','" + this.Session["Unit"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增知识评论[" + ShowTitle + "]", "知识管理");
            Title.Text = "";
            DataBindToGridview();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label ln2 = (Label)e.Row.FindControl("Lid2");
                Label ll2 = (Label)e.Row.FindControl("Label2");
                ll2.Text = null;

                string SQL_GetList1 = "select id,Username from qp_KmTitle  where  id=(select KmId from qp_KmBBS where  id='" + ln2.Text + "')  and Username='" + Session["username"] + "' ";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    ll2.Text = null;
                    ll2.Text = "[<a href='javascript:void(0)' onclick='window.open (\"KmShowDel.aspx?id=" + ln2.Text + "&backid=" + Request.QueryString["id"] + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>删除</a>]";
                }
                NewReader1.Close();

                string SQL_GetList = "select * from qp_KmManger where  (CHARINDEX('," + this.Session["username"] + ",',','+Username+',') > 0 ) ";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    ll2.Text = null;
                    ll2.Text = "[<a href='javascript:void(0)' onclick='window.open (\"KmShowDel.aspx?id=" + ln2.Text + "&backid=" + Request.QueryString["id"] + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>删除</a>]";

                }
                NewReader.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('管理员禁止知识[" + ShowTitle + "]发布，请注意查看！','管理员禁止知识[" + ShowTitle + "]发布，请注意查看！','" + System.DateTime.Now.ToString() + "','" + Username + "','" + Realname + "','系统消息','系统消息','否','KmManage/KmTitle.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
            List.ExeSql(sql_insertgly);


            string Sql_update = "Update qp_KmTitle  Set State='禁止发布'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);
            InsertLog("禁止发布[" + ShowTitle + "]", "知识");
            this.Response.Write("<script language=javascript>alert('禁止成功！');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("KmShowZj.aspx?KmNumber=" + Number.Text + "&backid="+Request.QueryString["id"]+"");
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            if (IfTj == "是")
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('管理员取消推荐了你的知识[" + ShowTitle + "]，请注意查看！','管理员取消推荐了你的知识[" + ShowTitle + "]，请注意查看！','" + System.DateTime.Now.ToString() + "','" + Username + "','" + Realname + "','系统消息','系统消息','否','KmManage/KmTitle.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);


                string Sql_update = "Update qp_KmTitle  Set IfTj='否' ,TjTime='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("取消推荐知识[" + ShowTitle + "]", "知识");
               
                this.Response.Write("<script language=javascript>alert('取消推荐成功！');</script>");
            }
            else
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('管理员推荐了你的知识[" + ShowTitle + "]，请注意查看！','管理员推荐了你的知识[" + ShowTitle + "]，请注意查看！','" + System.DateTime.Now.ToString() + "','" + Username + "','" + Realname + "','系统消息','系统消息','否','KmManage/KmTitle.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);


                string Sql_update = "Update qp_KmTitle  Set IfTj='是' ,TjTime='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("推荐知识[" + ShowTitle + "]", "知识");
              
                this.Response.Write("<script language=javascript>alert('推荐成功！');</script>"); 
            }


        }

    }
}

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
namespace qpoa.MyAffairs
{
    public partial class WorkTimeDj : System.Web.UI.Page
    {
        Db List = new Db();
        public static string DjType_1, DjType_2, DjType_3, DjType_4, DjType_5, DjType_6, jxtime;

        public static string DjType_1_u, DjType_2_u, DjType_3_u, DjType_4_u, DjType_5_u, DjType_6_u;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_WorkTime  where QyType='启用'   and  (CHARINDEX('," + Session["username"] + ",',','+SyUsername+',')   >   0 )";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    DjType_1 = NewReader["DjType_1"].ToString();
                    DjType_2 = NewReader["DjType_2"].ToString();
                    DjType_3 = NewReader["DjType_3"].ToString();
                    DjType_4 = NewReader["DjType_4"].ToString();
                    DjType_5 = NewReader["DjType_5"].ToString();
                    DjType_6 = NewReader["DjType_6"].ToString();

                    DjTime_1.Text = NewReader["DjTime_1"].ToString();
                    DjTime_2.Text = NewReader["DjTime_2"].ToString();
                    DjTime_3.Text = NewReader["DjTime_3"].ToString();
                    DjTime_4.Text = NewReader["DjTime_4"].ToString();
                    DjTime_5.Text = NewReader["DjTime_5"].ToString();
                    DjTime_6.Text = NewReader["DjTime_6"].ToString();
                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('未找到已启用上下班时间，操作失败\\n请在[人力资源--上下班时间]中设置');window.location.href='../main_d.aspx'</script>");
                    return;
                }
                NewReader.Close();

                string SQL_GetList1 = "select * from qp_WorkTimeJx";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    jxtime = NewReader1["jxtime"].ToString();


                }
                NewReader1.Close();
                BindAttribute();
            }



        }
        public void BindAttribute()
        {
            //this.Button1.Attributes.Add("onclick", "javascript:return dj();");
            this.Button2.Attributes.Add("onclick", "javascript:return dj();");
            this.Button3.Attributes.Add("onclick", "javascript:return dj();");
            this.Button4.Attributes.Add("onclick", "javascript:return dj();");
            this.Button5.Attributes.Add("onclick", "javascript:return dj();");
            this.Button6.Attributes.Add("onclick", "javascript:return dj();"); 
          
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            Response.Redirect("../main_d.aspx");

        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_1"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');</script>");
                    return;

                }


            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_1.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_1 == "上班")
                {

                    DjType_1_u = "迟到";
                }
                else
                {
                    DjType_1_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_1 == "上班")
                {

                    DjType_1_u = "正常";
                }
                else
                {
                    DjType_1_u = "正常";
                }
            }
            else
            {
                if (DjType_1 == "上班")
                {

                    DjType_1_u = "正常";
                }
                else
                {
                    DjType_1_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_1='" + DjType_1_u + "',DjTime_1='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            //Response.Write(Sql_update);
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_1_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            
            NewReader.Close();
        
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "'  and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_2"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');</script>");
                    return;

                }


                TimeSpan sp_f = new TimeSpan();
                DateTime st1_f = System.DateTime.Now;
                DateTime st2_f = System.DateTime.Parse(NewReader["FDjtime"].ToString());
                sp_f = st1_f - st2_f;

                if (sp_f.Minutes < int.Parse(jxtime))
                {
                    this.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + jxtime + "]分');</script>");
                    return;

                }



            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_2.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_2 == "上班")
                {

                    DjType_2_u = "迟到";
                }
                else
                {
                    DjType_2_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_2 == "上班")
                {

                    DjType_2_u = "正常";
                }
                else
                {
                    DjType_2_u = "正常";
                }
            }
            else
            {
                if (DjType_2 == "上班")
                {

                    DjType_2_u = "正常";
                }
                else
                {
                    DjType_2_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_2='" + DjType_2_u + "',DjTime_2='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_2_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            NewReader.Close();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_3"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }



                TimeSpan sp_f = new TimeSpan();
                DateTime st1_f = System.DateTime.Now;
                DateTime st2_f = System.DateTime.Parse(NewReader["FDjtime"].ToString());
                sp_f = st1_f - st2_f;

                if (sp_f.Minutes < int.Parse(jxtime))
                {
                    this.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + jxtime + "]分');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }


            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_3.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_3 == "上班")
                {

                    DjType_3_u = "迟到";
                }
                else
                {
                    DjType_3_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_3 == "上班")
                {

                    DjType_3_u = "正常";
                }
                else
                {
                    DjType_3_u = "正常";
                }
            }
            else
            {
                if (DjType_3 == "上班")
                {

                    DjType_3_u = "正常";
                }
                else
                {
                    DjType_3_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_3='" + DjType_3_u + "',DjTime_3='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_3_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            NewReader.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_4"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }



                TimeSpan sp_f = new TimeSpan();
                DateTime st1_f = System.DateTime.Now;
                DateTime st2_f = System.DateTime.Parse(NewReader["FDjtime"].ToString());
                sp_f = st1_f - st2_f;

                if (sp_f.Minutes < int.Parse(jxtime))
                {
                    this.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + jxtime + "]分');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }


            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_4.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_4 == "上班")
                {

                    DjType_4_u = "迟到";
                }
                else
                {
                    DjType_4_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_4 == "上班")
                {

                    DjType_4_u = "正常";
                }
                else
                {
                    DjType_4_u = "正常";
                }
            }
            else
            {
                if (DjType_4 == "上班")
                {

                    DjType_4_u = "正常";
                }
                else
                {
                    DjType_4_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_4='" + DjType_4_u + "',DjTime_4='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_4_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            NewReader.Close();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_5"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }



                TimeSpan sp_f = new TimeSpan();
                DateTime st1_f = System.DateTime.Now;
                DateTime st2_f = System.DateTime.Parse(NewReader["FDjtime"].ToString());
                sp_f = st1_f - st2_f;

                if (sp_f.Minutes < int.Parse(jxtime))
                {
                    this.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + jxtime + "]分');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }


            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_5.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_5 == "上班")
                {

                    DjType_5_u = "迟到";
                }
                else
                {
                    DjType_5_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_5 == "上班")
                {

                    DjType_5_u = "正常";
                }
                else
                {
                    DjType_5_u = "正常";
                }
            }
            else
            {
                if (DjType_5 == "上班")
                {

                    DjType_5_u = "正常";
                }
                else
                {
                    DjType_5_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_5='" + DjType_5_u + "',DjTime_5='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_5_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            NewReader.Close();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            string SQL_GetList = "select * from qp_WorkTimeDj where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToString() + "',120)";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                if (NewReader["DjState_6"].ToString() != "未考勤")
                {
                    this.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }


                TimeSpan sp_f = new TimeSpan();
                DateTime st1_f = System.DateTime.Now;
                DateTime st2_f = System.DateTime.Parse(NewReader["FDjtime"].ToString());
                sp_f = st1_f - st2_f;

                if (sp_f.Minutes < int.Parse(jxtime))
                {
                    this.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + jxtime + "]分');window.location.href='WorkTimeDj.aspx'</script>");
                    return;

                }



            }



            TimeSpan sp = new TimeSpan();
            DateTime st1 = System.DateTime.Now;
            DateTime st2 = System.DateTime.Parse(DjTime_6.Text);
            sp = st1 - st2;





            if (sp.TotalSeconds > 0)
            {


                if (DjType_6 == "上班")
                {

                    DjType_6_u = "迟到";
                }
                else
                {
                    DjType_6_u = "正常";
                }

            }
            else if (sp.TotalSeconds == 0)
            {
                if (DjType_6 == "上班")
                {

                    DjType_6_u = "正常";
                }
                else
                {
                    DjType_6_u = "正常";
                }
            }
            else
            {
                if (DjType_6 == "上班")
                {

                    DjType_6_u = "正常";
                }
                else
                {
                    DjType_6_u = "早退";
                }


            }

            string Sql_update = "Update qp_WorkTimeDj Set DjState_6='" + DjType_6_u + "',DjTime_6='" + System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString() + ":" + System.DateTime.Now.Second.ToString() + "',FDjtime='" + System.DateTime.Now.ToString() + "' where DjUsername='" + this.Session["username"] + "' and convert(varchar(10),Djtime,121)=convert(char(10),'" + System.DateTime.Now.ToShortDateString() + "',120)";
            List.ExeSql(Sql_update);
            this.Response.Write("<script language=javascript>alert('登记成功！\\n当前登记状态：[" + DjType_6_u + "]');window.location.href='WorkTimeDj.aspx'</script>");
            NewReader.Close();
        }



    }
}

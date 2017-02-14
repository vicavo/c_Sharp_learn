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
    public partial class MettingApply_sp_sp : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_MettingApply where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Name"].ToString();
                    Title.Text = NewReader["Title"].ToString();
                    Introduction.Text = List.TbToLb(NewReader["Introduction"].ToString());
                    WbPeople.Text = List.TbToLb(NewReader["WbPeople"].ToString());
                    NbPeopleUser.Text = NewReader["NbPeopleUser"].ToString();

                    NbPeopleName.Text = NewReader["NbPeopleName"].ToString();
                    MettingId.Text = NewReader["MettingId"].ToString();
                    MettingName.Text = NewReader["MettingName"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();

                    Remark.Text = List.TbToLb(NewReader["Remark"].ToString());

                   // CjRealname.Text = NewReader["CjRealname"].ToString();

                    SpRealname.Text = Session["realname"].ToString();
                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                  //  State.Text = NewReader["State"].ToString();
                   // SpTimes.Text = NewReader["SpTimes"].ToString();

                    Username.Text = NewReader["Username"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();

                }

                NewReader.Close();
              
                BindAttribute();
            }


            string sql_down_bh = "select Title from qp_UseSpRemark where Username='" + Session["username"].ToString() + "' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList(normalcontent, sql_down_bh, "Title", "Title");
            }
        }

        public void BindAttribute()
        {
            //ManagerName.Attributes.Add("readonly", "readonly");

            //NbPeopleName.Attributes.Add("readonly", "readonly");
            //MettingName.Attributes.Add("readonly", "readonly");

            //Starttime.Attributes.Add("readonly", "readonly");
            //Endtime.Attributes.Add("readonly", "readonly");

            //Button2.Attributes["onclick"] = "javascript:return showwait();";





        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MettingApply.aspx");
        //}



        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Shenpi.SelectedValue == "已通过")
            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的会议已经审批，审批结果为[已通过]！','您申请的会议已经审批，审批结果为[已通过]！','" + System.DateTime.Now.ToString() + "','" + Username.Text + "','" + Realname.Text + "','系统消息','系统消息','否','PublicAffairs/MettingApply_ytg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);

                //string SQL_GetList_xs1 = "select * from qp_InfoSend where  Number='" + Number.Text + "' ";
                //SqlDataReader NewReader1 = List.GetList(SQL_GetList_xs1);
                //if (NewReader1.Read())
                //{
                //    string strlist = null;
                //    string str1 = null;
                //    str1 = "" + NbPeopleUser.Text + "";
                //    ArrayList myarr = new ArrayList();
                //    string[] mystr = str1.Split(',');
                //    for (int s = 0; s < mystr.Length; s++)
                //    {
                //        strlist += "'" + mystr[s] + "',";
                //    }
                //    strlist += "'0'";

                //    string SQL_GetList_xs = "select * from qp_Username where  username in (" + strlist + ") ";
                //    SqlDataReader NewReader = List.GetList(SQL_GetList_xs);
                //    while (NewReader.Read())
                //    {
                //        string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的文件传阅信息，请注意查看！','有新的文件传阅信息，请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','InfoSpeech/MyMetting.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                //        List.ExeSql(sql_insertgly);
                //    }
                //    NewReader.Close();
                //}
                //NewReader1.Close();



               
            }
            else

            {
                string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('您申请的会议已经审批，审批结果为[未通过]！','您申请的会议已经审批，审批结果为[未通过]！','" + System.DateTime.Now.ToString() + "','" + Username.Text + "','" + Realname.Text + "','系统消息','系统消息','否','PublicAffairs/MettingApply_wtg.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertgly);
            }
            string Sql_update1 = "Update qp_MettingApply    Set SpRemark='" + List.GetFormatStr(SpRemark.Text) + "',State='" + Shenpi.SelectedValue + "',SpUsername='" + Session["username"] + "',SpRealname='" + Session["realname"] + "',SpTimes='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
            InsertLog("审批会议[" + Name.Text + "]，[" + Shenpi.SelectedValue + "]", "会议管理");



            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MettingApply_sp.aspx'</script>");
        }







    }
}

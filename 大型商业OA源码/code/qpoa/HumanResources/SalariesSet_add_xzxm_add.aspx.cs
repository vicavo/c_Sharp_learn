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
namespace qpoa.HumanResources
{
    public partial class SalariesSet_add_xzxm_add : System.Web.UI.Page
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
                BindAttribute();
            }

            if (CheckBox1.Checked == true)
            {
                Panel1.Visible = true;
                CsMoney.Text = "1";
                CsMoney.Enabled = false;
            }
            else
            {
                Panel1.Visible = false;
                
                CsMoney.Enabled = true;
               
            }

            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }
        }
        public void BindDroList()
        {
          
        }
        public void BindAttribute()
        {

            Button1.Attributes["onclick"] = "javascript:return chknull();";
            LinkButton1.Attributes["onclick"] = "javascript:return chkset();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            int PaixunAdd = 0;
            string SQL_GetList = "select top 1 PaiXun from qp_SaProduct  order by paixun desc";

            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                PaixunAdd = int.Parse(NewReader["PaiXun"].ToString());
            }
            else
            {
                PaixunAdd = 0;
            }
            NewReader.Close();
            int PaixunAdd_1 = PaixunAdd + 1;

            string IfGs = null;


            if (CheckBox1.Checked == true)
            {
                IfGs = "是";
            }
            else
            {
                IfGs = "否";
            }




            string sql_insert = "insert into qp_SaProduct    (Number,Name,CsMoney,showBl,Textbox,s_str,l_str,PaiXun,IfGs,GsName,SaNumber) values ('" + Number.Text + "','" + List.GetFormatStr(Name.Text) + "','" + CsMoney.Text + "','1','<INPUT type=text size=64 id=" + Number.Text + " name=" + Number.Text + " value=>','<INPUT type=text size=64 id=" + Number.Text + " name=" + Number.Text + " value=','>','" + PaixunAdd_1 + "','" + IfGs + "','" + txtForumla.Text + "','"+Request.QueryString["number"]+"')";
            List.ExeSql(sql_insert);
            InsertLog("新增薪资项目[" + Name.Text + "]", "帐套管理");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesSet_add_xzxm.aspx?number="+Request.QueryString["number"]+"';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //string sql_insert = "insert into qp_SalariesSet    (Number,Name,Content,IfOk,Startime,Endtime,Username,Realname,NowTimes) values ('" + Number.Text + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Content.Text) + "','" + IfOk.SelectedValue + "','" + Startime.SelectedValue + "','" + Endtime.SelectedValue + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            //List.ExeSql(sql_insert);

            //InsertLog("新增帐套名称[" + Name.Text + "]", "帐套管理");

            //Response.Redirect("SalariesSet_add_xzxm.aspx?Number=" + Number.Text + "");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {

            int sLenth=txtForumla.Text.IndexOf("[");
            int eLenth = txtForumla.Text.IndexOf("]") - (txtForumla.Text.IndexOf("[") - 1);
            string setstr = null;
            setstr = txtForumla.Text.Substring(sLenth, eLenth);
            CreateSaSql(setstr);

            string  returnint = CreateSaSql(setstr);
          
            //Response.Write(Eval(CreateStr(txtForumla.Text, returnint)));
            //Response.Write("<br>aaa："+CreateStr(txtForumla.Text, returnint)+"");
          
                try
                {
                    int var1a = Convert.ToInt32(Eval(CreateStr(txtForumla.Text, returnint)));
                    //Response.Write(var1a);
                    //int.Parse(Eval(CreateStr(txtForumla.Text, returnint)));
                }

                catch 
                {
                    this.Response.Write("<script language=javascript>alert('公式检验失败！');</script>");
                    return;
                }

             this.Response.Write("<script language=javascript>alert('公式检验通过！');</script>");


            }
            catch
            {
                this.Response.Write("<script language=javascript>alert('公式检验失败！');</script>");
                return;
            }
        }

        public object Eval(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            System.Data.DataColumn Col = new System.Data.DataColumn("col1 ", typeof(string), expression);
            table.Columns.Add(Col);

            table.Rows.Add(new object[] { " " });
            return table.Rows[0][0];
        }

        public string  CreateSaSql(string setstr)
        {
            string SaSql = null;


            if (setstr == "[迟到次数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='迟到'";
                SaSql = ""+List.GetCount(SQL_GetList_cd_1)+"";
            }
            if (setstr == "[早退次数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='早退'";
                SaSql = "" + List.GetCount(SQL_GetList_cd_1) + "";
            }
            if (setstr == "[旷工天数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where DjState_1='旷工'";
                SaSql = "" + List.GetCount(SQL_GetList_cd_1) + "";
            }
            if (setstr == "[出差天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Shenpi='已通过'  and  Type='3' ";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();


            }
            if (setstr == "[事假天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Shenpi='已通过'  and  Type='2' ";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();



            }
            if (setstr == "[病假天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Shenpi='已通过'  and  Type='1' ";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();
            }



            if (setstr == "[加班小时]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Shenpi='已通过'  and  Type='4' ";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();
            }





            return SaSql;
        }

        public string CreateStr(string AStr, string bbb)
        {

            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("[迟到次数]", "" + bbb + "");
                AStr = AStr.Replace("[早退次数]", "" + bbb + "");
                AStr = AStr.Replace("[旷工天数]", "" + bbb + "");
                AStr = AStr.Replace("[出差天数]", "" + bbb + "");
                AStr = AStr.Replace("[事假天数]", "" + bbb + "");
                AStr = AStr.Replace("[病假天数]", "" + bbb + "");
                AStr = AStr.Replace("[加班小时]", "" + bbb + "");
                return AStr;
            }
        }//替换字符





    }
}

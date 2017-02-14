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
    public partial class InfoSend_add : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string  fjkey;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {

                    fjkey = NewReader_fjkey["content"].ToString();

                }
                NewReader_fjkey.Close();

                BindAttribute();
            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }
            BindList();
            DataBindToGridview("order by id desc");
        }
        public void BindAttribute()
        {
            Button1.Attributes["onclick"] = "javascript:return checkForm();";
            LinkButton1.Attributes["onclick"] = "javascript:return openuser1();";
            Button2.Attributes["onclick"] = "javascript:return chknull();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }
        public void BindList()
        {
            string sql_down_1 = "select * from qp_InfoSendFj where KeyField='" + Number.Text + "' order by id desc";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void DataBindToGridview(string Sqlsort)
        {
            string SQL_GetList_xs = "select * from qp_InfoSendJsr where KeyField='" + Number.Text + "'  " + Sqlsort + "";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
         
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string AllowUpdate = null, AllowAddPeople = null, AllowCir = null;

            if (C1.Checked == true)
            { AllowUpdate = "是"; }
            else
            { AllowUpdate = "否"; }


            if (C2.Checked == true)
            { AllowAddPeople = "是"; }
            else
            { AllowAddPeople = "否"; }


            if (C3.Checked == true)
            { AllowCir = "是"; }
            else
            { AllowCir = "否"; }

            string sql_insertgly = "insert into qp_InfoSend  (Number,Title,Content,State,AllowUpdate,AllowAddPeople,AllowCir,Username,Realname,Settime) values ('" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStrbjq(d_content.Value) + "','正在传阅','" + AllowUpdate + "','" + AllowAddPeople + "','" + AllowCir + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insertgly);



            string SQL_GetList_xs1 = "select * from qp_InfoSendJsr where  KeyField='" + Number.Text + "' ";
            SqlDataReader NewReader1 = List.GetList(SQL_GetList_xs1);
            while (NewReader1.Read())
            {
                string sql_insertglya = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('有新的文件传阅信息[" + Title.Text + "]，请注意查看！','有新的文件传阅信息[" + Title.Text + "]，请注意查看！','" + System.DateTime.Now.ToString() + "','" + NewReader1["QrUsername"] + "','" + NewReader1["QrRealname"] + "','系统消息','系统消息','否','InfoSpeech/JsInfoSend.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                List.ExeSql(sql_insertglya);
            }
            NewReader1.Close();



            InsertLog("文件传阅", "文件传阅");
            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='InfoSend.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("InfoSend.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int ID = Convert.ToInt32(e.CommandArgument);

                string Sql_del = "delete from qp_InfoSendJsr where id='" + ID + "'";
                List.ExeSql(Sql_del);

                DataBindToGridview("order by id desc");

            }
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
                LinkButton l1 = (LinkButton)e.Row.FindControl("ShanChu");
                l1.Attributes.Add("onclick", "javascript:return confirm('确认删除人员" + e.Row.Cells[0].Text.ToString() + "]吗')");
          

            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview("order by id asc");
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("InfoSendFj/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);

      



                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名

                string sql_insert_file = "insert into qp_InfoSendFj    (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传文件传阅附件[" + fileName + "]", "文件传阅");
                BindList();
            }
        }

    }
}

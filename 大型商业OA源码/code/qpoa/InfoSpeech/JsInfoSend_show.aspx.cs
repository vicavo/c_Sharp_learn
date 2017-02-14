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
    public partial class JsInfoSend_show : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                LinkButton1.Attributes["onclick"] = "javascript:return openuser1();";
                Button1.Attributes["onclick"] = "javascript:return zx();";
                BindNewReader();
            }
            DataBindToGridview("order by id desc");
        }


        public void BindNewReader()
        {
  


            string AllowUpdate_u = null, AllowAddPeople_u = null, AllowCir_u = null;

            string SQL_GetList = "select * from qp_InfoSend where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' ";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                Number.Text = NewReader["Number"].ToString();
                Title.Text = NewReader["Title"].ToString();
                d_content.Text = List.GetFormatStrbjq_show(NewReader["Content"].ToString());
                State.Text = NewReader["State"].ToString();

                AllowUpdate_u = NewReader["AllowUpdate"].ToString();
                AllowAddPeople_u = NewReader["AllowAddPeople"].ToString();
                AllowCir_u = NewReader["AllowCir"].ToString();

                if (AllowUpdate_u == "是")
                { C1.Checked = true; }
                else
                { C1.Checked = false; }


                if (AllowAddPeople_u == "是")
                { 
                    C2.Checked = true;
                    LinkButton1.Visible = true;
                }
                else
                {
                    C2.Checked = false;
                    LinkButton1.Visible = false;
                }


                if (AllowCir_u == "是")
                { C3.Checked = true; }
                else
                { C3.Checked = false; }

              

            }
            NewReader.Close();


            string Sql_update1 = "Update qp_InfoSendJsr  Set QrContent='已开封', QrTime='" + System.DateTime.Now.ToString() + "', State='已开封'  where KeyField='" + Number.Text + "'  and   QrUsername='" + Session["username"] + "'   ";
            List.ExeSql(Sql_update1);

            BindList();


        }
        public void BindList()
        {
            string sql_down_1 = "select * from qp_InfoSendFj where KeyField='" + Number.Text + "'  order by id desc";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");



            string sql_down_bh = "select Title from qp_UseSpRemark where Username='" + Session["username"].ToString() + "' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList(normalcontent, sql_down_bh, "Title", "Title");
            }
        }
        public void DataBindToGridview(string Sqlsort)
        {
            string SQL_GetList_xs = "select * from qp_InfoSendJsr where KeyField='" + Number.Text + "'  " + Sqlsort + "";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();

        }


        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        protected void Button4_Click(object sender, EventArgs e)
        {
            Response.Redirect("JsInfoSend.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //if (e.CommandName == "ShanChu")
            //{
            //    int ID = Convert.ToInt32(e.CommandArgument);

            //    string Sql_del = "delete from qp_InfoSendJsr where id='" + ID + "'";
            //    List.ExeSql(Sql_del);

            //    DataBindToGridview("order by id desc");

            //}
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataBindToGridview("order by id asc");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string Sql_update1 = "Update qp_InfoSendJsr  Set QrContent='" + List.GetFormatStr(SpRemark.Text) + "', QrTime='" + System.DateTime.Now.ToString() + "', State='已确认'  where KeyField='" + Number.Text + "' and  QrUsername='" + Session["username"] + "' ";
            List.ExeSql(Sql_update1);

            string SQL_GetCount = "select count(id) from qp_InfoSendJsr  where KeyField='" + Number.Text + "' and  (State='未开封' or  State='已开封')";
            string CountQr = "" + List.GetCount(SQL_GetCount) + "";

            if (int.Parse(CountQr) == 0)
            {
                string Sql_update = "Update qp_InfoSend  Set State='传阅完成'   where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
            }
  


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='JsInfoSend.aspx'</script>"); 
        }



    }
}

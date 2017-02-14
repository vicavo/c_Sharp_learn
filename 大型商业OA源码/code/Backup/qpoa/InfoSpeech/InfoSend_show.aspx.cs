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
    public partial class InfoSend_show : System.Web.UI.Page
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
                BindNewReader();
            }
            DataBindToGridview("order by id desc");
        }


        public void BindNewReader()
        {

            string AllowUpdate_u = null, AllowAddPeople_u = null, AllowCir_u = null;

            string SQL_GetList = "select * from qp_InfoSend where id='" + List.GetFormatStr(Request.QueryString["id"]) + "' and Username='"+Session["username"]+"'";
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
                { C2.Checked = true; }
                else
                { C2.Checked = false; }


                if (AllowCir_u == "是")
                { C3.Checked = true; }
                else
                { C3.Checked = false; }

            }
            NewReader.Close();



            string SQL_rc = "select  * from qp_InfoSendFj where KeyField='" + Number.Text + "' order by id desc";

            SqlDataReader NewReader_rc = List.GetList(SQL_rc);

            this.richeng.Text = null;
            int glTMP2 = 0;
            this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            this.richeng.Text += "<tr>";
            while (NewReader_rc.Read())
            {


                this.richeng.Text += " <td width=100% >·<a href=InfoSend_add_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";

                glTMP2 = glTMP2 + 1;
                if (glTMP2 == 1)
                {
                    richeng.Text += "</tr><TR>";
                    glTMP2 = 0;
                }
            }
            this.richeng.Text += " </table>";
            NewReader_rc.Close();


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
            Response.Redirect("InfoSend.aspx");
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

      

    }
}

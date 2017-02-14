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
    public partial class Employee_show : System.Web.UI.Page
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

            if (!Page.IsPostBack)
            {
                BindAttribute();
            }



            if (!IsPostBack)
            {
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {

                    fjkey = NewReader_fjkey["content"].ToString();

                }
                NewReader_fjkey.Close();


                string SQL_GetList = "select * from qp_Employee where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Realname.Text = NewReader["Realname"].ToString();
                    worknum.Text = NewReader["worknum"].ToString();
                    Unit.Text = NewReader["Unit"].ToString();
                    UnitId.Text = NewReader["UnittId"].ToString();
                    Respon.Text = NewReader["Respon"].ToString();
                    ResponId.Text = NewReader["ResponId"].ToString();
                    Post.Text = NewReader["Post"].ToString();
                    PostId.Text = NewReader["PostId"].ToString();
                    StardType.Text = NewReader["StardType"].ToString();
                    Email.Text = NewReader["Email"].ToString();
                    Sex.Text = NewReader["Sex"].ToString();
                    Bothday.Text = NewReader["Bothday"].ToString();
                    Nationality.Text = NewReader["Nationality"].ToString();
                    IDnumber.Text = NewReader["IDnumber"].ToString();
                    Marriage.Text = NewReader["Marriage"].ToString();
                    Politics.Text = NewReader["Politics"].ToString();
                    Nativeplace.Text = NewReader["Nativeplace"].ToString();
                    Permanents.Text = NewReader["Permanents"].ToString();
                    Schoolrecord.Text = NewReader["Schoolrecord"].ToString();
                    TitleRank.Text = NewReader["TitleRank"].ToString();
                    School.Text = NewReader["School"].ToString();
                    Specialized.Text = NewReader["Specialized"].ToString();
                    Worktime.Text = NewReader["Worktime"].ToString();
                    Companytime.Text = NewReader["Companytime"].ToString();
                    Tel.Text = NewReader["Tel"].ToString();
                    Address.Text = List.TbToLb(NewReader["Address"].ToString());
                    Postchange.Text = List.TbToLb(NewReader["Postchange"].ToString());
                    Educational.Text = List.TbToLb(NewReader["Educational"].ToString());
                    Wxperience.Text = List.TbToLb(NewReader["Wxperience"].ToString());
                    Social.Text = List.TbToLb(NewReader["Social"].ToString());
                    Rewards.Text = List.TbToLb(NewReader["Rewards"].ToString());
                    Dutysituation.Text = List.TbToLb(NewReader["Dutysituation"].ToString());
                    Trains.Text = List.TbToLb(NewReader["Trains"].ToString());
                    Guarantees.Text = List.TbToLb(NewReader["Guarantees"].ToString());
                    Laborcontract.Text = List.TbToLb(NewReader["Laborcontract"].ToString());
                    Society.Text = List.TbToLb(NewReader["Society"].ToString());
                    Physical.Text = List.TbToLb(NewReader["Physical"].ToString());
                    Remark1.Text = List.TbToLb(NewReader["Remark1"].ToString());


                    Number.Text = NewReader["KeyFile"].ToString();

                }
                NewReader.Close();

                string SQL_rc = "select  * from qp_EmployeeFile where KeyField='" + Number.Text + "' order by id desc";

                SqlDataReader NewReader_rc = List.GetList(SQL_rc);

                this.richeng.Text = null;
                int glTMP2 = 0;
                this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this.richeng.Text += "<tr>";
                while (NewReader_rc.Read())
                {


                    this.richeng.Text += " <td width=100% >·<a href=../SystemManage/username_add_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";

                    glTMP2 = glTMP2 + 1;
                    if (glTMP2 == 1)
                    {
                        richeng.Text += "</tr><TR>";
                        glTMP2 = 0;
                    }
                }
                this.richeng.Text += " </table>";
                NewReader_rc.Close();



                InsertLog("查看人事信息[" + Realname.Text + "]", "档案管理");


            }


          

        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Employee.aspx");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }


        private bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf("|" + Str1 + "|") <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


    }
}

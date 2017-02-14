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
    public partial class OfficeThingGh_sp_sp : System.Web.UI.Page
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

                string SQL_GetList = "select * from qp_OfficeThingGh where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NameId.Text = NewReader["NameId"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    LyRealname.Text = NewReader["LyRealname"].ToString();
                    ShuLiang.Text = NewReader["ShuLiang"].ToString();
                    //Shenpi.Text = NewReader["Shenpi"].ToString();

                    // SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                    Remark.Text = NewReader["Remark"].ToString();

                }

                NewReader.Close();

                SpRealname.Text = Session["Realname"].ToString();

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
            Name.Attributes.Add("readonly", "readonly");
            // KhRealname.Attributes.Add("readonly", "readonly");


            Button2.Attributes["onclick"] = "javascript:return showwait();";

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("OfficeThingGh.aspx");
        }


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
                string Sql_update1 = "Update qp_OfficeThingGh   Set SpRemark='" + List.GetFormatStr(SpRemark.Text) + "',Shenpi='" + Shenpi.SelectedValue + "',SpUsername='" + Session["username"] + "',SpRealname='" + Session["realname"] + "',SpTimes='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update1);


                string Sql_updatesp = "Update qp_OfficeThing   Set Inventory=Inventory+" + ShuLiang.Text + " where id='" + NameId.Text + "'";
                List.ExeSql(Sql_updatesp);
            }
            else
            {
                string Sql_update1 = "Update qp_OfficeThingGh   Set SpRemark='" + List.GetFormatStr(SpRemark.Text) + "',Shenpi='" + Shenpi.SelectedValue + "',SpUsername='" + Session["username"] + "',SpRealname='" + Session["realname"] + "',SpTimes='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update1);
            }

            InsertLog("审批办公用品[" + Name.Text + "]归还，[" + Shenpi.SelectedValue + "]", "审批办公用品归还库");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OfficeThingGh_sp.aspx'</script>");
        }



    }
}

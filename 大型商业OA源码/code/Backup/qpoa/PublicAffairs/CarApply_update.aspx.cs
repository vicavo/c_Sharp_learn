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
    public partial class CarApply_update : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_CarApply  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    CarId.Text = NewReader["CarId"].ToString();
                    CarNum.Text = NewReader["CarNum"].ToString();
                    UnitName.SelectedValue = NewReader["UnitNameId"].ToString();

                    Drivers.Text = NewReader["Drivers"].ToString();
                    Carpeople.Text = NewReader["Carpeople"].ToString();
                    Starttime.Text = NewReader["Starttime"].ToString();
                    Endtime.Text = NewReader["Endtime"].ToString();
                    Destination.Text = NewReader["Destination"].ToString();
                    Miles.Text = NewReader["Miles"].ToString();
                    ManagerUser.Text = NewReader["ManagerUser"].ToString();
                    ManagerName.Text = NewReader["ManagerName"].ToString();
                    Subject.Text = NewReader["Subject"].ToString();
                 
                    Remark.Text = NewReader["Remark"].ToString();
                    State.Text = NewReader["State"].ToString();
                    Realname.Text = NewReader["Realname"].ToString();

                }

                NewReader.Close();

                BindDroList();
                BindAttribute();
                if (State.Text != "待审批")
                {


                    if (Request.QueryString["keyback"] == "1")
                    {
                        this.Response.Write("<script language=javascript>alert('此单据已经审批，不能再修改！');window.location.href = 'CarApply.aspx'</script>");
                        return;
                    }
                    if (Request.QueryString["keyback"] == "2")
                    {
                        this.Response.Write("<script language=javascript>alert('此单据已经审批，不能再修改！');window.location.href = 'CarApply_dsp.aspx'</script>");
                        return;
                    }

                }
            }
        }

        public void BindDroList()
        {
            //附件列表
            string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");

        }

        public void BindAttribute()
        {
            CarNum.Attributes.Add("readonly", "readonly");

            ManagerName.Attributes.Add("readonly", "readonly");

            Realname.Attributes.Add("readonly", "readonly");
            Starttime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";




        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["keyback"] == "1")
            {
                Response.Redirect("CarApply.aspx");
            }
            if (Request.QueryString["keyback"] == "2")
            {
                Response.Redirect("CarApply_dsp.aspx");
            }
         
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string Sql_update1 = "Update qp_CarApply    Set CarId='" + List.GetFormatStr(CarId.Text) + "',UnitNameId='" + List.GetFormatStr(UnitName.SelectedValue) + "',UnitName='" + List.GetFormatStr(UnitName.SelectedItem.Text) + "',CarNum='" + List.GetFormatStr(CarNum.Text) + "',Drivers='" + List.GetFormatStr(Drivers.Text) + "',Carpeople='" + List.GetFormatStr(Carpeople.Text) + "',Starttime='" + List.GetFormatStr(Starttime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "',Destination='" + List.GetFormatStr(Destination.Text) + "',Miles='" + List.GetFormatStr(Miles.Text) + "',ManagerUser='" + List.GetFormatStr(ManagerUser.Text) + "',ManagerName='" + List.GetFormatStr(ManagerName.Text) + "',Subject='" + List.GetFormatStr(Subject.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
           



            InsertLog("修改车辆使用申请[" + CarNum.Text + "]", "车辆使用申请");

            if (Request.QueryString["keyback"] == "1")
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply.aspx'</script>");
            }
            if (Request.QueryString["keyback"] == "2")
            {
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarApply_dsp.aspx'</script>");
            }


         


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

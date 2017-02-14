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
    public partial class Assets_add : System.Web.UI.Page
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
                BgRealname.Text = Session["realname"].ToString();
                BindDroList();
                BindAttribute();
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
            MadeTime.Attributes.Add("readonly", "readonly");
            SetTime.Attributes.Add("readonly", "readonly");
            DepStartDate.Attributes.Add("readonly", "readonly");
            DepType.Attributes.Add("readonly", "readonly");
            DepRate.Attributes.Add("readonly", "readonly");
            DepCycle.Attributes.Add("readonly", "readonly");
            BgRealname.Attributes.Add("readonly", "readonly");

            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assets.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string sql_insert = "insert into qp_Assets  (LastDepTime,Number,Name,AssetModel,MadeCompany,AssetType,MadeTime,SetTime,DepTypeID,DepType,DepRate,DepCycle,ActualMoney,FrontMoney,MinMoney,DepStartDate,UnitNameID,UnitName,BgUsername,BgRealname,Remark,Username,Realname,Unit,UnitId,Respon,ResponId,NowTimes,QxString) values ('" + List.GetFormatStr(DepStartDate.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(AssetModel.Text) + "','" + List.GetFormatStr(MadeCompany.Text) + "','" + List.GetFormatStr(AssetType.Text) + "','" + List.GetFormatStr(MadeTime.Text) + "','" + List.GetFormatStr(SetTime.Text) + "','" + List.GetFormatStr(DepTypeID.Text) + "','" + List.GetFormatStr(DepType.Text) + "','" + List.GetFormatStr(DepRate.Text) + "','" + List.GetFormatStr(DepCycle.Text) + "','" + List.GetFormatStr(ActualMoney.Text) + "','" + List.GetFormatStr(ActualMoney.Text) + "','" + List.GetFormatStr(MinMoney.Text) + "','" + List.GetFormatStr(DepStartDate.Text) + "','" + UnitName.SelectedValue + "','" + UnitName.SelectedItem.Text + "','" + Session["username"] + "','" + Session["realname"] + "','" + List.GetFormatStr(Remark.Text) + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert);
            //Response.Write(sql_insert);
            InsertLog("新增固定资产[" + Name.Text + "]", "固定资产");


         this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Assets.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

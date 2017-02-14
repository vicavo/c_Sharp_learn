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
    public partial class Assets_show : System.Web.UI.Page
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
                string SQL_GetList = "select * from qp_Assets where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Number.Text = NewReader["Number"].ToString();
                    UnitName.Text = NewReader["UnitNameId"].ToString();


                    Name.Text = NewReader["Name"].ToString();
                    AssetModel.Text = NewReader["AssetModel"].ToString();
                    MadeCompany.Text = NewReader["MadeCompany"].ToString();
                    AssetType.Text = NewReader["AssetType"].ToString();
                    MadeTime.Text = NewReader["MadeTime"].ToString();
                    SetTime.Text = NewReader["SetTime"].ToString();
                    DepTypeID.Text = NewReader["DepTypeID"].ToString();
                    DepType.Text = NewReader["DepType"].ToString();
                    DepRate.Text = ""+NewReader["DepRate"].ToString()+"%";
                    DepCycle.Text = ""+NewReader["DepCycle"].ToString()+"天";
                    ActualMoney.Text = NewReader["ActualMoney"].ToString();
                    MinMoney.Text = NewReader["MinMoney"].ToString();
                    DepStartDate.Text = System.DateTime.Parse(NewReader["DepStartDate"].ToString()).ToShortDateString();
                    BgRealname.Text = NewReader["BgRealname"].ToString();
                    Remark.Text = NewReader["Remark"].ToString();

                }

                NewReader.Close();

                InsertLog("查看固定资产[" + Name.Text + "]", "固定资产");

                BindDroList();
                BindAttribute();
            }

        }
        public void BindDroList()
        {
            //附件列表
            //string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";
            //list.Bind_DropDownList_nothing(UnitName, sql_down_bh, "id", "aaa");
        }

        public void BindAttribute()
        {
            //MadeTime.Attributes.Add("readonly", "readonly");
            //SetTime.Attributes.Add("readonly", "readonly");
            //DepStartDate.Attributes.Add("readonly", "readonly");
            //DepType.Attributes.Add("readonly", "readonly");
            //DepRate.Attributes.Add("readonly", "readonly");
            //DepCycle.Attributes.Add("readonly", "readonly");
            //BgRealname.Attributes.Add("readonly", "readonly");

           //Button2.Attributes["onclick"] = "javascript:return showwait();";
            //Button1.Attributes["onclick"] = "javascript:return chknull();";



        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assets.aspx");
        }


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }





    }
}

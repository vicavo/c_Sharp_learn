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
namespace qpoa.SaleManage
{
    public partial class SaleContract_show : System.Web.UI.Page
    {

        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;
        public static string fjkey, ContractContent;

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
                string SQL_GetList = "select * from qp_SaleContract where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {

                    Number.Text = NewReader["Number"].ToString();
                    KeyId.Text = NewReader["KeyId"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    ContractName.Text = NewReader["ContractName"].ToString();
                    ContractNum.Text = NewReader["ContractNum"].ToString();
                    ContractType.Text = NewReader["ContractType"].ToString();
                    ContractMoney.Text = NewReader["ContractMoney"].ToString();
                    Description.Text = NewReader["Description"].ToString();
                    ContractTerms.Text = NewReader["ContractTerms"].ToString();
                    ContractContent = NewReader["ContractContent"].ToString();
                  
                    Startime.Text = System.DateTime.Parse(NewReader["Startime"].ToString()).ToShortDateString();
                    Endtime.Text = System.DateTime.Parse(NewReader["Endtime"].ToString()).ToShortDateString();
                    ContractorA.Text = NewReader["ContractorA"].ToString();
                    ContractorUser.Text = NewReader["ContractorUser"].ToString();
                    ContractorB.Text = NewReader["ContractorB"].ToString();
                    CreateDate.Text = System.DateTime.Parse(NewReader["CreateDate"].ToString()).ToShortDateString();
                    Remark.Text = NewReader["Remark"].ToString();


                }
                NewReader.Close();


                string SQL_rc = "select  * from qp_SaleContractFile where KeyField='"+Number.Text+"' order by id desc";

                SqlDataReader NewReader_rc = List.GetList(SQL_rc);

                this.richeng.Text = null;
                int glTMP2 = 0;
                this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this.richeng.Text += "<tr>";
                while (NewReader_rc.Read())
                {


                    this.richeng.Text += " <td width=100% >·<a href=SaleContract_add_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";
               
                    glTMP2 = glTMP2 + 1;
                    if (glTMP2 == 1)
                    {
                        richeng.Text += "</tr><TR>";
                        glTMP2 = 0;
                    }
                }
                this.richeng.Text += " </table>";
                NewReader_rc.Close();







                InsertLog("查看销售合同[" + Name.Text + "]", "销售合同");

                string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";


                SqlDataReader NewReader_yz = List.GetList(SQL_yz);
                showjg = null;
                if (NewReader_yz.Read())
                {
                    string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";
                    SqlDataReader NewReader_mx = List.GetList(SQL_mx);

                    int glTMP1 = 0;

                    showjg += "<tr> <td align=center class=newtd2 colspan=4 height=26 width=33%><div align=center><strong>用户自定义字段</strong></div> </td> </tr>";

                    while (NewReader_mx.Read())
                    {

                        showjg += " <tr> <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + List.TbToLb(NewReader_mx["ivalue"].ToString()) + "</td></tr>";
                        glTMP1 = glTMP1 + 1;
                        if (glTMP1 == 1)
                        {

                            glTMP1 = 0;
                        }
                    }

                    NewReader_mx.Close();
                }

            }



          
        }
     
        public void BindAttribute()
        {
            


            //Button2.Attributes["onclick"] = "javascript:return showwait();";
         
        }


        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("SaleContract.aspx");
        //}


        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

     





    }
}

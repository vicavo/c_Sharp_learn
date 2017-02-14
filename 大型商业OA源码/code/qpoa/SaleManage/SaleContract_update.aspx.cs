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
namespace qpoa.myeditor
{
    public partial class SaleContract_update : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string showjg;
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
                    ContractContent.Text = NewReader["ContractContent"].ToString();
                    ContractContentupdate.Text = List.GetFormatStrbjq_show(NewReader["ContractContent"].ToString());
                    Startime.Text = System.DateTime.Parse(NewReader["Startime"].ToString()).ToShortDateString();
                    Endtime.Text = System.DateTime.Parse(NewReader["Endtime"].ToString()).ToShortDateString();
                    ContractorA.Text = NewReader["ContractorA"].ToString();
                    ContractorUser.Text = NewReader["ContractorUser"].ToString();
                    ContractorB.Text = NewReader["ContractorB"].ToString();
                    CreateDate.Text = System.DateTime.Parse(NewReader["CreateDate"].ToString()).ToShortDateString();
                    Remark.Text = NewReader["Remark"].ToString();
                   

                }
                NewReader.Close();



             
            }
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

                    showjg += " <tr> <td align=right class=newtd1 height=17 nowrap=nowrap width=17%>" + NewReader_mx["Name"] + "：</td> <td class=newtd2 height=17 width=33% colspan=3>" + NewReader_mx["s_str"] + "" + NewReader_mx["ivalue"] + "" + NewReader_mx["l_str"] + "</td></tr>";
                    glTMP1 = glTMP1 + 1;
                    if (glTMP1 == 1)
                    {

                        glTMP1 = 0;
                    }
                }

                NewReader_mx.Close();
            }


            BindDroList();
        }
        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_SaleContractFile where KeyField='" + Number.Text + "'";


            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
            Startime.Attributes.Add("readonly", "readonly");
            Endtime.Attributes.Add("readonly", "readonly");
            Realname.Attributes.Add("readonly", "readonly");
            CreateDate.Attributes.Add("readonly", "readonly");

            ContractorB.Attributes.Add("readonly", "readonly");


            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";



            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SaleContract.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_yz = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";

            SqlDataReader NewReader_yz = List.GetList(SQL_yz);
            if (NewReader_yz.Read())
            {
                string SQL_mx = "select  * from qp_SaleFieldDIYAdd where keyfile='" + Number.Text + "'  order by PaiXun asc";
                SqlDataReader NewReader_mx = List.GetList(SQL_mx);
                while (NewReader_mx.Read())
                {
                    string Sql_update = "Update qp_SaleFieldDIYAdd  Set ivalue='" + Request.Form["" + NewReader_mx["Number"] + ""] + "'  where Number='" + NewReader_mx["Number"] + "' and  keyfile='" + Number.Text + "' ";
                    List.ExeSql(Sql_update);


                }
            }


            string Sql_update1 = "Update qp_SaleContract  Set KeyId='" + List.GetFormatStr(KeyId.Text) + "',Name='" + List.GetFormatStr(Name.Text) + "',ContractName='" + List.GetFormatStr(ContractName.Text) + "',ContractNum='" + List.GetFormatStr(ContractNum.Text) + "',ContractType='" + List.GetFormatStr(ContractType.Text) + "',ContractMoney='" + List.GetFormatStr(ContractMoney.Text) + "',Description='" + List.GetFormatStr(Description.Text) + "',ContractTerms='" + List.GetFormatStr(ContractTerms.Text) + "',ContractContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',Startime='" + List.GetFormatStr(Startime.Text) + "',Endtime='" + List.GetFormatStr(Endtime.Text) + "',ContractorA='" + List.GetFormatStr(ContractorA.Text) + "',ContractorUser='" + List.GetFormatStr(ContractorUser.Text) + "',ContractorB='" + List.GetFormatStr(ContractorB.Text) + "',CreateDate='" + List.GetFormatStr(CreateDate.Text) + "',Remark='" + List.GetFormatStr(Remark.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update1);
            
            
            
            InsertLog("修改销售合同[" + Name.Text + "]", "销售合同");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='SaleContract.aspx'</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("SaleContract/");
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


                string sql_insert_file = "insert into qp_SaleContractFile (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + List.GetFormatStr(Number.Text) + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传合同附件[" + fileName + "]", "销售合同");
                BindDroList();
            }
        }





    }
}

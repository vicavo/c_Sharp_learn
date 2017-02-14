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
    public partial class EmpContract_update : System.Web.UI.Page
    {
        Db List = new Db();
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

                string SQL_GetList = "select * from qp_EmpContract where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NameId.Text = NewReader["NameId"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    Type.Text = NewReader["Type"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    FormType.Text = NewReader["FormType"].ToString();
                    ContractType.Text = NewReader["ContractType"].ToString();
                    Terms.Text = NewReader["Terms"].ToString();
                    Confident.Text = NewReader["Confident"].ToString();
                    QyTime.Text = System.DateTime.Parse(NewReader["QyTime"].ToString()).ToShortDateString();
                    MyTime.Text = System.DateTime.Parse(NewReader["MyTime"].ToString()).ToShortDateString();
                    Organs.Text = NewReader["Organs"].ToString();
                    QzTime.Text = NewReader["QzTime"].ToString();
                    WeiYue.Text = NewReader["WeiYue"].ToString();
                    OtherContent.Text = NewReader["OtherContent"].ToString();

                    if (NewReader["OldName"].ToString() == "无")
                    {
                        FjInfo.Text = "无";
                    }
                    else
                    {
                        FjInfo.Text = "<a href=EmpContract/" + NewReader["NewName"].ToString() + ">" + NewReader["OldName"].ToString() + "</a>";
                    }


                }
                NewReader.Close();



            }



        }
        public void BindAttribute()
        {
            Name.Attributes.Add("readonly", "readonly");
            QyTime.Attributes.Add("readonly", "readonly");
            MyTime.Attributes.Add("readonly", "readonly");
            QzTime.Attributes.Add("readonly", "readonly");
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return checkForm();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpContract.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            if (C1Fj.Checked == true)
            {
                //上传文件
                string strBaseLocation = Server.MapPath("EmpContract/");
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

                    string Sql_update = "Update qp_EmpContract  Set NameId='" + List.GetFormatStr(NameId.Text) + "',  Name='" + List.GetFormatStr(Name.Text) + "',  Type='" + List.GetFormatStr(Type.SelectedValue) + "',  Number='" + List.GetFormatStr(Number.Text) + "',  FormType='" + List.GetFormatStr(FormType.SelectedValue) + "',  ContractType='" + List.GetFormatStr(ContractType.Text) + "',  Terms='" + List.GetFormatStr(Terms.SelectedValue) + "',  Confident='" + List.GetFormatStr(Confident.Text) + "',  QyTime='" + List.GetFormatStr(QyTime.Text) + "',  MyTime='" + List.GetFormatStr(MyTime.Text) + "',  Organs='" + List.GetFormatStr(Organs.Text) + "',  QzTime='" + List.GetFormatStr(QzTime.Text) + "',  WeiYue='" + List.GetFormatStr(WeiYue.Text) + "',  OtherContent='" + List.GetFormatStr(OtherContent.Text) + "',  NewName='" + TruePath + "',  OldName='" + fileName + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                    List.ExeSql(Sql_update);

                    InsertLog("修改人事合同[" + Name.Text + "]", "人事合同");
                    this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='EmpContract.aspx'</script>");



                }
                else
                {
                    string Sql_update = "Update qp_EmpContract  Set NameId='" + List.GetFormatStr(NameId.Text) + "',  Name='" + List.GetFormatStr(Name.Text) + "',  Type='" + List.GetFormatStr(Type.SelectedValue) + "',  Number='" + List.GetFormatStr(Number.Text) + "',  FormType='" + List.GetFormatStr(FormType.SelectedValue) + "',  ContractType='" + List.GetFormatStr(ContractType.Text) + "',  Terms='" + List.GetFormatStr(Terms.SelectedValue) + "',  Confident='" + List.GetFormatStr(Confident.Text) + "',  QyTime='" + List.GetFormatStr(QyTime.Text) + "',  MyTime='" + List.GetFormatStr(MyTime.Text) + "',  Organs='" + List.GetFormatStr(Organs.Text) + "',  QzTime='" + List.GetFormatStr(QzTime.Text) + "',  WeiYue='" + List.GetFormatStr(WeiYue.Text) + "',  OtherContent='" + List.GetFormatStr(OtherContent.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                    List.ExeSql(Sql_update);


                    InsertLog("修改人事合同[" + Name.Text + "]", "人事合同");
                    this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='EmpContract.aspx'</script>");



                }

            }
            else
            {
                string Sql_update = "Update qp_EmpContract  Set NameId='" + List.GetFormatStr(NameId.Text) + "',  Name='" + List.GetFormatStr(Name.Text) + "',  Type='" + List.GetFormatStr(Type.SelectedValue) + "',  Number='" + List.GetFormatStr(Number.Text) + "',  FormType='" + List.GetFormatStr(FormType.SelectedValue) + "',  ContractType='" + List.GetFormatStr(ContractType.Text) + "',  Terms='" + List.GetFormatStr(Terms.SelectedValue) + "',  Confident='" + List.GetFormatStr(Confident.Text) + "',  QyTime='" + List.GetFormatStr(QyTime.Text) + "',  MyTime='" + List.GetFormatStr(MyTime.Text) + "',  Organs='" + List.GetFormatStr(Organs.Text) + "',  QzTime='" + List.GetFormatStr(QzTime.Text) + "',  WeiYue='" + List.GetFormatStr(WeiYue.Text) + "',  OtherContent='" + List.GetFormatStr(OtherContent.Text) + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("修改人事合同[" + Name.Text + "]", "人事合同");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='EmpContract.aspx'</script>");

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

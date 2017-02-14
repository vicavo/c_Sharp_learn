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
    public partial class EmpContract_add : System.Web.UI.Page
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

                string sql_insert = "insert into qp_EmpContract (NameId,Name,Type,Number,FormType,ContractType,Terms,Confident,QyTime,MyTime,Organs,QzTime,WeiYue,OtherContent,NewName,OldName,Username,Realname,Unit,UnitId,Respon,ResponId,NowTimes,QxString) values ('" + List.GetFormatStr(NameId.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Type.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(FormType.Text) + "','" + List.GetFormatStr(ContractType.Text) + "','" + List.GetFormatStr(Terms.Text) + "','" + List.GetFormatStr(Confident.Text) + "','" + List.GetFormatStr(QyTime.Text) + "','" + List.GetFormatStr(MyTime.Text) + "','" + List.GetFormatStr(Organs.Text) + "','" + List.GetFormatStr(QzTime.Text) + "','" + List.GetFormatStr(WeiYue.Text) + "','" + List.GetFormatStr(OtherContent.Text) + "','" + TruePath + "','" + fileName + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + this.Session["QxString"] + "')";
                List.ExeSql(sql_insert);
                InsertLog("新增人事合同[" + Name.Text + "]", "人事合同");
                this.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='EmpContract.aspx'</script>");

             

            }
            else
            {
                string sql_insert = "insert into qp_EmpContract (NameId,Name,Type,Number,FormType,ContractType,Terms,Confident,QyTime,MyTime,Organs,QzTime,WeiYue,OtherContent,NewName,OldName,Username,Realname,Unit,UnitId,Respon,ResponId,NowTimes,QxString) values ('" + List.GetFormatStr(NameId.Text) + "','" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(Type.Text) + "','" + List.GetFormatStr(Number.Text) + "','" + List.GetFormatStr(FormType.Text) + "','" + List.GetFormatStr(ContractType.Text) + "','" + List.GetFormatStr(Terms.Text) + "','" + List.GetFormatStr(Confident.Text) + "','" + List.GetFormatStr(QyTime.Text) + "','" + List.GetFormatStr(MyTime.Text) + "','" + List.GetFormatStr(Organs.Text) + "','" + List.GetFormatStr(QzTime.Text) + "','" + List.GetFormatStr(WeiYue.Text) + "','" + List.GetFormatStr(OtherContent.Text) + "','无','无','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + this.Session["QxString"] + "')";
                List.ExeSql(sql_insert);
                InsertLog("新增人事合同[" + Name.Text + "]", "人事合同");
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

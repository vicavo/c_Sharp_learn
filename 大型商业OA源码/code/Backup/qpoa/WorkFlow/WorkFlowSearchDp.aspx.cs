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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowSearchDp : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string ddstr, fjkey, FormName, NodeName, UpNodeNum, UpNodeNumKey, NodeId, WriteFileID, lshid, Name, SpModle, JBRObjectId, HyUsername, HyRealname;
        public static int a;
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

                //string SQL_GetList2 = "select * from qp_WorkFlowNode where id='" + int.Parse(Request.QueryString["UpNodeId"]) + "'";
                //SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                //if (NewReader2.Read())
                //{
                //    NodeName = NewReader2["NodeName"].ToString();
                //    UpNodeNum = NewReader2["UpNodeNum"].ToString();
                //    UpNodeNumKey = NewReader2["UpNodeNum"].ToString();
                //    NodeId = NewReader2["id"].ToString();
                //    WriteFileID = "" + NewReader2["WriteFileID"].ToString() + "0";

                //}

                //NewReader2.Close();



                string SQL_GetList = "select * from qp_AddWorkFlow where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NodeName = NewReader["UpNodeName"].ToString();
                    lshid = NewReader["Sequence"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Name = NewReader["Name"].ToString();
                    SpModle = NewReader["SpModle"].ToString();
                    JBRObjectId = NewReader["JBRObjectId"].ToString();
                    HyUsername = NewReader["JBRObjectId"].ToString().Replace("" + Session["username"] + ",", "");
                    HyRealname = NewReader["JBRObjectName"].ToString().Replace("" + Session["realname"] + ",", "");
                    FormName = NewReader["FormName"].ToString();

                }//表单
                NewReader.Close();

            }


            string sql_down_bh = "select Title from qp_UseSpRemark where Username='" + Session["username"].ToString() + "' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList(normalcontent, sql_down_bh, "Title", "Title");
            }//审批备注

            BindDroList();

           
        }
        public void BindAttribute()
        {
         
            Button1.Attributes["onclick"] = "javascript:return showwait();";
         
        }

        public void BindDroList()
        {
            ////附件列表
            //string sql_down_1 = "select * from qp_AddWorkFlowFj where KeyField='" + Number.Text + "'";
            //list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
          


            //上传文件
            string strBaseLocation = Server.MapPath("AddWorkFlowFj/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                Response.Write("a");
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);


   


                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名


                string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','" + fileName + "','" + TruePath + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_inserta);


                InsertLog("上传审批文件[" + fileName + "]", "工作管理");
                BindDroList();
            }
            else
            {
                if (SpContent.Text.Trim() == "")
                {
                   
                 
                }
                else
                {
                    
                    string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','','','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }
            }





            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");





        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

     





    }
}

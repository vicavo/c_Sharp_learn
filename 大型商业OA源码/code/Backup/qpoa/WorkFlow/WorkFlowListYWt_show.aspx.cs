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
    public partial class WorkFlowListYWt_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string FlowNumber,ddstr, fjkey, FormName, NodeName, UpNodeNum, UpNodeNumKey, NodeId, WriteFileID, lshid, Name, SpModle, JBRObjectId, HyUsername, HyRealname;
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
                //string SQL_GetList_fjkey = "select * from qp_FjKey";
                //SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                //if (NewReader_fjkey.Read())
                //{

                //    fjkey = NewReader_fjkey["content"].ToString();

                //}
                //NewReader_fjkey.Close();





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
                //else
                //{
                //    this.Response.Write("<script language=javascript>alert('此流程未找到“启始步骤”，请重新设置此流程！');window.location.href='WorkFlowList.aspx'</script>");
                //    return;
                //}
                //NewReader2.Close();//步骤名称，下一节点，当前节点ID

                string SQL_GetList = "select * from qp_WtWorkFlow where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    lshid = NewReader["Sequence"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Name = NewReader["Name"].ToString();
                    FlowNumber = NewReader["FlowNumber"].ToString();
                    //SpModle = NewReader["SpModle"].ToString();
                    //JBRObjectId = NewReader["JBRObjectId"].ToString();

                    string setfrom = null;
                    setfrom = List.GetFormatStrbjq_show(NewReader["FileContent"].ToString().Replace("BACKGROUND-COLOR:", "").Replace("id=Text1", "readonly").Replace("id=\"Text1\"", "readonly").Replace("id=Text2", "readonly").Replace("id=\"Text2\"", "readonly").Replace("id=Text3", "readonly").Replace("id=\"Text3\"", "readonly"));
                    ContractContent.Text = setfrom;
                    TextBox1.Text = setfrom;
                    FormName = NewReader["FormName"].ToString();
                    Label1.Text = NewReader["WtRealname"].ToString();

                }//表单
                NewReader.Close();

            }

            BindDroList();
        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void BindDroList()
        {
            //附件列表
            //string sql_down_1 = "select * from qp_AddWorkFlowFj where KeyField='" + Number.Text + "'";
            //list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");



            string SQL_rc = "select  * from qp_AddWorkFlowFj where KeyField='" + Number.Text + "' order by id desc";

            SqlDataReader NewReader_rc = List.GetList(SQL_rc);

            this.richeng.Text = null;
            int glTMP2 = 0;
            this.richeng.Text += "<table width=100% border=0 cellspacing=0 cellpadding=4>";
            this.richeng.Text += "<tr>";
            while (NewReader_rc.Read())
            {


                this.richeng.Text += " <td width=100% >·<a href=AddWorkFlow_add_down.aspx?number=" + NewReader_rc["NewName"].ToString() + "  target=_blank>" + NewReader_rc["Name"].ToString() + "</a></td>";

                glTMP2 = glTMP2 + 1;
                if (glTMP2 == 1)
                {
                    richeng.Text += "</tr><TR>";
                    glTMP2 = 0;
                }
            }
            this.richeng.Text += " </table>";
            NewReader_rc.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkFlowListYWt.aspx");
        }

        public void InsertLog(string Name, string MkName)
        {

            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }







    }
}

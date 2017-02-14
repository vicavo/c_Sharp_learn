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
    public partial class WorkFlowSearchCb : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {



                string SQL_GetList2 = "select * from qp_AddWorkFlow where  id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    Title.Text = "催办：请尽快" + NewReader2["UpNodeName"].ToString() + "，催办人（"+Session["realname"]+"）";
                    JBRObjectId.Text = NewReader2["JBRObjectId"].ToString();
                }
                NewReader2.Close();//步骤名称，下一节点，当前节点ID

                JBRObjectId.Attributes.Add("readonly", "readonly");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strlist = null;
            string str1 = null;
            str1 = "" + JBRObjectId.Text + "";
            ArrayList myarr = new ArrayList();
            string[] mystr = str1.Split(',');
            for (int s = 0; s < mystr.Length; s++)
            {
                strlist += "'" + mystr[s] + "',";
            }
            strlist += "'0'";

            string SQL_GetList_xs = "select * from qp_Username where  username in (" + strlist + ") ";
            SqlDataReader NewReader = List.GetList(SQL_GetList_xs);
            while (NewReader.Read())
            {
                if (C1.Checked == true)
                {
                    string sql_insertgly = "insert into qp_Messages  (title,content,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('" + List.GetFormatStr(Title.Text) + "','" + List.GetFormatStr(Title.Text) + "','" + System.DateTime.Now.ToString() + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','系统消息','系统消息','否','WorkFlow/WorkFlowList.aspx','" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "')";
                    List.ExeSql(sql_insertgly);
                }
                if (C2.Checked == true)
                {
                    string sql_insert = "insert into OutBox   (username,Mbno,Msg,SendTime,ComPort,Report,V1,V2,V3,V4,V5) values ('" + Session["realname"] + "(" + Session["username"] + ")','" + NewReader["Shouji"] + "','" + List.GetFormatStr(Title.Text) + "','" + System.DateTime.Now.ToString() + "','0','0','','','','','')";
                    List.ExeSql(sql_insert);
                }
            }
            NewReader.Close();


            this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }
    }
}

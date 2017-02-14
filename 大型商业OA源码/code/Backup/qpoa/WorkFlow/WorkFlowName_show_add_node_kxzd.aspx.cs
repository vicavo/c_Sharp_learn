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
    public partial class WorkFlowName_show_add_node_kxzd : System.Web.UI.Page
    {

        Db List = new Db();
        public string str, tqp, struser, strname, str1, strlist;
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
                BindAttribute();

                string SQL_GetList = "select  *  from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NodeNumber.Text = NewReader["NodeNumber"].ToString();
                    NodeNum.Text = NewReader["NodeNum"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    NodeName.Text = NewReader["NodeName"].ToString();
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    WriteFileID.Text = NewReader["WriteFileID"].ToString();
                }

                NewReader.Close();
                DataBindToDownList();


            }


        }

        public void DataBindToDownList()
        {
            string strlist_n = null, str_n = null;
            str_n = "" + WriteFileID.Text + "";
            ArrayList myarr_n = new ArrayList();
            string[] mystr_n = str_n.Split(',');
            for (int s = 0; s < mystr_n.Length; s++)
            {
                strlist_n += "'" + mystr_n[s] + "',";
            }
            strlist_n += "'0'";



            string sql_down1 = "select * from qp_FormFile   where  id in (" + strlist_n + ")  and KeyFile='" + FormNumber.Text + "' and Type!='[电子印章]'";
            list.Bind_DropDownList_ListBox(TargetListBox, sql_down1, "id", "Name");//已提交ID


            string sql_down2 = "select * from qp_FormFile   where  id not in (" + strlist_n + ") and KeyFile='" + FormNumber.Text + "' and Type!='[电子印章]'";
            list.Bind_DropDownList_ListBox(SourceListBox, sql_down2, "id", "Name");//未提交ID

        }

        public void BindAttribute()
        {
            NodeNum.Attributes.Add("readonly", "readonly");
            NodeName.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            string WriteFileID = null, WriteFileName = null;

            if (TargetListBox.Items.Count > 0)
            {
                for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
                {

                    str = "" + TargetListBox.Items[i].Value + ",";
                    tqp = str.Remove(str.LastIndexOf(","), 1);
                    ArrayList myarr = new ArrayList();
                    string[] mystr = tqp.Split(',');
                    for (int s = 0; s < mystr.Length; s++)
                    {
                        myarr.Add(mystr[s].ToString());

                        //string SQL_GetList = "select  *  from qp_FormFile  where KeyFile=(select Number from qp_DIYForm where id='" + mystr[s] + "')";
                        string SQL_GetList = "select  *  from qp_FormFile  where id='" + mystr[s] + "'";
                        SqlDataReader NewReader = List.GetList(SQL_GetList);
                        if (NewReader.Read())
                        {
                            WriteFileID += ""+NewReader["id"].ToString()+",";
                            WriteFileName += "" + NewReader["name"].ToString() + ",";

                            
                        }
                        NewReader.Close();

                    }


                }



                string Sql_update = "Update qp_WorkFlowNode  Set WriteFileID='" + WriteFileID + "',WriteFileName='" + WriteFileName + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);


            }
            else
            {


                string Sql_update = "Update qp_WorkFlowNode  Set WriteFileID='',WriteFileName='' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
            }




            InsertLog("修改工作流步骤[" + NodeName.Text + "]", "工作流步骤");


            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");


        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int i = 0;

            while (i <= SourceListBox.Items.Count - 1)
            {

                if (SourceListBox.Items[i].Selected)
                {
                    if (TargetListBox.Items.IndexOf(SourceListBox.Items[i]) >= 0)
                    {
                        this.Response.Write("<script language=javascript>alert('此项已经存在！');</script>");
                        return;
                    }

                    TargetListBox.Items.Add(new ListItem(SourceListBox.Items[i].Text, SourceListBox.Items[i].Value));
                    SourceListBox.Items.Remove(SourceListBox.Items[i]);
                }
                else
                    i += 1;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (SourceListBox.Items.Count > 0)
            {
                foreach (ListItem MyItem in SourceListBox.Items)
                    TargetListBox.Items.Add(MyItem);


                SourceListBox.Items.Clear();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int i = 0;

            while (i <= TargetListBox.Items.Count - 1)
            {

                if (TargetListBox.Items[i].Selected)
                {
                    SourceListBox.Items.Add(new ListItem(TargetListBox.Items[i].Text, TargetListBox.Items[i].Value));
                    TargetListBox.Items.Remove(TargetListBox.Items[i]);
                }
                else
                    i += 1;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TargetListBox.Items.Count > 0)
            {
                foreach (ListItem MyItem in TargetListBox.Items)
                    SourceListBox.Items.Add(MyItem);


                TargetListBox.Items.Clear();
            }
        }



    }
}

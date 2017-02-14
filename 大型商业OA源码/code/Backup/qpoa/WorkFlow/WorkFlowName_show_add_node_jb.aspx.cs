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
    public partial class WorkFlowName_show_add_node_jb : System.Web.UI.Page
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
                //string sql_down_bh = "select id,Linew+name as aaa  from qp_WorkFlowNodeGD  order by QxString asc";

                //if (!IsPostBack)
                //{
                //    list.Bind_DropDownList_gd(OverSetCon, sql_down_bh, "id", "aaa");
                //}

                BindAttribute();

                string SQL_GetList = "select  *  from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NodeNumber.Text = NewReader["NodeNumber"].ToString();
                    NodeNum.Text = NewReader["NodeNum"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    NodeName.Text = NewReader["NodeName"].ToString();
                    SpModle.SelectedValue = NewReader["SpModle"].ToString();
                    SpChoice.SelectedValue = NewReader["SpChoice"].ToString();
                    EndtimeSet.Text = NewReader["EndtimeSet"].ToString();
                    StopSp.SelectedValue = NewReader["StopSp"].ToString();
                    UpNodeNum.Text = NewReader["UpNodeNum"].ToString();
                    NodeSite.SelectedValue = NewReader["NodeSite"].ToString();
                    //OverSetCon.SelectedValue = NewReader["OverSetConId"].ToString();

                    AllowDelFile.SelectedValue = NewReader["AllowDelFile"].ToString();
                    AllowFile.SelectedValue = NewReader["AllowFile"].ToString();
                }

                NewReader.Close();
                DataBindToDownList();


            }


        }

        public void DataBindToDownList()
        {
            string strlist_n = null, str_n = null;
            str_n = "" + UpNodeNum.Text + "";
            ArrayList myarr_n = new ArrayList();
            string[] mystr_n = str_n.Split(',');
            for (int s = 0; s < mystr_n.Length; s++)
            {
                strlist_n += "'" + mystr_n[s] + "',";
            }
            strlist_n += "'0'";



            string sql_down1 = "select * from qp_WorkFlowNode   where  NodeNum in (" + strlist_n + ")  and FlowNumber='" + FlowNumber.Text+ "'";
            list.Bind_DropDownList_ListBox(TargetListBox, sql_down1, "NodeNum", "NodeName");//已提交ID


            string sql_down2 = "select * from qp_WorkFlowNode   where  NodeNum not in (" + strlist_n + ") and FlowNumber='" + FlowNumber.Text + "'";
            list.Bind_DropDownList_ListBox(SourceListBox, sql_down2, "NodeNum", "NodeName");//未提交ID

        }

        public void BindAttribute()
        {
            NodeNum.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            //int SETLEFT, SETTOP, SETLEFT1, SETTOP1, Pnum;
           // Pnum = int.Parse(NodeNum.Text) + 1;
            string LineContent = null, UpNodeNum = null;

            string Sql_del3 = " Delete from qp_WorkFlowNodeLine where Source='" + NodeNum.Text + "' and FlowNumber='" + FlowNumber.Text+ "'";
            List.ExeSql(Sql_del3);//删除线

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

                        LineContent = "<vml:line title=\"\" style=\"DISPLAY: none; Z-INDEX: 2; POSITION: absolute\" to=\"0,0\" from=\"0,0\" coordsize=\"21600,21600\" arcsize=\"4321f\" object=\"" + mystr[s] + "\" source=\"" + NodeNum.Text + "\" mfrID=\"" + NodeNum.Text + "\"><vml:stroke endarrow=\"block\"></vml:stroke><vml:shadow offset=\"1px,1px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow></vml:line>";
                        string sql_insert = "insert into qp_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + NodeNum.Text + "','" + mystr[s] + "','" + LineContent + "','" + List.GetFormatStr(NodeNumber.Text) + "','" + List.GetFormatStr(FlowNumber.Text) + "')";
                        List.ExeSql(sql_insert);

                        UpNodeNum += "" + mystr[s] + ",";
                    }


                }

                //string sql_insert1 = "insert into qp_WorkFlowNode (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,JBRObjectId,JBRObjectName,JBBMObjectId,JBBMObjectName,JBJSObjectId,JBJSObjectName,SpModle,SpChoice,EndtimeSet,StopSp,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,UpNodeNum,NodeSite,OverSetConId,OverSetConName) values ('" + List.GetFormatStr(FormId.Text) + "','" + List.GetFormatStr(FormNumber.Text) + "','" + List.GetFormatStr(FormName.Text) + "','" + List.GetFormatStr(FlowId.Text) + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(NodeNumber.Text) + "','" + List.GetFormatStr(NodeNum.Text) + "','" + List.GetFormatStr(NodeName.Text) + "','" + SETLEFT1 + "','" + SETTOP1 + "','未设置','未设置','未设置','未设置','未设置','未设置','" + SpModle.SelectedValue + "','" + SpChoice.SelectedValue + "','" + List.GetFormatStr(EndtimeSet.Text) + "','" + StopSp.SelectedValue + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + UpNodeNum + "','" + NodeSite.SelectedValue + "','" + OverSetCon.SelectedValue + "','" + OverSetCon.SelectedItem.Text + "')";
                //List.ExeSql(sql_insert1);

                string Sql_update = "Update qp_WorkFlowNode  Set AllowDelFile='" + AllowDelFile.SelectedValue + "',AllowFile='" + AllowFile.SelectedValue + "',NodeName='" + List.GetFormatStr(NodeName.Text) + "',SpModle='" + List.GetFormatStr(SpModle.SelectedValue) + "',SpChoice='" + List.GetFormatStr(SpChoice.SelectedValue) + "',EndtimeSet='" + List.GetFormatStr(EndtimeSet.Text) + "',StopSp='" + List.GetFormatStr(StopSp.SelectedValue) + "',UpNodeNum='" + UpNodeNum + "',NodeSite='" + NodeSite.SelectedValue + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);


            }
            else
            {




                string Sql_update = "Update qp_WorkFlowNode  Set AllowDelFile='" + AllowDelFile.SelectedValue + "',AllowFile='" + AllowFile.SelectedValue + "',NodeName='" + List.GetFormatStr(NodeName.Text) + "',SpModle='" + List.GetFormatStr(SpModle.SelectedValue) + "',SpChoice='" + List.GetFormatStr(SpChoice.SelectedValue) + "',EndtimeSet='" + List.GetFormatStr(EndtimeSet.Text) + "',StopSp='" + List.GetFormatStr(StopSp.SelectedValue) + "',UpNodeNum='',NodeSite='" + NodeSite.SelectedValue + "'  where id='" + int.Parse(Request.QueryString["id"]) + "'";
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

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
    public partial class WorkFlowName_show_add_node_zj : System.Web.UI.Page
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

                string SQL_GetListzj = "select  *  from qp_WorkFlowNode where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReaderzj = List.GetList(SQL_GetListzj);
                if (NewReaderzj.Read())
                {
                    shangbu.Text = NewReaderzj["NodeNum"].ToString();
                }
                NewReaderzj.Close();



                string SQL_GetList = "select top 1 *  from qp_WorkFlowNode where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "' order by NodeNum desc";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    NodeSite.SelectedValue = "中间段";
                    NodeNum.Text += int.Parse(NewReader["NodeNum"].ToString()) + 1;
                    FormId.Text = NewReader["FormId"].ToString();
                    FormNumber.Text = NewReader["FormNumber"].ToString();
                    FormName.Text = NewReader["FormName"].ToString();
                    FlowId.Text = NewReader["FlowId"].ToString();
                    FlowNumber.Text = NewReader["FlowNumber"].ToString();
                    FlowName.Text = NewReader["FlowName"].ToString();

                }
                else
                {
                    NodeSite.SelectedValue = "开始";
                    NodeNum.Text = "1";
                    string SQL_GetList1 = "select  *  from qp_WorkFlowName where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        FormId.Text = NewReader1["FormId"].ToString();
                        FormNumber.Text = NewReader1["FormNumber"].ToString();
                        FormName.Text = NewReader1["FormName"].ToString();
                        FlowId.Text = NewReader1["id"].ToString();
                        FlowNumber.Text = NewReader1["FlowNumber"].ToString();
                        FlowName.Text = NewReader1["FlowName"].ToString();



                    }
                    NewReader1.Close();



                }

                NewReader.Close();


                DataBindToDownList();


            }

            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                NodeNumber.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }


        }

        public void DataBindToDownList()
        {

            string sql_down1 = "select * from qp_WorkFlowNode  where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "'";
            list.Bind_DropDownList_ListBox(SourceListBox, sql_down1, "NodeNum", "NodeName");



            //string sql_down_bh = "select id,Linew+name as aaa  from qp_WorkFlowNodeGD  order by QxString asc";

            //if (!IsPostBack)
            //{
            //    list.Bind_DropDownList_gd(OverSetCon, sql_down_bh, "id", "aaa");
            //}


        }

        public void BindAttribute()
        {
            //QxRealname.Attributes.Add("readonly", "readonly");
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_GetList2 = "select top 1 * from qp_WorkFlowNode where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "' and NodeNum='" + NodeNum.Text + "' ";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                this.Response.Write("<script language=javascript>alert('序号重复！');</script>");
                return;
            }
            NewReader2.Close();//判断序号是否重复






            if (NodeSite.SelectedValue == "开始")
            {
                string SQL_GetList3 = "select top 1 * from qp_WorkFlowNode where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "' and NodeSite='开始' ";
                SqlDataReader NewReader3 = List.GetList(SQL_GetList3);
                if (NewReader3.Read())
                {
                    this.Response.Write("<script language=javascript>alert('“开始”步骤已经存在！');</script>");
                    return;
                }
                NewReader3.Close();//判断是否已存在开始步骤
            }

            //if (NodeSite.SelectedValue == "结束")
            //{
            //    string SQL_GetList4 = "select top 1 * from qp_WorkFlowNode where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "' and NodeSite='结束' ";
            //    SqlDataReader NewReader4 = List.GetList(SQL_GetList4);
            //    if (NewReader4.Read())
            //    {
            //        this.Response.Write("<script language=javascript>alert('“结束”步骤已经存在！');</script>");
            //        return;
            //    }
            //    NewReader4.Close();//判断是否已存在结束步骤
            //}




            int SETLEFT, SETTOP, SETLEFT1, SETTOP1, Pnum;
            Pnum = int.Parse(NodeNum.Text) + 1;
            string LineContent = null, UpNodeNum = null;


            string SQL_GetList = "select top 1 * from qp_WorkFlowNode where FlowNumber='" + List.GetFormatStr(Request.QueryString["FlowNumber"]) + "' and NodeNum<'" + NodeNum.Text + "' order by NodeNum desc";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {

                SETTOP = int.Parse(NewReader["SETTOP"].ToString());
                if (SETTOP == 20)
                {
                    SETTOP1 = 200;
                }
                else
                {
                    SETTOP1 = 20;
                }

                SETLEFT = int.Parse(NewReader["NodeNum"].ToString());

                if (SETLEFT % 2 == 0)
                {
                    SETLEFT1 = int.Parse(NewReader["SETLEFT"].ToString()) + 180;
                }
                else
                {
                    SETLEFT1 = int.Parse(NewReader["SETLEFT"].ToString());
                }

            }
            else
            {
                SETLEFT1 = 20;
                SETTOP1 = 20;

            }

            NewReader.Close();


            string LineContent1 = null;

            LineContent1 = "<vml:line title=\"\" style=\"DISPLAY: none; Z-INDEX: 2; POSITION: absolute\" to=\"0,0\" from=\"0,0\" coordsize=\"21600,21600\" arcsize=\"4321f\" object=\"" + NodeNum.Text + "\" source=\"" + shangbu.Text + "\" mfrID=\"" + shangbu.Text + "\"><vml:stroke endarrow=\"block\"></vml:stroke><vml:shadow offset=\"1px,1px\" color=\"#b3b3b3\" type=\"single\" on=\"T\"></vml:shadow></vml:line>";
            string sql_inserta = "insert into qp_WorkFlowNodeLine (Source,Object,LineContent,NodeNumber,FlowNumber) values ('" + shangbu.Text + "','" + NodeNum.Text + "','" + LineContent1 + "','" + List.GetFormatStr(NodeNumber.Text) + "','" + List.GetFormatStr(FlowNumber.Text) + "')";
            List.ExeSql(sql_inserta);


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



                string sql_insert1 = "insert into qp_WorkFlowNode (AllowFile,AllowDelFile,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,JBRObjectId,JBRObjectName,JBBMObjectId,JBBMObjectName,JBJSObjectId,JBJSObjectName,SpModle,SpChoice,EndtimeSet,StopSp,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,UpNodeNum,NodeSite) values ('" + List.GetFormatStr(AllowFile.SelectedValue) + "','" + List.GetFormatStr(AllowDelFile.SelectedValue) + "','" + List.GetFormatStr(FormId.Text) + "','" + List.GetFormatStr(FormNumber.Text) + "','" + List.GetFormatStr(FormName.Text) + "','" + List.GetFormatStr(FlowId.Text) + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(NodeNumber.Text) + "','" + List.GetFormatStr(NodeNum.Text) + "','" + List.GetFormatStr(NodeName.Text) + "','" + SETLEFT1 + "','" + SETTOP1 + "','0','未设置','0','未设置','0','未设置','" + SpModle.SelectedValue + "','" + SpChoice.SelectedValue + "','" + List.GetFormatStr(EndtimeSet.Text) + "','" + StopSp.SelectedValue + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + UpNodeNum + "','" + NodeSite.SelectedValue + "')";
                List.ExeSql(sql_insert1);

            }
            else
            {

                string sql_insert1 = "insert into qp_WorkFlowNode (AllowFile,AllowDelFile,UpNodeNum,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,SETLEFT,SETTOP,JBRObjectId,JBRObjectName,JBBMObjectId,JBBMObjectName,JBJSObjectId,JBJSObjectName,SpModle,SpChoice,EndtimeSet,StopSp,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,NodeSite) values ('" + List.GetFormatStr(AllowFile.SelectedValue) + "','" + List.GetFormatStr(AllowDelFile.SelectedValue) + "','','" + List.GetFormatStr(FormId.Text) + "','" + List.GetFormatStr(FormNumber.Text) + "','" + List.GetFormatStr(FormName.Text) + "','" + List.GetFormatStr(FlowId.Text) + "','" + List.GetFormatStr(FlowNumber.Text) + "','" + List.GetFormatStr(FlowName.Text) + "','" + List.GetFormatStr(NodeNumber.Text) + "','" + List.GetFormatStr(NodeNum.Text) + "','" + List.GetFormatStr(NodeName.Text) + "','" + SETLEFT1 + "','" + SETTOP1 + "','0','未设置','0','未设置','0','未设置','" + SpModle.SelectedValue + "','" + SpChoice.SelectedValue + "','" + List.GetFormatStr(EndtimeSet.Text) + "','" + StopSp.SelectedValue + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + NodeSite.SelectedValue + "')";
                List.ExeSql(sql_insert1);

            }


            string Sql_updateb = "Update qp_WorkFlowNode  Set UpNodeNum=UpNodeNum+'" + List.GetFormatStr(NodeNum.Text) + ",'  where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_updateb);
           //Response.Write(Sql_updateb);
            InsertLog("追加工作流步骤[" + NodeName.Text + "]", "工作流步骤");


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

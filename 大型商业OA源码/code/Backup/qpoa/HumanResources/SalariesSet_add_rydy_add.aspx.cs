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
    public partial class SalariesSet_add_rydy_add : System.Web.UI.Page
    {

        Db List = new Db();
        public string str, tqp, struser, strname, str1, strlist;
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DataBindToDownList("按人员设置");
                KeyBox.Text = "按人员设置";
                BindAttribute();
                BindTree(ListTreeView.Nodes, 0);

                //requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());


                //str1 = "" + requeststr.Text + "";
                //ArrayList myarr = new ArrayList();
                //string[] mystr = str1.Split(',');
                //for (int s = 0; s < mystr.Length; s++)
                //{
                //    strlist += "'" + mystr[s] + "',";
                //}
                //strlist += "'0'";

                //if (Request.QueryString["requeststr"] != null)
                //{
                //    string sql_down1 = "select * from qp_Username  where username in (" + strlist + ")";
                //    list.Bind_DropDownList_ListBox(TargetListBox, sql_down1, "Username", "Realname");

                //}

            }


        }
        public void DataBindToDownList(string SqlFile)
        {

            if (SqlFile == "按人员设置")
            {

                ListBox1.Items.Clear();
                string sql_down1 = "select * from qp_Username";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down1, "Username", "Realname");
            }

            if (SqlFile == "按部门设置")
            {
                string sql_down = "select * from qp_UnitName";
                list.Bind_DropDownList_ListBox(ListBox1, sql_down, "Id", "Name");
            }
            if (SqlFile == "按角色设置")
            {
                string sql_down = "select * from qp_Respon";
                list.Bind_DropDownList_ListBox(ListBox1, sql_down, "Id", "Name");
            }
            if (SqlFile == "按职位设置")
            {
                string sql_down = "select * from qp_PostName";
                list.Bind_DropDownList_ListBox(ListBox1, sql_down, "Id", "Name");
            }
        }

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string SQL_GetList = "select * from qp_UnitName where ParentNodesID=" + IDStr.ToString() + " ";
            SqlDataReader MyReader = List.GetList(SQL_GetList);


            while (MyReader.Read())
            {
                if (IDStr == 0)
                {
                    TreeNode OrganizationNode = new TreeNode();

                    OrganizationNode.Text = " " + MyReader["Name"].ToString();
                    OrganizationNode.Value = MyReader["ID"].ToString();
                    int strId = int.Parse(MyReader["ID"].ToString());
                    OrganizationNode.ImageUrl = "../images/parent.gif";
                    // OrganizationNode.NavigateUrl = "UnitName_show.aspx?id=" + strId + "";
                    OrganizationNode.Expanded = false;
                    //   OrganizationNode.Target = "unitform";
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
                }
                else
                {

                    TreeNode OrganizationNode = new TreeNode();

                    OrganizationNode.Text = " " + MyReader["Name"].ToString();
                    OrganizationNode.Value = MyReader["ID"].ToString();
                    int strId = int.Parse(MyReader["ID"].ToString());
                    OrganizationNode.ImageUrl = "../images/child.gif";
                    //  OrganizationNode.NavigateUrl = "UnitName_show.aspx?id=" + strId + "";
                    OrganizationNode.Expanded = false;
                    //  OrganizationNode.Target = "unitform";
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, strId);

                }
            }
            MyReader.Close();

        }


        public void DataBindUser(string SqlFile)
        {



            if (KeyBox.Text == "按部门设置")
            {
                string sql_down = "select * from qp_Username where UnitId='" + ListTreeView.SelectedValue + "'";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Username", "Realname");
            }
            if (KeyBox.Text == "按角色设置")
            {
                string sql_down = "select * from qp_Username  where ResponId='" + ListBox1.SelectedValue + "'";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Username", "Realname");
            }
            if (KeyBox.Text == "按职位设置")
            {
                string sql_down = "select * from qp_Username  where PostId='" + ListBox1.SelectedValue + "'";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Username", "Realname");
            }


        }






        public void BindAttribute()
        {
            Button11.Attributes["onclick"] = "javascript:return checkbutton();";
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

        protected void Button1_Click(object sender, EventArgs e)
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

        protected void Button7_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            SourceListBox.Items.Clear();
            DataBindToDownList("按人员设置");
            KeyBox.Text = "按人员设置";
            ListBox1.Visible = true;
            ListTreeView.Visible = false;

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            SourceListBox.Items.Clear();
            //  DataBindToDownList("按部门设置");
            KeyBox.Text = "按部门设置";
            ListBox1.Visible = false;
            ListTreeView.Visible = true;
        }

        protected void Button9_Click(object sender, EventArgs e)
        {

            KeyBox.Text = null;
            SourceListBox.Items.Clear();
            DataBindToDownList("按角色设置");
            KeyBox.Text = "按角色设置";
            ListBox1.Visible = true;
            ListTreeView.Visible = false;
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            SourceListBox.Items.Clear();
            DataBindToDownList("按职位设置");
            KeyBox.Text = "按职位设置";
            ListBox1.Visible = true;
            ListTreeView.Visible = false;
        }


        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindUser(ListBox1.SelectedValue);
        }

        protected void ListTreeView_SelectedNodeChanged(object sender, EventArgs e)
        {
            DataBindUser(ListTreeView.SelectedValue);
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            struser = null;

            for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
            {

                str = "" + TargetListBox.Items[i].Value + ",";
                tqp = str.Remove(str.LastIndexOf(","), 1);
                ArrayList myarr = new ArrayList();
                string[] mystr = tqp.Split(',');
                for (int s = 0; s < mystr.Length; s++)
                {
                    myarr.Add(mystr[s].ToString());

                    string SQL_GetList1 = "select * from qp_Username where username='" + mystr[s] + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        string sql_insertgly = "insert into qp_SaPerson  (Username,Realname,UnitId,Unit,JbMoney,SaNumber) values ('" + NewReader1["username"] + "','" + NewReader1["realname"] + "','" + NewReader1["UnitId"] + "','" + NewReader1["Unit"] + "','" + JbMoney.Text + "','" + Request.QueryString["Number"] + "')";
                        List.ExeSql(sql_insertgly);
                    }
                    NewReader1.Close();

                }

            }

            this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesSet_add_rydy.aspx?number=" + Request.QueryString["number"] + "';window.close();</script>");


        }
    }
}

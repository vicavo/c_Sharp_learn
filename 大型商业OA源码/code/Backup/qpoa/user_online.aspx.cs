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
namespace qpoa
{
    public partial class user_online : System.Web.UI.Page
    {
        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindTree(ListTreeView.Nodes, 0);
        }

        private void BindTree(TreeNodeCollection Nds, int IDStr)
        {
            string SQL_GetList = "select id,Name,ParentNodesID from qp_UnitName where ParentNodesID=" + IDStr.ToString() + "   order by id asc";
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                if (IDStr == 0)
                {
                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Value = MyReader["ID"].ToString();
                    int strId = int.Parse(MyReader["ID"].ToString());
                    OrganizationNode.ImageUrl = "/images/menu/zhu.gif";
                    OrganizationNode.Text = "" + MyReader["Name"].ToString() + "";
                    OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                    OrganizationNode.Expanded = true;
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, strId);

                    string SQL_GetListry = "select A.id,A.username, A.realname,A.lasttime from [qp_username] as [A] where [A].[UnitId]='" + MyReader["ID"].ToString() + "' and datediff(ss,lasttime,getdate())<=10 order by A.id asc";

                    SqlDataReader MyReaderry = List.GetList(SQL_GetListry);
                    while (MyReaderry.Read())
                    {
                        TreeNode OrganizationNode1 = new TreeNode();
                        OrganizationNode1.Value = MyReaderry["ID"].ToString();
                        int strId1 = int.Parse(MyReaderry["ID"].ToString());

                        DateTime dt1 = Convert.ToDateTime(System.DateTime.Now.ToString());

                        DateTime dt2 = Convert.ToDateTime(MyReaderry["lasttime"].ToString());
                        TimeSpan ts = dt1 - dt2;
                        //Response.Write("" + MyReaderry["realname"].ToString() + "：" + ts.TotalSeconds + "<br>");
                        if (ts.TotalSeconds < 10)
                        {
                            OrganizationNode1.ImageUrl = "/images/menu/on1.gif";
                        }
                        else
                        {
                            OrganizationNode1.ImageUrl = "/images/menu/on2.gif";
                        }

                        OrganizationNode1.Text = "<a href=MyData.aspx?user=" + MyReaderry["username"].ToString() + " onclick='parent.UploadComplete();'  target=rform><font color=#000000>" + MyReaderry["realname"].ToString() + "</font></a>[<a href='InfoSpeech/Messages_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>消息</a>][<a href='InfoSpeech/NbMailAccept_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>邮件</a>][<a href='InfoSpeech/MvTo_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>短信</a>]";
                        OrganizationNode1.SelectAction = TreeNodeSelectAction.Expand;
                        OrganizationNode1.Expanded = true;
                        OrganizationNode.ChildNodes.Add(OrganizationNode1);
                    }
                    MyReaderry.Close();
                }
                else
                {

                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Value = MyReader["ID"].ToString();
                    int strId = int.Parse(MyReader["ID"].ToString());
                    OrganizationNode.ImageUrl = "/images/menu/homepage.gif";
                    OrganizationNode.Text = " " + MyReader["Name"].ToString() + "";
                    OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                    OrganizationNode.Expanded = true;
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, strId);

                    string SQL_GetListry = "select A.id,A.username, A.realname,A.lasttime from [qp_username] as [A] where [A].[UnitId]='" + MyReader["ID"].ToString() + "' and datediff(ss,lasttime,getdate())<=10 order by A.id asc";
                    SqlDataReader MyReaderry = List.GetList(SQL_GetListry);
                    while (MyReaderry.Read())
                    {
                        TreeNode OrganizationNode1 = new TreeNode();
                        OrganizationNode1.Value = MyReaderry["ID"].ToString();
                        int strId1 = int.Parse(MyReaderry["ID"].ToString());

                        DateTime dt1 = Convert.ToDateTime(System.DateTime.Now.ToString());

                        DateTime dt2 = Convert.ToDateTime(MyReaderry["lasttime"].ToString());
                        TimeSpan ts = dt1 - dt2;

                        //Response.Write("" + MyReaderry["realname"].ToString() + "：" + ts.TotalSeconds + "<br>");
                        if (ts.TotalSeconds < 10)
                        {
                            OrganizationNode1.ImageUrl = "/images/menu/on1.gif";
                        }
                        else
                        {
                            OrganizationNode1.ImageUrl = "/images/menu/on2.gif";
                        }

                        OrganizationNode1.Text = "<a href=MyData.aspx?user=" + MyReaderry["username"].ToString() + " onclick='parent.UploadComplete();'  target=rform><font color=#000000>" + MyReaderry["realname"].ToString() + "</font></a>[<a href='InfoSpeech/Messages_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>消息</a>][<a href='InfoSpeech/NbMailAccept_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>邮件</a>][<a href='InfoSpeech/MvTo_add.aspx?user=" + MyReaderry["username"].ToString() + "&name=" + MyReaderry["realname"].ToString() + "' onclick='parent.UploadComplete();' target=rform>短信</a>]";

                        OrganizationNode1.SelectAction = TreeNodeSelectAction.Expand;
                        OrganizationNode1.Expanded = true;
                        OrganizationNode.ChildNodes.Add(OrganizationNode1);
                    }
                    MyReaderry.Close();
                }
            }
            MyReader.Close();

        }
    }
}

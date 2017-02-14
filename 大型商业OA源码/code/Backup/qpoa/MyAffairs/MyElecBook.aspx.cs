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
namespace qpoa.MyAffairs
{
    public partial class MyElecBook : System.Web.UI.Page
    {

        Db List = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindTree(ListTreeView.Nodes, "", "0", "0");
            }
        }

        private void BindTree(TreeNodeCollection Nds, string Share, string IDStr, string PID)
        {

            string SQL_GetList = "select * from qp_ElecBook where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
          
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                string SQL_GetList1 = "select * from qp_ElecBook where (id=" + MyReader["id"] + " and (( CHARINDEX('," + this.Session["Username"] + ",',','+GxUsername+',')   >   0  ) or (CHARINDEX('," + this.Session["Username"] + ",',','+(select GxUsername from qp_ElecBook where id='" + MyReader["ParentNodesID"] + "')+',')   >   0 ))) ";
              
                SqlDataReader MyReader1 = List.GetList(SQL_GetList1);
                if (MyReader1.Read())
                {
                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Text = "  " + MyReader["Name"].ToString() + "";
                    OrganizationNode.Value = MyReader["ID"].ToString();
                    string strId = MyReader["ID"].ToString();
                    string strId1 = MyReader["ParentNodesID"].ToString();
                    if (MyReader["IfShare"].ToString() == "是")
                    {
                        OrganizationNode.ImageUrl = "../images/shareFolder.gif";
                    }
                    else
                    {
                        OrganizationNode.ImageUrl = "../images/folder.gif";
                    }
                    OrganizationNode.NavigateUrl = "MyElecBook_show.aspx?id=" + strId + "";
                    OrganizationNode.Expanded = false;
                 
                    OrganizationNode.Target = "foldersform";
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, "", strId, strId1);

                }
                else
                {
                 
                    string strId = MyReader["ID"].ToString();
                    string strId1 = MyReader["ParentNodesID"].ToString();
                    BindTree(Nds, "", strId, strId1);
                }

            }
            MyReader.Close();

        }






    }
}

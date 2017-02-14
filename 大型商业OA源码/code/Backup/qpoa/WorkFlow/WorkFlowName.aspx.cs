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
    public partial class WorkFlowName : System.Web.UI.Page
    {
        Db List = new Db();
        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;

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
                BindTree();
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(ListTreeView, "bb3bb3a", Session["perstr"].ToString());


        }
        public void BindAttribute()
        {

            //IMG1.Attributes["onclick"] = "javascript:return showwait();";

        }
        private void BindTree()
        {
            string SQL_GetList = "select * from qp_FormType  order by id desc";
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Text = " " + MyReader["Name"].ToString();
                    OrganizationNode.Value = MyReader["Name"].ToString();
                    OrganizationNode.Expanded = false;
                    OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                    OrganizationNode.ImageUrl = "../images/folder.gif";

                    string SQL_GetFile = "select id,FormName from qp_DIYForm where TypeId='" + MyReader["id"].ToString() + "'";
                    SqlDataReader FileReader = List.GetList(SQL_GetFile);
                    while (FileReader.Read())
                    {
                        TreeNode OrganizationNode1 = new TreeNode();

                        OrganizationNode1.Text = " " + FileReader["FormName"].ToString();
                        OrganizationNode1.Value = FileReader["ID"].ToString();
                        int strId = int.Parse(FileReader["ID"].ToString());
                        OrganizationNode1.NavigateUrl = "WorkFlowName_show.aspx?FormId=" + strId + "";
                        OrganizationNode1.Expanded = false;
                        OrganizationNode1.ImageUrl = "../images/child.gif";
                        OrganizationNode1.Target = "foldersform";

                        OrganizationNode.ChildNodes.Add(OrganizationNode1);

                    }
                    FileReader.Close();
                    ListTreeView.Nodes.Add(OrganizationNode);
             
            }
            MyReader.Close();

        }






    }
}

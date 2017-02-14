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
    public partial class Folders_gx : System.Web.UI.Page
    {

//        Db List = new Db();
//        public static string CountsLabel, AllPageLabel, CurrentlyPageLabel, SqlStrStart, SqlStrMid, SqlStr, SqlStrStartCount, SqlStrCount;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (this.Session["username"] == null)
//            {
//                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
//                return;

//            }

//            if (!Page.IsPostBack)
//            {
//                BindAttribute();
//                BindTree(ListTreeView.Nodes,"是");
//                Bindquanxian();

//            }
//        }
//        public void Bindquanxian()
//        {
//            List.QuanXianVis(IMG1, "1111k", Session["perstr"].ToString());


//        }
//        public void BindAttribute()
//        {

//            //IMG1.Attributes["onclick"] = "javascript:return showwait();";

//        }
//        private void BindTree(TreeNodeCollection Nds, string IDStr)
//        {
//            string SQL_GetList = "select * from qp_Folders where  IfShare='" + IDStr.ToString() + "'  order by PxNum asc";
//            SqlDataReader MyReader = List.GetList(SQL_GetList);


//            while (MyReader.Read())
//            {

//                    if (IDStr == "0")
//                    {
                        
//                        TreeNode OrganizationNode = new TreeNode();

//                        OrganizationNode.Text = " " + MyReader["Name"].ToString();
//                        OrganizationNode.Value = MyReader["ID"].ToString();
//                        string strId = MyReader["ID"].ToString();
//                        if (MyReader["IfShare"].ToString() == "是")
//                        {
//                            OrganizationNode.ImageUrl = "../images/shareFolder.gif";
//                        }
//                        else
//                        {
//                            OrganizationNode.ImageUrl = "../images/folder.gif";
//                        }


//                        OrganizationNode.NavigateUrl = "FoldersGx_show.aspx?id=" + strId + "";
//                        OrganizationNode.Expanded = false;
//                        OrganizationNode.Target = "foldersform";
//                        Nds.Add(OrganizationNode);
//                        BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
                     
                    
//                    }
//                    else
//                    {
                       

//                        TreeNode OrganizationNode = new TreeNode();

//                        OrganizationNode.Text = " " + MyReader["Name"].ToString();
//                        OrganizationNode.Value = MyReader["ID"].ToString();
//                        string strId = MyReader["ID"].ToString();
//                        if (MyReader["IfShare"].ToString() == "是")
//                        {
//                            OrganizationNode.ImageUrl = "../images/shareFolder.gif";
//                        }
//                        else
//                        {
//                            OrganizationNode.ImageUrl = "../images/folder.gif";
//                        }
//                        OrganizationNode.NavigateUrl = "FoldersGx_show.aspx?id=" + strId + "";
//                        OrganizationNode.Expanded = false;
//                        OrganizationNode.Target = "foldersform";
//                        Nds.Add(OrganizationNode);
//                        BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
                      
                     
//                    }
              
//            }
//            MyReader.Close();

//        }






//    }
//}
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



            string SQL_GetList = "select * from qp_Folders where (ParentNodesID=" + IDStr.ToString() + ")  order by id asc";
            //Response.Write("" + SQL_GetList + "<br>");
            SqlDataReader MyReader = List.GetList(SQL_GetList);
            while (MyReader.Read())
            {
                string SQL_GetList1 = "select * from qp_Folders where (id=" + MyReader["id"] + " and (( CHARINDEX('," + this.Session["Username"] + ",',','+GxUsername+',')   >   0  and  IfShare='是') or (CHARINDEX('," + this.Session["Username"] + ",',','+(select GxUsername from qp_Folders where id='" + MyReader["ParentNodesID"] + "')+',')   >   0  and  (select IfShare from qp_Folders where id='" + MyReader["ParentNodesID"] + "')='是'))) ";
                //string SQL_GetList1 = "select * from qp_Folders where (CHARINDEX('," + this.Session["Username"] + ",',','+GxUsername+',')   >   0  and  id=" + MyReader["id"] + " and ( IfShare='是' or ((select IfShare from qp_Folders where id='" + MyReader["ParentNodesID"] + "')='是'))) or  (id=" + MyReader["id"] + " and ( IfShare='是' or (CHARINDEX('," + this.Session["Username"] + ",',','+(select GxUsername from qp_Folders where id='" + MyReader["ParentNodesID"] + "')+',')   >   0  and  (select IfShare from qp_Folders where id='" + MyReader["ParentNodesID"] + "')='是'))) ";
               // string SQL_GetList1 = "select * from qp_Folders where (id=" + MyReader["id"] + " and ( IfShare='是' or ((select IfShare from qp_Folders where id='" + MyReader["ParentNodesID"] + "')='是')))";
               // Response.Write("" + SQL_GetList1 + "<br>");
               // string SQL_GetList1 = "select * from qp_Folders where (CHARINDEX('," + this.Session["Username"] + ",',','+GxUsername+',')   >   0  and id=" + MyReader["id"] + " and ( IfShare='是' or ((select IfShare from qp_Folders where id='" + PID + "')='是')))";
                SqlDataReader MyReader1 = List.GetList(SQL_GetList1);
                if (MyReader1.Read())
                {
                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Text = "  " + MyReader["Name"].ToString() + "(" + MyReader["realname"].ToString() + ")";
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
                    OrganizationNode.NavigateUrl = "FoldersGx_show.aspx?id=" + strId + "";
                    OrganizationNode.Expanded = false;
                    // OrganizationNode.SelectAction = TreeNodeSelectAction.Expand; 
                    OrganizationNode.Target = "foldersform";
                    Nds.Add(OrganizationNode);
                    BindTree(Nds[Nds.Count - 1].ChildNodes, "", strId, strId1);

                }
                else
                {
                    //TreeNode OrganizationNode = new TreeNode();
                    //OrganizationNode.Text = " " + MyReader["Name"].ToString();
                    //OrganizationNode.Value = MyReader["ID"].ToString();
                    string strId = MyReader["ID"].ToString();
                    string strId1 = MyReader["ParentNodesID"].ToString();
                    //if (MyReader["IfShare"].ToString() == "是")
                    //{
                    //    OrganizationNode.ImageUrl = "../images/shareFolder.gif";
                    //}
                    //else
                    //{
                    //    OrganizationNode.ImageUrl = "../images/folder.gif";
                    //}
                    ////OrganizationNode.NavigateUrl = "#";
                    //OrganizationNode.Expanded = false;
                    //OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                    //OrganizationNode.Target = "foldersform";
                    //Nds.Add(OrganizationNode);
                    //BindTree(Nds[Nds.Count - 1].ChildNodes, "", strId, strId1);
                    BindTree(Nds, "", strId, strId1);
                }





            }
            MyReader.Close();

        }






    }
}

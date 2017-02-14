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
namespace qpoa.KmManage
{
    public partial class KmTitle : System.Web.UI.Page
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
                BindTree("2");
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(ListTreeView, "jjjj3", Session["perstr"].ToString());


        }
        public void BindAttribute()
        {

            //IMG1.Attributes["onclick"] = "javascript:return showwait();";

        }
        private void BindTree(string key)
        {
            ListTreeView.Nodes.Clear();
            if (key == "1")
            {

                string SQL_GetList = "select * from qp_KmBigType  order by id desc";
                SqlDataReader MyReader = List.GetList(SQL_GetList);
                while (MyReader.Read())
                {
                    

                    string SQL_GetListCzB = "select * from qp_KmTitle  where BigId='" + MyReader["id"] + "' and Username='" + Session["Username"] + "'";
                    SqlDataReader MyReaderCzB = List.GetList(SQL_GetListCzB);
                    if (MyReaderCzB.Read())
                    {
                        TreeNode OrganizationNode = new TreeNode();
                       
                        OrganizationNode.Text = " " + MyReader["Name"].ToString();
                        OrganizationNode.Value = MyReader["Name"].ToString();
                        OrganizationNode.Expanded = false;
                        OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                        OrganizationNode.ImageUrl = "../images/folder.gif";

                        string SQL_GetFile = "select id,Name from qp_KmLittleType where BigId='" + MyReader["id"].ToString() + "' and ((CHARINDEX('," + this.Session["username"] + ",',','+SyUsername+',')   >   0 ) or SyUsername='全部用户')";
                        SqlDataReader FileReader = List.GetList(SQL_GetFile);
                        while (FileReader.Read())
                        {
                            string SQL_GetCount = "select count(id) from  qp_KmTitle where LittleId='" + FileReader["id"] + "' and Username='" + Session["Username"] + "' ";
                            string Counts = "" + List.GetCount(SQL_GetCount) + "";

                            string SQL_GetListCz = "select * from qp_KmTitle  where LittleId='" + FileReader["id"] + "' and Username='" + Session["Username"] + "' order by id desc";
                            SqlDataReader MyReaderCz = List.GetList(SQL_GetListCz);
                            if (MyReaderCz.Read())
                            {
                                TreeNode OrganizationNode1 = new TreeNode();

                                OrganizationNode1.Text = " " + FileReader["Name"].ToString() + "(" + Counts + ")";
                                OrganizationNode1.Value = FileReader["ID"].ToString();
                                int strId = int.Parse(FileReader["ID"].ToString());
                                OrganizationNode1.NavigateUrl = "KmTitle_show.aspx?LittleId=" + strId + "";
                                OrganizationNode1.Expanded = false;
                                OrganizationNode1.ImageUrl = "../images/child.gif";
                                OrganizationNode1.Target = "foldersform";

                                OrganizationNode.ChildNodes.Add(OrganizationNode1);
                            }
                           
                            MyReaderCz.Close();
                        }

                        FileReader.Close();
                        ListTreeView.Nodes.Add(OrganizationNode);
                    }
                    MyReaderCzB.Close();

                  

                }
                MyReader.Close();




            
            }//只显示有数据项
            else
            {

                string SQL_GetList = "select * from qp_KmBigType  order by id desc";
                SqlDataReader MyReader = List.GetList(SQL_GetList);
                while (MyReader.Read())
                {
                    TreeNode OrganizationNode = new TreeNode();
                    OrganizationNode.Text = " " + MyReader["Name"].ToString();
                    OrganizationNode.Value = MyReader["Name"].ToString();
                    OrganizationNode.Expanded = false;
                    OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
                    OrganizationNode.ImageUrl = "../images/folder.gif";

                    string SQL_GetFile = "select id,Name from qp_KmLittleType where BigId='" + MyReader["id"].ToString() + "'  and ((CHARINDEX('," + this.Session["username"] + ",',','+SyUsername+',')   >   0 ) or SyUsername='全部用户')";
                    SqlDataReader FileReader = List.GetList(SQL_GetFile);
                    while (FileReader.Read())
                    {
                        string SQL_GetCount = "select count(id) from  qp_KmTitle where LittleId='" + FileReader["id"] + "' and Username='" + Session["Username"] + "' ";
                        string Counts = "" + List.GetCount(SQL_GetCount) + "";

                        TreeNode OrganizationNode1 = new TreeNode();

                        OrganizationNode1.Text = " " + FileReader["Name"].ToString() + "(" + Counts + ")";
                        OrganizationNode1.Value = FileReader["ID"].ToString();
                        int strId = int.Parse(FileReader["ID"].ToString());
                        OrganizationNode1.NavigateUrl = "KmTitle_show.aspx?LittleId=" + strId + "";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindTree("1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BindTree("2");
        }






    }
}

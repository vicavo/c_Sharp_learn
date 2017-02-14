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
namespace qpoa.SystemManage
{
    public partial class UnitName : System.Web.UI.Page
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
                BindTree(ListTreeView.Nodes, 0); 
                Bindquanxian();

            }
        }
        public void Bindquanxian()
        {
            List.QuanXianVis(IMG1, "iiii6b", Session["perstr"].ToString());
    

        }
        public void BindAttribute()
        {

            //IMG1.Attributes["onclick"] = "javascript:return showwait();";
   
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
                    OrganizationNode.NavigateUrl = "UnitName_show.aspx?id=" + strId + "";
                    OrganizationNode.Expanded = false;
                    OrganizationNode.Target = "unitform";
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
                        OrganizationNode.NavigateUrl = "UnitName_show.aspx?id=" + strId + "";
                        OrganizationNode.Expanded = false;
                        OrganizationNode.Target = "unitform";
                        Nds.Add(OrganizationNode);
                        BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
                  
                }
            }
            MyReader.Close();
          
        }






    }
}

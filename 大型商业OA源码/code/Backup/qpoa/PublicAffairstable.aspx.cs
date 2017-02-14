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
namespace qpoa.PublicAffairs
{
    public partial class PublicAffairstable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = this.Session["perstr"].ToString();

            BindTheTree(this.TreeView3.Nodes, str);

            if (Session["Target"].ToString() == "rform")
            {
                TreeView3.Visible = true;
                TreeView1.Visible = false;
            }
            else
            {
                TreeView3.Visible = false;
                TreeView1.Visible = true;

            }
        }

        protected void BindTheTree(TreeNodeCollection Nds, string UserPerStr)
        {
            for (int i = 0; i < Nds.Count; i++)
            {

                if (!StrIFInStr(Nds[i].Value.ToString(), UserPerStr))
                {
                    Nds.Remove(Nds[i]);
                    i = i - 1;
                }
                else
                {


                    BindTheTree(Nds[i].ChildNodes, UserPerStr);
                }
            }
        }
        private bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf(Str1) < 0)
            {

                return false;
            }
            else
            {

                return true;
            }
        }
    }
}

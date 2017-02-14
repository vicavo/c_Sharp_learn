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
    public partial class left : System.Web.UI.Page
    {
     
        protected void Page_Load(object sender, EventArgs e)
        {
            string str = this.Session["perstr"].ToString();

           // BindTheTree(this.TreeView1.Nodes, str);
        }

        //protected void BindTheTree(TreeNodeCollection Nds, string UserPerStr)
        //{
        //    for (int i = 0; i < Nds.Count; i++)
        //    {

        //        if (!StrIFInStr(Nds[i].Value.ToString(), UserPerStr))
        //        {
        //            Nds.Remove(Nds[i]);
        //            i = i - 1;
        //        }
        //        else
        //        {


        //            BindTheTree(Nds[i].ChildNodes, UserPerStr);
        //        }
        //    }
        //}
        //private bool StrIFInStr(string Str1, string Str2)
        //{
        //    if (Str2.IndexOf(Str1) < 0)
        //    {

        //        return false;
        //    }
        //    else
        //    {

        //        return true;
        //    }
        //} 
    }
}

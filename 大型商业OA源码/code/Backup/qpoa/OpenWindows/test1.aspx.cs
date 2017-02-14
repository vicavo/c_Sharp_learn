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

namespace qpoa.OpenWindows
{
    public partial class test1 : System.Web.UI.Page
    {
        public string str, tqp;
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            str = "" + TextBox1.Text+ "";
            ArrayList myarr = new ArrayList();
            string[] mystr = str.Split(',');
            for (int s = 0; s < mystr.Length; s++)
            {
                TextBox2.Text += "'" + mystr[s] + "',";
            }
            TextBox2.Text += "'0'";
        }
    }
}

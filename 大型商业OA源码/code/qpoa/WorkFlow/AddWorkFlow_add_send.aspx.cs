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

namespace qpoa.WorkFlow
{
    public partial class AddWorkFlow_add_send : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(TextBox1.Text.IndexOf(TextBox2.Text));
            if (TextBox1.Text.IndexOf(TextBox2.Text) >= 0)
            {
                Response.Write("a");
            }
            else
            {
                Response.Write("b");
            }

        }
    }
}

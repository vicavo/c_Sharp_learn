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

namespace qpoa.InfoSpeech
{
    public partial class WbMail_js : System.Web.UI.Page
    {
        public static int strid;
        protected void Page_Load(object sender, EventArgs e)
        {
            strid = int.Parse(Request.QueryString["id"].ToString());
        }
    }
}

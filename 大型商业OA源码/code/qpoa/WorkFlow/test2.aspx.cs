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
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //bool TjszStr = 1 == 1 &&-1>= 0 &&-1>= 0 ;
            //string aaa = "1 == 1";
            //string bbb = "&&0 >= 0";
            //string ccc = "&&-1 >= 0";
            //string TjszStr = aaa + bbb + ccc;
        
            //Response.Write(""+TjszStr+"<br>");
            //if (TjszStr != "")
            //{
            //    Response.Write("a");
            //}
            //else
            //{
            //    Response.Write("b");
            //}


            string aaa = "1 == 1";
            string bbb = "&&0 >= 0";
            string ccc = "&&0>= 0";
            string TjszStr = aaa + bbb + ccc;

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
            sc.Language = "javascript";
            if ((bool)sc.Eval(TjszStr) == false)
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

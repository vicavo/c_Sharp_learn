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

namespace qpoa.FreWebsite
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Unit.Attributes.Add("readonly", "readonly");
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("名称：" + Unit.Text + "ＩＤ号：" + this.UnitId.Text + "");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("名称：" + Request.Form["Unit"] + "ＩＤ号：" + Request.Form["UnitId"] + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write( Request.Form["Text1"]);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.Response.Write("<script language=javascript>alert('工号与人事信息库重复！');</script>");
        }
    }
}

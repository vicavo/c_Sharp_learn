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
namespace qpoa.myeditor
{
    public partial class modle : System.Web.UI.Page
    {
        Db List = new Db();
        public string ModelContent;
        protected void Page_Load(object sender, EventArgs e)
        {

            ModelContent = "";
            string SQL_mx = "select  * from qp_OftenModle  where Username='" + Session["Username"] + "' or ( CHARINDEX('," + this.Session["Username"] + ",',','+SharingUsername+',')   >   0 ) order by id desc";
            SqlDataReader NewReader_mx = List.GetList(SQL_mx);
          
            int glTMP1 = 0;
         

            while (NewReader_mx.Read())
            {
                string aaa = string.Empty;
                aaa = NewReader_mx["content"].ToString();

                ModelContent += "  <tr class=\"TableControl\">  <td align=\"middle\" class=\"menulines\" onclick=\"javascript:return click_model('CONTENT_" + NewReader_mx["id"] + "')\" style=\"cursor: hand\">" + NewReader_mx["name"] + "<input  type=\"hidden\" value=\"" + aaa + "\"  name=\"CONTENT_" + NewReader_mx["id"] + "\"/></td> </tr>";
                glTMP1 = glTMP1 + 1;
                if (glTMP1 == 1)
                {

                    glTMP1 = 0;
                }
            }

            NewReader_mx.Close();
         


        }
    }
}

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
namespace qpoa.OpenWindows
{
    public partial class open_Respon_List : System.Web.UI.Page
    {
        Db List = new Db();
        public string str, tqp, struser, strname, str1, strlist;
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DataBindToDownList();

                BindAttribute();


                requeststr.Text = Server.UrlDecode(Request.QueryString["requeststr"].ToString());


                str1 = "" + requeststr.Text + "";
                ArrayList myarr = new ArrayList();
                string[] mystr = str1.Split(',');
                for (int s = 0; s < mystr.Length; s++)
                {
                    strlist += "'" + mystr[s] + "',";
                }
                strlist += "'0'";

                if (Request.QueryString["requeststr"] != null)
                {
                    string sql_down1 = "select * from qp_Respon  where id in (" + strlist + ")";
                    list.Bind_DropDownList_ListBox(TargetListBox, sql_down1, "id", "name");

                }

            }


        }
        public void DataBindToDownList()
        {

            string sql_down1 = "select * from qp_Respon";
            list.Bind_DropDownList_ListBox(SourceListBox, sql_down1, "id", "name");

        }











        public void BindAttribute()
        {






        }
        protected void Button5_Click(object sender, EventArgs e)
        {

            if (SourceListBox.Items.Count > 0)
            {
                foreach (ListItem MyItem in SourceListBox.Items)
                    TargetListBox.Items.Add(MyItem);


                SourceListBox.Items.Clear();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int i = 0;

            while (i <= SourceListBox.Items.Count - 1)
            {

                if (SourceListBox.Items[i].Selected)
                {
                    if (TargetListBox.Items.IndexOf(SourceListBox.Items[i]) >= 0)
                    {
                        this.Response.Write("<script language=javascript>alert('此项已经存在！');</script>");
                        return;
                    }

                    TargetListBox.Items.Add(new ListItem(SourceListBox.Items[i].Text, SourceListBox.Items[i].Value));
                    SourceListBox.Items.Remove(SourceListBox.Items[i]);
                }
                else
                    i += 1;
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int i = 0;

            while (i <= TargetListBox.Items.Count - 1)
            {

                if (TargetListBox.Items[i].Selected)
                {
                    SourceListBox.Items.Add(new ListItem(TargetListBox.Items[i].Text, TargetListBox.Items[i].Value));
                    TargetListBox.Items.Remove(TargetListBox.Items[i]);
                }
                else
                    i += 1;
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if (TargetListBox.Items.Count > 0)
            {
                foreach (ListItem MyItem in TargetListBox.Items)
                    SourceListBox.Items.Add(MyItem);


                TargetListBox.Items.Clear();
            }
        }



        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    struser = null;

        //    for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
        //    {

        //        str = "" + TargetListBox.Items[i].Value + ",";
        //        tqp = str.Remove(str.LastIndexOf(","), 1);
        //        ArrayList myarr = new ArrayList();
        //        string[] mystr = tqp.Split(',');
        //        for (int s = 0; s < mystr.Length; s++)
        //        {
        //            myarr.Add(mystr[s].ToString());

        //            string SQL_GetList1 = "select * from qp_Username where username='" + mystr[s] + "'";
        //            SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
        //            if (NewReader1.Read())
        //            {
        //                string Username = NewReader1["Username"].ToString();
        //                string Realname = NewReader1["Realname"].ToString();


        //                struser = struser + "" + Username + ",";

        //            }
        //            NewReader1.Close();



        //        }

        //    }
        //   Response.Write(struser);
        //}


    }
}

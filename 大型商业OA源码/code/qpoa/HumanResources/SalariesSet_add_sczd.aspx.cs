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
namespace qpoa.HumanResources
{
    public partial class SalariesSet_add_sczd : System.Web.UI.Page
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


            }


        }
        public void DataBindToDownList()
        {
            string SQL_GetList = "select * from qp_SaFile  where SaNumber='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                requeststr.Text = NewReader["FileNumber"].ToString();

                if (NewReader["Sajjcp"].ToString() == "是")
                {
                    Sajjcp.Checked = true;
                }
                else
                {
                    Sajjcp.Checked = false;
                }

                if (NewReader["Sajjgx"].ToString() == "是")
                {
                    Sajjgx.Checked = true;
                }
                else
                {
                    Sajjgx.Checked = false;
                }

                if (NewReader["Sajsgz"].ToString() == "是")
                {
                    Sajsgz.Checked = true;
                }
                else
                {
                    Sajsgz.Checked = false;
                }

            }
            else
            {
                requeststr.Text = "0";
            }
            NewReader.Close();


            str1 = "" + requeststr.Text + "";
            ArrayList myarr = new ArrayList();
            string[] mystr = str1.Split(',');
            for (int s = 0; s < mystr.Length; s++)
            {
                strlist += "'" + mystr[s] + "',";
            }
            strlist += "'0'";


            string sql_down2 = "select * from qp_SaProduct  where Number in (" + strlist + ") and SaNumber='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            list.Bind_DropDownList_ListBox(TargetListBox, sql_down2, "Number", "name");



            string sql_down1 = "select * from qp_SaProduct  where Number not in (" + strlist + ") and  SaNumber='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            list.Bind_DropDownList_ListBox(SourceListBox, sql_down1, "Number", "name");




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

        protected void Button7_Click(object sender, EventArgs e)
        {
            string strnum = null;
            string strname = null;
            for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
            {

                str = "" + TargetListBox.Items[i].Value + ",";
                tqp = str.Remove(str.LastIndexOf(","), 1);
                ArrayList myarr = new ArrayList();
                string[] mystr = tqp.Split(',');
                for (int s = 0; s < mystr.Length; s++)
                {
                    myarr.Add(mystr[s].ToString());

                    string SQL_GetList1 = "select * from qp_SaProduct  where Number='" + mystr[s] + "'";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        string SNumber = NewReader1["Number"].ToString();
                        string SName = NewReader1["Name"].ToString();

                        strnum = strnum + "" + SNumber + ",";
                        strname = strname + "" + SName + ",";

                    }
                    NewReader1.Close();

                }

            }

            string LSajjcp = null, LSajjgx = null, LSajsgz = null;

            if (Sajjcp.Checked == true)
            { LSajjcp="是";   }
            else
            { LSajjcp = "否"; }


            if (Sajjgx.Checked == true)
            { LSajjgx = "是"; }
            else
            { LSajjgx = "否"; }


            if (Sajsgz.Checked == true)
            { LSajsgz = "是"; }
            else
            { LSajsgz = "否"; }






            string SQL_GetList = "select * from qp_SaFile  where SaNumber='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {

                string Sql_update = "Update qp_SaFile  Set Sajjcp='" + LSajjcp + "',Sajjgx='" + LSajjgx + "',Sajsgz='" + LSajsgz + "',FileNumber='" + strnum + "', FileName='" + strname + "'  where  SaNumber='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                List.ExeSql(Sql_update);
                InsertLog("设置输出字段", "帐套管理");
                DataBindToDownList();
                this.Response.Write("<script language=javascript>alert('提交成功！');</script>"); 
            }
            else
            {
                string sql_insert = "insert into qp_SaFile (FileNumber,FileName,SaNumber,Sajjcp,Sajjgx,Sajsgz) values ('" + strnum + "','" + strname + "','" + List.GetFormatStr(Request.QueryString["Number"]) + "','" + LSajjcp + "','" + LSajjgx + "','" + LSajsgz + "')";
                List.ExeSql(sql_insert);
                InsertLog("设置输出字段", "帐套管理");
                DataBindToDownList();
                this.Response.Write("<script language=javascript>alert('提交成功！');</script>");
  
            }
           
        }
        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }





    }
}

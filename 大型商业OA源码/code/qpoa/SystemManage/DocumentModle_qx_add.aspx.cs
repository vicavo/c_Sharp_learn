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
namespace qpoa.SystemManage
{
    public partial class DocumentModle_qx_add : System.Web.UI.Page
    {
        Db List = new Db();
        public string str, tqp;
        BindDrowDownList list = new BindDrowDownList();
        protected void Page_Load(object sender, EventArgs e)
        {

      
                if (!IsPostBack)
                {
                    DataBindToDownList("按人员设置");
                    KeyBox.Text = "按人员设置";
                    BindAttribute();

                }
           

        }
        public void DataBindToDownList(string SqlFile)
        {
           
            if (SqlFile == "按人员设置")
            {
                string sql_down = "select * from qp_Username";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Username", "Realname");
            }

            if (SqlFile == "按部门设置")
            {
                string sql_down = "select * from qp_UnitName";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Id", "Name");
            }
            if (SqlFile == "按角色设置")
            {
                string sql_down = "select * from qp_Respon";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Id", "Name");
            }
            if (SqlFile == "按职位设置")
            {
                string sql_down = "select * from qp_PostName";
                list.Bind_DropDownList_ListBox(SourceListBox, sql_down, "Id", "Name");
            }
        }
        public void BindAttribute()
        {



            Button2.Attributes["onclick"] = "javascript:return showwait();";

          
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
            KeyBox.Text = null;
            DataBindToDownList("按人员设置");
            KeyBox.Text = "按人员设置";
            TargetListBox.Items.Clear();
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            DataBindToDownList("按部门设置");
            KeyBox.Text = "按部门设置";
            TargetListBox.Items.Clear();
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            DataBindToDownList("按角色设置");
            KeyBox.Text = "按角色设置";
            TargetListBox.Items.Clear();
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            KeyBox.Text = null;
            DataBindToDownList("按职位设置");
            KeyBox.Text = "按职位设置";
            TargetListBox.Items.Clear();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (KeyBox.Text == "按人员设置")
            {
                for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
                {

                    str = "" + TargetListBox.Items[i].Value + ",";
                    tqp = str.Remove(str.LastIndexOf(","), 1);
                    ArrayList myarr = new ArrayList();
                    string[] mystr = tqp.Split(',');
                    for (int s = 0; s < mystr.Length; s++)
                    {
                        myarr.Add(mystr[s].ToString());

                        string SQL_GetList1 = "select * from qp_Username where username='" + mystr[s] + "'";
                        SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                        if (NewReader1.Read())
                        {
                            string Username = NewReader1["Username"].ToString();
                            string Realname = NewReader1["Realname"].ToString();
                            string Unit = NewReader1["Unit"].ToString();
                            string UnitId = NewReader1["UnitId"].ToString();
                            string Respon = NewReader1["Respon"].ToString();
                            string ResponId = NewReader1["ResponId"].ToString();
                            string Post = NewReader1["Post"].ToString();
                            string PostId = NewReader1["PostId"].ToString();

                            string SQL_GetList_c = "select * from qp_DocumentModleQx where username='" + mystr[s] + "' and KeyId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                              SqlDataReader NewReader_c = List.GetList(SQL_GetList_c);
                              if (!NewReader_c.Read())
                              {
                                  string insert = "insert into qp_DocumentModleQx (KeyId,Username,Realname,Unit,UnitId,Respon,ResponId,Post,PostId) values('" + Server.UrlDecode(List.GetFormatStr(Request.QueryString["id"])) + "','" + Username + "','" + Realname + "','" + Unit + "','" + UnitId + "','" + Respon + "','" + ResponId + "','" + Post + "','" + PostId + "')";
                                  List.ExeSql(insert);
                              }
                              NewReader_c.Close();

                       
                        


                        }
                        NewReader1.Close();
                        this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

                    }

                }

            }
            if (KeyBox.Text == "按部门设置")
            {
                for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
                {

                    str = "" + TargetListBox.Items[i].Value + ",";
                    tqp = str.Remove(str.LastIndexOf(","), 1);
                    ArrayList myarr = new ArrayList();
                    string[] mystr = tqp.Split(',');

                    for (int s = 0; s < mystr.Length; s++)
                    {
                        myarr.Add(mystr[s].ToString());
                        string SQL_GetList1 = "select * from qp_Username where UnitId='" + mystr[s] + "'";
                        SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                        while (NewReader1.Read())
                        {
                            string Username = NewReader1["Username"].ToString();
                            string Realname = NewReader1["Realname"].ToString();
                            string Unit = NewReader1["Unit"].ToString();
                            string UnitId = NewReader1["UnitId"].ToString();
                            string Respon = NewReader1["Respon"].ToString();
                            string ResponId = NewReader1["ResponId"].ToString();
                            string Post = NewReader1["Post"].ToString();
                            string PostId = NewReader1["PostId"].ToString();

                            string SQL_GetList_c = "select * from qp_DocumentModleQx where username='" + Username + "'  and KeyId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                            SqlDataReader NewReader_c = List.GetList(SQL_GetList_c);
                            if (!NewReader_c.Read())
                            {
                                string insert = "insert into qp_DocumentModleQx (KeyId,Username,Realname,Unit,UnitId,Respon,ResponId,Post,PostId) values('" + Server.UrlDecode(List.GetFormatStr(Request.QueryString["id"])) + "','" + Username + "','" + Realname + "','" + Unit + "','" + UnitId + "','" + Respon + "','" + ResponId + "','" + Post + "','" + PostId + "')";
                                List.ExeSql(insert);
                            }
                            NewReader_c.Close();

                        }
                        NewReader1.Close();
                        this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

                    }
                }

            }
            if (KeyBox.Text == "按角色设置")
            {

                for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
                {

                    str = "" + TargetListBox.Items[i].Value + ",";
                    tqp = str.Remove(str.LastIndexOf(","), 1);
                    ArrayList myarr = new ArrayList();
                    string[] mystr = tqp.Split(',');

                    for (int s = 0; s < mystr.Length; s++)
                    {
                        myarr.Add(mystr[s].ToString());
                        string SQL_GetList1 = "select * from qp_Username where ResponId='" + mystr[s] + "' ";
                        SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                        while (NewReader1.Read())
                        {
                            string Username = NewReader1["Username"].ToString();
                            string Realname = NewReader1["Realname"].ToString();
                            string Unit = NewReader1["Unit"].ToString();
                            string UnitId = NewReader1["UnitId"].ToString();
                            string Respon = NewReader1["Respon"].ToString();
                            string ResponId = NewReader1["ResponId"].ToString();
                            string Post = NewReader1["Post"].ToString();
                            string PostId = NewReader1["PostId"].ToString();

                            string SQL_GetList_c = "select * from qp_DocumentModleQx where username='" + Username + "'  and KeyId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                            SqlDataReader NewReader_c = List.GetList(SQL_GetList_c);
                            if (!NewReader_c.Read())
                            {
                                string insert = "insert into qp_DocumentModleQx (KeyId,Username,Realname,Unit,UnitId,Respon,ResponId,Post,PostId) values('" + Server.UrlDecode(List.GetFormatStr(Request.QueryString["id"])) + "','" + Username + "','" + Realname + "','" + Unit + "','" + UnitId + "','" + Respon + "','" + ResponId + "','" + Post + "','" + PostId + "')";
                                List.ExeSql(insert);
                            }
                            NewReader_c.Close();

                        }
                        NewReader1.Close();
                        this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

                    }
                }








            }
            if (KeyBox.Text == "按职位设置")
            {

                for (int i = 0; i <= TargetListBox.Items.Count - 1; i++)
                {

                    str = "" + TargetListBox.Items[i].Value + ",";
                    tqp = str.Remove(str.LastIndexOf(","), 1);
                    ArrayList myarr = new ArrayList();
                    string[] mystr = tqp.Split(',');

                    for (int s = 0; s < mystr.Length; s++)
                    {
                        myarr.Add(mystr[s].ToString());
                        string SQL_GetList1 = "select * from qp_Username where PostId='" + mystr[s] + "'";
                        SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                        while (NewReader1.Read())
                        {
                            string Username = NewReader1["Username"].ToString();
                            string Realname = NewReader1["Realname"].ToString();
                            string Unit = NewReader1["Unit"].ToString();
                            string UnitId = NewReader1["UnitId"].ToString();
                            string Respon = NewReader1["Respon"].ToString();
                            string ResponId = NewReader1["ResponId"].ToString();
                            string Post = NewReader1["Post"].ToString();
                            string PostId = NewReader1["PostId"].ToString();

                            string SQL_GetList_c = "select * from qp_DocumentModleQx where username='" + Username + "'  and KeyId='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                            SqlDataReader NewReader_c = List.GetList(SQL_GetList_c);
                            if (!NewReader_c.Read())
                            {
                                string insert = "insert into qp_DocumentModleQx (KeyId,Username,Realname,Unit,UnitId,Respon,ResponId,Post,PostId) values('" + Server.UrlDecode(List.GetFormatStr(Request.QueryString["id"])) + "','" + Username + "','" + Realname + "','" + Unit + "','" + UnitId + "','" + Respon + "','" + ResponId + "','" + Post + "','" + PostId + "')";
                                List.ExeSql(insert);
                            }
                            NewReader_c.Close();

                        }
                        NewReader1.Close();
                        this.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");

                    }
                }










            
            }
        }
    }
}

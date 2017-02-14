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
    public partial class username_qx : System.Web.UI.Page
    {
        Db List = new Db();
        public static string s_quanbu, s_xinzeng, s_chakan, s_xiugai, s_shanchu, s_daochu, s_shenpi, s_shouquan, s_geren, s_bumen, s_gongsi, s_chaxun, s_xiaoshou, PerSessionStr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {


                BindAttribute();
                DataBindToGridview();

                string SQL_GetList = "select * from qp_Username   where id='" + int.Parse(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    Name.Text = NewReader["Username"].ToString();
                    Label1.Text = NewReader["Realname"].ToString();
                    PerSessionStr = NewReader["ResponQx"].ToString();
                }
                NewReader.Close();



                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    GridViewRow row = GridView1.Rows[i];

                    CheckBox Cchaxun = (CheckBox)row.FindControl("chaxun");
                    Label Lchaxun = (Label)row.FindControl("chaxunid");//查询

                    CheckBox Cquanbu = (CheckBox)row.FindControl("quanbu");
                    Label Lquanbu = (Label)row.FindControl("quanbuid");//全部

                    CheckBox Cxinzeng = (CheckBox)row.FindControl("xinzeng");
                    Label Lxinzeng = (Label)row.FindControl("xinzengid");//新增

                    CheckBox Cchakan = (CheckBox)row.FindControl("chakan");
                    Label Lchakan = (Label)row.FindControl("chakanid");//查看　

                    CheckBox Cxiguai = (CheckBox)row.FindControl("xiguai");
                    Label Lxiguai = (Label)row.FindControl("xiguaiid");//修改

                    CheckBox Cshanchu = (CheckBox)row.FindControl("shanchu");
                    Label Lshanchu = (Label)row.FindControl("shanchuid");//删除

                    CheckBox Cdaochu = (CheckBox)row.FindControl("daochu");
                    Label Ldaochu = (Label)row.FindControl("daochuid");//导出

                    CheckBox Cshenpi = (CheckBox)row.FindControl("shenpi");
                    Label Lshenpi = (Label)row.FindControl("shenpiid");//审批

                    CheckBox Cshouquan = (CheckBox)row.FindControl("shouquan");
                    Label Lshouquan = (Label)row.FindControl("shouquanid");//授权



                    RadioButton Cgeren = (RadioButton)row.FindControl("geren");
                    Label Lgeren = (Label)row.FindControl("gerenid");//查看权限-个人


                    RadioButton Cbumen = (RadioButton)row.FindControl("bumen");
                    Label Lbumen = (Label)row.FindControl("bumenid");//查看权限-部门

                    RadioButton Cgongsi = (RadioButton)row.FindControl("gongsi");
                    Label Lgongsi = (Label)row.FindControl("gongsiid");//查看权限-公司

                    RadioButton Cxiaoshou = (RadioButton)row.FindControl("xiaoshou");
                    Label Lxiaoshou = (Label)row.FindControl("xiaoshouid");//查看权限-销售

                    if (List.StrIFInStr(Lgeren.Text, PerSessionStr) && Lgeren.Text != "0")
                    {
                        Cgeren.Checked = true;
                    }//查看权限-个人

                    if (List.StrIFInStr(Lbumen.Text, PerSessionStr) && Lbumen.Text != "0")
                    {
                        Cbumen.Checked = true;
                    }//查看权限-部门


                    if (List.StrIFInStr(Lgongsi.Text, PerSessionStr) && Lgongsi.Text != "0")
                    {
                        Cgongsi.Checked = true;
                    }//查看权限-公司

                    if (List.StrIFInStr(Lxiaoshou.Text, PerSessionStr) && Lxiaoshou.Text != "0")
                    {
                        Cxiaoshou.Checked = true;
                    }//查看权限-销售

                    if (List.StrIFInStr(Lquanbu.Text, PerSessionStr) && Lquanbu.Text != "0")
                    {
                        Cquanbu.Checked = true;
                    }

                    if (List.StrIFInStr(Lxinzeng.Text, PerSessionStr) && Lxinzeng.Text != "0")
                    {
                        Cxinzeng.Checked = true;
                    }

                    if (List.StrIFInStr(Lchakan.Text, PerSessionStr) && Lchakan.Text != "0")
                    {
                        Cchakan.Checked = true;
                    }

                    if (List.StrIFInStr(Lxiguai.Text, PerSessionStr) && Lxiguai.Text != "0")
                    {
                        Cxiguai.Checked = true;
                    }
                    if (List.StrIFInStr(Lshanchu.Text, PerSessionStr) && Lshanchu.Text != "0")
                    {
                        Cshanchu.Checked = true;
                    }

                    if (List.StrIFInStr(Ldaochu.Text, PerSessionStr) && Ldaochu.Text != "0")
                    {
                        Cdaochu.Checked = true;
                    }
                    if (List.StrIFInStr(Lshenpi.Text, PerSessionStr) && Lshenpi.Text != "0")
                    {
                        Cshenpi.Checked = true;
                    }

                    if (List.StrIFInStr(Lshouquan.Text, PerSessionStr) && Lshouquan.Text != "0")
                    {
                        Cshouquan.Checked = true;
                    }

                    if (List.StrIFInStr(Lchaxun.Text, PerSessionStr) && Lchaxun.Text != "0")
                    {
                        Cchaxun.Checked = true;
                    }

                }


            }
        }
        public void BindAttribute()
        {

            Button1.Attributes["onclick"] = "javascript:return showwait();";
            Button2.Attributes["onclick"] = "javascript:return showwait();";
        }
        public void DataBindToGridview()
        {
            string SQL_GetList_xs = "select * from qp_ResponQx order by paixu asc";
            GridView1.DataSource = List.GetGrid_Pages_not(SQL_GetList_xs);
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType itemType = e.Row.RowType;
            if (e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";

            }

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];

                CheckBox Cchaxun = (CheckBox)row.FindControl("chaxun");
                Label Lchaxun = (Label)row.FindControl("chaxunid");//查询

                CheckBox Cquanbu = (CheckBox)row.FindControl("quanbu");
                Label Lquanbu = (Label)row.FindControl("quanbuid");//全部

                CheckBox Cxinzeng = (CheckBox)row.FindControl("xinzeng");
                Label Lxinzeng = (Label)row.FindControl("xinzengid");//新增

                CheckBox Cchakan = (CheckBox)row.FindControl("chakan");
                Label Lchakan = (Label)row.FindControl("chakanid");//查看　

                CheckBox Cxiguai = (CheckBox)row.FindControl("xiguai");
                Label Lxiguai = (Label)row.FindControl("xiguaiid");//修改

                CheckBox Cshanchu = (CheckBox)row.FindControl("shanchu");
                Label Lshanchu = (Label)row.FindControl("shanchuid");//删除

                CheckBox Cdaochu = (CheckBox)row.FindControl("daochu");
                Label Ldaochu = (Label)row.FindControl("daochuid");//导出

                CheckBox Cshenpi = (CheckBox)row.FindControl("shenpi");
                Label Lshenpi = (Label)row.FindControl("shenpiid");//审批

                CheckBox Cshouquan = (CheckBox)row.FindControl("shouquan");
                Label Lshouquan = (Label)row.FindControl("shouquanid");//授权



                RadioButton Cgeren = (RadioButton)row.FindControl("geren");
                Label Lgeren = (Label)row.FindControl("gerenid");//查看权限-个人


                RadioButton Cbumen = (RadioButton)row.FindControl("bumen");
                Label Lbumen = (Label)row.FindControl("bumenid");//查看权限-部门

                RadioButton Cgongsi = (RadioButton)row.FindControl("gongsi");
                Label Lgongsi = (Label)row.FindControl("gongsiid");//查看权限-公司

                RadioButton Cxiaoshou = (RadioButton)row.FindControl("xiaoshou");
                Label Lxiaoshou = (Label)row.FindControl("xiaoshouid");//查看权限-销售


                if (Lgeren.Text == "0")
                { Cgeren.Visible = false; }
                else
                { Cgeren.Visible = true; }//查看权限-个人

                if (Lbumen.Text == "0")
                { Cbumen.Visible = false; }
                else
                { Cbumen.Visible = true; }//查看权限-部门

                if (Lgongsi.Text == "0")
                { Cgongsi.Visible = false; }
                else
                { Cgongsi.Visible = true; }///查看权限-公司

                if (Lxiaoshou.Text == "0")
                { Cxiaoshou.Visible = false; }
                else
                { Cxiaoshou.Visible = true; }///查看权限-销售


                if (Lchaxun.Text == "0")
                { Cchaxun.Visible = false; }
                else
                { Cchaxun.Visible = true; }//查询



                if (Lquanbu.Text == "0")
                { Cquanbu.Visible = false; }
                else
                { Cquanbu.Visible = true; }//全部

                if (Lxinzeng.Text == "0")
                { Cxinzeng.Visible = false; }
                else
                { Cxinzeng.Visible = true; }//新增

                if (Lchakan.Text == "0")
                { Cchakan.Visible = false; }
                else
                { Cchakan.Visible = true; }///查看　

                if (Lxiguai.Text == "0")
                { Cxiguai.Visible = false; }
                else
                { Cxiguai.Visible = true; }///修改　

                if (Lshanchu.Text == "0")
                { Cshanchu.Visible = false; }
                else
                { Cshanchu.Visible = true; }///删除　

                if (Ldaochu.Text == "0")
                { Cdaochu.Visible = false; }
                else
                { Cdaochu.Visible = true; }///导出　

                if (Lshenpi.Text == "0")
                { Cshenpi.Visible = false; }
                else
                { Cshenpi.Visible = true; }///审批


                if (Lshouquan.Text == "0")
                { Cshouquan.Visible = false; }
                else
                { Cshouquan.Visible = true; }///授权




            }





        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            s_quanbu = string.Empty;
            s_xinzeng = string.Empty;
            s_chakan = string.Empty;
            s_xiugai = string.Empty;
            s_shanchu = string.Empty;
            s_daochu = string.Empty;
            s_shenpi = string.Empty;
            s_shouquan = string.Empty;
            s_geren = string.Empty;
            s_bumen = string.Empty;
            s_gongsi = string.Empty;
            s_chaxun = string.Empty;
            s_xiaoshou = string.Empty;

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];

                CheckBox Cchaxun = (CheckBox)row.FindControl("chaxun");
                Label Lchaxun = (Label)row.FindControl("chaxunid");//查询

                CheckBox Cquanbu = (CheckBox)row.FindControl("quanbu");
                Label Lquanbu = (Label)row.FindControl("quanbuid");//全部

                CheckBox Cxinzeng = (CheckBox)row.FindControl("xinzeng");
                Label Lxinzeng = (Label)row.FindControl("xinzengid");//新增

                CheckBox Cchakan = (CheckBox)row.FindControl("chakan");
                Label Lchakan = (Label)row.FindControl("chakanid");//查看　

                CheckBox Cxiguai = (CheckBox)row.FindControl("xiguai");
                Label Lxiguai = (Label)row.FindControl("xiguaiid");//修改

                CheckBox Cshanchu = (CheckBox)row.FindControl("shanchu");
                Label Lshanchu = (Label)row.FindControl("shanchuid");//删除

                CheckBox Cdaochu = (CheckBox)row.FindControl("daochu");
                Label Ldaochu = (Label)row.FindControl("daochuid");//导出

                CheckBox Cshenpi = (CheckBox)row.FindControl("shenpi");
                Label Lshenpi = (Label)row.FindControl("shenpiid");//审批

                CheckBox Cshouquan = (CheckBox)row.FindControl("shouquan");
                Label Lshouquan = (Label)row.FindControl("shouquanid");//授权


                RadioButton Cgeren = (RadioButton)row.FindControl("geren");
                Label Lgeren = (Label)row.FindControl("gerenid");//查看权限-个人


                RadioButton Cbumen = (RadioButton)row.FindControl("bumen");
                Label Lbumen = (Label)row.FindControl("bumenid");//查看权限-部门

                RadioButton Cgongsi = (RadioButton)row.FindControl("gongsi");
                Label Lgongsi = (Label)row.FindControl("gongsiid");//查看权限-公司


                RadioButton Cxiaoshou = (RadioButton)row.FindControl("xiaoshou");
                Label Lxiaoshou = (Label)row.FindControl("xiaoshouid");//查看权限-销售


                if (Cchaxun.Checked == true)
                {
                    s_chaxun += "|" + Lchaxun.Text + "";
                }



                if (Cgeren.Checked == true)
                {
                    s_geren += "|" + Lgeren.Text + "";
                }

                if (Cbumen.Checked == true)
                {
                    s_bumen += "|" + Lbumen.Text + "";
                }

                if (Cgongsi.Checked == true)
                {
                    s_gongsi += "|" + Lgongsi.Text + "";
                }

                if (Cxiaoshou.Checked == true)
                {
                    s_xiaoshou += "|" + Lxiaoshou.Text + "";
                }


                if (Cquanbu.Checked == true)
                {
                    s_quanbu += "|" + Lquanbu.Text + "";
                }

                if (Cxinzeng.Checked == true)
                {
                    s_xinzeng += "|" + Lxinzeng.Text + "";
                }

                if (Cchakan.Checked == true)
                {
                    s_chakan += "|" + Lchakan.Text + "";
                }

                if (Cxiguai.Checked == true)
                {
                    s_xiugai += "|" + Lxiguai.Text + "";
                }

                if (Cshanchu.Checked == true)
                {
                    s_shanchu += "|" + Lshanchu.Text + "";
                }

                if (Cdaochu.Checked == true)
                {
                    s_daochu += "|" + Ldaochu.Text + "";
                }

                if (Cshenpi.Checked == true)
                {
                    s_shenpi += "|" + Lshenpi.Text + "";
                }

                if (Cshouquan.Checked == true)
                {
                    s_shouquan += "|" + Lshouquan.Text + "";
                }

            }
            string s_all = string.Empty;
            s_all = s_quanbu + s_xinzeng + s_chakan + s_xiugai + s_shanchu + s_daochu + s_shenpi + s_shouquan + s_chaxun + s_geren + s_bumen + s_gongsi + s_xiaoshou;

           
            string Sql_update1 = "Update qp_Username  Set ResponQx='" + s_all + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";

            List.ExeSql(Sql_update1);
           


            InsertLog("设置用户权限[" + Name.Text + "]", "用户管理");

            this.Response.Write("<script language=javascript>alert('提交成功，您设置的用户，需要重新登陆后才能生效！');window.location.href='username.aspx'</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("username.aspx");
        }
    }
}

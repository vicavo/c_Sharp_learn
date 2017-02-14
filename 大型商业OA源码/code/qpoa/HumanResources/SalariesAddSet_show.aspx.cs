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
    public partial class SalariesAddSet_show : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static decimal h_allmoney, jb_allmoney, hj_allmoney;
        public static string syear, smonth;
        public int item_ts;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList = "select * from qp_SalariesAdd where Number='" + List.GetFormatStr(Request.QueryString["Number"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    SaName.Text = NewReader["SaName"].ToString();
                    SaNumber.Text = NewReader["SaNumber"].ToString();
                    Name.Text = NewReader["Name"].ToString();
                    DyTime.Text = "" + NewReader["DyYear"].ToString() + "年" + NewReader["DyMonth"].ToString() + "月";

                    SpRealname.Text = NewReader["SpRealname"].ToString();
                    State.Text = NewReader["State"].ToString();

                    SpRemark.Text = List.TbToLb(NewReader["SpRemark"].ToString());
                }
                NewReader.Close();



                #region 工资内容


                string SQL_Check_jb_allmoney = "select sum(JbMoney) as allmoney from qp_SaXzPerson where Number='" + Request.QueryString["Number"] + "' ";

                SqlDataReader MyReader_jb_allmoney = List.GetList(SQL_Check_jb_allmoney);
                if (MyReader_jb_allmoney.Read())
                {

                    if (MyReader_jb_allmoney["allmoney"].ToString() == "")
                    {
                        jb_allmoney = 0;
                    }
                    else
                    {
                        jb_allmoney = decimal.Parse(MyReader_jb_allmoney["allmoney"].ToString());
                    }

                }//得到基本工资总和
                else
                {
                    jb_allmoney = 0;
                }
                MyReader_jb_allmoney.Close();




                string SQL_Check_hj_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData   where Number='" + Request.QueryString["number"] + "' ";

                SqlDataReader MyReader_hj_allmoney = List.GetList(SQL_Check_hj_allmoney);
                if (MyReader_hj_allmoney.Read())
                {

                    if (MyReader_hj_allmoney["allmoney"].ToString() == "")
                    {
                        hj_allmoney = jb_allmoney;
                    }
                    else
                    {
                        hj_allmoney = jb_allmoney + decimal.Parse(MyReader_hj_allmoney["allmoney"].ToString());
                    }
                }//得到基本工资+其他
                else
                {
                    hj_allmoney = jb_allmoney;
                }
                MyReader_hj_allmoney.Close();




                this.mx.Text += "<table cellSpacing=0 cellPadding=4 width=99% border=1 id=tableExcel>";

                this.mx.Text += "<tr><td><b>姓名</b></td><td><b>部门</b></td><td><b>基本工资</b></td>";

                string SQL_Check_bt = "select * from qp_SaProduct where SaNumber='" + SaNumber.Text + "' order by PaiXun asc";
                SqlDataReader MyReader_bt = List.GetList(SQL_Check_bt);
                while (MyReader_bt.Read())
                {
                    this.mx.Text += "<td><b>" + MyReader_bt["Name"].ToString() + "</b></td>";


                }//得到表头---薪资项目
                MyReader_bt.Close();

                mx.Text += "<td><b>计件产品</b></td><td><b>计件工序</b></td><td><b>计时工种</b></td><td><b>总金额</b></td></tr>";//得到表头--其他项目





                string SQL_Check_zj = "select * from qp_SaXzPerson where Number='" + Request.QueryString["Number"] + "' order by id desc";
                SqlDataReader MyReader_zj = List.GetList(SQL_Check_zj);
                while (MyReader_zj.Read())
                {


                    this.mx.Text += "<tr ><td>" + MyReader_zj["Realname"].ToString() + "</td><td>" + MyReader_zj["Unit"].ToString() + "</td><td>" + MyReader_zj["JbMoney"].ToString() + "</td>";


                    string SQL_Check_zj_xm = "select * from qp_SaProduct where SaNumber='" + SaNumber.Text + "' order by PaiXun asc";
                    SqlDataReader MyReader_zj_xm = List.GetList(SQL_Check_zj_xm);
                    while (MyReader_zj_xm.Read())
                    {

                        string SQL_Check_z_allmoney = "select id,SaMoney  from qp_SalariesAddData where  DyUsername='" + MyReader_zj["username"] + "' and    SaItem='" + MyReader_zj_xm["Name"].ToString() + "' and   Number='" + Request.QueryString["Number"] + "'";

                        SqlDataReader MyReader_z_allmoney = List.GetList(SQL_Check_z_allmoney);

                        if (MyReader_z_allmoney.Read())
                        {
                            if (MyReader_z_allmoney["SaMoney"].ToString() == "")
                            {
                                this.mx.Text += "<td>0</td>";
                            }
                            else
                            {
                                this.mx.Text += "<td>" + MyReader_z_allmoney["SaMoney"].ToString() + "</td>";
                            }

                        }
                        else
                        {
                            this.mx.Text += "<td>0</td>";
                        }
                        MyReader_z_allmoney.Close();
                    }
                    MyReader_zj_xm.Close();//中间薪资项目的金额







                    string SQL_Check_jjcp_zj = "select id,SaMoney from qp_SalariesAddData where SaItem='计件产品'  and   DyUsername='" + MyReader_zj["username"] + "'  and   Number='" + Request.QueryString["Number"] + "'";

                    SqlDataReader MyReader_jjcp_zj = List.GetList(SQL_Check_jjcp_zj);

                    if (MyReader_jjcp_zj.Read())
                    {

                        this.mx.Text += "<td>" + MyReader_jjcp_zj["SaMoney"].ToString() + "</td>";


                    }

                    MyReader_jjcp_zj.Close();//中间----计件产品





                    string SQL_Check_jjgx_zj = "select id,SaMoney from qp_SalariesAddData where SaItem='计件工序'  and   DyUsername='" + MyReader_zj["username"] + "'  and   Number='" + Request.QueryString["Number"] + "'";

                    SqlDataReader MyReader_jjgx_zj = List.GetList(SQL_Check_jjgx_zj);

                    if (MyReader_jjgx_zj.Read())
                    {

                        this.mx.Text += "<td>" + MyReader_jjgx_zj["SaMoney"].ToString() + "</td>";


                    }

                    MyReader_jjgx_zj.Close();//中间----计件工序




                    string SQL_Check_jsgz_zj = "select id,SaMoney from qp_SalariesAddData where SaItem='计时工种'  and   DyUsername='" + MyReader_zj["username"] + "'  and   Number='" + Request.QueryString["Number"] + "'";

                    SqlDataReader MyReader_jsgz_zj = List.GetList(SQL_Check_jsgz_zj);

                    if (MyReader_jsgz_zj.Read())
                    {

                        this.mx.Text += "<td>" + MyReader_jsgz_zj["SaMoney"].ToString() + "</td>";


                    }

                    MyReader_jsgz_zj.Close();//中间----计时工种





                    string SQL_Check_all_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData where  DyUsername='" + MyReader_zj["username"] + "'  and   Number='" + Request.QueryString["Number"] + "'";

                    SqlDataReader MyReader_all_allmoney = List.GetList(SQL_Check_all_allmoney);

                    if (MyReader_all_allmoney.Read())
                    {
                        if (MyReader_all_allmoney["allmoney"].ToString() == "")
                        {
                            this.mx.Text += "<td>" + decimal.Parse(MyReader_zj["JbMoney"].ToString()) + "</td><tr></tr>";
                        }
                        else
                        {
                            decimal allreadmoney = decimal.Parse(MyReader_all_allmoney["allmoney"].ToString()) + decimal.Parse(MyReader_zj["JbMoney"].ToString());
                            this.mx.Text += "<td>" + allreadmoney + "</font></td><tr></tr>";
                        }

                    }
                    else
                    {
                        this.mx.Text += "<td>" + decimal.Parse(MyReader_zj["JbMoney"].ToString()) + "</td><tr></tr>";
                    }
                    MyReader_all_allmoney.Close();//中间的金额总计







                }
                MyReader_zj.Close();





                //this.mx.Text += "";































                //表尾
                this.mx.Text += "<tr><td  colspan=2><font color=red><b>合计金额：</b></font></td><td><font color=red>" + jb_allmoney + "</font></td>";
                string SQL_Check_bw = "select * from qp_SaProduct where SaNumber='" + SaNumber.Text + "' order by PaiXun asc";
                SqlDataReader MyReader_bw = List.GetList(SQL_Check_bw);
                while (MyReader_bw.Read())
                {

                    string SQL_Check_w_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData where SaItem='" + MyReader_bw["Name"].ToString() + "' and   Number='" + Request.QueryString["Number"] + "'";

                    SqlDataReader MyReader_w_allmoney = List.GetList(SQL_Check_w_allmoney);

                    if (MyReader_w_allmoney.Read())
                    {
                        if (MyReader_w_allmoney["allmoney"].ToString() == "")
                        {
                            this.mx.Text += "<td><font color=red>0</font></td>";
                        }
                        else
                        {
                            this.mx.Text += "<td><font color=red>" + MyReader_w_allmoney["allmoney"].ToString() + "</font></td>";
                        }

                    }
                    else
                    {
                        this.mx.Text += "<td><font color=red>0</font></td>";
                    }
                    MyReader_w_allmoney.Close();

                }//得到表尾---薪资项目
                MyReader_bw.Close();



                string SQL_Check_jjcp_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData where SaItem='计件产品'  and   Number='" + Request.QueryString["Number"] + "'";

                SqlDataReader MyReader_jjcp_allmoney = List.GetList(SQL_Check_jjcp_allmoney);

                if (MyReader_jjcp_allmoney.Read())
                {
                    if (MyReader_jjcp_allmoney["allmoney"].ToString() == "")
                    {
                        this.mx.Text += "<td><font color=red>0</font></td>";
                    }
                    else
                    {
                        this.mx.Text += "<td><font color=red>" + MyReader_jjcp_allmoney["allmoney"].ToString() + "</font></td>";
                    }

                }
                else
                {
                    this.mx.Text += "<td><font color=red>0</font></td>";
                }
                MyReader_jjcp_allmoney.Close();//得到表尾---计件产品





                string SQL_Check_jjgx_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData where SaItem='计件工序'  and   Number='" + Request.QueryString["Number"] + "'";

                SqlDataReader MyReader_jjgx_allmoney = List.GetList(SQL_Check_jjgx_allmoney);

                if (MyReader_jjgx_allmoney.Read())
                {
                    if (MyReader_jjgx_allmoney["allmoney"].ToString() == "")
                    {
                        this.mx.Text += "<td><font color=red>0</font></td>";
                    }
                    else
                    {
                        this.mx.Text += "<td><font color=red>" + MyReader_jjgx_allmoney["allmoney"].ToString() + "</font></td>";
                    }

                }
                else
                {
                    this.mx.Text += "<td><font color=red>0</font></td>";
                }
                MyReader_jjgx_allmoney.Close();//得到表尾---计件工序




                string SQL_Check_jsgz_allmoney = "select sum(SaMoney) as allmoney from qp_SalariesAddData where SaItem='计时工种'  and   Number='" + Request.QueryString["Number"] + "'";

                SqlDataReader MyReader_jsgz_allmoney = List.GetList(SQL_Check_jsgz_allmoney);

                if (MyReader_jsgz_allmoney.Read())
                {
                    if (MyReader_jsgz_allmoney["allmoney"].ToString() == "")
                    {
                        this.mx.Text += "<td><font color=red>0</font></td>";
                    }
                    else
                    {
                        this.mx.Text += "<td><font color=red>" + MyReader_jsgz_allmoney["allmoney"].ToString() + "</font></td>";
                    }

                }
                else
                {
                    this.mx.Text += "<td><font color=red>0</font></td>";
                }
                MyReader_jsgz_allmoney.Close();//得到表尾---计件工序




                this.mx.Text += "<td><font color=red>" + hj_allmoney + "</font></td></tr>";





                this.mx.Text += "</table>";
                #endregion




            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesAdd.aspx';window.close();</script>");
        //}
    }
}

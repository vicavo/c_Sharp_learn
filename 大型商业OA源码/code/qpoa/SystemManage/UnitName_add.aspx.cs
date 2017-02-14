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
namespace qpoa
{
    public partial class UnitName_add : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public string LineW, QxString, QxStringSta,LineWSta;
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
            }

            string sql_down_bh = "select id,Linew+name as aaa  from qp_UnitName order by QxString asc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_unit(ParentNodesID, sql_down_bh, "id", "aaa");
            }

            if (Request.QueryString["id"] != null)
            {
                try
                {
                    ParentNodesID.SelectedValue = Request.QueryString["id"].ToString();
                }
                catch
                {
                    ParentNodesID.SelectedValue = "0";
                }
            }


        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return chknull();";
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("UnitName_show.aspx?id=10000");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string SQL_GetList_sta = "select top 1 * from qp_UnitName where id='" + ParentNodesID .SelectedValue+ "' ";
            SqlDataReader NewReader_sta = List.GetList(SQL_GetList_sta);
            if (NewReader_sta.Read())
            {
                QxStringSta = NewReader_sta["QxString"].ToString();
                LineWSta = NewReader_sta["LineW"].ToString();
            }
            NewReader_sta.Close();

            if (ParentNodesID.SelectedValue == "0")
            {
                string SQL_GetList = "select top 1 * from qp_UnitName where ParentNodesID='0' order by QxString desc";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    string SQL_GetList_key = "select  top 1 * from qp_UnitNameKey where id>(select  id  from qp_UnitNameKey where name='" + NewReader["QxString"] + "') order by name asc";
                 //   Response.Write("SQL_GetList_key：" + SQL_GetList_key + "<br>");
                    SqlDataReader NewReadert_key = List.GetList(SQL_GetList_key);
                    if (NewReadert_key.Read())
                    {
                        QxString = NewReadert_key["name"].ToString();
                        LineW = "|-";

                    }
                    else
                    {
                        QxString = "aaaaa";
                        LineW = "|-";
                    }
                    NewReadert_key.Close();

                }
                else
                {
                    QxString = "aaaaa";
                    LineW = "|-";
                }
                NewReader.Close();//如果节点在根节点，那么直接读去qp_UnitNameKey，得到QxString；
               
            }
            else
            {
                string SQL_GetList = "select  * from qp_UnitName where id='" + ParentNodesID .SelectedValue+ "'";
               // Response.Write("SQL_GetList：" + SQL_GetList + "<br>");
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    if (NewReader["QxString"].ToString().Length == 5)
                    {
                        
                        string SQL_GetList_key = "select  top 1 * from qp_UnitName where  QxString like '%" + NewReader["QxString"].ToString() + "%' and  len(QxString)=9 order by QxString desc";

                      //  Response.Write("SQL_GetList_key：" + SQL_GetList_key + "<br>");
                        SqlDataReader NewReadert_key = List.GetList(SQL_GetList_key);
                        if (NewReadert_key.Read())
                        {//直接为aaaaa或bbbbb的时候

                            string qxint = null;
                            qxint = NewReadert_key["QxString"].ToString().Substring(NewReadert_key["QxString"].ToString().Length - 4, 3);//得到最后２个数字。
                       //   Response.Write("qxint：" + qxint + "<br>");
                            int qxint_s = int.Parse(qxint) + 1;//把得到最后3个数字加１。
                            QxString = "" + QxStringSta + "" + qxint_s + "a";
                         //  Response.Write("QxString：" + QxString + "<br>");

                            LineW = "|---";
                          
                         // Response.Write("LineW：" + LineW + "<br>");

                        }
                        else
                        {
                            QxString = "" + QxStringSta + "100a";
                            //Response.Write("QxString：" + QxString + "<br>");
                            LineW = "|---";

                         //  Response.Write("LineW：" + LineW + "<br>");


                        }//如果没有，直接为１０

                        NewReadert_key.Close();

                    }
                    else
                    {　
                        //有数字可以直接加
                        string SQL_GetList_key = "select  top 1 * from qp_UnitName where  QxString like '%" + NewReader["QxString"].ToString() + "%' and  len(QxString)=" + NewReader["QxString"].ToString().Length + "+4 order by QxString desc";

                       //Response.Write("SQL_GetList_key：" + SQL_GetList_key + "<br>");
                        SqlDataReader NewReadert_key = List.GetList(SQL_GetList_key);
                        if (NewReadert_key.Read())
                        {

                            string qxint = null;
                            qxint = NewReadert_key["QxString"].ToString().Substring(NewReadert_key["QxString"].ToString().Length - 4, 3);//得到最后3个数字。
                          // Response.Write("qxint：" + qxint + "<br>");
                            int qxint_s = int.Parse(qxint) + 1;//把得到最后3个数字加１。
                            QxString = "" + QxStringSta + "" + qxint_s + "a";
                           //Response.Write("QxString：" + QxString + "<br>");


                            LineW = "|-";
                            for (int i = 0; i < LineWSta.ToString().Length +2; i++)
                            {
                                LineW = LineW + "-";
                            }
                          // Response.Write("LineW：" + LineW + "<br>");

                        }
                        else
                        {
                            string SQL_GetList_key1 = "select  top 1 * from qp_UnitName where  QxString like '%" + NewReader["QxString"].ToString().Substring(0, NewReader["QxString"].ToString().Length - 4) + "%' and  len(QxString)=" + NewReader["QxString"].ToString().Length + " order by QxString desc";
                           //Response.Write("SQL_GetList_key1：" + SQL_GetList_key1 + "<br>");

                            SqlDataReader NewReadert_key1 = List.GetList(SQL_GetList_key1);
                            if (NewReadert_key1.Read())
                            {
                                QxString = "" + QxStringSta + "100a";


                                LineW = "|-";
                                for (int i = 0; i < LineWSta.ToString().Length + 2; i++)
                                {
                                    LineW = LineW + "-";
                                }
                            }

                         // Response.Write("LineW：" + LineW + "<br>");
                        }//如果没有，直接为100

                        NewReadert_key.Close();
                    }


                 



                }
                NewReader.Close();
            }




            string sql_insert = "insert into qp_UnitName (Name,remark,ParentNodesID,KeyQx,LineW,QxString) values ('" + List.GetFormatStr(Name.Text) + "','" + List.GetFormatStr(remark.Text) + "','" + List.GetFormatStr(ParentNodesID.SelectedValue) + "','" + List.GetFormatStr(KeyQx.SelectedValue) + "','" + LineW + "','" + QxString + "')";
            List.ExeSql(sql_insert);
            InsertLog("新增部门[" + Name.Text + "]", "部门管理");

            this.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'UnitName.aspx'</script>");
        


        }

        public void InsertLog(string Name, string MkName)
        {

            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }



    }
}

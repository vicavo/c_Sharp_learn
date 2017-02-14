using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Data.SqlClient;
namespace qpsmartweb.Public
{
    public class Db
    {
        public static string strConn = "";
        public static DataView Config;
        public static DataView Board;

        public string DbPath()
        {
            strConn = "" + System.Configuration.ConfigurationManager.AppSettings["connstr"].ToString() + "";
            return strConn;
        }// 数据库连接字符串。


        public static string ConnectionString
        {
            get
            {
                Db ConnectionString = new Db();
                return ConnectionString.DbPath();
            }
        }// 数据库连接字符串属性。


        public void ToExcel(System.Web.UI.Control ctl, string FileName)
        {
            HttpContext.Current.Response.Charset = "UTF-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.Default;
            HttpContext.Current.Response.ContentType = "application/ms-excel";
            HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "" + FileName + ".xls");
            ctl.Page.EnableViewState = false;
            System.IO.StringWriter tw = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(tw);
            ctl.RenderControl(hw);
            HttpContext.Current.Response.Write(tw.ToString());
            HttpContext.Current.Response.End();
        }//导入excel


        public void QuanXianVis(System.Web.UI.Control ctl,string qxname,string qxstr)
        {
            if (!StrIFInStr(qxname, qxstr))
            {
                ctl.Visible = false;
            }
            else
            {
                ctl.Visible = true;
            }

        }//按钮权限管理


        public bool StrIFInStr(string Str1, string Str2)
        {
            if (Str2.IndexOf(Str1) < 0)
            {

                return false;
            }
            else
            {

                return true;
            }

        } //权限判断

        public SqlDataReader GetList(string Sql)
        {

            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlCommand myCommand = new SqlCommand(Sql, myConnection);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
            myCommand.Dispose();
            return result;
          
            
        }// 提取数据操作——用于“DataReader”控件。

       
        public DataView GetGrid(string Sql, string Tb)
        {
            DataSet DS;
            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlDataAdapter myCommand = new SqlDataAdapter(Sql, myConnection);
            DS = new DataSet();
            myCommand.Fill(DS, Tb);
            DataView result = DS.Tables[Tb].DefaultView;

            myCommand.Dispose();
            return result;
        }


        public int ExeSql(string Sql)
        {
            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlCommand myCommand = new SqlCommand(Sql, myConnection);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myCommand.Dispose();
                myConnection.Close();
                return 1;
            }
            catch
            {
                myCommand.Dispose();
                myConnection.Close();
                return 0;
            }
        }  // 执行无提取值的 SQL 语句。
      
        public DataView GetGrid_Pages(string Sql, string Sort)
        {
            DataTable Cart = new DataTable();

            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlDataAdapter myCommand = new SqlDataAdapter(Sql, myConnection);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "MyDt");
            Cart = ds.Tables["MyDt"];

            DataView CartView = new DataView(Cart);
            CartView.Sort = Sort + " Desc";

            myCommand.Dispose();
            myConnection.Close();
            return CartView;
           
            
        }  // 提取数据操作——用于“GridView”控件。


      
        public DataView GetGrid_Pages_not(string Sql)
        {
            DataTable Cart = new DataTable();

            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlDataAdapter myCommand = new SqlDataAdapter(Sql, myConnection);
            DataSet ds = new DataSet();
            myCommand.Fill(ds, "MyDt");
            Cart = ds.Tables["MyDt"];

            DataView CartView = new DataView(Cart);
            //CartView.Sort = Sort + " asc";

            myCommand.Dispose();
            myConnection.Close();
            return CartView;
         
          

        }  // 提取数据操作——用于“GridView”控件不排序。

        public int GetCount(string Sql)
        {
            SqlConnection myConnection = new SqlConnection(Db.ConnectionString);
            SqlCommand myCommand = new SqlCommand(Sql, myConnection);

            myConnection.Open();
            SqlDataReader result = myCommand.ExecuteReader();
            int i = 0;
            while (result.Read())
            {
                i = result.GetInt32(0);
            }
            result.Close();
            myCommand.Dispose();
            myConnection.Close();
            return i;
        }//得到某数据表中纪录的条数，返回 int 型值。







        public string GetFormatStr(string AStr)
        {

            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("<", "〈");
                AStr = AStr.Replace(">", "〉");
                AStr = AStr.Replace("'", "’");

                return AStr;
            }
        }//格式化字符串

        public string GetFormatStrbjq(string AStr)
        {

            if ("" == AStr)
                return "";

            else
            {
               
                AStr = AStr.Replace("'", "’");

                return AStr;
            }
        }//格式化字符串——用编辑器的－录入的时候



        public string GetFormatStrmb(string AStr)
        {

            if ("" == AStr)
                return "";

            else
            {

                AStr = AStr.Replace("'", "’");
                AStr = AStr.Replace("\"", "");

                return AStr;
            }
        }//格式化字符串——用编辑器的－设置模版的时候


        public string GetFormatStrbjq_show(string AStr)
        {

            if ("" == AStr)
                return "";

            else
            {

                AStr = AStr.Replace("’", "'");

                return AStr;
            }
        }//格式化字符串——用编辑器的－显示的时候

        public string TbToLb(string AStr)
        {

            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("\n", "<br>");
                AStr = AStr.Replace(" ", "&nbsp;&nbsp;");
               

                return AStr;
            }
        }//从textbox的数据转换到lable中

    }

    // 将数据绑定到下拉列表上。
    public class BindDrowDownList
    {
        Db List = new Db();

      
        public void Bind_DropDownList(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "请选择";
            Item.Value = "请选择";
            MyDropDownList.Items.Insert(0, Item);
        }


        public void Bind_DropDownListFlow(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "所有表单类型";
            Item.Value = "0";
            MyDropDownList.Items.Insert(0, Item);
        }


        public void Bind_DropDownListFlowBh(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "开始";
            Item.Value = "0";
            MyDropDownList.Items.Insert(0, Item);
        }//驳回


        public void Bind_DropDownListForm(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "常规表单字段";
            Item.Value = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "";
            MyDropDownList.Items.Insert(0, Item);
        }



        public void Bind_DropDownList_unit(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "根节点";
            Item.Value = "0";
            MyDropDownList.Items.Insert(0, Item);
        }



        public void Bind_DropDownList_gd(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "不归档";
            Item.Value = "0";
            MyDropDownList.Items.Insert(0, Item);
        }



        public void Bind_DropDownList_kong(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();
            Item.Text = "";
            Item.Value = "";
            MyDropDownList.Items.Insert(0, Item);
        }


        // 将码表中的数据绑定到下拉列表中去。其中参数“MyDropDownList”为下拉列表对象、“SQL”为获取绑定数据的SQL语句、“DataValueField”为填充下拉列表项value值的数据字段、“DataTextField”为填充下拉列表项text值的数据字段。


        public void Bind_DropDownList_ListBox(System.Web.UI.WebControls.ListBox MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

       
        }

        public void Bind_DropDownList_nothing(System.Web.UI.WebControls.DropDownList MyDropDownList, string SQL, string DataValueField, string DataTextField)
        {
            string SQL_GetCode = SQL;
            MyDropDownList.DataSource = List.GetGrid(SQL_GetCode, "DataView");
            MyDropDownList.DataValueField = DataValueField;
            MyDropDownList.DataTextField = DataTextField;
            MyDropDownList.DataBind();

            System.Web.UI.WebControls.ListItem Item = new ListItem();

            //MyDropDownList.Items.Insert(0, Item);
        }


        public void Bind_DropDownList_Year(System.Web.UI.WebControls.DropDownList MyDropDownList, int _Begin, int _End)
        {
            ArrayList myList = new ArrayList();
            myList.Add("----");

            for (int i = _Begin; i <= _End; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }   /// 将年份绑定到下拉列表中，其中参数“_Begin”为起始年份、“_End”为结束年份。



        public void Bind_DropDownList_YearForSa(System.Web.UI.WebControls.DropDownList MyDropDownList, int _Begin, int _End)
        {
            ArrayList myList = new ArrayList();
            //myList.Add("----");

            for (int i = _Begin; i <= _End; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }   /// 将年份绑定到下拉列表中，其中参数“_Begin”为起始年份、“_End”为结束年份。薪资录入。


        public void Bind_DropDownList_MonthForSa(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
            //myList.Add("----");

            for (int i = 1; i < 13; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        } /// 将月份绑定到下拉列表中。薪资录入。

        public void Bind_DropDownList_Month(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
            myList.Add("----");

            for (int i = 1; i < 13; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        } /// 将月份绑定到下拉列表中。


      
        public void Bind_DropDownList_Date(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
           // myList.Add("----");

            for (int i = 1; i < 32; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }  /// 将日期绑定到下拉列表中。



        public void Bind_DropDownList_Kq(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();

            for (int i = 1; i < 29; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }  /// 考勤开始时间
           

      
        public void Bind_DropDownList_Hour(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
           // myList.Add("----");

            for (int i = 0; i < 24; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }  /// 将小时绑定到下拉列表中。

     
        public void Bind_DropDownList_Mini(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
            //myList.Add("----");

            for (int i = 0; i < 60; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        }   /// 将分绑定到下拉列表中。
       
        public void Bind_DropDownList_Age(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            ArrayList myList = new ArrayList();
            myList.Add("[请选择年龄]");

            for (int i = 20; i < 50; i++) myList.Add(i.ToString());

            MyDropDownList.DataSource = myList;
            MyDropDownList.DataBind();
        } //将年龄绑定到下拉列表中。
     
        public void Bind_DropDownList_Sex(System.Web.UI.WebControls.DropDownList MyDropDownList)
        {
            System.Web.UI.WebControls.ListItem Item1 = new ListItem();
            System.Web.UI.WebControls.ListItem Item2 = new ListItem();
            System.Web.UI.WebControls.ListItem Item3 = new ListItem();

            Item1.Text = "------------------------------------------------";
            Item1.Value = "----";
            Item2.Text = "男";
            Item2.Value = "1";
            Item3.Text = "女";
            Item3.Value = "0";

            MyDropDownList.Items.Add(Item1);
            MyDropDownList.Items.Add(Item2);
            MyDropDownList.Items.Add(Item3);
        }   /// 将性别绑定到下拉列表中。
    }


}
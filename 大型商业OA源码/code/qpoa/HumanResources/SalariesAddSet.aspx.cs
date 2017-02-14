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
    public partial class SalariesAddSet : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();

        public static string fjkey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }


            if (!IsPostBack)
            {

                BindDroList();
                BindAttribute();


            }
            if (!IsPostBack)
            {
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }


        }
        public void BindDroList()
        {
            string sql_down_bh = "select *  from qp_SalariesSet where IfOk='是' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList_nothing(SaName, sql_down_bh, "Number", "Name");
            }

            list.Bind_DropDownList_YearForSa(DyYear,2006,2016);
            list.Bind_DropDownList_MonthForSa(DyMonth);

            DyYear.SelectedValue = System.DateTime.Now.Year.ToString();
            DyMonth.SelectedValue = System.DateTime.Now.Month.ToString();


        }
        public void BindAttribute()
        {

            //Button1.Attributes["onclick"] = "javascript:return chknull();";
            Button4.Attributes["onclick"] = "javascript:return chknull();";
        }




        protected void Button1_Click(object sender, EventArgs e)
        {

            //string SQL_GetList = "select * from qp_SalariesAdd where DyYear='" + DyYear.SelectedValue + "'  and  DyMonth='" + DyMonth.SelectedValue + "' ";
            //SqlDataReader NewReader = List.GetList(SQL_GetList);
            //if (NewReader.Read())
            //{
            //    this.Response.Write("<script language=javascript>alert('" + DyYear.SelectedValue + "年" + DyMonth.SelectedValue + "月已经存在数据！');</script>");
            //}
            //NewReader.Close();


            //string sql_insert = "insert into qp_SalariesAdd    (Number,SaNumber,SaName,Name,DyYear,DyMonth,State,SpUsername,SpRealname,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + DyYear.SelectedValue + "','" + DyMonth.SelectedValue + "','未审批','','','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            //List.ExeSql(sql_insert);

            //InsertLog("薪资录入[" + Name.Text + "]", "薪资管理");
            //this.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='SalariesAdd.aspx';window.close();</script>");
        }

        public void InsertLog(string Name, string MkName)
        {
            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                   + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string SQL_GetListc = "select * from qp_SalariesAdd where DyYear='" + DyYear.SelectedValue + "'  and  DyMonth='" + DyMonth.SelectedValue + "' and State='已通过'";
            SqlDataReader NewReaderc = List.GetList(SQL_GetListc);
            if (NewReaderc.Read())
            {
                this.Response.Write("<script language=javascript>alert('" + DyYear.SelectedValue + "年" + DyMonth.SelectedValue + "月已经存在通过审批的工资数据！');</script>");
                return;
            }
            NewReaderc.Close();


            string sql_insert = "insert into qp_SalariesAdd    (Number,SaNumber,SaName,Name,DyYear,DyMonth,State,SpUsername,SpRealname,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + DyYear.SelectedValue + "','" + DyMonth.SelectedValue + "','未审批','','','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert);

            InsertLog("薪资录入[" + Name.Text + "]", "薪资管理");


            string  SQtMonth = null, EQtMonth = null,QtSql=null;

            string SQL_GetList_Qt = "select * from qp_SalariesSet where Number='" + SaName.SelectedValue + "'";
            SqlDataReader NewReader_Qt = List.GetList(SQL_GetList_Qt);
            if (NewReader_Qt.Read())//判断数据来源
            {
                //if (NewReader_Qt["HsMonth"].ToString() == "本月数据")
                //{
                //    SQtMonth = "" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + NewReader_Qt["Startime"].ToString() + "";
                //    EQtMonth = "" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + NewReader_Qt["Endtime"].ToString() + "";


                
                //}
                //if (NewReader_Qt["HsMonth"].ToString() == "上一月数据")
                //{
                    SQtMonth = "" + System.DateTime.Now.AddMonths(-1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(-1).Month.ToString() + "-" + NewReader_Qt["Startime"].ToString() + "";
                    EQtMonth = "" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + NewReader_Qt["Endtime"].ToString() + "";


                //}
                //if (NewReader_Qt["HsMonth"].ToString() == "下一月数据")
                //{
                //    SQtMonth = "" + System.DateTime.Now.AddMonths(1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(1).Month.ToString() + "-" + NewReader_Qt["Startime"].ToString() + "";
                //    EQtMonth = "" + System.DateTime.Now.AddMonths(1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(1).Month.ToString() + "-" + NewReader_Qt["Endtime"].ToString() + "";
                //}

                QtSql = " and (WorkTime between '" + SQtMonth + "'and  '" + EQtMonth + "' or convert(char(10),cast(WorkTime as datetime),120)=convert(char(10),cast('" + SQtMonth + "' as datetime),120) or convert(char(10),cast(WorkTime as datetime),120)=convert(char(10),cast('" + EQtMonth + "' as datetime),120) ) ";


            }
            NewReader_Qt.Close();




            string SQL_GetList = "select * from qp_SaPerson where SaNumber='" + SaName.SelectedValue + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            while (NewReader.Read())//读去帐套对应人员，保存进薪资明细表，用于读去全部薪资信息
            {

                string SQL_GetListXm = "select * from qp_SaProduct where SaNumber='" + SaName.SelectedValue + "'";
                SqlDataReader NewReaderXm = List.GetList(SQL_GetListXm);
                while (NewReaderXm.Read())//读去帐套对应项目。
                {

                    if (NewReaderXm["IfGs"].ToString() == "是")//是否包含计算公式，不包含计算公式直接插进去
                    {
                        int sLenth = NewReaderXm["GsName"].ToString().IndexOf("[");//截取特殊字段
                        int eLenth = NewReaderXm["GsName"].ToString().IndexOf("]") - (NewReaderXm["GsName"].ToString().IndexOf("[") - 1);//截取特殊字段

                        string setstr = null;
                        setstr = NewReaderXm["GsName"].ToString().Substring(sLenth, eLenth);


                        string returnint = CreateSaSql(setstr, NewReader["Username"].ToString());//得到特殊字段的数据和。如［请假天数］
                        int var1a = Convert.ToInt32(Eval(CreateStr(NewReaderXm["GsName"].ToString(), returnint)));//将文字公式转换成数学公式


                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + NewReaderXm["Name"] + "','" + var1a + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);


                    }
                    else
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + NewReaderXm["Name"] + "','" + NewReaderXm["CsMoney"] + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);
                    }


                }
                NewReaderXm.Close();//特殊字段




                string SQL_GetList_jjcp = "select sum(AllMoney) as counts from qp_SaXzPieces where DyUsername='" + NewReader["username"] + "'  and SaNumber='" + SaName.SelectedValue + "'  " + QtSql + "";
                //计件产品
                SqlDataReader NewReader_jjcp = List.GetList(SQL_GetList_jjcp);
                if (NewReader_jjcp.Read())
                {
                    if (NewReader_jjcp["counts"].ToString() == "")
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计件产品','0','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);
                    }
                    else
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计件产品','" + NewReader_jjcp["counts"] + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);

                    }

                }
                NewReader_jjcp.Close();// //计件产品





                string SQL_GetList_jjgx = "select sum(AllMoney) as counts from qp_SaXzPiecesPro where DyUsername='" + NewReader["username"] + "'  and SaNumber='" + SaName.SelectedValue + "'  " + QtSql + "";
                //计件工序
                SqlDataReader NewReader_jjgx = List.GetList(SQL_GetList_jjgx);
                if (NewReader_jjgx.Read())
                {
                    if (NewReader_jjgx["counts"].ToString() == "")
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计件工序','0','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);
                    }
                    else
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计件工序','" + NewReader_jjgx["counts"] + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);

                    }

                }
                NewReader_jjgx.Close();// //计件工序




                string SQL_GetList_jsgz = "select sum(AllMoney) as counts from qp_SaXzJobs where DyUsername='" + NewReader["username"] + "'  and SaNumber='" + SaName.SelectedValue + "'  " + QtSql + "";
                //计时工种
                SqlDataReader NewReader_jsgz = List.GetList(SQL_GetList_jsgz);
                if (NewReader_jsgz.Read())
                {
                    if (NewReader_jsgz["counts"].ToString() == "")
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计时工种','0','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);
                    }
                    else
                    {
                        string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','计时工种','" + NewReader_jsgz["counts"] + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                        List.ExeSql(sql_insert_data);

                    }

                }
                NewReader_jsgz.Close();// //计时工种





            }
            NewReader.Close();










            //string SQL_GetListXm = "select * from qp_SaProduct where SaNumber='" + SaName.SelectedValue + "'";
            //SqlDataReader NewReaderXm = List.GetList(SQL_GetListXm);
            //while (NewReaderXm.Read())//读去帐套对应项目。
            //{

            //    string SQL_GetList = "select * from qp_SaPerson where SaNumber='" + SaName.SelectedValue + "'";
            //    SqlDataReader NewReader = List.GetList(SQL_GetList);
            //    while (NewReader.Read())//读去帐套对应人员，保存进薪资明细表，用于读去全部薪资信息
            //    {

            //            if (NewReaderXm["IfGs"].ToString() == "是")//是否包含计算公式，不包含计算公式直接插进去
            //            {
            //                int sLenth = NewReaderXm["GsName"].ToString().IndexOf("[");//截取特殊字段
            //                int eLenth = NewReaderXm["GsName"].ToString().IndexOf("]") - (NewReaderXm["GsName"].ToString().IndexOf("[") - 1);//截取特殊字段

            //                string setstr = null;
            //                setstr = NewReaderXm["GsName"].ToString().Substring(sLenth, eLenth);


            //                string returnint = CreateSaSql(setstr);//得到特殊字段的数据和。如［请假天数］
            //                int var1a = Convert.ToInt32(Eval(CreateStr(NewReaderXm["GsName"].ToString(), returnint)));//将文字公式转换成数学公式


            //                string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + NewReaderXm["Name"] + "','" + var1a + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            //                List.ExeSql(sql_insert_data);


            //            }
            //            else
            //            {
            //                string sql_insert_data = "insert into qp_SalariesAddData  (Number,SaNumber,SaName,Name,DyUsername,DyRealname,SaItem,SaMoney,Username,Realname,NowTimes) values ('" + Number.Text + "','" + SaName.SelectedValue + "','" + SaName.SelectedItem.Text + "','" + List.GetFormatStr(Name.Text) + "','" + NewReader["username"] + "','" + NewReader["realname"] + "','" + NewReaderXm["Name"] + "','" + NewReaderXm["CsMoney"] + "','" + Session["Username"] + "','" + Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            //                List.ExeSql(sql_insert_data);
            //            }


            //     }
            //     NewReader.Close();

            //}
            //NewReaderXm.Close();









            string SQL_GetListry = "select * from qp_SaPerson where SaNumber='" + SaName.SelectedValue + "'";
            SqlDataReader NewReaderry = List.GetList(SQL_GetListry);
            while (NewReaderry.Read())//读去帐套对应人员，保存进薪资明细表，用于读去全部薪资信息
            {
                string sql_insert_data = "insert into qp_SaXzPerson  (Number,Username,Realname,UnitId,Unit,JbMoney,SaNumber) values ('" + Number.Text + "','" + NewReaderry["Username"] + "','" + NewReaderry["Realname"] + "','" + NewReaderry["UnitId"] + "','" + NewReaderry["Unit"] + "','" + NewReaderry["JbMoney"] + "','" + NewReaderry["SaNumber"] + "')";
                List.ExeSql(sql_insert_data);
            }
            NewReaderry.Close();









            //Response.Write(SQtMonth);




            Response.Redirect("SalariesAddSet_add.aspx?Number=" + Number.Text + "");
        }





        public object Eval(string expression)
        {
            System.Data.DataTable table = new System.Data.DataTable();
            System.Data.DataColumn Col = new System.Data.DataColumn("col1 ", typeof(string), expression);
            table.Columns.Add(Col);

            table.Rows.Add(new object[] { " " });
            return table.Rows[0][0];
        }

        public string CreateSaSql(string setstr,string user)
        {
            string SaSql = null, SHsMonth = null, EHsMonth = null;

            string SQL_GetList_hs = "select * from qp_SalariesSet where Number='" + SaName.SelectedValue + "'";
            SqlDataReader NewReader_hs = List.GetList(SQL_GetList_hs);
            if (NewReader_hs.Read())//判断数据来源
            {
                //if (NewReader_hs["HsMonth"].ToString() == "本月数据")
                //{
                //    SHsMonth = ""+System.DateTime.Now.Year.ToString()+"-"+System.DateTime.Now.Month.ToString() +"-"+NewReader_hs["Startime"].ToString()+"";
                //    EHsMonth = "" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + NewReader_hs["Endtime"].ToString() + "";
                //}
                //if (NewReader_hs["HsMonth"].ToString() == "上一月数据")
                //{
                    SHsMonth = "" + System.DateTime.Now.AddMonths(-1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(-1).Month.ToString() + "-" + NewReader_hs["Startime"].ToString() + "";
                    EHsMonth  = "" + System.DateTime.Now.Year.ToString() + "-" + System.DateTime.Now.Month.ToString() + "-" + NewReader_hs["Endtime"].ToString() + "";


                //}
                //if (NewReader_hs["HsMonth"].ToString() == "下一月数据")
                //{
                //    SHsMonth = "" + System.DateTime.Now.AddMonths(1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(1).Month.ToString() + "-" + NewReader_hs["Startime"].ToString() + "";
                //    EHsMonth = "" + System.DateTime.Now.AddMonths(1).Year.ToString() + "-" + System.DateTime.Now.AddMonths(1).Month.ToString() + "-" + NewReader_hs["Endtime"].ToString() + "";
                //}



            }
            NewReader_hs.Close();






            if (setstr == "[迟到次数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where (DjState_1='迟到' or DjState_2='迟到'  or DjState_3='迟到'  or DjState_4='迟到'  or DjState_5='迟到'  or DjState_6='迟到' ) and DjUsername='" + user + "' and (Djtime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) ) ";
                SaSql = "" + List.GetCount(SQL_GetList_cd_1) + "";
            
            }
            if (setstr == "[早退次数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where (DjState_1='早退' or DjState_2='早退' or DjState_3='早退' or DjState_4='早退' or DjState_5='早退' or DjState_6='早退') and DjUsername='" + user + "'  and (Djtime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) ) ";
                SaSql = "" + List.GetCount(SQL_GetList_cd_1) + "";
            }
            if (setstr == "[旷工天数]")
            {
                string SQL_GetList_cd_1 = "select count(*) as counts from qp_WorkTimeDj where (DjState_1='旷工' or DjState_2='旷工' or DjState_3='旷工' or DjState_4='旷工' or DjState_5='旷工' or DjState_6='旷工') and DjUsername='" + user + "'  and (Djtime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) ) ";
                SaSql = "" + List.GetCount(SQL_GetList_cd_1) + "";
            }
            if (setstr == "[出差天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Username='" + user + "' and  Shenpi='已通过'  and  Type='3' and (StartTime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) ) ";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();


            }
            if (setstr == "[事假天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Username='" + user + "' and   Shenpi='已通过'  and  Type='2'  and (StartTime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) )";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();



            }
            if (setstr == "[病假天数]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where  Username='" + user + "' and   Shenpi='已通过'  and  Type='1'  and (StartTime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) )";
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();
            }



            if (setstr == "[加班小时]")
            {
                string SQL_GetList_cc = "select sum(DiffTime) as counts from qp_MyAttendance where   Username='" + user + "' and  Shenpi='已通过'  and  Type='4'  and (StartTime between '" + SHsMonth + "'and  '" + EHsMonth + "' or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + SHsMonth + "' as datetime),120) or convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + EHsMonth + "' as datetime),120) )";
                //Response.Write(SQL_GetList_cc);
                SqlDataReader NewReader_cc = List.GetList(SQL_GetList_cc);
                if (NewReader_cc.Read())
                {
                    if (NewReader_cc["counts"].ToString() == "")
                    {
                        SaSql = "0";
                    }
                    else
                    {

                        SaSql = NewReader_cc["counts"].ToString();
                    }
                }
                NewReader_cc.Close();
            }





            return SaSql;
        }

        public string CreateStr(string AStr, string bbb)
        {

            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("[迟到次数]", "" + bbb + "");
                AStr = AStr.Replace("[早退次数]", "" + bbb + "");
                AStr = AStr.Replace("[旷工天数]", "" + bbb + "");
                AStr = AStr.Replace("[出差天数]", "" + bbb + "");
                AStr = AStr.Replace("[事假天数]", "" + bbb + "");
                AStr = AStr.Replace("[病假天数]", "" + bbb + "");
                AStr = AStr.Replace("[加班小时]", "" + bbb + "");
                return AStr;
            }
        }//替换字符




    }
}

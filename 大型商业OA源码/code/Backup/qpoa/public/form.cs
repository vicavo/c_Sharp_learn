using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using qpsmartweb.Public;
using System.Data.SqlClient;

namespace qiupeng.form
{

	public class divform
    {
        Db List = new Db();




        public string FormatWh(string AStr, string LcNameId, string BianhaoWs, string FlowName)
        {
            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("{Y}", System.DateTime.Now.Year.ToString());//表示年
                AStr = AStr.Replace("{M}", System.DateTime.Now.Month.ToString());//表示月
                AStr = AStr.Replace("{D}", System.DateTime.Now.Day.ToString());//表示日
                AStr = AStr.Replace("{H}", System.DateTime.Now.Hour.ToString());//表示时
                AStr = AStr.Replace("{I}", System.DateTime.Now.Minute.ToString());//表示分
                AStr = AStr.Replace("{S}", System.DateTime.Now.Second.ToString());//表示秒
                AStr = AStr.Replace("{F}", FlowName);//流程名
                AStr = AStr.Replace("{U}", System.Web.HttpContext.Current.Session["realname"].ToString());//表示用户姓名
                AStr = AStr.Replace("{SD}", System.Web.HttpContext.Current.Session["Unit"].ToString());//表示部门
                AStr = AStr.Replace("{R}", System.Web.HttpContext.Current.Session["Respon"].ToString());//表示角色
                AStr = AStr.Replace("{N}",""+LcNameId+"");//表示编号
                AStr = AStr.Replace("{W}", GetWeekDay());//表示星期
            

                return AStr;
            }
        }//文号


        public string FormatHkj(string AStr, string LcName, string FlowName)
        {
            if ("" == AStr)
                return "";

            else
            {
                AStr = AStr.Replace("{Y}", System.DateTime.Now.Year.ToString());//表示年
                AStr = AStr.Replace("{M}", System.DateTime.Now.Month.ToString());//表示月
                AStr = AStr.Replace("{D}", System.DateTime.Now.Day.ToString());//表示日
                AStr = AStr.Replace("{H}", System.DateTime.Now.Hour.ToString());//表示时
                AStr = AStr.Replace("{I}", System.DateTime.Now.Minute.ToString());//表示分
                AStr = AStr.Replace("{S}", System.DateTime.Now.Second.ToString());//表示秒
                AStr = AStr.Replace("{F}", FlowName);//流程名
                AStr = AStr.Replace("{U}", System.Web.HttpContext.Current.Session["realname"].ToString());//表示用户姓名
                AStr = AStr.Replace("{SD}", System.Web.HttpContext.Current.Session["Unit"].ToString());//表示部门
                AStr = AStr.Replace("{R}", System.Web.HttpContext.Current.Session["Respon"].ToString());//表示角色
                AStr = AStr.Replace("{W}", GetWeekDay());//表示星期
                AStr = AStr.Replace("{BD}", LcName);//表示工作名称/文号


                return AStr;
            }
        }//自定义宏控件

        private string GetWeekDay()
        {
            string Temp = "";
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    Temp = "星期日";
                    break;
                case DayOfWeek.Monday:
                    Temp = "星期一";
                    break;
                case DayOfWeek.Tuesday:
                    Temp = "星期二";
                    break;
                case DayOfWeek.Wednesday:
                    Temp = "星期三";
                    break;
                case DayOfWeek.Thursday:
                    Temp = "星期四";
                    break;
                case DayOfWeek.Friday:
                    Temp = "星期五";
                    break;
                case DayOfWeek.Saturday:
                    Temp = "星期六";
                    break;
            }
            return Temp;
        }//星期几



        public string BumenName(string id)//部门名称
        {
            string CodeName = null;
            string SQL_GetList = "select Name from qp_oa_Bumen where  id='" + id + "'";
            SqlDataReader NewReader = List.GetList(SQL_GetList);
            if (NewReader.Read())
            {
                CodeName = NewReader["Name"].ToString();
            }
            NewReader.Close();
            return CodeName;
        }



	}
}

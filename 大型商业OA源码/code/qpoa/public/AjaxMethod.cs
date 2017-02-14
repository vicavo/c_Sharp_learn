using System;
using System.Data;
using System.Data.SqlClient;
using qpsmartweb.Public;
namespace qpoa
{
	/// <summary>
	/// AjaxMethod ��ժҪ˵����
	/// </summary>
	public class AjaxMethod
	{
		Db List=new Db();

	
		[Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataSet Getchat(string NameId, string Name)
		{

            string sql = "select  *  from qp_chatcontent where NameId='" + NameId + "'";
            return GetDataSet(sql);	
		}//�б�


        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataSet sendmessage(string content, string senduser, string seadname, string atpuser, string atpname, string setime, string NameId, string Name)
        {

            string sql = "insert into qp_chatcontent (content,senduser,seadname,atpuser,atpname,setime,NameId,Name) values('" + List.GetFormatStr(content) + "','" + senduser + "','" + seadname + "','" + atpuser + "','" + atpname + "','" + setime + "','" + NameId + "','" + Name + "')";
            return GetDataSet(sql);

        }//������Ϣ



        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataSet ListPeople(string NameId, string Name)
        {

            string sql = "select * from qp_chatListPeople where  datediff(ss,firsttime,lasttime)<=20  and NameId='" + NameId + "'";
            return GetDataSet(sql);

        }//�г����������û�

        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataSet ListPeopleUser()
        {

            string sql = "select * from qp_useronline where  datediff(ss,firsttime,lasttime)<=20  ";
            return GetDataSet(sql);

        }//�г���ǰ�����û�


        [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
        public DataSet ListAllUser()
        {
            string sql = "select * from qp_username ";
            return GetDataSet(sql);

        }//�г������û�

		public static DataSet GetDataSet(string sql)
		{
			string ConnectionString=System.Configuration.ConfigurationSettings.AppSettings["connstr"];
			SqlDataAdapter	sda =new SqlDataAdapter(sql,ConnectionString);
			DataSet ds=new DataSet();
			sda.Fill(ds);
			return ds;
		}
	}
}

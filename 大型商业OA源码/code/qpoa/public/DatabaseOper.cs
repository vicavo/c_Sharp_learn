/*
 * Author:Gaofa Wu
 * Date:2003-11-1
 * Function:Search,add,delete and modification to database.
 */

using System; 
using System.Data;
using System.Data .SqlClient ;
using System.Collections;


namespace OI.DatabaseOper
{
	/// <summary>
	/// Database operation
	/// </summary>
	public class DatabaseConnect: System.IDisposable 
	{
        private string source = System.Configuration.ConfigurationManager.AppSettings["connstr"].ToString();
		private  SqlConnection conn;
		
		public DatabaseConnect()
		{
			dataConnect();
		}
		public void DataBaseClose()
		{
			closeConnect();
		}
		~DatabaseConnect()
		{
			this.Dispose();
		}
		public void Dispose()
		{
//			if(conn!=null)
//			closeConnect();
//			conn=null;
			GC.SuppressFinalize (true);
		}
		/// <summary>
		/// Bind data
		/// </summary>
		/// <param name="SQL">"SELECT" sentence.</param>
		/// <param name="fillTable">Temp table's name</param>
		/// <returns>Data of "DataSet" type</returns>
		public DataSet getBinding(string SQL,string fillTable)
		{
			GC.Collect();
			this.dataConnect ();
			DataSet myDataSet= new DataSet();
			SqlDataAdapter myCommand=new SqlDataAdapter(SQL,conn);
			//Fill DataSet 
			myCommand.Fill(myDataSet,fillTable);
			this.closeConnect ();//Close connect
			myCommand.Dispose();			
			return myDataSet;
		}
		/// <summary>
		///  返回多个查询操作的结果集
		/// </summary>
		/// <param name="sql"></param>
		/// <returns></returns>
		public DataSet Binding(string[] sql)
		{
			this.dataConnect();
			DataSet ds=new DataSet();
			for(int i=0; i<sql.Length; i++)
			{
				SqlDataAdapter myAdapter =new SqlDataAdapter(sql[i],conn);
				myAdapter.Fill(ds,i.ToString());				
				myAdapter.Dispose ();
			}
			this.closeConnect();
			return ds;
		}
		public System.Data.SqlClient.SqlConnection GetConn()
		{
			this.dataConnect ();
			return conn;
		}
		/// <summary>
		/// Connect database
		/// </summary>
		/// 
		private void dataConnect()
		{
			if(conn==null)
				conn=new SqlConnection(source);
			if(conn.State!=System.Data.ConnectionState.Open)
				try
				{
					conn.Open ();			
				}
				catch(Exception er)
				{
					throw new ApplicationException (er.Message );
				}
		}
		/// <summary>
		/// Close database
		/// </summary>
		private void closeConnect()
		{
			if(conn.State ==System.Data .ConnectionState .Open )
			{
				conn.Close ();
				
			}
		}
		/// <summary>
		/// Search data in table
		/// </summary>
		/// <param name="SQL">"SELECT" sentence</param>
		/// <returns>Search result</returns>
		public ArrayList getData(string SQL)
		{
			
			this.dataConnect ();
			SqlDataReader reader=null;
			ArrayList data=new ArrayList ();
			
				SqlCommand cmd=new SqlCommand (SQL,conn);
				reader=cmd.ExecuteReader ();
			
				while(reader.Read ())
				{
					for(int i=0;i<reader.FieldCount ;i++)
					{
						data.Add (reader[i]);
					}
				}	
			reader.Close();
			
			
			this.closeConnect ();				
			return data;

		}
		/// <summary>
		/// Modification data
		/// </summary>
		/// <param name="strSQL"></param>
		public void updateData(string strSQL)
		{
			this.dataOperater (strSQL);
		}
		/// <summary>
		/// Add data
		/// </summary>
		/// <param name="strSQL"></param>
		public void addData(string strSQL)
		{
			this.dataOperater (strSQL);
		}
		/// <summary>
		/// Delete data
		/// </summary>
		/// <param name="strSQL"></param>
		public void deleteData(string strSQL)
		{
			this.dataOperater (strSQL);
		}
		/// <summary>
		/// Add,Delete and Modification operation.
		/// </summary>
		/// <param name="strSQL">"SQL" sentence</param>
		private void dataOperater(string strSQL)
		{
			this.dataConnect ();
			SqlCommand cmd=null;
			try
			{
				cmd=new SqlCommand (strSQL,conn);
				cmd.ExecuteNonQuery ();	
			}
			catch(System.Exception e)
			{
				cmd.Dispose ();
				this.closeConnect ();	
				throw new Exception("SQL error:{0}",e);
			}
			//cmd.Dispose ();
			this.closeConnect ();
		}
		public int dataOperater1(string strSQL)
		{
			int tempN=0;
			this.dataConnect ();
			SqlCommand cmd=null;
			
			try
			{
				cmd=new SqlCommand (strSQL,conn);
				cmd.ExecuteNonQuery ();	
			}
			catch(System.Data.SqlClient.SqlException e)
			{
				cmd.Dispose ();
				this.closeConnect ();	
				tempN=e.Number ;
			}
			//cmd.Dispose ();
			this.closeConnect ();
			return tempN;
			
		}
		public bool ExcuteSqls(string []al)
		{
			dataConnect();
			SqlTransaction trans=conn.BeginTransaction("trans1");
			SqlCommand cmd=new SqlCommand();
			
			cmd.Connection=conn;
			cmd.Transaction=trans;
			
			try
			{
				for(int i=0;i<al.Length  ;i++)
				{ 
					if(al[i].Trim() !="")
					{
						cmd.CommandText=al[i];
						cmd.ExecuteNonQuery();
					}
				}
				
				trans.Commit(); //没有错误就提交事务
				//trans.Dispose ();
				this.closeConnect ();
				return  true;
			}
			catch 
			{
				trans.Rollback("trans1"); //回滚事务
				//trans.Dispose ();
				this.closeConnect ();
				return false ;
			}
		}
		public bool ExcuteSqls(string [,]al)
		{
			dataConnect();
			SqlTransaction trans=conn.BeginTransaction("trans1");
			SqlCommand cmd=new SqlCommand();
			
			cmd.Connection=conn;
			cmd.Transaction=trans;
			
			try
			{
				for(int i=0;i<al.Length/2  ;i++)
				{ 
					for (int j=0; j<2;j++)
					{
						if(al[i,j].Trim() !="")
						{
							cmd.CommandText=al[i,j];
							cmd.ExecuteNonQuery();
						}
					}
				}
				
				trans.Commit(); //没有错误就提交事务
				//trans.Dispose ();
				this.closeConnect ();
				return  true;
			}
			catch (Exception er)
			{
				
				trans.Rollback("trans1"); //回滚事务
				//trans.Dispose ();
				this.closeConnect ();
				throw new ApplicationException (er.Message );
				//return false ;
			}
		
		}

		/// <summary>
		/// 替换单引号
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public string ReplaceDYH(string str)
		{
			if (str.Trim ()=="") return "";
			str=str.Replace ("'","＇");
			//str=str.Replace ("\r\n","<br>");
			return str ;
		}
		/// <summary>
		/// 根据strSQL语名反回一个对象
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public object GetObjectBySql (string strSQL)
		{
			dataConnect();
			SqlCommand c=new SqlCommand (strSQL,conn);
			object o=c.ExecuteScalar ();
			this.closeConnect();
			return o;
		}

		/// <summary>
		/// 根据strSQL语名反回一个值,
		/// </summary>
		/// <param name="strSQL"></param>
		/// <returns></returns>
		public string GetValueBySql (string strSQL)
		{
			dataConnect();
			SqlCommand c=new SqlCommand (strSQL,conn);
			object o=c.ExecuteScalar ();
			 
			if(o!=null)
				return o.ToString ();
			
			return null;
		}
		/// <summary>
		/// 执行一条 SQL语句.
		/// </summary>
		/// <param name="strSQL"></param>
		public void ExecuteSQL(string strSQL)
		{
			dataConnect();
			try
			{
				SqlCommand c=new SqlCommand (strSQL,conn);
				c.ExecuteNonQuery ();
			}
			catch (Exception er)
			{
				throw new ApplicationException  (er.Message );
			}
			//c.Dispose ();
			this.closeConnect ();
		}
		/// <summary>
		/// 执行事务(已测试并通过)
		/// </summary>
		/// <param name="al">用来存储执行事务所需要的sql语句</param>
		/// <returns></returns>
		
		

		public int IFExist(string strSql)
		{
			this.dataConnect();
			SqlCommand cmd=new SqlCommand (strSql,conn);
			int re=(int)cmd.ExecuteScalar ();
			//cmd.Dispose ();
			this.closeConnect ();
			return re ;
			
		}
		/// <summary>
		/// 绑定Dropdownlist
		/// </summary>
		/// <param name="dst"></param>
		/// <param name="sql"></param>
		/// <param name="TextField"></param>
		/// <param name="Values"></param>
	
		public bool ExecuteTransaction(System.Collections.ArrayList al) 
		{
			dataConnect();
			SqlTransaction trans=conn.BeginTransaction("trans1");
			SqlCommand cmd=new SqlCommand();
			
			cmd.Connection=conn;
			cmd.Transaction=trans;
			
			try
			{
				for(int i=0;i<al.Count;i++)
				{
					cmd.CommandText=al[i].ToString();
					cmd.ExecuteNonQuery();
				}
				trans.Commit(); //没有错误就提交事务
				//trans.Dispose ();
				this.closeConnect ();
				return true;
			}
			catch
			{
				trans.Rollback("trans1"); //回滚事务
				//trans.Dispose ();
				this.closeConnect ();
				return false;
			}
			
		
		}
		public string  GetDateTime()
		{
			System.DateTime SystemTime;
			SystemTime=DateTime.Now;
			
			return (SystemTime.ToString("yyyy-MM-dd HH:mm:ss"));

		}
		public void RunCommand(string proedurename,IDataParameter[] para)
		{
			dataConnect();
			SqlCommand sqlcomm=new SqlCommand(proedurename,conn);
			sqlcomm.CommandType=CommandType.StoredProcedure;
			foreach(SqlParameter sqlpara in para )
			{
				sqlcomm.Parameters.Add(sqlpara);
			}
			sqlcomm.ExecuteNonQuery();
			closeConnect();

		}
	} 	
}

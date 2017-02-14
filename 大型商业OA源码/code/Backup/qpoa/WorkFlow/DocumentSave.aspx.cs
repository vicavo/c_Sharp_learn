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
namespace qpoa.WorkFlow
{
    public partial class DocumentSave : System.Web.UI.Page
    {	
        
        
        string mRecordID="";
		string mTemplate="";
		string mSubject="";
		string mAuthor="";
		string mFileDate="";
		string mFileType="";
		string mHTMLPath="";
        string mStatus = "";
        private OI.DatabaseOper.DatabaseConnect oConn = new OI.DatabaseOper.DatabaseConnect();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["bbb"] = "aaaaaaa";
            SqlCommand nCommand;
            string strSelectCmd;
            string strUpdateCmd;
            string strInsertCmd;

            mRecordID = Request.Form["RecordID"];
            mTemplate = Request.Form["Template"];
            mSubject = Request.Form["Subject"];
            mAuthor = Request.Form["Author"];
            mFileDate = Request.Form["FileDate"];
            mFileType = Request.Form["FileType"];
            mHTMLPath = Request.Form["HTMLPath"];
            mStatus = "READ";

            strSelectCmd = "SELECT RecordID from  Document Where RecordID='" + mRecordID + "'";
            Session["bbb"] = strSelectCmd;
            SqlCommand mCommand = new SqlCommand(strSelectCmd, oConn.GetConn());//更改
            SqlDataReader mReader;

            mReader = mCommand.ExecuteReader(CommandBehavior.CloseConnection);
            if (mReader.Read())
            {
                mReader.Close();

                strUpdateCmd = "update Document set RecordID=@RecordID,Template=@Template,Subject=@Subject,Author=@Author,FileDate=@FileDate,FileType=@FileType,HtmlPath=@HtmlPath,Status=@Status where RecordID='" + mRecordID + "'";
                nCommand = new SqlCommand(strUpdateCmd, oConn.GetConn());//更改
            }
            else
            {
                mReader.Close();

                strInsertCmd = "insert into Document (RecordID,Template,Subject,Author,FileDate,FileType,HtmlPath,Status) values (@RecordID,@Template,@Subject,@Author,@FileDate,@FileType,@HtmlPath,@Status)";
                Session["ccc"] = strInsertCmd;
                nCommand = new SqlCommand(strInsertCmd, oConn.GetConn());//更改
            }

            nCommand.Parameters.Add(new SqlParameter("@RecordID", SqlDbType.VarChar, 16));
            nCommand.Parameters["@RecordID"].Value = mRecordID;


            nCommand.Parameters.Add(new SqlParameter("@Template", SqlDbType.VarChar, 16));
            nCommand.Parameters["@Template"].Value = mTemplate;


            nCommand.Parameters.Add(new SqlParameter("@Subject", SqlDbType.VarChar, 32));
            nCommand.Parameters["@Subject"].Value = mSubject;


            nCommand.Parameters.Add(new SqlParameter("@Author", SqlDbType.VarChar, 32));
            nCommand.Parameters["@Author"].Value = mAuthor;

            nCommand.Parameters.Add(new SqlParameter("@FileDate", SqlDbType.DateTime));
            nCommand.Parameters["@FileDate"].Value = mFileDate;

            nCommand.Parameters.Add(new SqlParameter("@FileType", SqlDbType.VarChar, 4));
            nCommand.Parameters["@FileType"].Value = mFileType;

            nCommand.Parameters.Add(new SqlParameter("@HtmlPath", SqlDbType.VarChar, 64));
            nCommand.Parameters["@HtmlPath"].Value = mHTMLPath;

            nCommand.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 64));
            nCommand.Parameters["@Status"].Value = mStatus;
            if (nCommand.ExecuteNonQuery() == 1)
            {
                oConn.DataBaseClose();
                Response.Redirect("DocumentList.aspx");
            }
            else
            {
                oConn.DataBaseClose();
            }
        }
    }
}

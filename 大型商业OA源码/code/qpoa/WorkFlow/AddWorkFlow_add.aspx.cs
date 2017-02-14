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
using qiupeng.form;
using System.IO;
namespace qpoa.WorkFlow
{
    public partial class AddWorkFlow_add : System.Web.UI.Page
    {
        Db List = new Db();
        divform showform = new divform();
        BindDrowDownList list = new BindDrowDownList();
        public static string ddstr, fjkey, FormName, NodeName, UpNodeNum, UpNodeNumKey, NodeId, WriteFileID;
        public static int lshid, LcNameId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                this.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
                return;

            }

            if (!Page.IsPostBack)
            {
                string SQL_GetList_fjkey = "select * from qp_FjKey";
                SqlDataReader NewReader_fjkey = List.GetList(SQL_GetList_fjkey);
                if (NewReader_fjkey.Read())
                {

                    fjkey = NewReader_fjkey["content"].ToString();

                }
                NewReader_fjkey.Close();

                BindAttribute();

                string SQL_GetList2 = "select * from qp_WorkFlowNode where NodeSite='开始' and FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    NodeName = NewReader2["NodeName"].ToString();
                    UpNodeNum = NewReader2["UpNodeNum"].ToString();
                    UpNodeNumKey = NewReader2["UpNodeNum"].ToString();
                    GqUpNodeNumKey.Text = NewReader2["UpNodeNum"].ToString();
                    NodeId = NewReader2["id"].ToString();
                    WriteFileID = ""+NewReader2["WriteFileID"].ToString()+"0";


                    if (NewReader2["AllowFile"].ToString() == "是")
                    {
                        Button9.Visible = true;
                    }
                    else
                    {
                        Button9.Visible = false;
                    }

                    if (NewReader2["AllowDelFile"].ToString() == "是")
                    {
                        Button3.Visible = true;
                    }
                    else
                    {
                        Button3.Visible = false;
                    }


                    string SQL_GetListLcNameId = "select top 1 id,LcNameId from qp_AddWorkFlow where FlowNumber='" + Request.QueryString["FlowNumber"] + "' order by id desc";
                    SqlDataReader NewReaderLcNameId = List.GetList(SQL_GetListLcNameId);
                    if (NewReaderLcNameId.Read())//自动编号计数器
                    {
                        LcNameId = int.Parse(NewReaderLcNameId["LcNameId"].ToString()) + 1;

                        string SQL_GetListlc = "select Wenhao,BianhaoWs,FlowName,xgwenhao from qp_WorkFlowName where FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
                        SqlDataReader NewReaderlc = List.GetList(SQL_GetListlc);
                        if (NewReaderlc.Read())
                        {
                            if (NewReaderlc["xgwenhao"].ToString() == "否")
                            {
                                whname.Attributes.Add("readonly", "readonly");
                            }
                            whname.Text = showform.FormatWh(NewReaderlc["Wenhao"].ToString(), LcNameId.ToString().PadLeft(int.Parse(NewReaderlc["BianhaoWs"].ToString()), '0'), NewReaderlc["BianhaoWs"].ToString(), NewReaderlc["FlowName"].ToString());
                        }
                        NewReaderlc.Close();//文号名称
                    }
                    else
                    {
                        string SQL_GetListlc = "select Wenhao,BianhaoWs,FlowName,BianhaoJs,BianhaoWs,xgwenhao from qp_WorkFlowName where FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
                        SqlDataReader NewReaderlc = List.GetList(SQL_GetListlc);
                        if (NewReaderlc.Read())
                        {
                            if (NewReaderlc["xgwenhao"].ToString() == "否")
                            {
                                whname.Attributes.Add("readonly", "readonly");
                            }

                            LcNameId = int.Parse(NewReaderlc["BianhaoJs"].ToString());
                            whname.Text = showform.FormatWh(NewReaderlc["Wenhao"].ToString(), LcNameId.ToString().PadLeft(int.Parse(NewReaderlc["BianhaoWs"].ToString()), '0'), NewReaderlc["BianhaoWs"].ToString(), NewReaderlc["FlowName"].ToString());
                        }
                        NewReaderlc.Close();//文号名称
                    }
                    NewReaderLcNameId.Close();

                }
                else
                {
                    this.Response.Write("<script language=javascript>alert('此流程未找到“启始步骤”，请重新设置此流程！');window.location.href='AddWorkFlow.aspx'</script>");
                    return;
                }
                NewReader2.Close();//步骤名称，下一节点，当前节点ID



                string SQL_GetList = "select * from qp_DIYForm where id='" + List.GetFormatStr(Request.QueryString["FormId"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    // FormContent.Text = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString());
                    // ddstr = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString().Replace("宏控件-用户姓名", Session["realname"].ToString()).Replace("宏控件-用户部门", Session["Unit"].ToString()).Replace("宏控件-用户角色", Session["Respon"].ToString()).Replace("宏控件-用户职位", Session["Post"].ToString()).Replace("宏控件-当前时间(日期)", System.DateTime.Now.ToShortDateString()));

                    string setfrom = null;
                    setfrom = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString().Replace("BACKGROUND-COLOR: #EFEFEF", "").Replace("readonly", "").Replace("value=\"宏控件-用户姓名\"", "readonly  value=\"" + Session["realname"].ToString() + "\"").Replace("value=\"宏控件-用户部门\"", "readonly  value=\"" + Session["Unit"].ToString() + "\"").Replace("value=\"宏控件-用户角色\"", "readonly  value=\"" + Session["Respon"].ToString() + "\"").Replace("value=\"宏控件-用户职位\"", "readonly  value=" + Session["Post"].ToString() + "").Replace("value=\"宏控件-当前时间(日期)\"", "readonly  value=\"" + System.DateTime.Now.ToShortDateString() + "\""));




                    string SQL_GetListlc = "select FlowName from qp_WorkFlowName where FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
                    SqlDataReader NewReaderlc = List.GetList(SQL_GetListlc);
                    if (NewReaderlc.Read())
                    {
                        setfrom = showform.FormatHkj(setfrom, whname.Text, NewReaderlc["FlowName"].ToString());
                    }
                    NewReaderlc.Close();//替换自定义宏控件




                    string SQL_GetListf = "select * from qp_FormFile where  id not in (" + WriteFileID + ") and Type!='[电子印章]'";
                    SqlDataReader NewReaderf = List.GetList(SQL_GetListf);
                    while (NewReaderf.Read())
                    {
                        setfrom = setfrom.Replace("name=" + NewReaderf["Number"] + "", "name=" + NewReaderf["Number"] + "  style=\"BACKGROUND-COLOR: #EFEFEF\"  readonly").Replace("name=\"" + NewReaderf["Number"] + "\"", "name=" + NewReaderf["Number"] + "  style=\"BACKGROUND-COLOR: #EFEFEF\"  readonly");
                       
                    }
                    NewReaderf.Close();//设置可写字段


                    ContractContent.Text = setfrom;
                    TextBox1.Text = setfrom;
                    FormName = NewReader["FormName"].ToString();

                }//表单
                NewReader.Close();




                string SQL_GetList1 = "select top 1 id from qp_AddWorkFlow order by id desc";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    lshid = int.Parse(NewReader1["id"].ToString()) + 1;
                }
                else
                {
                    lshid = 1;
                }
                NewReader1.Close();//流水号




            }

            if (!IsPostBack)
            {

                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Number.Text = "" + System.DateTime.Now.Year.ToString() + "" + System.DateTime.Now.Month.ToString() + "" + System.DateTime.Now.Day.ToString() + "" + System.DateTime.Now.Hour.ToString() + "" + System.DateTime.Now.Minute.ToString() + "" + System.DateTime.Now.Second.ToString() + "" + System.DateTime.Now.Millisecond.ToString() + "" + rad + "";
            }
            BindDroList();
        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return showwait();";
            Button4.Attributes["onclick"] = "javascript:return checkForm();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }

        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_AddWorkFlowFj where KeyField='" + Number.Text + "' order by id desc";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("AddWorkFlow.aspx");

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string TjszStrSz, TjszStrCg;
                string TjszStr;
                // InsertLog("快速新建", "快速新建");
                //TjszStr = "";
                string str1 = null;
                str1 = "" + UpNodeNum + "0";
                ArrayList myarr = new ArrayList();
                string[] mystr = str1.Split(',');
                for (int s = 0; s < mystr.Length; s++)//循环得到下一步骤ID，按照ID来读字段
                {
                    TjszStrCg = null; TjszStrSz = null;
                    TjszStr = null;
                    TjszStr = "1 == 1";
                    string SQL_GetListCg = "select * from qp_FlowFormFile where KeyID=(select id from qp_WorkFlowNode where NodeNum='" + mystr[s] + "' and FlowNumber='" + Request.QueryString["FlowNumber"] + "') and NodeId='" + NodeId + "' and  Type='[常规型]'";
                    //Response.Write("" + SQL_GetListCg + "<br><br>");
                    SqlDataReader NewReaderCg = List.GetList(SQL_GetListCg);
                    while (NewReaderCg.Read())
                    {
                        if (NewReaderCg["Conditions"].ToString() == "包含")
                        {

                            TjszStrCg += "&&" + Request.Form["" + NewReaderCg["Number"] + ""].IndexOf(NewReaderCg["JudgeBasis"].ToString()) + ">= 0 ";

                        }
                        else if (NewReaderCg["Conditions"].ToString() == "不包含")
                        {
                            TjszStrCg += "&&" + Request.Form["" + NewReaderCg["Number"] + ""].IndexOf(NewReaderCg["JudgeBasis"].ToString()) + "< 0 ";
                        }
                        //Response.Write("常规型：" + TjszStrCg + "<br><br>");
                    }

                    NewReaderCg.Close();//条件设置--常规型


                    string SQL_GetListSz = "select * from qp_FlowFormFile where  KeyID=(select id from qp_WorkFlowNode where NodeNum='" + mystr[s] + "' and FlowNumber='" + Request.QueryString["FlowNumber"] + "') and  NodeId='" + NodeId + "' and  Type='[数字型]'";
                    //Response.Write("" + SQL_GetListSz + "");
                    SqlDataReader NewReaderSz = List.GetList(SQL_GetListSz);
                    while (NewReaderSz.Read())
                    {
                        TjszStrSz += "&&" + int.Parse(Request.Form["" + NewReaderSz["Number"] + ""]) + " " + NewReaderSz["Conditions"] + " " + NewReaderSz["JudgeBasis"] + "  ";
                    }

                    NewReaderSz.Close();//条件设置--数字型


                    TjszStr += TjszStrCg + TjszStrSz;
                     //Response.Write("比较：" + TjszStr + "<br><br>");
                    MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
                    sc.Language = "javascript";
                    if ((bool)sc.Eval(TjszStr) == false)
                    {
                        //Response.Write("啊：啊" + mystr[s] + " <br><br>");
                        UpNodeNumKey = UpNodeNumKey.Replace("" + mystr[s] + ",", "");
                        GqUpNodeNumKey.Text = GqUpNodeNumKey.Text.Replace("" + mystr[s] + ",", "");
                    }
                    




                }

                string SQL_GetList2 = "select * from qp_WorkFlowNode where NodeSite='开始' and FlowNumber='" + Request.QueryString["FlowNumber"] + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    string JkUsername = null, JkRealname = null;

                    string SQL_GetList1 = "select * from qp_WorkFlowName where id='" + NewReader2["FlowId"] + "' ";
                    SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                    if (NewReader1.Read())
                    {
                        JkUsername = NewReader1["JkUsername"].ToString();
                        JkRealname = NewReader1["JkRealname"].ToString();
                    }
                    NewReader1.Close();


                    string sql_insert1 = "insert into qp_AddWorkFlow (LcNameId,JkUsername,JkRealname,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,State,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,WGLObjectId,WGLObjecName,GZObjectId,GZObjecName,Username,Realname,Unit,UnitId,QxString,Respon,ResponId,NowTimes,UpTimeSet,WtUsername,WtRealname) values ('" + LcNameId + "','" + JkUsername + "','" + JkRealname + "','" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["NodeNumber"] + "','" + NewReader2["NodeNum"] + "','" + NewReader2["NodeName"] + "','" + Number.Text + "','" + lshid + "','" + List.GetFormatStr(whname.Text) + "','等待送审','" + List.GetFormatStrbjq(ContractContent.Text) + "','" + Session["username"] + "','" + Session["realname"] + "','','','','','','','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "','" + this.Session["Respon"] + "','" + this.Session["ResponId"] + "','" + System.DateTime.Now.ToString() + "','" + System.DateTime.Now.ToString() + "','','')";
                    List.ExeSql(sql_insert1);
                }
                else
                {

                    this.Response.Write("<script language=javascript>alert('保存失败，请检查是否存在开始流程！');</script>");
                    return;

                }
                NewReader2.Close();

             // Response.Redirect("AddWorkFlow_add_Next.aspx?UpNodeNum=" + UpNodeNumKey + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&Number="+Number.Text+"");
                Response.Redirect("AddWorkFlow_add_Next.aspx?UpNodeNum=" + GqUpNodeNumKey.Text + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&Number=" + Number.Text + "");





            }
            catch
            {
                this.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或可写字段设置错误！');</script>");
                return;
            }


        }

        public void InsertLog(string Name, string MkName)
        {

            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //上传文件
            string strBaseLocation = Server.MapPath("AddWorkFlowFj/");
            string TruePath = string.Empty;
            string Temp1 = string.Empty;

            if (uploadFile.PostedFile.ContentLength != 0)
            {
                //获得文件全名
                string fileName = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
                //获得扩展名
                string rightName = System.IO.Path.GetExtension(fileName);

    
                Random g = new Random();
                string rad = g.Next(10000).ToString();
                Temp1 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + rad;
                uploadFile.PostedFile.SaveAs(strBaseLocation + Temp1 + rightName);
                TruePath = Temp1 + rightName;  //获得随即文件名


                string sql_insert_file = "insert into qp_AddWorkFlowFj   (Name,NewName,KeyField) values ('" + fileName + "','" + TruePath + "','" + Number.Text + "')";
                List.ExeSql(sql_insert_file);


                InsertLog("上传审批文件[" + fileName + "]", "工作管理");
                BindDroList();
            }
        }
    }
}

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
namespace qpoa.WorkFlow
{
    public partial class WorkFlowListSp : System.Web.UI.Page
    {
        Db List = new Db();
        BindDrowDownList list = new BindDrowDownList();
        public static string ddstr, fjkey, FormName, NodeName, UpNodeNum, BhUpNodeNum, UpNodeNumKey, NodeId, WriteFileID, lshid, Name, SpModle, JBRObjectId, HyUsername, HyRealname;
        public static int a;
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

                string SQL_GetList2 = "select * from qp_WorkFlowNode where id='" + int.Parse(Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
                if (NewReader2.Read())
                {
                    NodeName = NewReader2["NodeName"].ToString();
                    UpNodeNum = NewReader2["UpNodeNum"].ToString();
                    UpNodeNumKey = NewReader2["UpNodeNum"].ToString();
                    GqUpNodeNumKey.Text = NewReader2["UpNodeNum"].ToString();
                    NodeId = NewReader2["id"].ToString();
                    WriteFileID = "" + NewReader2["WriteFileID"].ToString() + "0";



                    if (NewReader2["AllowFile"].ToString() == "是")
                    {
                        Button10.Visible = true;
                    }
                    else
                    {
                        Button10.Visible = false;
                    }

                    if (NewReader2["AllowDelFile"].ToString() == "是")
                    {
                        Button3.Visible = true;
                    }
                    else
                    {
                        Button3.Visible = false;
                    }


                }
              
                NewReader2.Close();



                string SQL_GetList = "select * from qp_AddWorkFlow where id='" + List.GetFormatStr(Request.QueryString["id"]) + "'";
                SqlDataReader NewReader = List.GetList(SQL_GetList);
                if (NewReader.Read())
                {
                    BhUpNodeNum = NewReader["UpNodeNum"].ToString();
                    lshid = NewReader["Sequence"].ToString();
                    Number.Text = NewReader["Number"].ToString();
                    Name = NewReader["Name"].ToString();
                    whname.Text = NewReader["Name"].ToString();
                    SpModle = NewReader["SpModle"].ToString();
                    JBRObjectId = NewReader["JBRObjectId"].ToString();
                    // FormContent.Text = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString());
                    // ddstr = List.GetFormatStrbjq_show(NewReader["FormContent"].ToString().Replace("宏控件-用户姓名", Session["realname"].ToString()).Replace("宏控件-用户部门", Session["Unit"].ToString()).Replace("宏控件-用户角色", Session["Respon"].ToString()).Replace("宏控件-用户职位", Session["Post"].ToString()).Replace("宏控件-当前时间(日期)", System.DateTime.Now.ToShortDateString()));
                    HyUsername = NewReader["JBRObjectId"].ToString().Replace(""+Session["username"]+",","");
                    HyRealname = NewReader["JBRObjectName"].ToString().Replace("" + Session["realname"] + ",", "");

                    string setfrom = null;

                    setfrom = List.GetFormatStrbjq_show(NewReader["FileContent"].ToString().Replace("BACKGROUND-COLOR:", "").Replace("readOnly", "").Replace("BACKGROUND-COLOR: #EFEFEF", "").Replace("readonly", "").Replace("id=Text2", "readonly").Replace("id=\"Text2\"", "readonly"));


                    string SQL_GetListf = "select * from qp_FormFile where  id not in (" + WriteFileID + ") and Type!='[电子印章]'";
                    //Response.Write(SQL_GetListf);
                    SqlDataReader NewReaderf = List.GetList(SQL_GetListf);
                    while (NewReaderf.Read())
                    {
                        setfrom = setfrom.Replace("name=" + NewReaderf["Number"] + "", "name=" + NewReaderf["Number"] + "  style=\"BACKGROUND-COLOR: #EFEFEF\"  readonly").Replace("name=\"" + NewReaderf["Number"] + "\"", "name=" + NewReaderf["Number"] + " style=\"BACKGROUND-COLOR: #EFEFEF\"  readonly");

                    }
                    NewReaderf.Close();//设置可写字段


                    ContractContent.Text = setfrom;
                    TextBox1.Text = setfrom;
                    FormName = NewReader["FormName"].ToString();



                    string SQL_GetListlc = "select xgwenhao from qp_WorkFlowName where FlowNumber='" + NewReader["FlowNumber"].ToString() + "'";
                    SqlDataReader NewReaderlc = List.GetList(SQL_GetListlc);
                    if (NewReaderlc.Read())
                    {
                        if (NewReaderlc["xgwenhao"].ToString() == "否")
                        {
                            whname.Attributes.Add("readonly", "readonly");
                        }
                    }
                    NewReaderlc.Close();//文号名称
             

                }//表单
                NewReader.Close();




                //string SQL_GetList1 = "select top 1 id from qp_AddWorkFlow order by id desc";
                //SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                //if (NewReader1.Read())
                //{
                //    lshid = int.Parse(NewReader1["id"].ToString()) + 1;
                //}
                //else
                //{
                //    lshid = 1;
                //}
                //NewReader1.Close();//流水号

               
                int   m   =   JBRObjectId.Length;
                int s = JBRObjectId.Replace(",", "").Length;
                a = m - s;

                if (a <= 1)
                {
                    Button4.Visible = true;
                    Button1.Visible = false;
                }
                else
                {
                    if (SpModle == "只要有一人通过审批即可向下流转")
                    {
                        Button4.Visible = true;
                    }
                    else
                    {
                        Button4.Visible = false;
                    }
                    Button1.Visible = true;

                }//判断有几个“,”，如果小于1个，那么说明为最后一个审批人了，可以转交到下一个节点去。




            }


            string sql_down_bh = "select Title from qp_UseSpRemark where Username='" + Session["username"].ToString() + "' order by id desc";

            if (!IsPostBack)
            {
                list.Bind_DropDownList(normalcontent, sql_down_bh, "Title", "Title");
            }//审批备注

            BindDroList();
        }
        public void BindAttribute()
        {
            Button2.Attributes["onclick"] = "javascript:return showwait();";
            Button1.Attributes["onclick"] = "javascript:return showwait();";
            Button4.Attributes["onclick"] = "javascript:return showwait();";
            Button9.Attributes["onclick"] = "javascript:return showwait();";
            Button3.Attributes["onclick"] = "javascript:return delfj();";
        }

        public void BindDroList()
        {
            //附件列表
            string sql_down_1 = "select * from qp_AddWorkFlowFj where KeyField='" + Number.Text + "'";
            list.Bind_DropDownList_nothing(fjlb, sql_down_1, "NewName", "Name");
        }
        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("WorkFlowList.aspx");

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



            string sql_insert1 = "insert into qp_AddWorkFlowLog (WorkFlowId,FormName,WorkFlowName,Content,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + FormName + "','" + Name + "','审批工作','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','"+System.DateTime.Now.ToString()+"')";
            List.ExeSql(sql_insert1);
            if (SpModle == "只要有一人通过审批即可向下流转")
            {
                //string Sql_update = "Update qp_AddWorkFlow  Set Name='"+List.GetFormatStr(whname.Text)+"',State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',WGLObjectId=WGLObjectId+'" + Session["username"] + ",',WGLObjecName=WGLObjecName+'" + Session["realname"] + ",',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                string Sql_update = "Update qp_AddWorkFlow  Set Name='" + List.GetFormatStr(whname.Text) + "',State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
            }
            else
            {
                //string Sql_update = "Update qp_AddWorkFlow  Set State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',WGLObjectId=WGLObjectId+'" + Session["username"] + ",',WGLObjecName=WGLObjecName+'" + Session["realname"] + ",',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',JBRObjectId='" + HyUsername + "',JBRObjectName='" + HyRealname + "',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                string Sql_update = "Update qp_AddWorkFlow  Set Name='" + List.GetFormatStr(whname.Text) + "',State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',JBRObjectId='" + HyUsername + "',JBRObjectName='" + HyRealname + "',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);
            }



        


            //Response.Redirect("WorkFlowListSp_Next.aspx?UpNodeNum=" + UpNodeNumKey + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&UpNodeId=" + Request.QueryString["UpNodeId"] + "&Number=" + Number.Text + "");





            }
            catch
            {
                this.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写！');</script>");
                return;
            }


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


                string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','" + fileName + "','" + TruePath + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_inserta);
               

                InsertLog("上传审批文件[" + fileName + "]", "工作管理");
                BindDroList();
            }
            else
            {
                if (SpContent.Text == "")
                {
                  
                }
                else
                {
                    string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','','','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }
            }


            string SQL_GetList2 = "select * from qp_AddWorkFlow where  id='" + Request.QueryString["id"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                string SQL_GetList1 = "select * from qp_YBLWorkFlow where  Number='" + NewReader2["Number"] + "'";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    string Sql_updatea = "Update qp_YBLWorkFlow  Set  FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "' where Number='" + NewReader2["Number"] + "'";
                    List.ExeSql(Sql_updatea);

                }
                else
                {


                    string sql_inserta = "insert into qp_YBLWorkFlow (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes) values ('" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["UpNodeNumber"] + "','" + NewReader2["UpNodeNum"] + "','" + NewReader2["UpNodeName"] + "','" + NewReader2["Number"] + "','" + NewReader2["Sequence"] + "','" + NewReader2["Name"] + "','" + List.GetFormatStrbjq(ContractContent.Text) + "','" + NewReader2["FqUsername"] + "','" + NewReader2["FqRealname"] + "','" + NewReader2["YJBObjectId"] + "','" + NewReader2["YJBObjecName"] + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }
                NewReader1.Close();
            }//保存已办理
            NewReader2.Close();





            Response.Redirect("WorkFlowList.aspx");



        }

        public void InsertLog(string Name, string MkName)
        {


            string sql_insert_log = "insert into qp_SystemLog (Name,MkName,Username,Realname,Nowtimes,Ip,Unit,UnitId,QxString) "
                                      + "values ('" + Name + "','" + MkName + "','" + this.Session["username"] + "','" + this.Session["realname"] + "','" + System.DateTime.Now.ToString() + "','" + Page.Request.UserHostAddress + "','" + this.Session["Unit"] + "','" + this.Session["UnitId"] + "','" + this.Session["QxString"] + "')";
            List.ExeSql(sql_insert_log);

        }

        protected void Button4_Click(object sender, EventArgs e)
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



            string sql_insert1 = "insert into qp_AddWorkFlowLog (WorkFlowId,FormName,WorkFlowName,Content,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + FormName + "','" + Name + "','审批工作','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
            List.ExeSql(sql_insert1);


            //string Sql_update = "Update qp_AddWorkFlow  Set State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',WGLObjectId=WGLObjectId+'" + Session["username"] + ",',WGLObjecName=WGLObjecName+'" + Session["realname"] + ",',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            string Sql_update = "Update qp_AddWorkFlow  Set Name='" + List.GetFormatStr(whname.Text) + "',State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
            List.ExeSql(Sql_update);

            List.ExeSql(sql_insert1);







            }
            catch
            {
                this.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写！');</script>");
                return;
            }


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


                string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','" + fileName + "','" + TruePath + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_inserta);


                InsertLog("上传审批文件[" + fileName + "]", "工作管理");
                BindDroList();
            }
            else
            {


                if (SpContent.Text == "")
                {

                }
                else
                {
                    string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','','','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }


            }


            string SQL_GetList2 = "select * from qp_AddWorkFlow where  id='" + Request.QueryString["id"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                string SQL_GetList1 = "select * from qp_YBLWorkFlow where  Number='" + NewReader2["Number"] + "'";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    string Sql_updatea = "Update qp_YBLWorkFlow  Set  FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "' where Number='" + NewReader2["Number"] + "'";
                    List.ExeSql(Sql_updatea);

                }
                else
                {


                    string sql_inserta = "insert into qp_YBLWorkFlow (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes) values ('" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["UpNodeNumber"] + "','" + NewReader2["UpNodeNum"] + "','" + NewReader2["UpNodeName"] + "','" + NewReader2["Number"] + "','" + NewReader2["Sequence"] + "','" + NewReader2["Name"] + "','" + List.GetFormatStrbjq(ContractContent.Text) + "','" + NewReader2["FqUsername"] + "','" + NewReader2["FqRealname"] + "','" + NewReader2["YJBObjectId"] + "','" + NewReader2["YJBObjecName"] + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }
                NewReader1.Close();
            }//保存已办理
            NewReader2.Close();



           // Response.Redirect("WorkFlowListSp_Next.aspx?UpNodeNum=" + UpNodeNumKey + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&UpNodeId=" + Request.QueryString["UpNodeId"] + "&Number=" + Number.Text + "");
            Response.Redirect("WorkFlowListSp_Next.aspx?UpNodeNum=" + GqUpNodeNumKey.Text + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&UpNodeId=" + Request.QueryString["UpNodeId"] + "&Number=" + Number.Text + "");


        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string TjszStrSz, TjszStrCg;
            //    string TjszStr;
            //    // InsertLog("快速新建", "快速新建");
            //    //TjszStr = "";
            //    string str1 = null;
            //    str1 = "" + UpNodeNum + "0";
            //    ArrayList myarr = new ArrayList();
            //    string[] mystr = str1.Split(',');
            //    for (int s = 0; s < mystr.Length; s++)//循环得到下一步骤ID，按照ID来读字段
            //    {
            //        TjszStrCg = null; TjszStrSz = null;
            //        TjszStr = null;
            //        TjszStr = "1 == 1";
            //        string SQL_GetListCg = "select * from qp_FlowFormFile where KeyID=(select id from qp_WorkFlowNode where NodeNum='" + mystr[s] + "' and FlowNumber='" + Request.QueryString["FlowNumber"] + "') and NodeId='" + NodeId + "' and  Type='[常规型]'";
            //        //Response.Write("" + SQL_GetListCg + "<br><br>");
            //        SqlDataReader NewReaderCg = List.GetList(SQL_GetListCg);
            //        while (NewReaderCg.Read())
            //        {
            //            if (NewReaderCg["Conditions"].ToString() == "包含")
            //            {

            //                TjszStrCg += "&&" + Request.Form["" + NewReaderCg["Number"] + ""].IndexOf(NewReaderCg["JudgeBasis"].ToString()) + ">= 0 ";

            //            }
            //            else if (NewReaderCg["Conditions"].ToString() == "不包含")
            //            {
            //                TjszStrCg += "&&" + Request.Form["" + NewReaderCg["Number"] + ""].IndexOf(NewReaderCg["JudgeBasis"].ToString()) + "< 0 ";
            //            }
            //            //Response.Write("常规型：" + TjszStrCg + "<br><br>");
            //        }

            //        NewReaderCg.Close();//条件设置--常规型


            //        string SQL_GetListSz = "select * from qp_FlowFormFile where  KeyID=(select id from qp_WorkFlowNode where NodeNum='" + mystr[s] + "' and FlowNumber='" + Request.QueryString["FlowNumber"] + "') and  NodeId='" + NodeId + "' and  Type='[数字型]'";
            //        //Response.Write("" + SQL_GetListSz + "");
            //        SqlDataReader NewReaderSz = List.GetList(SQL_GetListSz);
            //        while (NewReaderSz.Read())
            //        {
            //            TjszStrSz += "&&" + int.Parse(Request.Form["" + NewReaderSz["Number"] + ""]) + " " + NewReaderSz["Conditions"] + " " + NewReaderSz["JudgeBasis"] + "  ";
            //        }

            //        NewReaderSz.Close();//条件设置--数字型


            //        TjszStr += TjszStrCg + TjszStrSz;
            //        //Response.Write("比较：" + TjszStr + "<br><br>");
            //        MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControlClass();
            //        sc.Language = "javascript";
            //        if ((bool)sc.Eval(TjszStr) == false)
            //        {
            //            //Response.Write("啊：啊" + mystr[s] + " <br><br>");
            //            UpNodeNumKey = UpNodeNumKey.Replace("" + mystr[s] + ",", "");
            //            GqUpNodeNumKey.Text = GqUpNodeNumKey.Text.Replace("" + mystr[s] + ",", "");

            //        }





            //    }



                string sql_insert1 = "insert into qp_AddWorkFlowLog (WorkFlowId,FormName,WorkFlowName,Content,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + FormName + "','" + Name + "','审批工作','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_insert1);


                //string Sql_update = "Update qp_AddWorkFlow  Set State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',WGLObjectId=WGLObjectId+'" + Session["username"] + ",',WGLObjecName=WGLObjecName+'" + Session["realname"] + ",',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                string Sql_update = "Update qp_AddWorkFlow  Set Name='" + List.GetFormatStr(whname.Text) + "',State='正在办理', FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "',YJBObjectId=YJBObjectId+'" + Session["username"] + ",',YJBObjecName=YJBObjecName+'" + Session["realname"] + ",',UpTimeSet='" + System.DateTime.Now.ToString() + "' where id='" + int.Parse(Request.QueryString["id"]) + "'";
                List.ExeSql(Sql_update);

                List.ExeSql(sql_insert1);







            //}
            //catch
            //{
            //    this.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写！');</script>");
            //    return;
            //}


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


                string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','" + fileName + "','" + TruePath + "','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                List.ExeSql(sql_inserta);


                InsertLog("上传审批文件[" + fileName + "]", "工作管理");
                BindDroList();
            }
            else
            {


                if (SpContent.Text == "")
                {

                }
                else
                {
                    string sql_inserta = "insert into qp_AddWorkFlowMessage (WorkFlowId,FormName,WorkFlowName,Content,OldName,NewName,Username,Realname,Settime) values ('" + Request.QueryString["id"] + "','" + NodeName + "','" + Name + "','" + SpContent.Text + "','','','" + this.Session["Username"] + "','" + this.Session["Realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }


            }


            string SQL_GetList2 = "select * from qp_AddWorkFlow where  id='" + Request.QueryString["id"] + "'";
            SqlDataReader NewReader2 = List.GetList(SQL_GetList2);
            if (NewReader2.Read())
            {
                string SQL_GetList1 = "select * from qp_YBLWorkFlow where  Number='" + NewReader2["Number"] + "'";
                SqlDataReader NewReader1 = List.GetList(SQL_GetList1);
                if (NewReader1.Read())
                {
                    string Sql_updatea = "Update qp_YBLWorkFlow  Set  FileContent='" + List.GetFormatStrbjq(ContractContent.Text) + "' where Number='" + NewReader2["Number"] + "'";
                    List.ExeSql(Sql_updatea);

                }
                else
                {


                    string sql_inserta = "insert into qp_YBLWorkFlow (FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes) values ('" + NewReader2["FormId"] + "','" + NewReader2["FormNumber"] + "','" + NewReader2["FormName"] + "','" + NewReader2["FlowId"] + "','" + NewReader2["FlowNumber"] + "','" + NewReader2["FlowName"] + "','" + NewReader2["UpNodeNumber"] + "','" + NewReader2["UpNodeNum"] + "','" + NewReader2["UpNodeName"] + "','" + NewReader2["Number"] + "','" + NewReader2["Sequence"] + "','" + NewReader2["Name"] + "','" + List.GetFormatStrbjq(ContractContent.Text) + "','" + NewReader2["FqUsername"] + "','" + NewReader2["FqRealname"] + "','" + NewReader2["YJBObjectId"] + "','" + NewReader2["YJBObjecName"] + "','" + Session["username"] + "','" + Session["realname"] + "','" + System.DateTime.Now.ToString() + "')";
                    List.ExeSql(sql_inserta);
                }
                NewReader1.Close();
            }//保存已办理
            NewReader2.Close();



            Response.Redirect("WorkFlowListSp_BhNext.aspx?UpNodeNum=" + BhUpNodeNum + "&FlowNumber=" + Request.QueryString["FlowNumber"] + "&FormId=" + Request.QueryString["FormId"] + "&UpNodeId=" + Request.QueryString["UpNodeId"] + "&Number=" + Number.Text + "");


        }

    



    }
}

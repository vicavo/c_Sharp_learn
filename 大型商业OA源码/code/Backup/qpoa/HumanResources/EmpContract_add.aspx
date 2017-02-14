<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpContract_add.aspx.cs" Inherits="qpoa.HumanResources.EmpContract_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<SCRIPT language="javascript" type="text/javascript">

function checkForm()
{
if(document.getElementById('Name').value=='')
{
alert('人员姓名不能为空');
form1.Name.focus();
return false;
}	

if(document.getElementById('QyTime').value=='')
{
alert('签约日期不能为空');
form1.QyTime.focus();
return false;
}	



if(document.getElementById('MyTime').value=='')
{
alert('满约日期不能为空');
form1.MyTime.focus();
return false;
}	

var strUploadFile=document.getElementById('uploadFile').value;
if (strUploadFile!="")
{
//var nameLen=strUploadFile.length;
//var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();
//var objRe = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(<%=fjkey%>)$/;
//if(!objRe.test(document.getElementById('uploadFile').value))
//{
//alert("提示:\r不支持此格式的文件！请区分文件扩展名大小写\r只能上传<%=fjkey%>");
//form1.uploadFile.focus();
//return false;
//}

var sAllowExt = "<%=fjkey%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	return false;
}



}


showwait();	



}
</SCRIPT>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
             </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
           <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="EmpContract.aspx"  class="line_b">人事合同</a> >> 新增人事合同</td>
                      <td width="81%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                    <tr> 
                      <td></td>
                    </tr>
                  </table></td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
             </div>
            </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
           <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">人事合同</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 人事合同</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人员：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser()" src="../images/FDJ.gif" border="0"></A>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同状态：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:DropDownList ID="Type" runat="server" Width="90%">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>有效</asp:ListItem>
                                        <asp:ListItem>无效</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同编号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Number" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>                            
 
                             <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    期限形式：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:DropDownList ID="FormType" runat="server" Width="90%">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>有限期</asp:ListItem>
                                        <asp:ListItem>无限期</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同类型：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="ContractType" runat="server" Width="90%"></asp:TextBox></td>
                            </tr> 
 
                             <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    竞业条款：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:DropDownList ID="Terms" runat="server" Width="90%">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>有</asp:ListItem>
                                        <asp:ListItem>无</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    保密协议：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Confident" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>  
 
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                   签约日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="QyTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('QyTime')</script>
                                      <A href="javascript:void(0)"><IMG id="QyTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                     满约日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="MyTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('MyTime')</script>
                                      <A href="javascript:void(0)"><IMG id="MyTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                            </tr>  
                            
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    鉴证机关：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="Organs" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    鉴证日期：</td>
                                <td class="newtd2" height="24" width="35%">
                                  <asp:TextBox ID="QzTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('QzTime')</script>
                                      <A href="javascript:void(0)"><IMG id="QzTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                
                                   
                                    </td>
                            </tr>        
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    违约责任：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="WeiYue" runat="server" Width="90%" Height="68px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>                  
                        
                           <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    其他事宜：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="OtherContent" runat="server" Width="90%" Height="75px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>                             
                            
                            
                            
                            <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 501px" type="file" name="uploadFile" />
                                    </td>
                          
                            </tr>  
                              
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
								</FONT>
							</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>
   <asp:TextBox ID="NameId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox> 
 
 <script>
 var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('NameId').value+"|"+document.getElementById('Name').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Employee.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("NameId").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
}
}

 
 
 
 </script>   
    
    </form>
</body>
</html>
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDiary_update.aspx.cs" Inherits="qpoa.MyAffairs.MyDiary_update" validateRequest="false"%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
    if(document.getElementById('DiaryTime').value=='')
    {
    alert('日志时间不能为空');
    form1.DiaryTime.focus();
    return false;
    }	

    if(document.getElementById('LdRealname').value=='')
    {
    alert('职员领导不能为空');
    form1.LdRealname.focus();
    return false;
    }	
    
    showwait();					
}

function openqiupengmodle()
{
var num=Math.random();
window.open ("../fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
oEditor.InsertHtml(''+str+'');
}

</script>

<SCRIPT language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();

var sAllowExt = "<%=fjkey%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
}


showwait();	



}


function  down()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');

return false;
}
else
{

var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.open ("../file_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


}

function  delfj()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');
return false;
}
else
{
if (!confirm("是否确定要删除？"))
return false;

showwait();	
var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.showModalDialog("../file_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                

}


}			




</SCRIPT>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <META http-equiv=Pragma content=no-cache>
<META http-equiv=Cache-Control content=no-cache>
<META http-equiv=Expires content=0>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="MyDiary.aspx"  class="line_b">日志上报</a> >> 新增日志上报</td>
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
                                    <font class="shadow_but">日志上报</font></button></td>
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
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    日志时间：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                   <asp:TextBox ID="DiaryTime" runat="server" Width="85%"></asp:TextBox>
                                      <script>SetNeed('DiaryTime')</script>
                                      <A href="javascript:void(0)"><IMG id="DiaryTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                    
                                    
                                    </td>
                            </tr>

                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    日志类型：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                <asp:DropDownList ID="DiaryType" runat="server" Width="90%">
                                    <asp:ListItem>工作日志</asp:ListItem>
                                    <asp:ListItem>个人日志</asp:ListItem>
                                </asp:DropDownList>   
                                   
                                   
                                   </td>
                            </tr>
                        
     
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                     日志内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
                   
  <fckeditorv2:fckeditor id="d_content" runat="server" Height="250px" ToolbarSet="Qiupeng1"></fckeditorv2:fckeditor>


                                
                                </td>
                            </tr>
                       
                                                       <tr>
                            <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                width="15%">
                                职员领导：</td>
                            <td class="newtd2" height="17" colspan="3" width="85%">
                       <asp:TextBox ID="LdRealname" runat="server" Width="80%"></asp:TextBox><a
                                                        href="javascript:void(0)"><img onclick="openuser1();" alt="" src="../images/FDJ.gif"
                                                            border="0"></a> 
                               
                               
                               </td>
                        </tr>
                            
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="70%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
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

<asp:TextBox ID="Number" runat="server"  style="DISPLAY: none"></asp:TextBox>
            <asp:TextBox ID="LdUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	



var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('LdUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("LdUsername").value=arr[0]; 
document.getElementById("LdRealname").value=arr[1]; 
}
}



        </script>
    
    </form>
</body>
</html>
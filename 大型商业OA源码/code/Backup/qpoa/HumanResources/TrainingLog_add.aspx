<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrainingLog_add.aspx.cs" Inherits="qpoa.HumanResources.TrainingLog_add" validateRequest="false"%>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
if(document.getElementById('TrainingPro').value=='')
{
alert('培训项目不能为空');
form1.TrainingPro.focus();
return false;
}	

if(document.getElementById('StaffName').value=='')
{
alert('参与人员不能为空');
form1.StaffName.focus();
return false;
}	


showwait();					



}

</script>



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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>&nbsp; <a href="TrainingLog.aspx"  class="line_b">培训记录</a> >>&nbsp; 新增培训记录</td>
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
                                    <font class="shadow_but">培训记录</font></button></td>
                              <td style="height: 26px" align="right" > 
                                  <a href="javascript:void(0)"></a></td>
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
                            width="100%" id="tableprint">
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    培训项目：</td>
                                <td class="newtd2" height="17" colspan="3" width="83%">
                                    <asp:TextBox ID="TrainingPro" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    培训单位：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:TextBox ID="TrainingCompany" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                                                      <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    参与用户：</td>
                                <td class="newtd2" colspan="3" height="17">
                                     <asp:TextBox ID="StaffName" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>  
                               <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Starttime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Starttime')</script>
                                      <A href="javascript:void(0)"><IMG id="Starttime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>
                            
                            
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    培训内容：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    &nbsp;<fckeditorv2:fckeditor id="d_content" runat="server" height="350px" toolbarset="Qiupeng1"></fckeditorv2:fckeditor></td>
                            </tr>                          
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:TextBox ID="Remark" runat="server" Height="85px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>

                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button2" runat="server" CssClass="button_blue" OnClick="Button1_Click"
                                                Text="确 定" />
                                            &nbsp; &nbsp;
                                            &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CssClass="button_blue" OnClick="Button4_Click"
                                                Text="返 回" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="StaffId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('StaffId').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_EmployeeList.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("StaffId").value=arr[0]; 
document.getElementById("StaffName").value=arr[1]; 
}
}



</script>  



    </form>
</body>
</html>
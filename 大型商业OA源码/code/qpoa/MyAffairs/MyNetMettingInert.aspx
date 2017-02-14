<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyNetMettingInert.aspx.cs" Inherits="qpoa.MyAffairs.MyNetMettingInert" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


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
    <td valign="top">
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
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
                                    width="15%">
                                    会议名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">会议主题：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="Title" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="center" class="newtd2" colspan="4" height="17">
                                <div><a  href="callto:<%= MettingIp%>">呼叫进入</a>&nbsp;&nbsp;<a  href="javascript:void(0)" onclick=NetMeeting.LeaveConference()>挂断会议</a>  </div>
                                 <OBJECT id=NetMeeting
            classid=clsid:3E9BAF2D-7A79-11D2-9334-0000F875AE17
            VIEWASTEXT>
 </OBJECT>
 
                                </td>
                            </tr>
                         
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <input id="Button1" class="button_blue" onclick="window.close()" type="button" value="关 闭" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="NbPeopleUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="MettingId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox> 

    </form>
</body>
</html>
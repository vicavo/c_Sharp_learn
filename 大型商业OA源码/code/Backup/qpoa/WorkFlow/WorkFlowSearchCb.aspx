<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowSearchCb.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowSearchCb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" onload="Settb();Load_Do();" >
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
                            width="100%">
                            <tr class="">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    内容：</td>
                                <td class="newtd2"  colspan="3" height="17" width="83%">
                                    <asp:TextBox ID="Title" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr class="">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    催办人员：</td>
                                <td class="newtd2"  colspan="3" height="17" width="83%">
                                    <asp:TextBox ID="JBRObjectId" runat="server" Height="55px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 24px"
                                    width="15%">
                                    短信提醒：</td>
                                <td class="newtd2" colspan="3" style="height: 24px" width="85%">
                                    <img src="../images/menu/sms.gif" /><asp:CheckBox ID="C1" runat="server" Text="内部短信通知" Checked="True" /><img id="IMG1" runat="server" src="../images/menu/mobile_sms.gif" /><asp:CheckBox ID="C2" runat="server"
                                        Text="手机短信通知" /></td>
                            </tr>
                            
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="催 办" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp;&nbsp;&nbsp;</FONT></div> </td>
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
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyData.aspx.cs" Inherits="qpoa.SaleManage.MyData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >







<head id="Head1" runat="server">
    <title>用户资料</title>
        <LINK href="css/public.css" type="text/css" rel="stylesheet">
         <LINK href="css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="public/pleasewait.htm"-->
    <!--#include file="public/public.js"-->
  
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
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                           
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    用户姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Realname" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Worknum" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                           
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Unit" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Post" runat="server" Width="95%"></asp:Label></td>
                            </tr>                     
                        
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    性别：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Sex" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    生日：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Bothday" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>联系信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    单位电话：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Tel" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    单位传真：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Fax" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                          
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    手机：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="MoveTel" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    小灵通：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="LittleTel" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                          
                                                    <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    电子邮件：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Email" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                   QQ号码：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="QQNum" runat="server" Width="95%"></asp:Label></td>
                            </tr>  
                          
                          
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    MSN：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Msn" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                   ICQ号码：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ICQ" runat="server" Width="95%"></asp:Label></td>
                            </tr>               
                           
                           
                                                       <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>家庭信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    家庭住址：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Address" runat="server" Width="95%"></asp:Label></td>
                          
                            </tr>                           
                         <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    家庭邮编：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="ZipCode" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                  家庭电话：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="HomeTel" runat="server" Width="95%"></asp:Label></td>
                            </tr>  
                             
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <input id="Button3" class="button_blue" onclick="window.close()" type="button" value="关 闭" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="KeyId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
    
<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    
    
    </form>
</body>
</html>
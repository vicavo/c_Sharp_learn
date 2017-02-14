<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerPublicLxr_show.aspx.cs" Inherits="qpoa.SaleManage.CustomerPublicLxr_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >







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
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                        <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>  <a href=CustomerPublic.aspx class="line_b">共享客户信息</a> >> 查看联系人信息</td>
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
                                    <font class="shadow_but">联系人信息</font></button></td>
                              <td style="height: 26px" align="right"  > 
                                      <a href="javascript:void(0)"><img src="../images/button_print.jpg" border= 0 onclick="printpage()"/></a></td>
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
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    客户名称：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Name" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    联系人姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="KhRealname" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    联系人职位：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="LxrPost" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                                                       <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    是否共享：</td>
                                <td class="newtd2" height="24" width="33%" colspan="3">
                                    <asp:Label ID="Sharing" runat="server" Width="90%"></asp:Label></td>
                                
                            </tr>
                            <asp:Panel ID="Panel1" runat="server" >
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    共享人：</td>
                                <td class="newtd2" height="17" colspan="3">
                                <asp:Label id="SharingName" runat="server" Width="90%"></asp:Label>
                                
                                   </td>
                            </tr>
                            
                            </asp:Panel> 
                            
                            
                            
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
                                    <script>SetNeed('Bothday')</script>

                                    <asp:Label ID="BothDay" runat="server" Width="95%"></asp:Label></td>
                            </tr>
               
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    爱好：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Lovly" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                              
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>联系信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    家庭电话：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="JtTel" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    家庭邮编：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="JtZipCode" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                               <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    家庭地址：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="JtAddress" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    工作电话：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="GzTel" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    手机：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="MoveTel" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                          
                                                    <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    Email：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Email" runat="server" Width="95%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    QQ号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="QqNumber" runat="server" Width="95%"></asp:Label></td>
                            </tr>  
                          
                          
                          
                           
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    MSN号</td>
                                <td class="newtd2" height="24" colspan="3">
                                    <asp:Label ID="MsnNumber" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                                                       <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>备注信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Remark" runat="server" Width="95%"></asp:Label></td>
                          
                            </tr>                           
                            
                            
                            
  
                                   <%=showjg%> 
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <input id="Button3" class="button_blue" onclick="history.back()" type="button" value="返 回" /></FONT>&nbsp;</div> </td>
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
    

    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IncentiveLog_show.aspx.cs" Inherits="qpoa.HumanResources.IncentiveLog_show" %>


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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>&nbsp; <a href="IncentiveLog.aspx"  class="line_b">奖惩记录</a> >>&nbsp; 查看奖惩记录</td>
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
                                    <font class="shadow_but">奖惩记录</font></button></td>
                              <td style="height: 26px" align="right" > 
                                  <a href="javascript:void(0)"><img border="0" onclick="printpage()" src="../images/button_print.jpg" /></a></td>
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
                                    奖惩用户：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="StaffName" runat="server" Width="90%"></asp:Label></td>
                            </tr>   
                            
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">奖惩区分：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:Label ID="Type" runat="server" Width="90%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">奖惩日期：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('SetTime')</script>

                                    <asp:Label ID="SetTime" runat="server" Width="90%"></asp:Label></td>           
                              
                                
                            </tr>                       
                        
                        
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    授予单位：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:Label ID="Unit" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                               
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    奖惩名目：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="JcNames" runat="server" Width="90%"></asp:Label></td>
                            </tr>                         
                            
                            
                            
                                              
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    奖惩原因：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="Reasons" runat="server" Width="90%"></asp:Label></td>
                            </tr>

                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button4" runat="server" CssClass="button_blue" OnClick="Button4_Click"
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




    </form>
</body>
</html>
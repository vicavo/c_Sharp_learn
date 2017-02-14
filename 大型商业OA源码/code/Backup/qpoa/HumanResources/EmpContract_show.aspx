<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpContract_show.aspx.cs" Inherits="qpoa.HumanResources.EmpContract_show" %>

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="EmpContract.aspx"  class="line_b">人事合同</a> >> 查看人事合同</td>
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
                              <td style="height: 26px" align="right" > 
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
                                    <b> 人事合同</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人员：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同状态：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Type" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同编号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Number" runat="server" Width="90%"></asp:Label></td>
                            </tr>                            
 
                             <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    期限形式：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="FormType" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同类型：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ContractType" runat="server" Width="90%"></asp:Label></td>
                            </tr> 
 
                             <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    竞业条款：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Terms" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    保密协议：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Confident" runat="server" Width="90%"></asp:Label></td>
                            </tr>  
 
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                   签约日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('QyTime')</script>

                                    <asp:Label ID="QyTime" runat="server" Width="90%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                     满约日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('MyTime')</script>

                                    <asp:Label ID="MyTime" runat="server" Width="90%"></asp:Label></td>           
                            </tr>  
                            
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    鉴证机关：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Organs" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    鉴证日期：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <script>SetNeed('QzTime')</script>

                                    <asp:Label ID="QzTime" runat="server" Width="90%"></asp:Label></td>
                            </tr>        
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    违约责任：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="WeiYue" runat="server" Width="90%"></asp:Label></td>
                            </tr>                  
                        
                           <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    其他事宜：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="OtherContent" runat="server" Width="90%"></asp:Label></td>
                            </tr>                             
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    附件信息：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="FjInfo" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                              
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
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
 

    
    </form>
</body>
</html>
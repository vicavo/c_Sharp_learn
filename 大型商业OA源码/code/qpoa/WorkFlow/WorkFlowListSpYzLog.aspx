﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowListSpYzLog.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowListSpYzLog" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody"  >
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
         
         
                                 
                            <tr>
                                <td class="newtd2" colspan="4" height="17" >
                                    <asp:GridView ID="GridView1" runat="server"
                                        AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                        BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                        PageSize="12" Style="font-size: 12px" Width="100%">
                                        <PagerSettings Visible="False" />
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <Columns>
                                       <asp:TemplateField HeaderText="印章使用记录" >
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                         
                                        <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                        <tr>
                                        <td align="center">  <img src="CompanySeal/<%# DataBinder.Eval(Container.DataItem, "Newname")%>" style="width: 140px; height: 140px" id="img1" name="img1" /></td>
                                        </tr>
                                        <tr>
                                        <td align="center"> <b>印章名称：</b><%# DataBinder.Eval(Container.DataItem, "Name")%>  <b>&nbsp;&nbsp;&nbsp;&nbsp;使用人：</b><%# DataBinder.Eval(Container.DataItem, "Realname")%>    <b>&nbsp;&nbsp;&nbsp;&nbsp;IP：</b><%# DataBinder.Eval(Container.DataItem, "IpAddress") %>  &nbsp;&nbsp;&nbsp;&nbsp;<b>时间：</b><%# DataBinder.Eval(Container.DataItem, "Settime") %></td>
                                        </tr>
                                        </table>    
                                         
                                         
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField> 
                                        </Columns>
                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                        <EmptyDataTemplate>
                                            <div align="center">
                                                <font color="white">无相关数据！</font></div>
                                        </EmptyDataTemplate>
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="Transparent" ForeColor="Black" HorizontalAlign="Right" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                        <AlternatingRowStyle BackColor="#E6EDF7" />
                                    </asp:GridView>
                                    </td>
                            </tr>
                            
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <input id="Button3" class="button_blue" onclick="javascript:window.close()" type="button"
                                                value="关 闭" /></FONT>&nbsp;</div> </td>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmShowZjShow.aspx.cs" Inherits="qpoa.KmManage.KmShowZjShow" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head id="Head1" runat="server">
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" >
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" style="height: 573px">
    
    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0" id="printshow1">
        <tr>
          <td>
              工作台 &gt;&gt;&nbsp;  知识章节&nbsp; &gt;&gt;&nbsp;<span style="color: #ff0000">
                 <%=KmTitle %></span></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2" align=right> 
             <input id="Button1" type="button" value="打 印"  onclick="printpage()"/>
                &nbsp;&nbsp; &nbsp;</div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="tableprint">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            
                        <tr  class="" id="Tr1">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    章节标题：</td>
                                <td class="newtd2"  height="17" width="83%" colspan=3>
                                    <asp:Label ID="Name" runat="server" Width="99%"></asp:Label></td>
                          
                            </tr>     
                            
                            
                            <tr>
                                <td class="newtd2"  colspan="4" height="17">
                                             <%=d_content %>
                                
                                
                                </td>
                            </tr>                         
                            
                            <tr>
                                 <td class="newtd2"  colspan="4" height="17" style="text-align: center">
                                     <strong>章节附件</strong></td>
                            </tr>                           
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    附件列表：</td>
                                <td class="newtd2"  height="17" width="83%" colspan=3>
                                    <asp:Label ID="richeng" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                           
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <input id="Button2" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT>&nbsp;</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table>
              <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox></td>
  </tr>
</table>

  
    
    </form>
</body>
</html>
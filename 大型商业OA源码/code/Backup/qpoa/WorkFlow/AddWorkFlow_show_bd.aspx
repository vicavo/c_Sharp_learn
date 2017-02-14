<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlow_show_bd.aspx.cs" Inherits="qpoa.WorkFlow.AddWorkFlow_show_bd" %>
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
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              
           </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" style="width: 918px" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1" style="width: 86%">
                
                             <tr>
                                <td class="newtd2" height="17" width="85%">
                                   类别：<asp:Label ID="Type" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                
                            <tr>
                                <td class="newtd2" height="17" width="85%">
                                    名称：<asp:Label ID="FormName" runat="server" Width="90%"></asp:Label></td>
                            </tr>
               
                                <tr>
                                <td bgcolor="#ffffff" class="cpx12hei" >
                                    <asp:Label ID="FormContent" runat="server" Width="90%"></asp:Label></td>
                            </tr>             
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <input id="Button3" class="button_blue" type="button"
                                                value="关 闭" onclick="window.close()"/>
                             
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
<asp:TextBox ID="openusername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

    </form>
</body>
</html>
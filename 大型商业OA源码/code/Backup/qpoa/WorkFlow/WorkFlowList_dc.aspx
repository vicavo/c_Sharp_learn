<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowList_dc.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowList_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" onload="" >
    <form id="form1" runat="server">
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
                                <td class="newtd2" colspan="4" height="17">
                                    9流水号：<%=lshid %> － <%=Name%> － 当前步骤：<%=NodeName %> </td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                    <strong>表单信息</strong>
                                    

                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" class="cpx12hei" colspan="4" height="17">
                                     <div id="strhtm"><%=ddstr %></div>
                                    </td>
                                
                                
                                
                                
                            </tr>                            
                             <tr>
                                 <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                     <strong>公共附件</strong></td>
                            </tr>                           
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件列表：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                                    <asp:Label ID="richeng" runat="server" Width="90%"></asp:Label></td>
                          
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

<asp:TextBox ID="Number" runat="server" style="DISPLAY: none" ></asp:TextBox>
  
    
    </form>
</body>
</html>
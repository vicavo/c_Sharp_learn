<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkTimeDj.aspx.cs" Inherits="qpoa.MyAffairs.WorkTimeDj" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
	   function dj()
			{
			
			    if (!confirm("是否确定要登记？"))
			    return false;
		     
			
			}
				

</script>


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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 上下班登记</td>
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
                                    <font class="shadow_but">上下班登记</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
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
                            width="100%">
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第一次<FONT color="#ff0000"><%=DjType_1%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                    <asp:textbox id="DjTime_1" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button2" runat="server" Text="登  记" OnClick="Button2_Click"></asp:button></td>
                            </tr>
                              
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第二次<FONT color="#ff0000"><%=DjType_2%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                   <asp:textbox id="DjTime_2" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button3" runat="server" Text="登  记" OnClick="Button3_Click"></asp:button></td>
                            </tr>
                            
                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第三次<FONT color="#ff0000"><%=DjType_3%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                    <asp:textbox id="DjTime_3" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button4" runat="server" Text="登  记" OnClick="Button4_Click"></asp:button></td>
                            </tr>
                            
                            
                               <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第四次<FONT color="#ff0000"><%=DjType_4%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                    <asp:textbox id="DjTime_4" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button5" runat="server" Text="登  记" OnClick="Button5_Click"></asp:button></td>
                            </tr>
                            
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第五次<FONT color="#ff0000"><%=DjType_5%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                    <asp:textbox id="DjTime_5" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button6" runat="server" Text="登  记" OnClick="Button6_Click"></asp:button></td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" Width="25%" >
                                    第六次<FONT color="#ff0000"><%=DjType_6%></FONT>登记时间：</td>
                                <td class="newtd2" height="17"  Width="75%" >
                                   <asp:textbox id="DjTime_6" runat="server" ReadOnly="True" Width="80%"></asp:textbox><asp:button id="Button7" runat="server" Text="登  记" OnClick="Button7_Click"></asp:button></td>
                            </tr>                                              
                                                                                         
                                            
                              
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" /></FONT></div> </td>
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
	<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="username_updateps.aspx.cs" Inherits="qpoa.SystemManage.username_updateps" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{


    if(document.getElementById('Password').value=='')
    {
    alert('用户密码不能为空');
    form1.Password.focus();
    return false;
    }	
    if(document.getElementById('Password').value!=document.getElementById('oldPassword').value)
    {
    alert('两次密码输入不一样');
    form1.Password.focus();
    return false;
    }	

  

    showwait();					
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
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="username.aspx" class="line_b">用户管理</a> >> 修改用户密码</td>
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
            </table></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                    <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <button  class="btn4off"  onclick="javascript:window.location='username_update.aspx?id=<%=requestid%>';showwait();" type="button">
                                    <font class="shadow_but">用户信息</font></button>
                                <button class="btn4on" onclick="javascript:window.location='username_updateps.aspx?id=<%=requestid%>';showwait();" type="button"><font class="shadow_but">密码修改</font></button>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="17">&nbsp;</td>
              </tr>
            </table></td>
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
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 用户信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    用户名：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="username" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    用户姓名：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    新密码：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Password" runat="server" Width="90%" TextMode="Password"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    确认新密码：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="oldPassword" runat="server" Width="90%" TextMode="Password"></asp:TextBox>
                                    </td>
                            </tr>
                      
                               
                          
  
                                   
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
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
      </table>  
      
      
      
      
      
      
      </td>
  </tr>
</table>
    </form>
</body>
</html>
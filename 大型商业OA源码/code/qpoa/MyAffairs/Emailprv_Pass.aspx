<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Emailprv_Pass.aspx.cs" Inherits="qpoa.MyAffairs.Emailprv_Pass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{


if(document.getElementById('EmailName').value=='')
{
alert('邮箱名称不能为空');
form1.EmailName.focus();
return false;
}	

if(document.getElementById('EmailAdd').value=='')
{
alert('邮件地址不能为空');
form1.EmailAdd.focus();
return false;
}	

if(document.getElementById('EmailAdd').value!='')
{
var objRe = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
if(!objRe.test(document.getElementById('EmailAdd').value))
{
alert('邮件地址格式不正确');
form1.EmailAdd.focus();
return false;
}

}  



if(document.getElementById('EmailUserName').value=='')
{
alert('邮件用户名不能为空');
form1.EmailUserName.focus();
return false;
}	



if(document.getElementById('Pop3').value=='')
{
alert('POP3服务器不能为空');
form1.Pop3.focus();
return false;
}	

if(document.getElementById('Smtp').value=='')
{
alert('SMTP服务器不能为空');
form1.Smtp.focus();
return false;
}		
	
if(document.getElementById('MainNet').value=='')
{
alert('邮件主页不能为空');
form1.MainNet.focus();
return false;
}	
		
			
			
if(document.getElementById('MainNet').value!='')
{
var objRe =/http:\/\/([\w-]+\.)+[\w-]+(\/[\w- ./?%&=]*)?/
if(!objRe.test(document.getElementById('MainNet').value))
{
alert('邮件主页格式不正确');
form1.MainNet.focus();
return false;
}

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="Emailprv.aspx"  class="line_b">邮件参数设置</a> >> 修改邮件密码</td>
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
                                    <font class="shadow_but">邮件参数</font></button></td>
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
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
         
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    邮箱名称：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="EmailName" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    邮箱地址：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="EmailAdd" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    邮箱密码：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="Password" runat="server" Width="90%" TextMode="Password"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    邮箱新密码：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="NewPassword" runat="server" Width="90%" TextMode="Password"></asp:TextBox></td>
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
      </table></td>
  </tr>
</table>


    
    </form>
</body>
</html>
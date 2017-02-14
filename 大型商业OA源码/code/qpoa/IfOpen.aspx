<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IfOpen.aspx.cs" Inherits="qpoa.IfOpen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    showwait();					
}

function select_sound()
{
	sound=document.form1.Sound.value;
	if(sound!="0")
	{
	   str="<object  classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='#' width='0' height='0'><param name='movie' value='sound/"+sound+"'><param name=quality value=high><embed src='sound/"+sound+"' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>"
	   document.getElementById("sms_sound").innerHTML=str;
	}
}




</script>






<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="css/public.css" type="text/css" rel="stylesheet">
         <LINK href="css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="public/pleasewait.htm"-->
    <!--#include file="public/public.js"-->
    <script language="javascript" src="public/DateSelect.js"></script>
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
                      <td width="3%"><img src="images/top_3.gif" ></td>
                       <td width="81%" valign="bottom"><a href="main_d.aspx"  class="line_b">工作台</a> >> 用户提醒设置</td>
                      <td width="81%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="images/lingbg.jpg">
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
           <table align="center" background="images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">其他设置</font></button></td>
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
                                    <b> 其他设置</b></td>
                            </tr>
         
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    左边菜单弹出模式：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:DropDownList ID="Name" runat="server" Width="95%">
                                        <asp:ListItem Value="rform">不弹出</asp:ListItem>
                                        <asp:ListItem Value="_blank">弹出</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    系统提示音：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:DropDownList ID="Sound" runat="server" Width="95%" onchange="select_sound()">
                                        <asp:ListItem Value="1.swf">语音1</asp:ListItem>
                                        <asp:ListItem Value="8.swf">语音2</asp:ListItem>
                                        <asp:ListItem Value="2.swf">激光</asp:ListItem>
                                        <asp:ListItem Value="3.swf">水滴</asp:ListItem>
                                        <asp:ListItem Value="4.swf">手机</asp:ListItem>
                                        <asp:ListItem Value="5.swf">电话</asp:ListItem>
                                        <asp:ListItem Value="6.swf">鸡叫</asp:ListItem>
                                        <asp:ListItem Value="7.swf">OICQ</asp:ListItem>
                                        <asp:ListItem Value="0.swf">无</asp:ListItem>
                                    </asp:DropDownList>
                                   
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
      </table></td>
  </tr>
</table>

 <div align="right" id="sms_sound"></div>
    
    </form>
</body>
</html>
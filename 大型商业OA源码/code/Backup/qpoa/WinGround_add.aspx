<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WinGround_add.aspx.cs" Inherits="qpoa.WinGround_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<SCRIPT language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;
if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
showwait();	

}
</SCRIPT>

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
                       <td width="81%" valign="bottom"><a href="main_d.aspx"  class="line_b">工作台</a> >> <a href="WinGround.aspx"  class="line_b">Windows快捷组</a> >> 新增Windows快捷组</td>
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
                                    <font class="shadow_but">快捷组</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    快捷方式名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                                                         <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    程序路径：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 501px" type="file" name="uploadFile" />
                                    <br />
                                    本机Windows程序路径，如
C:\Program Files\Windows Media Player\wmplayer.exe

也可以定义使用IE访问网址，如
iexplore http://www.baidu.com 
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

 
    
    
    </form>
</body>
</html>
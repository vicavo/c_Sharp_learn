<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyDiaryCY_show.aspx.cs" Inherits="qpoa.MyAffairs.MyDiaryCY_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
    if(document.getElementById('DiaryTime').value=='')
    {
    alert('日志时间不能为空');
    form1.DiaryTime.focus();
    return false;
    }	

    showwait();					
}



</script>



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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="MyDiaryCY.aspx"  class="line_b">日志查阅</a> >> 查看日志查阅</td>
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
                                    <font class="shadow_but">日志查阅</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    日志时间：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                      <script>SetNeed('DiaryTime')</script>

                                    <asp:Label ID="DiaryTime" runat="server" Width="90%"></asp:Label></td>
                            </tr>

                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    日志类型：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="DiaryType" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                        
     
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                     日志内容：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
<%=ContractContentupdate %>

                                
                                </td>
                            </tr>
                       
                                                           <tr>
                            <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                width="15%">
                                职员领导：</td>
                            <td class="newtd2" height="17" colspan="3" width="85%">
                               
                                 <asp:Label ID="LdRealname" runat="server" Width="90%"></asp:Label>
                               </td>
                        </tr>
                          
                                                           <tr>
                            <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                width="15%">
                                上报人：</td>
                            <td class="newtd2" height="17" colspan="3" width="85%">
                               
                                 <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label>
                               </td>
                        </tr>
                             <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label></td>
                          
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


 <SCRIPT>




  
function Load_Do()
{
setTimeout("Load_Do()",0);
var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
document.getElementById("ContractContent").value=content;  
}


</SCRIPT>   
    
    </form>
</body>
</html>
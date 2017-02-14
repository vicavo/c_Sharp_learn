<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OftenModle_update.aspx.cs" Inherits="qpoa.MyAffairs.OftenModle_update" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('名称不能为空');
    form1.Name.focus();
    return false;
    }	

    if(document.getElementById('Sharing').value=='是')
    {
    
        if(document.getElementById('SharingRealname').value==''||document.getElementById('SharingRealname').value=='未共享')
        {
        alert('请选择共享人员');
        form1.SharingRealname.focus();
        return false;
        }	
    
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
<body onload="Load_Do();" class="newbody">
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="OftenModle.aspx"  class="line_b">常用模版设置</a> >> 修改常用模版</td>
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
                                    <font class="shadow_but">常用模版</font></button></td>
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
                                    模版名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>


                        
     
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                     模版内容：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
                   
<iframe name="EDIT_HTML" width="100%" height=260 src="../myeditor/updateeditor.htm" viewastext type="text/x-scriptlet"></iframe>


                                
                                </td>
                            </tr>
                       
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    是否共享：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="Sharing" runat="server" Width="95%">
                                        <asp:ListItem>否</asp:ListItem>
                                        <asp:ListItem>是</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                       
                       
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    共享人员：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="SharingRealname" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
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

<asp:TextBox ID="ContractContent" runat="server"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="SharingUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ContractContentupdate" runat="server"   style="DISPLAY: none"></asp:TextBox>
 <SCRIPT>
var  wName_1;  
function  openuser1()  
{  
if(document.getElementById('Sharing').value=='否')
{
alert('请选择共享模版');
form1.Sharing.focus();
return false;
}	

var num=Math.random();
var str=""+document.getElementById('SharingUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SharingUsername").value=arr[0]; 
document.getElementById("SharingRealname").value=arr[1]; 
}
}




  
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
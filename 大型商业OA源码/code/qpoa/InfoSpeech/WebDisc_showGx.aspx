<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebDisc_showGx.aspx.cs" Inherits="qpoa.MyAffairs.WebDisc_showGx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{

    if(document.getElementById('Sharing').value=='是')
    {
    
        if(document.getElementById('GxRealname').value==''||document.getElementById('GxRealname').value=='未共享')
        {
        alert('请选择共享人员');
        form1.GxRealname.focus();
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
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
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
                            width="100%">
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    文件夹名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="95%"></asp:Label></td>
                            </tr>


 
                       
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    是否共享：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="Sharing" runat="server" Width="50px">
                                        <asp:ListItem>否</asp:ListItem>
                                        <asp:ListItem>是</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="font-family: 宋体">共享操作将会共享文件夹下的所有子文件夹</span></td>
                            </tr>
                       
                       
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    共享人员：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="GxRealname" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>                       
                            
                            
                            
  
                                
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button2" class="button_blue" onclick="history.back()"
                                                type="button" value="返 回" /></FONT></div> </td>
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


<asp:TextBox ID="GxUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

 <SCRIPT>
var  wName_1;  
function  openuser1()  
{  
if(document.getElementById('Sharing').value=='否')
{
alert('请选择共享文件夹');
form1.Sharing.focus();
return false;
}	

var num=Math.random();
var str=""+document.getElementById('GxUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("GxUsername").value=arr[0]; 
document.getElementById("GxRealname").value=arr[1]; 
}
}




</SCRIPT>   
    
    </form>
</body>
</html>
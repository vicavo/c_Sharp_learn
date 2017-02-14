<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="username_show.aspx.cs" Inherits="qpoa.SystemManage.username_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
 <script>
function chknull()
{
    if(document.getElementById('Username').value=='')
    {
    alert('用户名不能为空');
    form1.Username.focus();
    return false;
    }	

    if(document.getElementById('worknum').value=='')
    {
    alert('工号不能为空');
    form1.worknum.focus();
    return false;
    }

    if(document.getElementById('Unit').value=='')
    {
    alert('部门名称不能为空');
    form1.Unit.focus();
    return false;
    }


    if(document.getElementById('Respon').value=='')
    {
    alert('角色名称不能为空');
    form1.Respon.focus();
    return false;
    }

    if(document.getElementById('Post').value=='')
    {
    alert('职位不能为空');
    form1.Post.focus();
    return false;
    }

    if(document.getElementById('Email').value!='')
    {
    var objRe = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if(!objRe.test(document.getElementById('Email').value))
    {
    alert('Email格式不正确');
    form1.Email.focus();
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
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top">
    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="username.aspx"  class="line_b">用户管理</a> >> 查看用户信息</td>
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
                                    <font class="shadow_but">用户信息</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                            <td align="right">
                                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/button_print.jpg" OnClick="ImageButton5_Click" />&nbsp;</td>
                        </tr>
                    </table>
                </td>
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
                                    真实姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="worknum" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    手机号：</td>
                               <td class="newtd2" colspan="3" height="17">
                                   <asp:Label ID="ShouJi" runat="server" Width="90%"></asp:Label></td>
                            </tr>   
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Unit" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Respon" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Post" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    在岗状态：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="StardType" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    Email：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:Label ID="Email" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    是否允许登陆：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:Label ID="Iflogin" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                    性别：</td>
                                <td class="newtd2" style="height: 17px" colspan="3">
                                    <asp:Label ID="Sex" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                       
                               
                          
  
                                   
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                                  </div>
								
							</td>
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

<asp:TextBox ID="UnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ResponId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="PostId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
    
<script language="javascript">	


var  wName_1;  
function  openunit()  
{  
var num=Math.random();
wName_1=window.showModalDialog("../OpenWindows/open_UnitName.aspx?tmp="+num+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("UnitId").value=arr[0]; 
document.getElementById("Unit").value=arr[1]; 
}
}



var  wName_2;  
function  openpost()  
{  
var num=Math.random();
wName_2=window.showModalDialog("../OpenWindows/open_PostName.aspx?tmp="+num+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("PostId").value=arr[0]; 
document.getElementById("Post").value=arr[1]; 
}
}



var  wName_3;  
function  openrespon()  
{  
var num=Math.random();
wName_3=window.showModalDialog("../OpenWindows/open_Respon.aspx?tmp="+num+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("ResponId").value=arr[0]; 
document.getElementById("Respon").value=arr[1]; 
}
}

</script>  
    
    </form>
</body>
</html>
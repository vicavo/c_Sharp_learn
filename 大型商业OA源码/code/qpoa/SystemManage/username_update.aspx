<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="username_update.aspx.cs" Inherits="qpoa.SystemManage.username_update" %>



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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="username.aspx"  class="line_b">用户管理</a> >> 修改用户信息</td>
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
          <td height="35">
           <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                    <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td>
                                <button class="btn4on" onclick="javascript:window.location='username_update.aspx?id=<%=requestid%>';showwait();"
                                    type="button">
                                    <font class="shadow_but">用户信息</font></button>
                                <button class="btn4off" onclick="javascript:window.location='username_updateps.aspx?id=<%=requestid%>';showwait();" type="button"><font class="shadow_but">密码修改</font></button>
                            </td>
                            <td align="right">
                                &nbsp;</td>
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
                                    真实姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Realname" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="worknum" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>
                           <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    手机号：</td>
                               <td class="newtd2" colspan="3" height="17">
                                    <asp:TextBox ID="ShouJi" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>    
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="Unit" runat="server" Width="80%"   title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openunit();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Respon" runat="server" Width="80%"   title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openrespon();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Post" runat="server" Width="80%"   title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openpost();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    在岗状态：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="StardType" runat="server" Width="90%">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    Email：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Email" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    是否允许登陆：</td>
                                <td class="newtd2" width="35%" style="height: 17px"><asp:DropDownList ID="Iflogin" runat="server" Width="90%">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                    性别：</td>
                                <td class="newtd2" style="height: 17px" colspan="3">
                                    <asp:DropDownList ID="Sex" runat="server" Width="90%">
                                        <asp:ListItem>男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Remark" runat="server" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
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
<asp:TextBox ID="QxString" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="KeyQx" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="UnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ResponId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="PostId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
    
<script language="javascript">	


var  wName_1;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('UnitId').value+"|"+document.getElementById('Unit').value+"|"+document.getElementById('QxString').value+"|"+document.getElementById('KeyQx').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_UnitName.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("UnitId").value=arr[0]; 
document.getElementById("Unit").value=arr[1]; 
document.getElementById("QxString").value=arr[2]; 
document.getElementById("KeyQx").value=arr[3]; 
}
}



var  wName_2;  
function  openpost()  
{  
var num=Math.random();
var str=""+document.getElementById('PostId').value+"|"+document.getElementById('Post').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_PostName.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
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
var str=""+document.getElementById('ResponId').value+"|"+document.getElementById('Respon').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Respon.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
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
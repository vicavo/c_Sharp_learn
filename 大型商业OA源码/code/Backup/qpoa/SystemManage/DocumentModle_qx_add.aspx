<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocumentModle_qx_add.aspx.cs" Inherits="qpoa.SystemManage.DocumentModle_qx_add" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>网络办公系统</title>
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
		<base target=_self />	
<script  language="javascript">			
var  getFromParent=window.dialogArguments;  
function CheckSelect()
{

var a=0
for(var i=0;i<document.Form1.elements.length;i++)
{
if(document.Form1.elements[i].checked==true)
	{a=a+1}

}

if(a>0)
{

}
else
{
alert('提交数据失败！未选中项');
return false;
}
	

for(var i=0;i<window.document.Form1.elements.length;i++)
{
var e = Form1.elements[i];
if (e.checked)
return e.value;
}
var retrunstr="";
return retrunstr;




}

function  sendFromChild()  
{       
window.returnValue=CheckSelect();  
window.close();  
} 

function  CCC()  
{       
window.returnValue="|";  
window.close();  
} 

window.onbeforeunload = function()  
{
var n = window.event.screenX - window.screenLeft;
var b = n > document.documentElement.scrollWidth-20;
if(b && window.event.clientY < 0 || window.event.altKey)
{
  

}


}      

function  closewin()  
{ 

window.close();  
     

}  
</script> 	
</HEAD>
	<body scroll="no" >
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"-->
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　请选择职位</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="0" style="width: 519px; height: 49px">
                    <tr>
                        <td  style="height: 31px; text-align: center;" >
                            <asp:TextBox ID="KeyBox" runat="server" Visible="False"></asp:TextBox>
                            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="按人员设置" />
                            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="按部门设置" />
                            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="按角色设置" />
                            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="按职位设置" /></td>
                    </tr>
                  
                    <tr>
                        <td  style="height: 31px; text-align: center;">
                            <table border="0" cellpadding="0" cellspacing="0" style="width: 393px; height: 302px">
                                <tr>
                                    <td align="center" style="width: 113px">
                                        <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                    <td align="center" style="width: 42px">
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                        <br />
                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                    </td>
                                    <td align="center" style="width: 100px">
                                        <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                </tr>
                            </table>
                            </td>
                    </tr>
                  
                      <tr>
                          <td  style="height: 31px; text-align: center; ">
                              <asp:Button ID="Button2" runat="server" CssClass="button_blue"
                                  Text="确　定" OnClick="Button2_Click" />
                              <INPUT  TYPE="button"  VALUE="关　闭"  onclick="closewin();" class="button_blue" id="Button3"></td>
                      </tr>                        
                    </table></td>
				</tr>
				<tr>
					<td height="22" background="../images/show_02.gif">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>
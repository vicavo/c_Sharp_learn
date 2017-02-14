<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoSend_add_people.aspx.cs" Inherits="qpoa.OpenWindows.InfoSend_add_people" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>网络办公系统</title>
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
		<base target=_self />	

<script  language="javascript">	
function checkbutton()
{
    for(var i=0;i<document.getElementById('TargetListBox').length;i++)
    { 

    document.getElementById("TextBox1").value=""+document.getElementById("TextBox1").value+""+document.getElementById('TargetListBox').options[i].value+",";
    document.getElementById("TextBox2").value=""+document.getElementById("TextBox2").value+""+document.getElementById('TargetListBox').options[i].text+",";

    } 

    if(document.getElementById("TextBox1").value=='')
    {
     alert('提交数据失败！未选中项');
     return false;
    }

}


		


function  closewin()  
{ 

window.close();  
     

}  
</script>




	
</HEAD>
	<body>
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"-->
            <asp:TextBox ID="TextBox1" runat="server"  style="DISPLAY: none"></asp:TextBox>
               <asp:TextBox ID="TextBox2" runat="server"  style="DISPLAY: none"></asp:TextBox>
            <asp:TextBox ID="requeststr" runat="server"  style="DISPLAY: none"></asp:TextBox>
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　请选择用户</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="0" style="width: 588px; height: 49px">
                    <tr>
                        <td  style="height: 31px; text-align: center;" >
                            <asp:TextBox ID="KeyBox" runat="server"  style="DISPLAY: none"></asp:TextBox>
                            <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="按人员设置" />
                            <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="按部门设置" />
                            <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="按角色设置" />
                            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="按职位设置" /></td>
                    </tr>
                  
                    <tr>
                        <td  style="height: 31px; text-align: center;">
                            <table border="0" cellpadding="0" cellspacing="0" style="height: 302px">
                                <tr>
                                           <td align="left" style="width: 113px" valign="top">
                                        <asp:ListBox ID="ListBox1" runat="server" Height="411px" Width="157px" AutoPostBack="True" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
                                               <asp:TreeView ID="ListTreeView" runat="server" OnSelectedNodeChanged="ListTreeView_SelectedNodeChanged"
                                                   ShowLines="True" Visible="False">
                                               </asp:TreeView>
                                           </td>
                                         <td align="center" style="width: 42px"></td>
                                    <td align="center" style="width: 113px" valign="top">
                                        <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                    <td align="center" style="width: 42px" valign="top">
                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                        <br />
                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                    </td>
                                    <td align="center" style="width: 100px" valign="top">
                                        <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                </tr>
                            </table>
                            </td>
                    </tr>
                  
                      <tr>
                          <td  style="height: 31px; text-align: center; ">
                              <asp:Button ID="Button11" runat="server" CssClass="button_blue" OnClick="Button11_Click"
                                  Text="确  定" />
                              &nbsp;
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
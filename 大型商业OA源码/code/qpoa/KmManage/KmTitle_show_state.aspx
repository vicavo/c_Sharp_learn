<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmTitle_show_state.aspx.cs" Inherits="qpoa.KmManage.KmTitle_show_state" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD runat="server">
		 <title>办公自动化</title>
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</HEAD>
	<body scroll="no" onload="onradiobutton()">
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"--> 
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体; height: 22px;">
                        请选择更改知识[<font color=red><%=ShowTitle%></font>]状态</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="4" width="400" >
                    <tr>
                        <td colspan="2" style="height: 14px">
                            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="100%" Visible=false>
                                <div align=center>当前状态为[<font color=red><%=State %></font>]，还没有通过审批，是否决定送审</div>
                               <br>
                                <div align=center><asp:Button ID="Button1" runat="server" Text="送审" OnClick="Button1_Click" />
                                <input id="Button2" type="button" value="关闭" onclick="window.close()"/></div>
                            </asp:Panel>
                            
                            <asp:Panel ID="Panel2" runat="server" Height="50px" Width="100%" Visible=false>
                                <div align=center>当前状态为[<font color=red><%=State %></font>]，请等待知识管理员审批</div>
                               <br>
                                <div align=center>
                                <input id="Button4" type="button" value="关闭" onclick="window.close()"/></div>
                            </asp:Panel>            
                            
                            <asp:Panel ID="Panel3" runat="server" Height="50px" Width="100%" Visible=false>
                                <div align=center>当前状态为[<font color=red><%=State %></font>]，是否重新开启</div>
                               <br>
                                <div align=center><asp:Button ID="Button3" runat="server" Text="开启" OnClick="Button3_Click" />
                                <input id="Button5" type="button" value="关闭" onclick="window.close()"/></div>
                            </asp:Panel>                
                            
                            <asp:Panel ID="Panel4" runat="server" Height="50px" Width="100%" Visible=false>
                                <div align=center>当前状态为[<font color=red><%=State %></font>]，是否重新送审</div>
                               <br>
                                <div align=center><asp:Button ID="Button6" runat="server" Text="送审" OnClick="Button6_Click"/>
                                <input id="Button7" type="button" value="关闭" onclick="window.close()"/></div>
                            </asp:Panel>      
                            
                             <asp:Panel ID="Panel5" runat="server" Height="50px" Width="100%" Visible=false>
                                <div align=center>当前状态为[<font color=red><%=State %></font>]，是否终止</div>
                               <br>
                                <div align=center><asp:Button ID="Button8" runat="server" Text="终止" OnClick="Button8_Click" />
                                <input id="Button9" type="button" value="关闭" onclick="window.close()"/></div>
                            </asp:Panel>        
                            
                            
                            
                        </td>
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
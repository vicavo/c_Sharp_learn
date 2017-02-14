<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MettingApply_sp_ct.aspx.cs" Inherits="qpoa.PublicAffairs.MettingApply_sp_ct" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>网络办公系统</title>
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
		<base target=_self />	

</HEAD>
	<body scroll="no" >
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"-->
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　会议冲突</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
                    &nbsp;<table  border="0" cellspacing="0" cellpadding="0" style="width: 727px; height: 49px">
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: center;">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None"
                              
                                PageSize="12" Style="font-size: 12px" Width="97%" OnRowDataBound="GridView1_RowDataBound">
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="会议名称">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Title" HeaderText="主题">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MettingName" HeaderText="会议室">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Starttime" HeaderText="开始时间">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Endtime" HeaderText="结束时间">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Realname" HeaderText="申请人">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <font color="white">无相关数据！</font></div>
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                <AlternatingRowStyle BackColor="#E6EDF7" />
                            </asp:GridView>
                            &nbsp;</td>
                    </tr>
                    </table>
                    </td>
				</tr>
				<tr>
					<td background="../images/show_02.gif" style="height: 19px">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>
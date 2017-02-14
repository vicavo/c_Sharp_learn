<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenNotice_show.aspx.cs" Inherits="qpoa.SystemManage.OpenNotice_show" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>弹出公告</title>
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
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"></td>
				</tr>
				<tr>
			    <td valign="top">
                   <%=d_content %></td>
				</tr>
				<tr>
					<td height="22" background="../images/show_02.gif">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>
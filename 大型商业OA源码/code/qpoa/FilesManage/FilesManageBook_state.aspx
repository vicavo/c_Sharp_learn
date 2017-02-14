<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilesManageBook_state.aspx.cs" Inherits="qpoa.FilesManage.FilesManageBook_state" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
<HEAD id="HEAD1" runat="server">
		 <title>网络办公系统</title>
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
                        当前借阅人</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="4" width="400" >
                    <tr>
                        <td colspan="2" style="height: 14px">
                            &nbsp; &nbsp;
                            
                            
                                <div align=center>
                                    <strong>当前借阅人</strong></div>
                               <br>
                                <div align=center><%=JrUsername %>
                               </div>
                          
                            
                            
                            
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
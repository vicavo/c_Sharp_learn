<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProManageLL_show.aspx.cs"
    Inherits="qpoa.ProManage.ProManageLL_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <!--#include file="../public/pleasewait.htm"-->
        <!--#include file="../public/public.js"-->

        <script language="javascript" src="../public/DateSelect.js"></script>

        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
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
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="../images/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="../main_d.aspx" class="line_b">工作台</a> >> <a href="ProManageLL.aspx" class="line_b">
                                                                项目浏览</a> >> 查看项目浏览</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
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
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off6k" type="button">
                                                                <font class="shadow_but">项目浏览</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="Button1" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Name" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目编号：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ConName" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目状态：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="States" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目类别：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Types" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        评审级别：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Jibie" runat="server" Width="90%"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目描述：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="Conetent" runat="server" Width="90%"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目负责人：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="FzRealname" runat="server" Width="90%"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目参与人：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="CyRealname" runat="server" Width="90%"></asp:Label></td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label></td>
                                                </tr>
                                                <tr id="Tr1">
                                                    <td  class="newtd2" colspan="4" height="26" width="33%">
                                                      
                                                            <hr style="height: 1px; color: #003333;">
                                                            &nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageGG.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目公告</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageJD.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目进度</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageZY.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目资源</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageYS.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目预算</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageRW.aspx?XmName=<%=Request.QueryString["XmName"] %>">任务计划</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageWB.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目外包</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageLR.aspx?XmName=<%=Request.QueryString["XmName"] %>">项目利润</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageFY.aspx?XmName=<%=Request.QueryString["XmName"] %>">费用报销</a>&nbsp;&nbsp;
                                                            <img src="/images/menu/hrms.gif" /><a target="RMid" href="ProManageFYGL.aspx?XmName=<%=Request.QueryString["XmName"] %>">报销管理</a>&nbsp;&nbsp;
                                                            <hr style="height: 1px; color: #003333;">
                                                            <iframe name="RMid" frameborder="0" marginheight="0" marginwidth="0" width="100%"
                                                                height="500" bordercolor="#ffffFF" src="ProManageGG.aspx?XmName=<%=Request.QueryString["XmName"] %>"
                                                                border="0"></iframe>
                                                    
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="FzUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="CyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>

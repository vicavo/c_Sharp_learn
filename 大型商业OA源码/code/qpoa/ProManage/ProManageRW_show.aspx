﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProManageRW_show.aspx.cs"
    Inherits="qpoa.ProManage.ProManageRW_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
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
                            </td>
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
                                                            <a href="../main_d.aspx" class="line_b">工作台</a> >> <a href="ProManageRW.aspx?XmName="
                                                                class="line_b">任务计划</a> >> 查看任务计划</td>
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
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">任务计划</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
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
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        所属项目：</td>
                                                    <td class="newtd2" colspan="3" height="24">
                                                        <asp:Label ID="XmName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务类别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Leibie" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        任务主题：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="Zhuti" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务内容：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="Contents" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        参与人：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="CyRealname" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button6" type="button" value="返 回" onclick="history.go(-1)" class="button_blue" />
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
        <asp:TextBox ID="CyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>

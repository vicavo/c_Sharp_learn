<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_copy.aspx.cs"
    Inherits="qpoa.WorkFlow.WorkFlowName_show_copy" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function  aaa()  
{
    if(document.getElementById('FlowNumber').value=='请选择')
    {
        alert('请选择流程');
        return false;
    }
    else
    {
        var num=Math.random();
        var littleproduct=document.getElementById("FlowNumber");
        var cindex = littleproduct.selectedIndex;
        var cValue = littleproduct.options[cindex].value;
        window.open ("WorkFlowName_show_add_node.aspx?tmp="+num+"&FlowNumber="+cValue+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")             
    }
}			


</script>

<head id="Head1" runat="server">
    <title>续易网络办公系统</title>
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
                                <div id="printshow2">
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top" style="width: 918px">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                style="width: 86%">
                                                <tr>
                                                    <td class="newtd2" height="17" width="85%" align="center">
                                                        选择工作流：<asp:DropDownList ID="FlowNumber" runat="server" Width="227px">
                                                        </asp:DropDownList>［<a href="javascript:void(0)" onclick="aaa()">查看流程</a>］</td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_blue" OnClick="Button1_Click"
                                                                    Text="确 定" />
                                                                <input id="Button3" class="button_blue" type="button" value="关 闭" onclick="window.close()" />
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
        <asp:TextBox ID="openusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>

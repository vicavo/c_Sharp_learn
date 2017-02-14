<%@ Page Language="C#" AutoEventWireup="true" Codebehind="user_online.aspx.cs" Inherits="qpoa.user_online" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
    <title>在线人员</title>
    <meta http-equiv="refresh" content="30"> 
</head>
<body>
    <form id="form1" runat="server">
        <table width="180" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="180" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                                    ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
                                </asp:TreeView>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="qpoa._Default" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网络办公系统</title>
    <link href="css/public.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div align="center">
            <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" valign="middle">
                        <table width="100%" height="301" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td background="images/de2a.jpg">
                                    <table width="100%" height="301" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="500" background="images/de2b.jpg">
                                                &nbsp;</td>
                                            <td width="400" valign="top">
                                                <table width="100%" height="97" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td background="images/de21.jpg">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="113" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top" background="images/de22.jpg">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="371">
                                                                <tr>
                                                                    <td height="55">
                                                                        <table border="0" cellpadding="0" cellspacing="0" height="55" width="351">
                                                                            <tr>
                                                                                <td width="104">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td width="199" align="center">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="43%">
                                                                                                <font color="#0000FF">用户名：</font></td>
                                                                                            <td width="57%">
                                                                                                <asp:TextBox ID="Username" runat="server" onfocus="this.select()" onmouseover="this.focus()"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="5" colspan="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <font color="#0000FF">密 &nbsp; 码：</font></td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="Password" runat="server" onfocus="this.select()" onmouseover="this.focus()"
                                                                                                    TextMode="Password"></asp:TextBox></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/btdl.gif" OnClick="ImageButton1_Click" /></td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="91" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td background="images/de23.jpg">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

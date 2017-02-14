<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_yz.aspx.cs"
    Inherits="qpoa.WorkFlow.WorkFlowName_show_add_yz" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function  adddatefile()  
{  
  var num=Math.random();
  window.showModalDialog("WorkFlowName_show_add_yz_add.aspx?tmp="+num+"&FlowNumber=<%=Request.QueryString["FlowNumber"]%>","window", "dialogWidth:460px;DialogHeight=280px;status:no;scroll=yes;help:no"); 	
}	
</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />
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
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:Button ID="Button1" runat="server" Text="增 加" />
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#4D77B1"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                            GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                            PageSize="12" Style="font-size: 12px" Width="100%">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Name" HeaderText="印章域" SortExpression="Name">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="SyRealname" HeaderText="允许使用人" SortExpression="SyRealname">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" ForeColor="white" Width="120px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="XiuGai">修改</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" Wrap="False" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#E6EDF7" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button3" class="button_blue" onclick="javascript:window.close()" type="button"
                                                                    value="关 闭" /></font>&nbsp;</div>
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
        <asp:TextBox ID="FormId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>

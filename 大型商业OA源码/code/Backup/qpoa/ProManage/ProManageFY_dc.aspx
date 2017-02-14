<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProManageFY_dc.aspx.cs" Inherits="qpoa.ProManage.ProManageFY_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView Style="font-size: 12px" ID="GridView1" runat="server" Width="100%"
                PageSize="12" CellSpacing="2" CellPadding="4" BorderWidth="1px" BorderStyle="Solid"
                BorderColor="#999999" BackColor="#CCCCCC" AutoGenerateColumns="False" AllowSorting="True"
                ForeColor="Black" OnRowDataBound="GridView1_RowDataBound">
                <PagerSettings Visible="False" />
                <FooterStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:BoundField DataField="XmName" HeaderText="项目名称">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Leibie" HeaderText="报销类别">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Zhuti" HeaderText="报销类别">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Neirong" HeaderText="报销内容">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SpRealname" HeaderText="审批人">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Jieguo" HeaderText="审批结果">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                </Columns>
                <RowStyle BackColor="White" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Wrap="False" />
                <EmptyDataTemplate>
                    <div align="center">
                        <font color="white">无相关数据！</font></div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
    </form>
</body>
</html>

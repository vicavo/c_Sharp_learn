<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProManageJD_dc.aspx.cs" Inherits="qpoa.ProManage.ProManageJD_dc" %>

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
                    <asp:BoundField DataField="Jieduan" HeaderText="项目阶段">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Wanchenglv" HeaderText="项目完成率">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NowTimes" HeaderText="创建时间">
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
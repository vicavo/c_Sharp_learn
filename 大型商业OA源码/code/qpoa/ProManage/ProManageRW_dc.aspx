<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ProManageRW_dc.aspx.cs"
    Inherits="qpoa.ProManage.ProManageRW_dc" %>

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
                    <asp:BoundField DataField="Leibie" HeaderText="任务类别">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Zhuti" HeaderText="任务主题">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Contents" HeaderText="任务内容">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Starttime" HeaderText="开始时间">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Endtime" HeaderText="结束时间">
                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CyRealname" HeaderText="参与人用户名">
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

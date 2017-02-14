<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SeadChatAlDc.aspx.cs" Inherits="qpoa.InfoSpeech.SeadChatAlDc"
    ValidateRequest="false" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView Style="font-size: 12px" ID="GridView1" runat="server" Width="100%"
                PageSize="12" CellSpacing="2" CellPadding="4" BorderWidth="1px" BorderStyle="Solid"
                BorderColor="#999999" BackColor="#CCCCCC" AutoGenerateColumns="False" ForeColor="Black">
                <PagerSettings Visible="False" />
                <FooterStyle BackColor="#CCCCCC" />
                <Columns>
                    <asp:TemplateField HeaderText="对话" SortExpression="title">
                        <ItemStyle Wrap="True" />
                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center"
                            Wrap="False" />
                        <ItemTemplate>
                            <%# DataBinder.Eval(Container.DataItem, "seadname")%>
                            对<%# DataBinder.Eval(Container.DataItem, "atpname")%>说：<%# DataBinder.Eval(Container.DataItem, "content")%>(<%# DataBinder.Eval(Container.DataItem, "setime")%>)
                        </ItemTemplate>
                        <FooterStyle Wrap="True" />
                    </asp:TemplateField>
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

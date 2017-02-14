<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLxr_dc.aspx.cs" Inherits="qpoa.SaleManage.CustomerLxr_dc" %>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<asp:GridView style="FONT-SIZE: 12px" id="GridView1" runat="server" Width="100%" PageSize="12" CellSpacing="2" CellPadding="4" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" BackColor="#CCCCCC" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" ForeColor="Black">
                                <PagerSettings Visible="False"  />
                                <FooterStyle BackColor="#CCCCCC"  />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="所属供应商名">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="KhRealname" HeaderText="联系人姓名">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LxrPost" HeaderText="联系人职位">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Sex" HeaderText="性别">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="BothDay" HeaderText="生日">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Lovly" HeaderText="爱好">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JtZipCode" HeaderText="家庭邮编">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JtAddress" HeaderText="家庭地址">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GzTel" HeaderText="工作电话">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="JtTel" HeaderText="家庭电话">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MoveTel" HeaderText="手机">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="QqNumber" HeaderText="QQ号">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="MsnNumber" HeaderText="Msn号">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remark" HeaderText="备注">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Realname" HeaderText="录入人">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Unit" HeaderText="所属部门">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="GroupName" HeaderText="所属销售组">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="用户自定义字段">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                        <ItemTemplate>
                                         <asp:Label ID="Lnumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Number")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="White"  />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"  />
                                <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left"  />
                                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Wrap="False"  />
                                     <EmptyDataTemplate>
                                    <div align=center><font color=white>无相关数据！</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>
    </div>
    </form>
</body>
</html>

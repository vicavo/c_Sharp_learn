<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleContract_dc.aspx.cs" Inherits="qpoa.SaleManage.SaleContract_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
                                    <asp:BoundField DataField="Name" HeaderText="客户名称">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractName" HeaderText="合同名称">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractNum" HeaderText="合同编号">
                                        <ItemStyle HorizontalAlign="Center"  />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractType" HeaderText="合同类型">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractMoney" HeaderText="合同金额">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="合同描述">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractTerms" HeaderText="合同条款">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                                       <asp:TemplateField HeaderText="合同内容">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                        <ItemTemplate>
                                         <%#DataBinder.Eval(Container.DataItem, "ContractContent")%>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Startime" HeaderText="生效日期" DataFormatString="{0:d}" HtmlEncode="False">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Endtime" HeaderText="终止日期" DataFormatString="{0:d}" HtmlEncode="False">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                         <asp:BoundField DataField="ContractorA" HeaderText="签约人(甲方)">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractorB" HeaderText="签约人(乙方)">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CreateDate" HeaderText="创建日期" DataFormatString="{0:d}" HtmlEncode="False">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Remark" HeaderText="备注">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
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
                                    
                                 <asp:TemplateField HeaderText="附件信息">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                        <ItemTemplate>
                                         <asp:Label ID="Fjumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Number")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    
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

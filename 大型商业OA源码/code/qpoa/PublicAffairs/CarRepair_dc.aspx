<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarRepair_dc.aspx.cs" Inherits="qpoa.CarRepair_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView style="FONT-SIZE: 12px" id="GridView1" runat="server" Width="100%" PageSize="12" CellSpacing="2" CellPadding="4" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" BackColor="#CCCCCC" AutoGenerateColumns="False" AllowSorting="True" ForeColor="Black">
                                <PagerSettings Visible="False"  />
                                <FooterStyle BackColor="#CCCCCC"  />
                                <Columns>
                                    <asp:BoundField DataField="CarNum" HeaderText="车牌号">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RepairTime" HeaderText="维护日期" DataFormatString="{0:d}" HtmlEncode="False" >
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="RepairType" HeaderText="维护类型">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Reasons" HeaderText="维护原因">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="People" HeaderText="经办人">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="RepairMoney" HeaderText="维护费用">
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

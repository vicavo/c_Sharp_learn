<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarInfo_dc.aspx.cs" Inherits="qpoa.PublicAffairs.CarInfo_dc" %>

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
                                  
                                    <asp:BoundField DataField="CarModel" HeaderText="厂牌型号">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CarType" HeaderText="车辆类型">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Driver" HeaderText="驾驶员">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="CarPrice" HeaderText="购买价格">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>    
                                    <asp:BoundField DataField="CarTime" HeaderText="购置日期">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="EngineNum" HeaderText="发动机号码">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status" HeaderText="当前状态">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                                              
                                    
                                      <asp:BoundField DataField="Remark" HeaderText="备注">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>                                     
                                    
                                    
                                    
                                    
                                    <asp:BoundField DataField="Realname" HeaderText="录入人">
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

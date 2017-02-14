<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyWorkPlan_bm_dc.aspx.cs" Inherits="qpoa.PublicAffairs.MyWorkPlan_bm_dc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView style="FONT-SIZE: 12px" id="GridView1" runat="server" Width="100%" PageSize="12" CellSpacing="2" CellPadding="4" BorderWidth="1px" BorderStyle="Solid" BorderColor="#999999" BackColor="#CCCCCC" AutoGenerateColumns="False" AllowSorting="True" ForeColor="Black" OnRowDataBound="GridView1_RowDataBound">
                                <PagerSettings Visible="False"  />
                                <FooterStyle BackColor="#CCCCCC"  />
                                <Columns>
                                    <asp:BoundField DataField="Name" HeaderText="计划名称">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Content" HeaderText="计划内容">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PlanCycle" HeaderText="计划周期">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PlanType" HeaderText="计划类型">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                     <asp:BoundField DataField="Startime" HeaderText="有效期(开始)">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="Endtime" HeaderText="有效期(结束)">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>    
                                     <asp:BoundField DataField="SendUnit" HeaderText="参与部门 ">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="SendRealname" HeaderText="参与人员">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                       <asp:BoundField DataField="Header" HeaderText="负责人">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False"  />
                                    </asp:BoundField>
                                      <asp:TemplateField HeaderText="附件信息">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                        <ItemTemplate>
                                         <asp:Label ID="Fjumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Number")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:BoundField DataField="FjRemark" HeaderText="附件说明">
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

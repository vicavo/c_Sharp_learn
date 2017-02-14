<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyQx.aspx.cs" Inherits="qpoa.Desk.MyQx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
   
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                     <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 我的权限</td>
                      <td width="16%">&nbsp;</td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                    <tr> 
                      <td></td>
                    </tr>
                  </table></td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
            </div></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17" style="height: 40px">&nbsp;</td>
                <td valign="top" style="height: 40px"> 
                   <div id="printshow2"> 
                   <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 26px; width: 11%;">
                                <button class="btn4off" 
                                    type="button" 
                                    <font class="shadow_but">我的权限</font></button>
                            </td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
              </tr>
            </table>
            
            <a href="javascript:void(0)" onclick="checkAll()" class="line"></a>
            
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                      <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 我的权限</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    用户名：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
              
                          
                        </table>
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="模块名称">
                                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Width="120px" />
                                        <ItemTemplate>
                                           <%# DataBinder.Eval(Container.DataItem, "name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="操作权限">
                                        <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="quanbu" runat="server" Text="全部" Enabled=false/>
                                             <asp:Label ID="quanbuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "quanbu") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                            <asp:CheckBox ID="xinzeng" runat="server" Text="新增"  Enabled=false/>
                                             <asp:Label ID="xinzengid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "xinzeng") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                             <asp:CheckBox ID="chakan" runat="server" Text="查看"  Enabled=false/>
                                             <asp:Label ID="chakanid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "chakan") %>'
                                                Visible="False" Width="0px"></asp:Label> 
                                              <asp:CheckBox ID="xiguai" runat="server" Text="修改"  Enabled=false/>
                                             <asp:Label ID="xiguaiid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "xiguai") %>'
                                                Visible="False" Width="0px"></asp:Label>  
                                               <asp:CheckBox ID="shanchu" runat="server" Text="删除"  Enabled=false/>
                                             <asp:Label ID="shanchuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shanchu") %>'
                                                Visible="False" Width="0px"></asp:Label>  
                                                 <asp:CheckBox ID="daochu" runat="server" Text="导出"  Enabled=false/>
                                             <asp:Label ID="daochuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "daochu") %>'
                                                Visible="False" Width="0px"></asp:Label>  
                                                    <asp:CheckBox ID="shenpi" runat="server" Text="审批"  Enabled=false/>
                                             <asp:Label ID="shenpiid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shenpi") %>'
                                                Visible="False" Width="0px"></asp:Label>  
                                                         <asp:CheckBox ID="shouquan" runat="server" Text="授权"  Enabled=false/>
                                             <asp:Label ID="shouquanid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "shouquan") %>'
                                                Visible="False" Width="0px"></asp:Label>  
                                               <asp:CheckBox ID="chaxun" runat="server" Text="查询"  Enabled=false/>
                                             <asp:Label ID="chaxunid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "chaxun") %>'
                                                Visible="False" Width="0px"></asp:Label> 
                                               
                                                  
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    
                                     <asp:TemplateField HeaderText="查看权限">
                                        <ItemStyle HorizontalAlign="Left" Wrap="True" Width="230px" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                             <asp:RadioButton ID="xiaoshou" runat="server" GroupName="1" Text="销售组"  Enabled=false/>
                                               <asp:Label ID="xiaoshouid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "xiaoshou") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                                
                                                        <asp:RadioButton ID="gongsi" runat="server" GroupName="1" Text="公司"  Enabled=false/>
                                               <asp:Label ID="gongsiid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "gongsi") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                                
                                                 

                                            <asp:RadioButton ID="bumen" runat="server" GroupName="1" Text="部门"  Enabled=false/>
                                             <asp:Label ID="bumenid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "bumen") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                                
                                    
                                                            <asp:RadioButton ID="geren" runat="server" GroupName="1" Text="个人"  Enabled=false/>
                                                <asp:Label ID="gerenid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "geren") %>'
                                                Visible="False" Width="0px"></asp:Label>
                                                  
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    
                           
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                <AlternatingRowStyle BackColor="#E6EDF7" />
                                     <EmptyDataTemplate>
                                    <div align=center><font color=white>无相关数据！</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            &nbsp;</div>
                            </td>
							</tr>
						</table>
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
            
              <div id="printshow3">
              <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                      <td width="17" >
                          &nbsp;</td>
                      <td valign="top" background="../images/next_bg.jpg">
                     
                          <table border="0" cellpadding="0" cellspacing="0" width=100%>
                              <tr>
                                  
                                  <td style="height: 19px" >
                                  <div align=center>
                                      <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返 回" />&nbsp;</div>
                                          
                                 </td>
                              </tr>
                          </table>
                          </td>
                      <td width="17">
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
	<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    </form>
</body>
</html>

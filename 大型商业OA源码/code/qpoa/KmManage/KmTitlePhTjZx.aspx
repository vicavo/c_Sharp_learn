<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmTitlePhTjZx.aspx.cs" Inherits="qpoa.KmManage.KmTitlePhTjZx" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
        <script>
function showfrom(str)
{
var num=Math.random();
window.open ("KmShow.aspx?tmp="+num+"&id="+str+"", "_blank", "height=700, width=900,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=80,left=60")
}
        
        </script> 
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->

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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 知识排行(显示前２０条数据)</td>
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
                   <div id="printshow2"> <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 26px; width: 11%;">
                               
                               <button class="btn4off" onclick="javascript:window.location='KmTitlePh.aspx';showwait();" type="button"><font class="shadow_but">用户点击</font></button>
                               <button class="btn4off" onclick="javascript:window.location='KmTitlePhTj.aspx';showwait();" type="button"><font class="shadow_but">用户推荐</font></button>
                              <button class="btn4off" onclick="javascript:window.location='KmTitlePhTjDy.aspx';showwait();" type="button"><font class="shadow_but">用户订阅</font></button>
                              <button class="btn4off" onclick="javascript:window.location='KmTitlePhTjSc.aspx';showwait();" type="button"><font class="shadow_but">用户收藏</font></button>
                              <button class="btn4on" onclick="javascript:window.location='KmTitlePhTjZx.aspx';showwait();" type="button"><font class="shadow_but">最新知识</font></button>
                             <button class="btn4off" onclick="javascript:window.location='KmTitlePhTjQl.aspx';showwait();" type="button"><font class="shadow_but">强力推荐</font></button>
                            </td>
                              <td style="height: 26px" align="right" > 
                                  </td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
              </tr>
            </table><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" >
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                 PageSize="12" Style="font-size: 12px" Width="100%" OnRowCommand="GridView1_RowCommand" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                              
                                   <asp:TemplateField HeaderText="排序号">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="40px"/>
                                        <ItemTemplate>
                                             <%# (Container.DataItemIndex+1).ToString()%>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="40px"/>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Title" HeaderText="知识名称" SortExpression="Title">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    
                                   <asp:BoundField DataField="Realname" HeaderText="作者" SortExpression="Realname">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>     
                                
                                    <asp:BoundField DataField="LastTime" HeaderText="最后更新时间" SortExpression="LastTime">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>                        
                                
                                    <asp:TemplateField HeaderText="相关操作">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="120px"/>
                                        <ItemTemplate>
                                          <a href="javascript:void(0)" onclick="showfrom(<%# DataBinder.Eval(Container.DataItem, "id") %>);">查看</a>
                                            <asp:Label ID="HyId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                            <asp:LinkButton ID="TuiJian" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CommandName="TuiJian">推荐</asp:LinkButton>
                                            <asp:LinkButton ID="DingYue" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CommandName="DingYue">订阅</asp:LinkButton>
                                            <asp:LinkButton ID="ShouCang" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>' CommandName="ShouCang">收藏</asp:LinkButton>
                                        </ItemTemplate>
                                        
                                        
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="120px"/>
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
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>

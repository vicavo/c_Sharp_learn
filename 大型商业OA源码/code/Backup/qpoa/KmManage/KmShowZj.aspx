<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmShowZj.aspx.cs" Inherits="qpoa.KmManage.KmShowZj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>



function showfrom(str)
{
var num=Math.random();
window.open ("KmShowZjShow.aspx?tmp="+num+"&id="+str+"&Number=<%=Request.QueryString["Number"] %>", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=60,left=130")
}


</script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->
<table width="100%"  border="0" cellpadding="0" cellspacing="0" height="350">
  <tr>
    <td valign="top">
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17" >
                        &nbsp;</td>
                    <td valign="top" >
                    	<table  cellSpacing="0" cellPadding="5" width="100%" border="0">
                          
                             <tr>
                                <td  valign="top">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                        <tr>
                                         
                                            <td align=right>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">返回知识</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">推荐知识</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">订阅知识</asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">收藏知识</asp:LinkButton>
                                            </td>
                                            <td style="width: 50px">
                                            </td>
                                        </tr>
                                    </table>
                                    </td>
                            </tr>
                          
                            <tr>
                                <td align="center" valign="top"><strong><font size="2"><%=Namefile%></font></strong> </td>
                            </tr>
                            
                            
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                 PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                     <asp:TemplateField HeaderText="序号">
                                        <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center" Wrap="False" />
                                        <ItemTemplate>
                                              <%# (Container.DataItemIndex+1).ToString()%>
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="章节标题" SortExpression="Name">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                           <%# DataBinder.Eval(Container.DataItem, "Name") %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>  
                                     
                                    <asp:TemplateField HeaderText="录入时间" SortExpression="Settime">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container.DataItem, "Settime") %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="相关操作">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="120px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="WFNId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                            <asp:Label ID="LNumber" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Number")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                          
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
                            &nbsp;&nbsp;</div>
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

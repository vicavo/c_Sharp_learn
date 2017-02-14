<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsideBBS.aspx.cs" Inherits="qpoa.InfoSpeech.InsideBBS" %>

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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 讨论区</td>
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
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                 PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                 <asp:TemplateField HeaderText="讨论区" SortExpression="Name">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                        <a href=InsideBBSList.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>><%# DataBinder.Eval(Container.DataItem, "Name") %></a>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField> 
                                   
                                    <asp:TemplateField HeaderText="主题">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="50px"/>
                                        <ItemTemplate>
                                        <asp:Label ID="Lid1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="50px"/>
                                    </asp:TemplateField>       
                                   
                                      <asp:TemplateField HeaderText="帖数">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="50px"/>
                                        <ItemTemplate>
                                        <asp:Label ID="Lid2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label2" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="50px"/>
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
	<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    </form>
</body>
</html>

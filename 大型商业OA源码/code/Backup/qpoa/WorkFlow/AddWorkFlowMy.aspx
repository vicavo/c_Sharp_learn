<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlowMy.aspx.cs" Inherits="qpoa.WorkFlow.AddWorkFlowMy" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>
function chkyema()
{
    if(document.getElementById('GoPage').value=='')
    {
    alert('页码不能为空');
    form1.GoPage.focus();
    return false;
    }	
   
    if(document.getElementById('GoPage').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('GoPage').value))
    {
    alert('页码只能为数字');
    form1.GoPage.focus();
    return false;
    }
    }
   
    
    showwait();	
}  

function qingkong()
{
   document.getElementById('Sequence').value='';
   document.getElementById('FqRealname').value='';
   document.getElementById('Name').value='';
   document.getElementById('StartTime').value='';
   document.getElementById('EndTime').value='';
   
   document.getElementById('FormName').value='0';
   document.getElementById('State').value='所有类型';
   
}  



</script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->
 <script language="javascript" src="../public/DateSelect.js"></script>
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >>  工作管理  >>  <a href=AddWorkFlowMy.aspx>我的新建</a></td>
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
                            <button class="btn4off" type="button" onclick="javascript:window.location='AddWorkFlow.aspx';showwait();"><font class="shadow_but">工作管理</font></button>
                            <button class="btn4on" type="button" onclick="javascript:window.location='AddWorkFlowMy.aspx';showwait();"><font class="shadow_but">我的新建</font></button>
                              
                            </td>
                            <td style="width: 739px; height: 26px">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="height: 22px" ></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px">
                                        </td>
                                    </tr>
                                </table>
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
						 <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1" width="100%" id="tableprint">
                            <tr>
                              <td class="newtd2"  >
                                  流水号<asp:TextBox ID="Sequence" runat="server" Width="63px"></asp:TextBox>
                                  表单类型<asp:DropDownList ID="FormName" runat="server" Width="193px">
                                  </asp:DropDownList>
                                  状态<asp:DropDownList ID="State" runat="server" Width="120px">
                                      <asp:ListItem>所有类型</asp:ListItem>
                                      <asp:ListItem>等待办理</asp:ListItem>
                                      <asp:ListItem>正在办理</asp:ListItem>
                                      <asp:ListItem>正常结束</asp:ListItem>
                                      <asp:ListItem>强制结束</asp:ListItem>
                                      <asp:ListItem>驳回审批</asp:ListItem>
                                  </asp:DropDownList>
                                  发起人<asp:TextBox ID="FqRealname" runat="server" Width="79px"></asp:TextBox></td>
                            </tr>
                             <tr>
                                 <td class="newtd2" >
                                     名称<asp:TextBox ID="Name" runat="server" Width="170px"></asp:TextBox>
                                     时间<asp:TextBox id="StartTime" runat="server" Width="107px"></asp:TextBox>
															<script>SetNeed('StartTime')</script>
															<A href="javascript:void(0)"><IMG id="StartTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"src="../images/FDJ.gif" border="0"></A> 至<asp:TextBox id="EndTime" runat="server" Width="97px"></asp:TextBox>
															<script>SetNeed('EndTime')</script>
															<A href="javascript:void(0)"><IMG id="EndTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"src="../images/FDJ.gif" border="0"></A>
                                     <asp:Button ID="Button2" runat="server" Text="开始查询" OnClick="Button2_Click1" />
                                     <input id="Button3" type="button" value="清空" onclick="qingkong()"/></td>
                             </tr>
                        </table>
                        <br>
                        <div id="Div1">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:BoundField DataField="Sequence" HeaderText="流水号" SortExpression="Sequence">
                                        <ItemStyle Wrap="False" Width="50px" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" />
                                         <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    
                                    <asp:TemplateField HeaderText="表单类型" SortExpression="FormName">
                                          <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                          <a href='javascript:void(0)' onclick='window.open ("DIYForm_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "FormId") %>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'><%# DataBinder.Eval(Container.DataItem, "FormName") %></a>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>   
                                    
                                     <asp:TemplateField HeaderText="工作名称/文号" SortExpression="Name">
                                          <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                          <a href='javascript:void(0)' onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%# DataBinder.Eval(Container.DataItem, "FlowNumber") %>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'><%# DataBinder.Eval(Container.DataItem, "Name") %></a>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>                                   
                                    
                                    
                                    
                                   <asp:BoundField DataField="FqRealname" HeaderText="发起人" SortExpression="FqRealname">
                                        <ItemStyle Wrap="False" />
                                           <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>                                 
                                       <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle  CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>                                              
                                               
                                               
                                               
                                    <asp:TemplateField HeaderText="步骤与流程图" SortExpression="NodeName">
                                          <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                          <a href='javascript:void(0)' onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%# DataBinder.Eval(Container.DataItem, "FlowNumber") %>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'><%# DataBinder.Eval(Container.DataItem, "UpNodeName") %></a>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>   
                                     
                                     
                                            
                                      <asp:TemplateField HeaderText="流程操作">
                                        <HeaderStyle  CssClass="newtitle" ForeColor="white" Wrap="False" Width="200px"/>
                                        <ItemTemplate>
                                        <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Label1" runat="server" ></asp:Label>
                                            
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="200px"/>
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
                      <td valign="top" background="../images/next_bg.jpg" >
                     
                          <table border="0" cellpadding="0" cellspacing="0">
                              <tr>
                                  <td >
                                
                                  </td>
                                  <td >
                                                              <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first" OnClick="PagerButtonClick">首页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev" OnClick="PagerButtonClick">上一页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next" OnClick="PagerButtonClick">下一页</asp:LinkButton>
                                    &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last" OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                  &nbsp;&nbsp;&nbsp;<font color="#000000"> 页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                      <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"　Height="20px" OnClick="Button1_Click1" />
                                      &nbsp;&nbsp;&nbsp;每页<font color=red>12</font>条数据
                                      &nbsp;&nbsp; 共有<font color=red><%=CountsLabel%></font>条数据
                                      &nbsp;&nbsp;&nbsp;当前为第<font color=red><%=CurrentlyPageLabel%></font>页 
                                      &nbsp;&nbsp;&nbsp; 共<font color=red><%=AllPageLabel%></font>页</font>
                         
                                  </td>
                              </tr>
                          </table>
                          </td>
                      <td width="17" >
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>

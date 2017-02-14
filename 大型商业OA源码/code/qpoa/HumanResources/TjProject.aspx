<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TjProject.aspx.cs" Inherits="qpoa.HumanResources.TjProject" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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
   document.getElementById('Realname').value='';
   document.getElementById('Unit').value='';
   document.getElementById('StartTime').value='';
   document.getElementById('EndTime').value='';

   
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >>  人力资源  >>  考勤统计  >>  考勤项目</td>
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
                              <button class="btn4off" onclick="javascript:window.location='TjProject.aspx?Realname=&Unit=&start=&last=';showwait();"
                                    type="button">
                                    <font class="shadow_but">考勤项目</font></button>
                              
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
                                 <td class="newtd2">
                                     人员<asp:TextBox ID="Realname" runat="server" Width="100px"></asp:TextBox>部门<asp:TextBox ID="Unit" runat="server" Width="100px"></asp:TextBox>
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
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                  
                                    <asp:TemplateField HeaderText="人员姓名" SortExpression="Realname">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                         <%# DataBinder.Eval(Container.DataItem, "Realname") %>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>   
                                    
                                     <asp:TemplateField HeaderText="所属部门" SortExpression="Unit">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                        <%# DataBinder.Eval(Container.DataItem, "Unit") %>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>                                   
                                            
                                     <asp:TemplateField HeaderText="迟到">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="50px"/>
                                        <ItemTemplate>
                                        <asp:Label ID="LUser" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Username")%>' Visible=false></asp:Label>
                                            <asp:Label ID="Chidao" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="50px"/>
                                    </asp:TemplateField>   
                                    
                                    
                                     <asp:TemplateField HeaderText="早退">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="50px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="ZaoTui" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="50px"/>
                                    </asp:TemplateField>                                  
                                    
                                    
                                   <asp:TemplateField HeaderText="未考勤">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="50px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="WeiKaoQin" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="50px"/>
                                    </asp:TemplateField>                                   
                                    
                                    
                                   <asp:TemplateField HeaderText="出差天数">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="70px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="ChuChai" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="70px"/>
                                    </asp:TemplateField>                                   
           
           
                                 <asp:TemplateField HeaderText="加班小时">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="70px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="JiaBan" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="70px"/>
                                    </asp:TemplateField>   
           
           
                                    <asp:TemplateField HeaderText="病假天数">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="70px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="BingJia" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="70px"/>
                                    </asp:TemplateField>   
                                    
                                    <asp:TemplateField HeaderText="事假天数">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="70px"/>
                                        <ItemTemplate>
                                            <asp:Label ID="ShiJia" runat="server" ></asp:Label>
                                       </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="70px"/>
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
	<script type="text/javascript">
	    parent.closeAlert('UploadChoose');
	</script>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalysisCustomer_ht.aspx.cs" Inherits="qpoa.SaleManage.AnalysisCustomer_ht" %>



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

function outexcel()
{
showwait();
var num=Math.random();
window.open ("AnalysisCustomer_ht_dc.aspx?id=<%=Request.QueryString["id"] %>&tmp="+num+"", "_blank", "height=1, width=1")
}	
function outexcels()
{
showwait();
var num=Math.random();
window.open ("AnalysisCustomer_ht_dc.aspx?id=<%=Request.QueryString["id"] %>&tmp="+num+"&str=<%=SqlStrMid%>", "_blank", "height=1, width=1")
}	


var  wName6;  
function  OpenSaleData11()  
{  

var num=Math.random();
var str=document.getElementById("jscontracttype").value;
wName6=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=11","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName6!=null && wName6!= "undefined")
{
document.getElementById("jscontracttype").value=wName6; 
}

}


</script>
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
                     <td valign="bottom" width="81%"><a href="../main_d.aspx" class="line_b">工作台</a> >> <a href="AnalysisCustomer.aspx"  class="line_b">客户综合信息</a>  >>  销售合同</td>
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
 <button class="btn4off" onclick="javascript:window.location='AnalysisCustomer_show.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">客户信息</font></button><button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_lxr.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">联系人</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_jw.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">交往</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_fw.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">服务</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_gh.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">关怀</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_hf.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">回访</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_ts.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">投诉</font></button>&nbsp;<button class="btn2off" onclick="javascript:window.location='AnalysisCustomer_myd.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">满意度</font></button>&nbsp;<button class="btn2on" onclick="javascript:window.location='AnalysisCustomer_ht.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">合同</font></button>&nbsp;<button class="btn4off" onclick="javascript:window.location='AnalysisCustomer_cpxs.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">产品销售</font></button><button class="btn4off" onclick="javascript:window.location='AnalysisCustomer_fwxcp.aspx?id=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">服务型产品</font></button>
                           
                              
                            </td>
                              <td style="height: 26px" align="right" > 
                                  <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/button_out.jpg" />
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
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" 
                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                      <asp:TemplateField HeaderText="客户名称">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                        <ItemTemplate>
                                             <a href=AnalysisCustomer_ht_show.aspx?id=<%= Request.QueryString["id"]%>&showid=<%# DataBinder.Eval(Container.DataItem, "ID") %> ><%# DataBinder.Eval(Container.DataItem, "name") %></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ContractNum" HeaderText="合同编号" SortExpression="ContractNum">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ContractType" HeaderText="合同类型" SortExpression="ContractType">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="合同金额" SortExpression="ContractMoney" DataField="ContractMoney">
                                        <ItemStyle Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                          
                                    
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
                     
                          <table border="0" cellpadding="0" cellspacing="0">
                              <tr>
                                  <td >
                                
                                  </td>
                                  <td >
                                                              &nbsp;&nbsp; <a href="javascript:void(0)" onclick="checkAll()" class="line">全选</a>
                                      &nbsp;&nbsp;<a href="javascript:void(0)" onclick="fanAll()" class="line">反选</a>
                                    &nbsp;&nbsp;&nbsp; <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first" OnClick="PagerButtonClick">首页</asp:LinkButton>
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
    </form>
</body>
</html>

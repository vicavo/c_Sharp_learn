<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlow_show.aspx.cs" Inherits="qpoa.WorkFlow.AddWorkFlow_show" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>


function delf()
{
if (!confirm("是否确定删除文件夹？"))
return false;
}

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


function showfrom(str)
{
var num=Math.random();
window.open ("WorkFlowName_show_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height=460, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")
}

function updatefrom(str)
{
var num=Math.random();
window.open ("WorkFlowName_show_update.aspx?tmp="+num+"&id="+str+"", "_blank", "height=460, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")
}


function addfrom()
{
var num=Math.random();
window.open ("WorkFlowName_show_add.aspx?tmp="+num+"&id=<%=Request.QueryString["FormId"] %>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")
}



</script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->
<table width="100%"  border="0" cellpadding="0" cellspacing="0">
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
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top">
                                    <font color=red>对应表单：<%=Namefile %></font></td>
                            </tr>
							<tr>
								<td vAlign="top">
                        <div id="Div1" class="mainDiv">
                            <asp:GridView ID="GridView1" runat="server"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" 
                                OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px" Width="100%" >
                                <PagerSettings Visible="False" />
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                     <asp:TemplateField HeaderText="流程名称" SortExpression="FlowName">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                        <ItemTemplate>
                                           <%# DataBinder.Eval(Container.DataItem, "FlowName") %>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" HorizontalAlign=Center />
                                    </asp:TemplateField>   
                                        <asp:TemplateField HeaderText="相关操作">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" Width="160px"/>
                                        <ItemTemplate>
                                            <a href="javascript:void(0)" onClick="parent.location='AddWorkFlow_add.aspx?FlowNumber=<%#DataBinder.Eval(Container.DataItem, "FlowNumber")%>&FormId=<%=Request.QueryString["FormId"]%>'">新建工作</a>
                                             <a href="javascript:void(0)" onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%#DataBinder.Eval(Container.DataItem, "FlowNumber")%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'>流程结构</a>
                                              <a href="javascript:void(0)" onclick='window.open ("AddWorkFlow_show_bd.aspx?id=<%=Request.QueryString["FormId"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'>表单模版</a>
                                        </ItemTemplate>
                                        
                                         
                                        <ItemStyle Wrap="False" HorizontalAlign=Center Width="160px"/>
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

﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_SupplierProFw.aspx.cs" Inherits="qpoa.OpenWindows.open_SupplierProFw" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		 <title>网络办公系统</title>
          <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
		<base target=_self />	
<script  language="javascript">		
function checkbutton()
{
var a=0
for(var i=0;i<document.Form1.elements.length;i++)
{
if(document.Form1.elements[i].checked==true)
	{a=a+1}

}

if(a>0)
{
sendFromChild();
}
else
{
alert('提交数据失败！未选中项');
return false;
}

}/////	
var  getFromParent=window.dialogArguments;  
function CheckSelect()
{


for(var i=0;i<window.document.Form1.elements.length;i++)
{
var e = Form1.elements[i];
if (e.checked)
return e.value;
}
var retrunstr="";
return retrunstr;




}

function  sendFromChild()  
{       
window.returnValue=CheckSelect();  
window.close();  
} 

function  CCC()  
{       
window.returnValue="|";  
window.close();  
} 

window.onbeforeunload = function()  
{
var n = window.event.screenX - window.screenLeft;
var b = n > document.documentElement.scrollWidth-20;
if(b && window.event.clientY < 0 || window.event.altKey)
{
  

}


}      

function  closewin()  
{ 

window.close();  
     

}  
</script> 
<script>
function onradiobutton()
{
aa   =   document.getElementsByName("Rad");  

for   (i=0;i<aa.length;i++)  
{ 

 if(aa[i].value==document.getElementById('requeststr').value)
 {
 aa[i].checked=true;
 
 //alert(i);  
 return false;
 }
 else
 {
  aa[i].checked=false;
 }

}   
}
</script>
	
</HEAD>
	<body scroll="no" onload="onradiobutton()">
	
		<form id="Form1" method="post" runat="server">
		    <!--#include file="../public/public.js"-->
            <!--#include file="../public/pleasewait.htm"--> <asp:TextBox ID="requeststr" runat="server" style="DISPLAY: none"></asp:TextBox>
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="../images/show_02.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　请选择产品</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="0" style="width: 670px; height: 49px">
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: left">
                            产品名称关键字：<asp:TextBox ID="CpName" runat="server"></asp:TextBox>
                            供应商：<asp:TextBox ID="Name" runat="server"></asp:TextBox>
                            <asp:Button ID="Button4" runat="server" CssClass="button_blue" Text="查询" OnClick="Button4_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: center;">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" BackColor="#4D77B1" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" Style="font-size: 12px" Width="98%" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="选择">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="True" />
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" HorizontalAlign="Center"
                                            Wrap="False" />
                                        <ItemTemplate>
                                           <input id="Radio1" type="radio" value='<%#DataBinder.Eval(Container.DataItem, "id")%>|<%#DataBinder.Eval(Container.DataItem, "FwName")%>' name="Rad"  />
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FwName" HeaderText="产品名称" SortExpression="FwName">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Name" HeaderText="所属供应商" SortExpression="Name">
                                        <HeaderStyle CssClass="newtitle" ForeColor="white" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <font color="white">无相关数据！</font></div>
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#94C3CE" ForeColor="Transparent" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                <AlternatingRowStyle BackColor="#E6EDF7" />
                            </asp:GridView>
                        </td>
                    </tr>
                      <tr>
                          <td colspan="2" style="height: 31px; text-align: center;">
                              &nbsp;&nbsp; &nbsp;<INPUT  TYPE="button"  VALUE="确定"  onclick="return checkbutton();" style="width: 70px" class="button_blue" id="Button1">  <INPUT  TYPE="button"  VALUE="关闭"  onclick="closewin();" style="width: 72px" class="button_blue" id="Button3">  <INPUT  TYPE="button"  VALUE="清空"  onclick="CCC();" style="width: 72px" class="button_blue" id="Button2">
                             </td>
                      </tr>                        
                    </table></td>
				</tr>
				<tr>
					<td height="22" background="../images/show_02.gif">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>
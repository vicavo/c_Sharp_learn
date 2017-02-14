<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleProduct_add.aspx.cs" Inherits="qpoa.SaleManage.SaleProduct_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('ProductName').value=='')
    {
    alert('产品名称不能为空');
    form1.ProductName.focus();
    return false;
    }	
    
    
    if(document.getElementById('CustomerName').value=='')
    {
    alert('客户名称不能为空');
    form1.CustomerName.focus();
    return false;
    }	


    if(document.getElementById('UnitMoney').value=='')
    {
    alert('单价不能为空，没有请填为0');
    form1.UnitMoney.focus();
    return false;
    }	
    
    
    if(document.getElementById('UnitMoney').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('UnitMoney').value))
    {
    alert("单价只能为正数");
    form1.UnitMoney.focus();
    return false;
    }

    }  
    
    
    
    
     if(document.getElementById('ManyNum').value=='')
    {
    alert('数量不能为空，没有请填为0');
    form1.ManyNum.focus();
    return false;
    }	  
    
    if(document.getElementById('ManyNum').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('ManyNum').value))
    {
    alert("数量只能为正数");
    form1.ManyNum.focus();
    return false;
    }

    }  
    
    
    
    if(document.getElementById('AllMoney').value=='')
    {
    alert('总价不能为空，没有请填为0');
    form1.AllMoney.focus();
    return false;
    }	
  
    if(document.getElementById('AllMoney').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('AllMoney').value))
    {
    alert("总价只能为正数");
    form1.AllMoney.focus();
    return false;
    }

    }  
  
  
  
  
  
     if(document.getElementById('SaleTime').value=='')
    {
    alert('销售日期不能为空');
    form1.SaleTime.focus();
    return false;
    }	  
  
      if(document.getElementById('SaleRealname').value=='')
    {
    alert('销售人员不能为空');
    form1.SaleRealname.focus();
    return false;
    }	 
       
    showwait();					
}


function allmoneycheck()
{
document.getElementById('AllMoney').value=document.getElementById('UnitMoney').value*document.getElementById('ManyNum').value;
}

</script>






<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <META http-equiv=Pragma content=no-cache>
<META http-equiv=Cache-Control content=no-cache>
<META http-equiv=Expires content=0>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
           <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>  销售记录 >>   <a href=SaleProduct.aspx class="line_b">常规产品</a> >> 新增常规产品</td>
                      <td width="81%">&nbsp;</td>
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
             </div>
            </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
           <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">常规产品</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    客户名称：</td>
                                <td class="newtd2" colspan="3" style="height: 17px">
                                    <asp:TextBox ID="CustomerName" runat="server" Width="90%" title="此文本框不能进行编辑，请点击右边按钮进行选择"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openSupplier();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    产品名称：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:TextBox ID="ProductName" runat="server" title="此文本框不能进行编辑，请点击右边按钮进行选择" Width="90%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="opencp();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    单价：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="UnitMoney" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    数量：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="ManyNum" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>
                                                        <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    总价：</td>
                                <td class="newtd2" height="24" width="33%" colspan="3">
                                    <asp:TextBox ID="AllMoney" runat="server" Width="90%" onclick="allmoneycheck()"></asp:TextBox></td>
                                
                            </tr>
           
                            
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    销售人员：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="SaleRealname" runat="server" Width="85%" ></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A> </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    销售日期：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <script>SetNeed('SaleTime')</script>
                                    <asp:TextBox ID="SaleTime" runat="server" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG id="SaleTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                                                       <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>备注信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>                           
                            
                            
                            
  
                                   <%=showjg%> 
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
								</FONT>
							</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="KeyId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="SaleUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="CpId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	


var  wName_1;  
function  openSupplier()  
{  
var num=Math.random();
var str=""+document.getElementById('KeyId').value+"|"+document.getElementById('CustomerName').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_CustomerForSpro.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("KeyId").value=arr[0]; 
document.getElementById("CustomerName").value=arr[1]; 
}
}




</script>  
    


    
<script language="javascript">	



var  wName_2;  
function  openuser1()  
{  

var num=Math.random();
var str=""+document.getElementById('SaleUsername').value+"|"+document.getElementById('SaleRealname').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SaleUsername").value=arr[0]; 
document.getElementById("SaleRealname").value=arr[1]; 
}
}


var  wName_cp;  
function  opencp()  
{  
var num=Math.random();
var str=""+document.getElementById('CpId').value+"|"+document.getElementById('ProductName').value+"";
wName_cp=window.showModalDialog("../OpenWindows/open_SupplierPro.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_cp.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("CpId").value=arr[0]; 
document.getElementById("ProductName").value=arr[1]; 
}
}



</script>   
  
  
    
    </form>
</body>
</html>
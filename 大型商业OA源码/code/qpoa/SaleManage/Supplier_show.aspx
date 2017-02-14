<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Supplier_show.aspx.cs" Inherits="qpoa.SaleManage.Supplier_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('名称不能为空');
    form1.Name.focus();
    return false;
    }	


    showwait();					
}



</script>






<head id="Head1" runat="server">
    <title>网络办公系统</title>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="Supplier.aspx"  class="line_b">供应商信息</a> >> 查看供应商信息</td>
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
                                      <button class="btn4on" onclick="javascript:window.location='Supplier_show.aspx?id=<%=Request.QueryString["id"] %>';showwait();"
                                    type="button">
                                    <font class="shadow_but">供应商信息</font></button>
                                <button class="btn4off" onclick="javascript:window.location='SupplierLxrxg.aspx?KeyId=<%=Request.QueryString["id"] %>';showwait();" type="button"><font class="shadow_but">联系人信息</font></button>
                                 <button class="btn4off" onclick="javascript:window.location='SupplierSpxg.aspx?KeyId=<%=Request.QueryString["id"]%>';showwait();" type="button"><font class="shadow_but">产品信息</font></button></td>
                              <td style="height: 26px" align="right" > 
                                   <a href="javascript:void(0)"><img src="../images/button_print.jpg" border= 0 onclick="printpage()"/></a></td>
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
                            width="100%" id="tableprint">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    名称：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Name" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    电话：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Tel" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    传真：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Fax" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    区域：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Region" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    网址：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Website" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    详细地址：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Address" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    电子邮件：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:Label ID="Email" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    邮政编码：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:Label ID="Zipcode" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Remark" runat="server" Width="95%"></asp:Label></td>
                            </tr>
                              
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>财务信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="nextrs9">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    开户行：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Bank" runat="server" Width="95%"></asp:Label></td>
                          
                            </tr>                           
                                
                             <tr  class="" id="nextrs10">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    帐号：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Account" runat="server" Width="95%"></asp:Label></td>
                          
                            </tr>   
  
                                   <%=showjg%> 
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
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

    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalysisCustomer_fw_show.aspx.cs" Inherits="qpoa.SaleManage.AnalysisCustomer_fw_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >






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
                       <td width="81%" valign="bottom" style="height: 24px"><a href="../main_d.aspx"  class="line_b">工作台</a> >>  <a href="AnalysisCustomer.aspx"  class="line_b">客户综合信息</a> >> <a href="AnalysisCustomer_fw.aspx?id=<%=Request.QueryString["id"] %>"  class="line_b">客户服务</a> >> 查看客户服务</td>
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
                                    <font class="shadow_but">客户服务</font></button></td>
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
                                    width="15%">
                                    客户名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                  
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">联系人：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
        <asp:Label ID="KhRealname" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                                      <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    服务方式：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label
                                            ID="ServicesType" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    服务估计成本：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ServicesMoney" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">服务开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('StartTime')</script>
                                      <asp:Label ID="Startime" runat="server" Width="90%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">服务结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('Endtime')</script>
                                      <asp:Label ID="Endtime" runat="server" Width="90%"></asp:Label></td>           
                                
                                
                                
                            </tr>  
                            
                            
                            
                  
               
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    服务内容：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Content" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                              
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>客户反馈</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    客户满意度：</td>
                                <td class="newtd2" height="24" colspan="3">
                                    <asp:Label ID="Satisfaction" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    客户反馈意见：</td>
                                <td class="newtd2" colspan="3" height="24">
                                    <asp:Label ID="Feedback" runat="server" Width="90%"></asp:Label></td>
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
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                          
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
<asp:TextBox ID="KeyId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  <asp:TextBox ID="KhId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
   
<script language="javascript">	


var  wName_1;  
function  openSupplier()  
{  
var num=Math.random();
var str=""+document.getElementById('KeyId').value+"|"+document.getElementById('Name').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_CustomerPublic.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("KeyId").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
}
}




</script>  
    


    
<script language="javascript">	



var  wName_2;  
function  openuser1()  
{  
    if(document.getElementById('Name').value=='')
    {
    alert('请先选择客户');
    form1.Name.focus();
    return false;
    }	


var num=Math.random();
var keyid=""+document.getElementById('KeyId').value+"";
var str=""+document.getElementById('KhId').value+"|"+document.getElementById('KhRealname').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_CustomerLxr.aspx?tmp="+num+"&requeststr="+str+"&keyid="+keyid+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("KhId").value=arr[0]; 
document.getElementById("KhRealname").value=arr[1]; 
}
}



</script>    
    
    </form>
</body>
</html>
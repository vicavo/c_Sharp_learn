<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ServicesLog_update.aspx.cs" Inherits="qpoa.SaleManage.ServicesLog_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
  if(document.getElementById('Name').value=='')
    {
    alert('客户名称不能为空');
    form1.Name.focus();
    return false;
    }	



    if(document.getElementById('KhRealname').value=='')
    {
    alert('联系人名称不能为空');
    form1.KhRealname.focus();
    return false;
    }	



    if(document.getElementById('Startime').value=='')
    {
    alert('交往开始时间不能为空');
    form1.Startime.focus();
    return false;
    }	


    if(document.getElementById('Endtime').value=='')
    {
    alert('交往结束时间不能为空');
    form1.Endtime.focus();
    return false;
    }	 
    
    showwait();					
}



var  wName3;  
function  OpenSaleData8()  
{  

var num=Math.random();
var str=document.getElementById("ServicesType").value;
wName3=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=8","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("ServicesType").value=wName3; 
}

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="ServicesLog.aspx"  class="line_b">客户服务</a> >> 修改客户服务</td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    客户名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openSupplier();" alt="" src="../images/FDJ.gif" border="0"></A>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">联系人：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="KhRealname" runat="server" Width="90%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            
                                      <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    服务方式：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="ServicesType" runat="server" DataType="DateTime" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG onclick="OpenSaleData8()" src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    服务估计成本：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="ServicesMoney" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                            
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">服务开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Startime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('StartTime')</script>
                                      <A href="javascript:void(0)"><IMG id="Startime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">服务结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>  
                            
                            
                            
                  
               
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    服务内容：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Content" runat="server"  Width="95%" Height="90px" TextMode="MultiLine"></asp:TextBox></td>
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
                                    <asp:TextBox ID="Satisfaction" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    客户反馈意见：</td>
                                <td class="newtd2" colspan="3" height="24">
                                    <asp:TextBox ID="Feedback" runat="server" Height="71px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
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
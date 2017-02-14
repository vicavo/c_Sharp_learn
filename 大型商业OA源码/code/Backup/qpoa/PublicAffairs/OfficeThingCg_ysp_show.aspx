<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfficeThingCg_ysp_show.aspx.cs" Inherits="qpoa.PublicAffairs.OfficeThingCg_ysp_show" %>
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


 
    if(document.getElementById('DanJia').value=='')
    {
    alert('当前单价不能为空，没有请填为０');
    form1.DanJia.focus();
    return false;
    }
   
    if(document.getElementById('DanJia').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('DanJia').value))
    {
    alert("提示:\r单价只能为正数");
    form1.DanJia.focus();
    return false;
    }

    }      
 
    if(document.getElementById('ShuLiang').value=='')
    {
    alert('当前入库数量不能为空，没有请填为０');
    form1.ShuLiang.focus();
    return false;
    }
   
    
    if(document.getElementById('ShuLiang').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('ShuLiang').value))
    {
    alert("提示:\r入库数量只能为正数");
    form1.ShuLiang.focus();
    return false;
    }

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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >>  办公用品管理  >>  <a href=OfficeThingCg_ysp.aspx class="line_b">审批办公用品入库</a>  >>  查看办公用品入库审批</td>
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
                                <button class="btn4off6k" 
                                    type="button">
                                    <font class="shadow_but">入库登记</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    办公用品名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    单价：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="DanJia" runat="server" Width="90%"></asp:Label></td>
                                  <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                      数量：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:Label ID="ShuLiang" runat="server" Width="90%"></asp:Label></td>    
                                 
                                 
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    备注：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="17" align=center>
                                    <strong>审批信息</strong></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批状态：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Shenpi" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批人：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="SpRealname" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批时间：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="SpTimes" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批备注：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:Label ID="SpRemark" runat="server" Width="90%"></asp:Label></td>
                            </tr>   
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" /></FONT></div> </td>
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
  <asp:TextBox ID="NameId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
   
<script language="javascript">	


var  wName_1;  
function  openoffice()  
{  
var num=Math.random();
var str=""+document.getElementById('NameId').value+"|"+document.getElementById('Name').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_OfficeThing.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:500px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("NameId").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
}
}




</script>  
    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarRepair_update.aspx.cs" Inherits="qpoa.PublicAffairs.CarRepair_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
  if(document.getElementById('CarNum').value=='')
    {
    alert('车牌号不能为空');
    form1.CarNum.focus();
    return false;
    }	

  if(document.getElementById('RepairTime').value=='')
    {
    alert('维护日期不能为空');
    form1.RepairTime.focus();
    return false;
    }	

    showwait();					
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
           </td>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="CarRepair.aspx"  class="line_b">车辆维护管理</a> >> 修改车辆维护</td>
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
                                    <font class="shadow_but">车辆维护</font></button></td>
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
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    车牌号：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="CarNum" runat="server" Width="85%"></asp:TextBox> <A href="javascript:void(0)"><IMG onclick="Opencar()" src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    维护日期：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="RepairTime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('RepairTime')</script>
                                      <A href="javascript:void(0)"><IMG id="RepairTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>  
																		</td>
                            </tr>  
                            
                           <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    维护类型：</td>
                                <td class="newtd2" height="24" width="33%">
                                      <asp:DropDownList ID="RepairType" runat="server" Width="95%">
                                        <asp:ListItem>维修</asp:ListItem>
                                        <asp:ListItem>加油</asp:ListItem>
                                        <asp:ListItem>洗车</asp:ListItem>
                                        <asp:ListItem>年检</asp:ListItem>
                                       <asp:ListItem>其他</asp:ListItem>
                                    </asp:DropDownList></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    经办人：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="People" runat="server" Width="95%"></asp:TextBox>
                                     
                                </td>
                            </tr>
                            
                         

                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    维护费用：</td>
                                <td class="newtd2" height="24" width="83%" colspan=3>
                                    <asp:TextBox ID="RepairMoney" runat="server" Width="95%"></asp:TextBox></td>
                             
                            </tr> 

           
                                 <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    维护原因：</td>
                                <td class="newtd2" height="24" width="83%" colspan=3>
                                    <asp:TextBox ID="Reasons" runat="server" Width="95%"></asp:TextBox></td>
                             
                            </tr>          
                           
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>                           
                            
                            
                            
  
                           
                      
                          
                          
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
<asp:TextBox ID="CarId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  


    


    
<script language="javascript">	



var  wName_2;  
function  Opencar()  
{  
var num=Math.random();
var str=""+document.getElementById('CarId').value+"|"+document.getElementById('CarNum').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_CarInfo.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("CarId").value=arr[0]; 
document.getElementById("CarNum").value=arr[1]; 
}
}


</script>    

    
    </form>
</body>
</html>
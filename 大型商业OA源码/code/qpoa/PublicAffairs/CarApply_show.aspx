<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarApply_show.aspx.cs" Inherits="qpoa.PublicAffairs.CarApply_show" %>
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


	

if(document.getElementById('ManagerName').value=='')
{
alert('调度员不能为空');
form1.ManagerName.focus();
return false;
}	


if(document.getElementById('Starttime').value=='')
{
alert('开始时间不能为空');
form1.Starttime.focus();
return false;
}	

if(document.getElementById('Endtime').value=='')
{
alert('结束时间不能为空');
form1.Endtime.focus();
return false;
}	



return check_Date(document.getElementById('Starttime').value,document.getElementById('Endtime').value,"开始时间","结束时间")

showwait();					



}
function check_Date(date1,date2,date1Text,date2Text)
{
    var date1,date2,date1Text,date2Text;
    date1=date1.replace(/\-/g,"/");
    date2=date2.replace(/\-/g,"/");
    if(Date.parse(date1) > Date.parse(date2))
    {
        alert("错误！"+date1Text+"应在"+date2Text+"之前！")
        return false;
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 查看车辆使用</td>
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
                                    <font class="shadow_but">车辆申请</font></button></td>
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
                            width="100%"  id="tableprint">
                
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    车牌号：</td>
                                <td class="newtd2" height="17"  width="35%">
                                     <asp:Label ID="CarNum"
                                             runat="server" Width="90%"></asp:Label></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    司机：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:Label ID="Drivers" runat="server" Width="90%"></asp:Label></td>                           
                                    
                                    
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    用车人：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:Label ID="Carpeople" runat="server" Width="90%"></asp:Label></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    用车部门：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:Label ID="UnitName" runat="server" Width="90%"></asp:Label></td>                           
                                    
                                    
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('Starttime')</script>
                                      <asp:Label ID="Starttime" runat="server" Width="90%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('Endtime')</script>
                                      <asp:Label ID="Endtime" runat="server" Width="90%"></asp:Label></td>           
                                
                                
                                
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    目的地：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:Label ID="Destination" runat="server" Width="90%"></asp:Label></td>
                                    
                                         <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    里程：</td>
                                <td class="newtd2" height="17"  width="35%">
                                    <asp:Label ID="Miles" runat="server" Width="90%"></asp:Label></td>                           
                                    
                                    
                            </tr>


                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    调度员：</td>
                                <td class="newtd2"  width="35%" style="height: 17px">
                                    <asp:Label
                                        ID="ManagerName" runat="server" Width="90%"></asp:Label></td>
                                    
                                         <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    申请人：</td>
                                <td class="newtd2"  width="35%" style="height: 17px">
                                    <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label></td>                           
                                    
                                    
                            </tr>





                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">事由：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="Subject" runat="server" Width="90%"></asp:Label></td>
                            </tr>
   
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                          
                            </tr>                           

                                <tr>
                                <td class="newtd2" colspan="4" height="17" align=center>
                                    <strong>其他信息</strong></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    状态：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="State" runat="server" Width="90%"></asp:Label></td>
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
                                            <input id="Button1" class="button_blue" onclick="history.back()" type="button" value="返 回" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  

    </form>
</body>
</html>
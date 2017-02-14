<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NetMetting_show.aspx.cs" Inherits="qpoa.PublicAffairs.NetMetting_show" %>
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

if(document.getElementById('NbPeopleName').value=='')
{
alert('出席人员(内部)不能为空');
form1.NbPeopleName.focus();
return false;
}	

if(document.getElementById('MettingName').value=='')
{
alert('会议室不能为空');
form1.MettingName.focus();
return false;
}	

if(document.getElementById('ManagerName').value=='')
{
alert('会议室管理员不能为空');
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
alert('结束时间管理员不能为空');
form1.Endtime.focus();
return false;
}	



check_Date(document.getElementById('Starttime').value,document.getElementById('Endtime').value,"开始时间","结束时间")

showwait();					



}
function check_Date(date1,date2,date1Text,date2Text)
{
    var date1,date2,date1Text,date2Text;
    date1=date1.replace(/\-/g,"/");
    date2=date2.replace(/\-/g,"/");
    if(Date.parse(date1) > Date.parse(date2)){
        alert("错误！"+date1Text+"应在"+date2Text+"之前！")
        return(false)
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 查看网络会议</td>
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
                                    <font class="shadow_but">网络会议</font></button></td>
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
                                    会议名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">会议主题：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="Title" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">描述：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="Introduction" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">出席人员(外部)：

                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="WbPeople" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">出席人员(内部)：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:Label ID="NbPeopleName" runat="server" Width="90%"></asp:Label></td>
                            </tr>


                               <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 24px">
                                    网络会议室IP：</td>
                                <td class="newtd2" width="33%" style="height: 24px">
                                    <asp:Label ID="MettingIp" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 24px">
                                   会议主持人：</td>
                                <td class="newtd2" width="35%" style="height: 24px">
                                    <asp:Label ID="MettingHeader" runat="server" Width="90%"></asp:Label></td>
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
                                <td class="newtd2" colspan="4" height="17" align=center>
                                    <strong>其他信息</strong></td>
                            </tr>
                            
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    会议状态：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:Label ID="State" runat="server" Width="90%"></asp:Label></td>
                            </tr>               
                                 <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签到人员：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:Label ID="CjRealname" runat="server" Width="90%"></asp:Label></td>
                            </tr>                           
  
                           
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                               <input id="Button1" class="button_blue" type="button" value="返 回"  onclick="history.back()"/>
                             
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
<asp:TextBox ID="NbPeopleUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="MettingId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox> 

    </form>
</body>
</html>
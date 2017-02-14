<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MettingApply_add.aspx.cs" Inherits="qpoa.PublicAffairs.MettingApply_add" %>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="MettingApply.aspx"  class="line_b">会议申请</a> >> 新增会议申请</td>
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
                                    <font class="shadow_but">会议申请</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    会议名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">会议主题：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="Title" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">描述：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="Introduction" runat="server" Height="78px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">出席人员(外部)：

                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="WbPeople" runat="server" Height="55px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">出席人员(内部)：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="NbPeopleName" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>


                               <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 24px">
                                    会议室：</td>
                                <td class="newtd2" width="33%" style="height: 24px">
                                    <asp:TextBox ID="MettingName" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openhys();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 24px">
                                   会议室管理员：</td>
                                <td class="newtd2" width="35%" style="height: 24px">
                                    <asp:TextBox ID="ManagerName" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>              
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">开始时间：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Starttime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Starttime')</script>
                                      <A href="javascript:void(0)"><IMG id="Starttime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">结束时间：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>                           
                            <tr class="">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    通知会议室管理员：</td>
                                <td class="newtd2" colspan="3" height="17" width="33%">
                                    <asp:DropDownList ID="DL1" runat="server" Width="95%">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr class="">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    通知出席人员：</td>
                                <td class="newtd2" colspan="3" height="17" width="33%">
                                    <asp:DropDownList ID="DL2" runat="server" Width="95%">
                                        <asp:ListItem>是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:DropDownList></td>
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
<asp:TextBox ID="NbPeopleUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="MettingId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox> 
<script language="javascript">	


var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('ManagerUser').value+"|"+document.getElementById('ManagerName').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_metting.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("ManagerUser").value=arr[0]; 
document.getElementById("ManagerName").value=arr[1]; 
}
}


var  wName_hys;  
function  openhys()  
{  
var num=Math.random();
var str=""+document.getElementById('MettingId').value+"|"+document.getElementById('MettingName').value+"";
wName_hys=window.showModalDialog("../OpenWindows/open_MettingHouse.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:450px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_hys.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("MettingId").value=arr[0]; 
document.getElementById("MettingName").value=arr[1]; 
}
}





var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('NbPeopleUser').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("NbPeopleUser").value=arr[0]; 
document.getElementById("NbPeopleName").value=arr[1]; 
}
}



</script>  
    </form>
</body>
</html>
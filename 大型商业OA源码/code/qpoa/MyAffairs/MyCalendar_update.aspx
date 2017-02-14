<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCalendar_update.aspx.cs" Inherits="qpoa.MyAffairs.MyCalendar_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('CalendarTime').value=='')
    {
    alert('事务时间不能为空');
    form1.CalendarTime.focus();
    return false;
    }	

    if(document.getElementById('Content').value=='')
    {
    alert('内容不能为空');
    form1.Content.focus();
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="MyCalendar.aspx"  class="line_b">我的日程</a> >> 修改日程</td>
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
                                    <font class="shadow_but">我的日程</font></button></td>
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
                                    事务时间：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="CalendarTime" runat="server" Width="85%"></asp:TextBox>
                                      <script>SetNeed('CalendarTime')</script>
                                      <A href="javascript:void(0)"><IMG id="CalendarTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    开始时间：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="StarttimeHour" runat="server" Width="52px">
                                </asp:DropDownList>：<asp:DropDownList ID="StarttimeMini" runat="server" Width="52px">
                                </asp:DropDownList></td>
                                
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    结束时间：</td>
                                <td class="newtd2" height="17" width="35%"><asp:DropDownList ID="EndtimeHour" runat="server" Width="52px">
                                </asp:DropDownList>
                                    ：<asp:DropDownList ID="EndtimeMini" runat="server" Width="52px">
                                    </asp:DropDownList></td>                                
                                
                                
                                
                                
                            </tr>                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    事务类型：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%"><asp:DropDownList ID="CalendarType" runat="server" Width="90%">
                                    <asp:ListItem>工作事务</asp:ListItem>
                                    <asp:ListItem>个人事务</asp:ListItem>
                                </asp:DropDownList></td>
                            </tr>                           
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    内容：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Content" runat="server" Width="90%" Height="73px" MaxLength="8000" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>                         
                                             
                                                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    监控人员：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                           <asp:TextBox ID="JkRealname" runat="server" Width="80%"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser1();" alt="" src="../images/FDJ.gif"
                                                                border="0"></a> 
                                   
                                   
                                   </td>
                            </tr>
                               <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    是否需要提醒：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:DropDownList ID="Iftx" runat="server" Width="90%">
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
 
              <asp:TextBox ID="JkUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	



var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('JkUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JkUsername").value=arr[0]; 
document.getElementById("JkRealname").value=arr[1]; 
}
}



        </script>
 
    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkTime_show.aspx.cs" Inherits="qpoa.HumanResources.WorkTime_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{

    if(document.getElementById('PbType').value=='')
    {
    alert('排班类型不能为空');
    form1.PbType.focus();
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
                      <td width="3%" style="height: 24px"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom" style="height: 24px"><a href="../main_d.aspx" class="line_b">工作台</a> >>  考勤设置  >>  <a href=WorkTime.aspx class="line_b">上下班时间</a>  >>  查看上下班时间</td>
                      <td width="81%" style="height: 24px">&nbsp;</td>
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
                                    <font class="shadow_but">上下班时间</font></button></td>
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
                                    排班类型：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="PbType" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    状态：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="QyType" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    第一次登记类型：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="DjType_1" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    第一次登记时间：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="DjTime_1" runat="server" Width="99%"></asp:Label></td>
                            </tr>                  
                            
                            
                            <tr bgColor="#efefef">
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第二次登记类型：</FONT></td>
												<td>
                                                    <asp:Label ID="DjType_2" runat="server" Width="99%"></asp:Label><A href="javascript:void(0)"></A></td>
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第二次登记时间：</FONT></td>
												<td><FONT face="宋体"><FONT face="宋体">
                                                    <asp:Label ID="DjTime_2" runat="server" Width="99%"></asp:Label></FONT></FONT></td>
											</tr>
											<tr bgColor="#efefef">
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第三次登记类型：</FONT></td>
												<td>
                                                    <asp:Label ID="DjType_3" runat="server" Width="99%"></asp:Label><A href="javascript:void(0)"></A></td>
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第三次登记时间：</FONT></td>
												<td><FONT face="宋体"><FONT face="宋体">
                                                    <asp:Label ID="DjTime_3" runat="server" Width="99%"></asp:Label></FONT></FONT></td>
											</tr>
											<tr bgColor="#efefef">
												<td align="right" style="HEIGHT: 16px" bgcolor="#cccccc"><FONT face="宋体">第四次登记类型：</FONT></td>
												<td style="HEIGHT: 16px">
                                                    <asp:Label ID="DjType_4" runat="server" Width="99%"></asp:Label><A href="javascript:void(0)"></A></td>
												<td align="right" style="HEIGHT: 16px" bgcolor="#cccccc"><FONT face="宋体">第四次登记时间：</FONT></td>
												<td style="HEIGHT: 16px"><FONT face="宋体"><FONT face="宋体">
                                                    <asp:Label ID="DjTime_4" runat="server" Width="99%"></asp:Label></FONT></FONT></td>
											</tr>
											<tr bgColor="#efefef">
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第五次登记类型：</FONT></td>
												<td>
                                                    <asp:Label ID="DjType_5" runat="server" Width="99%"></asp:Label><A href="javascript:void(0)"></A></td>
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第五次登记时间：</FONT></td>
												<td><FONT face="宋体"><FONT face="宋体">
                                                    <asp:Label ID="DjTime_5" runat="server" Width="99%"></asp:Label></FONT></FONT></td>
											</tr>
											<tr bgColor="#efefef">
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第六次登记类型：</FONT></td>
												<td>
                                                    <asp:Label ID="DjType_6" runat="server" Width="99%"></asp:Label><A href="javascript:void(0)"></A></td>
												<td align="right" bgcolor="#cccccc"><FONT face="宋体">第六次登记时间：</FONT></td>
												<td><FONT face="宋体"><FONT face="宋体">
                                                    <asp:Label ID="DjTime_6" runat="server" Width="99%"></asp:Label></FONT></FONT></td>
											</tr>
                            
                            
                            
                                      <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap" >
                                    使用人员：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="SyRealname" runat="server" Width="99%"></asp:Label></td>
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
    </form>
</body>
</html>
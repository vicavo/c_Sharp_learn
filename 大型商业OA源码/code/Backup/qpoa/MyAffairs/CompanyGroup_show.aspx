<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyGroup_show.aspx.cs" Inherits="qpoa.MyAffairs.CompanyGroup_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="CompanyGroup.aspx"  class="line_b">公司通讯录</a> >> 查看公司通讯录</td>
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
                                    <font class="shadow_but">公司通讯录</font></button></td>
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
                                    姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Name" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Worknum" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="Unit" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="Respon" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:Label ID="Post" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    性别：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Sex" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    生日：</td>
                                <td class="newtd2" height="17" width="33%">
                                      <script>SetNeed('BothDay')</script>

                                    <asp:Label ID="BothDay" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    办公电话：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Officetel" runat="server" Width="90%"></asp:Label></td>
                            </tr>                          
                            
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    传真：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:Label ID="Fax" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    手机：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:Label ID="MoveTel" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                    住宅电话：</td>
                                <td class="newtd2" style="height: 17px" width="33%">
                                    <asp:Label ID="HomeTel" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="15%">
                                   E-mail ：</td>
                                <td class="newtd2" style="height: 17px" width="35%">
                                    <asp:Label ID="Email" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                             <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    QQ号：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                  
                                    <asp:Label ID="QQNum" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    MSN：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                 
                                    <asp:Label ID="MsnNum" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    内部即时通：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                 
                                    <asp:Label ID="NbNum" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    邮政编码：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                   
                                    <asp:Label ID="ZipCode" runat="server" Width="90%"></asp:Label></td>
                            </tr>                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    通信地址：</td>
                                <td class="newtd2" height="17" colspan="3">
                                   
                                    <asp:Label ID="Address" runat="server" Width="90%"></asp:Label></td>
                            </tr>                          
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
                                <td class="newtd2" height="17" colspan="3">
                                  
                                    <asp:Label ID="Remark" runat="server" Width="90%"></asp:Label></td>
                            </tr>
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
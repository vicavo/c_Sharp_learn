<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnalysisCustomer_ht_show.aspx.cs" Inherits="qpoa.SaleManage.AnalysisCustomer_ht_show" %>

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
                       <td width="81%" valign="bottom" style="height: 24px"><a href="../main_d.aspx"  class="line_b">工作台</a> >>  <a href="AnalysisCustomer.aspx"  class="line_b">客户综合信息</a> >> <a href="AnalysisCustomer_ht.aspx?id=<%=Request.QueryString["id"] %>"  class="line_b">销售合同</a> >> 查看销售合同</td>
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
                <td width="17" style="height: 40px">&nbsp;</td>
                <td valign="top" style="height: 40px"> 
           <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">销售合同</font></button></td>
                              <td style="height: 26px" align="right" >   <a href="javascript:void(0)"><img src="../images/button_print.jpg" border= 0 onclick="printpage()"/></a></td>
                        </tr>
                    </table>
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
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
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="ContractName" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同编号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ContractNum" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                                      <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同类型：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:Label ID="ContractType" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同金额：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:Label ID="ContractMoney" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    生效日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('StartTime')</script>

                                    <asp:Label ID="Startime" runat="server" Width="90%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                     终止日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('Endtime')</script>

                                    <asp:Label ID="Endtime" runat="server" Width="90%"></asp:Label></td>           
                                
                                
                                
                            </tr>  
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人(甲方)：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="ContractorA" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人(乙方)：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="ContractorB" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    创建日期：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <script>SetNeed('CreateDate')</script>

                                    <asp:Label ID="CreateDate" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    创建人：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Realname" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                            
                            
                  
               
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同描述：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:Label ID="Description" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同条款：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:Label ID="ContractTerms" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同内容：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
<%=ContractContent %>

                                
                                </td>
                            </tr>
                       
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:Label ID="richeng" runat="server" Width="90%"></asp:Label></td>
                          
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
  
   <asp:TextBox ID="ContractorUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox> 
  
       <asp:TextBox ID="ContractContentupdate" runat="server"   style="DISPLAY: none"></asp:TextBox>

    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarApply_sp_sp.aspx.cs" Inherits="qpoa.PublicAffairs.CarApply_sp_sp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function _change()
{
   var text=form1.normalcontent.value;
   if (text !="请选择")
   {
       document.getElementById('SpRemark').value +="\r\n"+text;
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> 车辆使用申请 >> 审批车辆使用</td>
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
                                  <a href="javascript:void(0)"></a></td>
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
                                    审批人：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="SpRealname" runat="server" Width="90%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批操作：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:DropDownList ID="Shenpi" runat="server" Width="85%">
                                        <asp:ListItem Value="已通过">已通过</asp:ListItem>
                                        <asp:ListItem>未通过</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    常用审批备注：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="normalcontent" runat="server" Width="90%" onchange =_change()>
                                    </asp:DropDownList></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    审批备注：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%" >
                                    <asp:TextBox ID="SpRemark" runat="server" Height="81px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                            </tr>   
     
     
     
     
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button2" runat="server" CssClass="button_blue" OnClick="Button1_Click"
                                                Text="确 定" />
                                            &nbsp; &nbsp; &nbsp;<input id="Button1" class="button_blue" onclick="history.back()" type="button" value="返 回" /></FONT>&nbsp;</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
              <asp:TextBox ID="Username" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="CarId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ManagerUser" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  

    </form>
</body>
</html>
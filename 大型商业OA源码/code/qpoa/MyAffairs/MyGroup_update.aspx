<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyGroup_update.aspx.cs" Inherits="qpoa.MyAffairs.MyGroup_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('姓名不能为空');
    form1.Name.focus();
    return false;
    }	


    if(document.getElementById('Email').value!='')
    {
    var objRe = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
    if(!objRe.test(document.getElementById('Email').value))
    {
    alert('Email格式不正确');
    form1.Email.focus();
    return false;
    }
    
    }  

    showwait();					
}





var  wName1;  
function  OpenSaleData1()  
{  

var num=Math.random();
var str=document.getElementById("GroupName").value;
wName1=window.showModalDialog("../OpenWindows/open_PlanCycle.aspx?tmp="+num+"&requeststr="+str+"&type=5","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName1!=null && wName1!= "undefined")
{
document.getElementById("GroupName").value=wName1; 
}

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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="MyGroup.aspx"  class="line_b">个人通讯录</a> >> 修改个人通讯录</td>
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
                                    <font class="shadow_but">个人通讯录</font></button></td>
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
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 个人信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    是否公开：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:DropDownList ID="IfOpen" runat="server" Width="90%">
                                        <asp:ListItem>否</asp:ListItem>
                                        <asp:ListItem>是</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    姓名：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%" ></asp:TextBox>
                                </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    类别：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="GroupName" runat="server" Width="80%" ></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    性别：</td>
                                <td class="newtd2" height="24" width="33%">
                                   <asp:DropDownList ID="Sex" runat="server" Width="90%">
                                        <asp:ListItem>男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    生日：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="BothDay" runat="server" Width="80%"></asp:TextBox>
                                      <script>SetNeed('BothDay')</script>
                                    <A href="javascript:void(0)"><IMG id="BothDay_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>  
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    昵称：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="OtherName" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    职务：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Post" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    配偶：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Spouses" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    子女：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Children" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>                          
                            
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 联系方式（单位）</b></td>
                            </tr>           
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    单位名称：</td>
                                <td class="newtd2" width="83%" style="height: 17px" colspan=3>
                                    <asp:TextBox ID="CName" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                               
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                     单位地址：</td>
                                <td class="newtd2" style="height: 17px" width="33%">
                                    <asp:TextBox ID="CAddress" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="15%">
                                   单位邮编：</td>
                                <td class="newtd2" style="height: 17px" width="35%">
                                    <asp:TextBox ID="CZipCode" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                             <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                  单位电话：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="CTel" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    单位传真：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="CFax" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                           <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 联系方式（家庭）</b></td>
                            </tr>              
                            
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    家庭住址：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="HAddress" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    家庭邮编：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="HZipCode" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>                            
     
                              <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    家庭电话：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="HTel" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    手机：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="HMoveTel" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>  
                            
                            
                             <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    小灵通：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="HXiaoTel" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    电子邮件：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="Email" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>     
     
                             <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    QQ号码：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="QQNum" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    MSN：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="MsnNum" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>        
     
                              <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 备注信息</b></td>
                            </tr>     
     
                                   
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Remark" runat="server" TextMode="MultiLine" Width="95%" Height="47px"></asp:TextBox></td>
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

    </form>
</body>
</html>
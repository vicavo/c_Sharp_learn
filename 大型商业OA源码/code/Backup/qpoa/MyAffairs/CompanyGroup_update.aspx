<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyGroup_update.aspx.cs" Inherits="qpoa.MyAffairs.CompanyGroup_update" %>

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
var str=document.getElementById("Unit").value;
wName1=window.showModalDialog("../OpenWindows/open_UnitNameOnly.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName1!=null && wName1!= "undefined")
{
document.getElementById("Unit").value=wName1; 
}

}

var  wName2;  
function  OpenSaleData2()  
{  

var num=Math.random();
var str=document.getElementById("Respon").value;
wName2=window.showModalDialog("../OpenWindows/open_Respon.aspx?tmp="+num+"&requeststr="+str+"&type=2","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName2!=null && wName2!= "undefined")
{
var aaa=wName2.substring(wName2.lastIndexOf('|')+1,wName2.length)

document.getElementById("Respon").value=aaa; 
}

}




var  wName3;  
function  OpenSaleData3()  
{  
var num=Math.random();
var str=document.getElementById("Post").value;
wName3=window.showModalDialog("../OpenWindows/open_PostName.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
var aaa=wName3.substring(wName3.lastIndexOf('|')+1,wName3.length)

document.getElementById("Post").value=aaa; 
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="CompanyGroup.aspx"  class="line_b">公司通讯录</a> >> 修改公司通讯录</td>
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
                                    <b> 基本信息</b></td>
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
                                    工号：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Worknum" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    部门名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="Unit" runat="server" Width="80%" ></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData1();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    角色名称：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="Respon" runat="server" Width="80%" ></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData2();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    职位：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Post" runat="server" Width="80%"  ></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData3();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    性别：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:DropDownList ID="Sex" runat="server" Width="90%">
                                        <asp:ListItem>男</asp:ListItem>
                                        <asp:ListItem>女</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                              <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    生日：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="BothDay" runat="server" Width="80%"></asp:TextBox>
                                      <script>SetNeed('BothDay')</script>
                                    <A href="javascript:void(0)"><IMG id="BothDay_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>  
                                   
                                   
                                   
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    办公电话：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Officetel" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                            </tr>                          
                            
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    传真：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Fax" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    手机：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="MoveTel" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="17%">
                                    住宅电话：</td>
                                <td class="newtd2" style="height: 17px" width="33%">
                                    <asp:TextBox ID="HomeTel" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px"
                                    width="15%">
                                   E-mail ：</td>
                                <td class="newtd2" style="height: 17px" width="35%">
                                    <asp:TextBox ID="Email" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                             <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    QQ号：</td>
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
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    内部即时通：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="NbNum" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    邮政编码：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="ZipCode" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>                            
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    通信地址：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Address" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>                          
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注信息：</td>
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
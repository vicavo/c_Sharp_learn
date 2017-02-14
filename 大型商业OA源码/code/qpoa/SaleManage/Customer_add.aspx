<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_add.aspx.cs" Inherits="qpoa.SaleManage.Customer_add" %>

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


    showwait();					
}

var  wName;  
function  OpenSaleData()  
{  
var num=Math.random();
var str=document.getElementById('Regional').value;
wName=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=1","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName!=null && wName!= "undefined")
{
document.getElementById("Regional").value=wName; 
}

}






var  wName6;  
function  OpenSaleData6()  
{  

var num=Math.random();
var str=document.getElementById("Nature").value;
wName6=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=6","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName6!=null && wName6!= "undefined")
{
document.getElementById("Nature").value=wName6; 
}

}


var  wName3;  
function  OpenSaleData3()  
{  

var num=Math.random();
var str=document.getElementById("CSource").value;
wName3=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=3","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("CSource").value=wName3; 
}

}



var  wName4;  
function  OpenSaleData4()  
{  

var num=Math.random();
var str=document.getElementById("CImportant").value;
wName4=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=4","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName4!=null && wName4!= "undefined")
{
document.getElementById("CImportant").value=wName4; 
}

}



var  wName7;  
function  OpenSaleData7()  
{  

var num=Math.random();
var str=document.getElementById("Sales").value;
wName7=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=7","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName7!=null && wName7!= "undefined")
{
document.getElementById("Sales").value=wName7; 
}

}


var  wName2;  
function  OpenSaleData2()  
{  

var num=Math.random();
var str=document.getElementById("Industry").value;
wName2=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=2","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName2!=null && wName2!= "undefined")
{
document.getElementById("Industry").value=wName2; 
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="Customer.aspx"  class="line_b">客户信息管理</a> >> 新增客户信息</td>
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
                                    <font class="shadow_but">客户信息</font></button></td>
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
                                    客户名称：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Name" runat="server" Width="95%" ></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    客户编号：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="CustomerNumber" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    业务员姓名：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="YwRealname" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    是否共享：</td>
                                <td class="newtd2" height="24" width="33%" colspan="3">
                                    <asp:DropDownList ID="Sharing" runat="server" AutoPostBack="True" Width="90%">
                                        <asp:ListItem>默认</asp:ListItem>
                                        <asp:ListItem>共享</asp:ListItem>
                                        <asp:ListItem>公开</asp:ListItem>
                                    </asp:DropDownList></td>
                                
                            </tr>
                            <asp:Panel ID="Panel1" runat="server" >
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    共享人：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="SharingName" runat="server" Width="95%" Height="49px" TextMode="MultiLine"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            
                            </asp:Panel>

                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    电话：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Tel" runat="server" Width="90%"></asp:TextBox>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    传真：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="Fax" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                                         <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    网址：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Website" runat="server" Width="90%"></asp:TextBox>
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
                                    区域：</td>
                                <td class="newtd2" width="33%" style="height: 17px">
                                    <asp:TextBox ID="Regional" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData()" alt="" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    邮政编码：</td>
                                <td class="newtd2" width="35%" style="height: 17px">
                                    <asp:TextBox ID="Postcode" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>       
                            
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    详细地址：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Address" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                              
                                         
                           <tr class="" id="nextrs1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>客户类型</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="nextrs9">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    客户来源：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="CSource" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData3()" alt="" src="../images/FDJ.gif" border="0"></A></td>
                                    
                                                          <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    重要度：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="CImportant" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData4()" alt="" src="../images/FDJ.gif" border="0"></A></td>          
                                    
                          
                            </tr>                           
                                
                             <tr  class="" id="nextrs10">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    销售方式：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Sales" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData7()" alt="" src="../images/FDJ.gif" border="0"></A></td>
                          
                            </tr>   
  
  
                             <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>企业概况</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    行业：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Industry" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData2()" alt="" src="../images/FDJ.gif" border="0"></A></td>
    
    
                                   <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    企业性质：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Nature" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="OpenSaleData6()" alt="" src="../images/FDJ.gif" border="0"></A></td> 
                          
                            </tr>                           
    
    
                               <tr  class="" id="Tr7">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    企业规模：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Scale" runat="server" Width="95%"></asp:TextBox></td>
    
    
                                   <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    年营业额：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Annual" runat="server" Width="95%"></asp:TextBox></td> 
                          
                            </tr>    
    
    
                                
                             <tr  class="" id="Tr3">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    企业描述：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Description" runat="server" Width="95%" Height="67px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>  
                            
                                                       <tr class="" id="Tr4">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>财务信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="Tr5">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    开户行：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Bank" runat="server" Width="95%"></asp:TextBox></td>
                          
                            </tr>                           
                                
                             <tr  class="" id="Tr6">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    银行账号：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="BankAccount" runat="server" Width="95%"></asp:TextBox></td>
                          
                            </tr>  
  
                               <tr  class="" id="Tr8">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    税号：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Paragraphs" runat="server" Width="95%"></asp:TextBox></td>
                          
                            </tr>  
  
  
  
                                                         <tr class="" id="Tr9">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>备注信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            

  
                               <tr  class="" id="Tr12">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="63px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>  
  
  
  
  
                                   <%=showjg%> 
                      
                          
                          
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

  <asp:TextBox ID="SharingUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="YwUsername" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
    
<script language="javascript">	


var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('YwUsername').value+"|"+document.getElementById('YwRealname').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("YwUsername").value=arr[0]; 
document.getElementById("YwRealname").value=arr[1]; 
}
}


var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('SharingUser').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SharingUser").value=arr[0]; 
document.getElementById("SharingName").value=arr[1]; 
}
}



</script>    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmLittleType_add.aspx.cs" Inherits="qpoa.KmManage.KmLittleType_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{

    if(document.getElementById('BigId').value=='请选择')
    {
    alert('请选择大类');
    form1.BigId.focus();
    return false;
    }	


    if(document.getElementById('Name').value=='')
    {
    alert('知识小类名不能为空');
    form1.Name.focus();
    return false;
    }	
    
    
    showwait();	
}  
	
function AllPeople()
{

document.getElementById('SyUsername').value='全部用户';
document.getElementById('SyRealname').value='全部用户';
 
}  	
				

</script>


<head id="Head1" runat="server">
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" >
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" style="height: 573px"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="KmLittleType.aspx"  class="line_b">知识小类维护</a> >> 新增知识小类信息</td>
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
                                    <font class="shadow_but">知识小类维护</font></button></td>
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
                                <td align="center" class="newtd2"  colspan="4" width="33%" style="height: 26px">
                                    <b> 知识小类信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="15%">
                                    知识大类：</td>
                                <td class="newtd2"  height="17" colspan="3" width="85%">
                                    <asp:DropDownList ID="BigId" runat="server" Width="90%">
                                    </asp:DropDownList></td>
                            </tr>                         
                            
                            <tr>
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="15%">
                                    知识小类名：</td>
                                <td class="newtd2"  height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            
                           <tr class="">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap" width="17%">
                                    允许使用人员：</td>
                                <td class="newtd2"  colspan="3" height="17" width="33%">
                                <asp:TextBox ID="SyRealname" runat="server" Height="55px" TextMode="MultiLine" Width="80%">全部用户</asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    <input id="Button3" type="button" value="全部用户" onclick="AllPeople();"/></td>
                            </tr>         
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
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

  <asp:TextBox ID="SyUsername" runat="server" Width="90%"  style="DISPLAY: none">全部用户</asp:TextBox>
<script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('SyUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SyUsername").value=arr[0]; 
document.getElementById("SyRealname").value=arr[1]; 
}
}



</script>   
    
    
    </form>
</body>
</html>
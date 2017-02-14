<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaXzPieces_show.aspx.cs" Inherits="qpoa.HumanResources.SaXzPieces_show" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
if(document.getElementById('Name').value=='')
{
alert('产品名称不能为空');
form1.Name.focus();
return false;
}	

if(document.getElementById('DjMoney').value=='')
{
alert('单价不能为空');
form1.DjMoney.focus();
return false;
}	




if(document.getElementById('DyRealname').value=='')
{
alert('人员姓名不能为空');
form1.DyRealname.focus();
return false;
}	




if(document.getElementById('WorkNum').value=='')
{
alert('数量不能为空');
form1.WorkNum.focus();
return false;
}	


if(document.getElementById('WorkTime').value=='')
{
alert('工作日不能为空');
form1.WorkTime.focus();
return false;
}	


if(document.getElementById('AllMoney').value=='')
{
alert('总价不能为空');
form1.AllMoney.focus();
return false;
}	








if(document.getElementById('DjMoney').value!='')
{    
var objRe = /^\d+(\.\d+)?$/;
if(!objRe.test(document.getElementById('DjMoney').value))
{
alert("单价只能为正数");
form1.DjMoney.focus();
return false;
}

} 







if(document.getElementById('WorkNum').value!='')
{    
var objRe = /^\d+(\.\d+)?$/;
if(!objRe.test(document.getElementById('WorkNum').value))
{
alert("数量只能为正数");
form1.WorkNum.focus();
return false;
}

} 




if(document.getElementById('AllMoney').value!='')
{    
var objRe = /^\d+(\.\d+)?$/;
if(!objRe.test(document.getElementById('AllMoney').value))
{
alert("总价只能为正数");
form1.AllMoney.focus();
return false;
}

} 


showwait();					



}

function allmoneycheck()
{
document.getElementById('AllMoney').value=document.getElementById('DjMoney').value*document.getElementById('WorkNum').value;
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>&nbsp; <a href="SaXzPieces.aspx"  class="line_b">计件产品</a> >>&nbsp; 查看计件产品</td>
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
                                    <font class="shadow_but">计件产品</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    帐套名称：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:Label ID="SaName" runat="server" Width="99%"></asp:Label></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">工作日：  
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <script>SetNeed('WorkTime')</script>

                                    <asp:Label ID="WorkTime" runat="server" Width="99%"></asp:Label></td>           
                              
                                
                            </tr>                       
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">产品名称：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="Name" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">人员姓名：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="DyRealname" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    单价：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="DjMoney" runat="server" Width="99%"></asp:Label></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    数量：
                                </td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:Label ID="WorkNum" runat="server" Width="99%"></asp:Label></td>
                            </tr>
                        
                        
                        
                        
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    总价：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:Label ID="AllMoney" runat="server" Width="99%"></asp:Label></td>
                            </tr>

                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button4" runat="server" CssClass="button_blue" OnClick="Button4_Click"
                                                Text="返 回" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="DyUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

<script language="javascript">	

function  opengj()  
{

var num=Math.random();
var littleproduct=document.getElementById("SaName");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;


var num=Math.random();
var str=""+document.getElementById('Name').value+"|"+document.getElementById('DjMoney').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_SaXzPieces.aspx?tmp="+num+"&requeststr="+str+"&number="+cValue+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("Name").value=arr[0]; 
document.getElementById("DjMoney").value=arr[1]; 

}


}





var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('DyUsername').value+"|"+document.getElementById('DyRealname').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("DyUsername").value=arr[0]; 
document.getElementById("DyRealname").value=arr[1]; 


}
}


</script>  



    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmTitle_show_show.aspx.cs" Inherits="qpoa.KmManage.KmTitle_show_show" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('LittleName').value=='')
    {
    alert('所属于小类不能为空');
    form1.LittleName.focus();
    return false;
    }	
    

    if(document.getElementById('Title').value=='')
    {
    alert('知识名称不能为空');
    form1.Title.focus();
    return false;
    }	

    showwait();					
}


function AllPeople1()
{

document.getElementById('QxYdUsername').value='全部用户';
document.getElementById('QxYdRealname').value='全部用户';
 
}  	

function AllPeople2()
{

document.getElementById('QxXgUsername').value='全部用户';
document.getElementById('QxXgRealname').value='全部用户';
 
}  	

</script>


<head id="Head1" runat="server">
    <title>办公自动化</title>
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
           工作台 >> 查看知识信息</td>
            
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                
                            <tr>
                                <td align="right" class="newtd1"  nowrap="nowrap"
                                    width="15%" style="height: 17px">
                                    小类名称：</td>
                                <td class="newtd2"  colspan="3" width="85%" style="height: 17px">
                                    <asp:Label ID="LittleName" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    知识名称：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:Label ID="Title" runat="server" Width="90%"></asp:Label></td>
                            </tr>
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    知识描述：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:Label ID="Content" runat="server" Width="90%"></asp:Label></td>
                            </tr> 
                            
                             <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    作者有话：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:Label ID="AthourSay" runat="server" Width="90%"></asp:Label></td>
                            </tr>                           
                            
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    关键字：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:Label ID="KeyWord" runat="server" Width="90%"></asp:Label></td>
                            </tr>     
   
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    阅读权限：</td>
                                <td class="newtd2"  height="24" width="80%"  colspan=3>
                                    <asp:Label ID="QxYdRealname" runat="server" Width="90%"></asp:Label></td>
                               
                            </tr>                          

                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    最后更新时间：</td>
                                <td class="newtd2"  height="24" width="80%"  colspan=3>
                                    <asp:Label ID="LastTime" runat="server" Width="90%"></asp:Label></td>
                               
                            </tr>  


                             <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT>&nbsp;</div> </td>
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
<asp:TextBox ID="QxYdUsername" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="QxXgUsername" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>

<asp:TextBox ID="BigId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="BigName" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="LittleId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="Number" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	


var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('QxYdUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("QxYdUsername").value=arr[0]; 
document.getElementById("QxYdRealname").value=arr[1]; 
}
}




var  wName_2;  
function  openuser2()  
{  
var num=Math.random();
var str=""+document.getElementById('QxXgUsername').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("QxXgUsername").value=arr[0]; 
document.getElementById("QxXgRealname").value=arr[1]; 
}
}



var  wName_3;  
function  opentype()  
{  
var num=Math.random();
var str=""+document.getElementById('BigId').value+"|"+document.getElementById('BigName').value+"|"+document.getElementById('LittleId').value+"|"+document.getElementById('LittleName').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_KmLittleType.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("BigId").value=arr[0]; 
document.getElementById("BigName").value=arr[1]; 
document.getElementById("LittleId").value=arr[2]; 
document.getElementById("LittleName").value=arr[3]; 
}
}



</script>    

    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmTitle_show_add.aspx.cs" Inherits="qpoa.KmManage.KmTitle_show_add"  validateRequest="false"%>
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

//document.getElementById('QxXgUsername').value='全部用户';
//document.getElementById('QxXgRealname').value='全部用户';
 
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
           工作台 >> 新增知识信息</td>
            
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
                                    <asp:TextBox ID="LittleName" runat="server" Width="90%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="opentype()" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    知识名称：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:TextBox ID="Title" runat="server" Width="95%" MaxLength="1000"></asp:TextBox>
                                    </td>
                            </tr>
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    知识描述：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:TextBox ID="Content" runat="server" Width="95%" Height="65px" MaxLength="6000" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                            </tr> 
                            
                             <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    作者有话：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:TextBox ID="AthourSay" runat="server" Width="95%" MaxLength="120"></asp:TextBox>
                                    </td>
                            </tr>                           
                            
                           <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    关键字：</td>
                               <td class="newtd2"  colspan="3" height="24">
                                   <asp:TextBox ID="KeyWord" runat="server" Width="95%"></asp:TextBox>
                                    </td>
                            </tr>     
   
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    阅读权限：</td>
                                <td class="newtd2"  height="24" width="80%"  colspan=3>
                                    <asp:TextBox ID="QxYdRealname" runat="server" Height="34px" TextMode="MultiLine" Width="80%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1()" src="../images/FDJ.gif" border="0"></A><input id="Button2" type="button" value="全部用户" onclick="AllPeople1();"/></td>
                               
                            </tr>                          




                             <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="提交并关闭窗口" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" Text="下一步新建章节" CssClass="button_blue" OnClick="Button4_Click" />
                                            &nbsp; &nbsp;&nbsp;&nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="不保留关闭窗口" /></FONT></div> </td>
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
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerMoveBm.aspx.cs" Inherits="qpoa.SaleManage.CustomerMoveBm" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>
function RyMove()
{



    if(document.getElementById('Realname').value=='')
    {
    alert('用户不能为空');
   
    return false;
    }	
    
var littleproduct=document.getElementById("UnitName");
var cindex = littleproduct.selectedIndex;
				
var cValue = littleproduct.options[cindex].text;

	
    if (!window.confirm("你确认要将部门["+cValue+"]的数据转移给用户["+document.getElementById('Realname').value+"]吗？"))
    {
     //showwait()

      return false;
    }
 showwait();
	
}



</script>
</head>
<body class="newbody">
    <form id="form1" runat="server">

    <!--#include file="../public/public.js"-->
  <!--#include file="../public/pleasewait.htm"-->

<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>&nbsp;</td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <div id="printshow1"><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 客户管理 >>  客户转移 >>  按部门转移</td>
                      <td width="16%">&nbsp;</td>
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
            </div></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17" style="height: 40px">&nbsp;</td>
                <td valign="top" style="height: 40px"> 
                   <div id="printshow2"> <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 26px; width: 80%;">
                              <button class="btn4off6k" onclick="javascript:window.location='CustomerMove.aspx';showwait();" type="button"><font class="shadow_but">按结果转移</font></button>&nbsp;
                                <button class="btn4off6k" onclick="javascript:window.location='CustomerMoveRy.aspx';showwait();" type="button"><font class="shadow_but">按人员转移</font></button>&nbsp;
                                  <button class="btn4on6k" onclick="javascript:window.location='CustomerMoveBm.aspx';showwait();" type="button"><font class="shadow_but">按部门转移</font></button>&nbsp;
                                   <button class="btn4off6k" onclick="javascript:window.location='CustomerMoveXsz.aspx';showwait();" type="button"><font class="shadow_but">按销售组转移</font></button>&nbsp;
                            </td>
                              <td style="height: 26px" align="right" > </td>
                        </tr>
                    </table>
                    </div>
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
              </tr>
            </table><table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top">
                    	<table  cellSpacing="0" cellPadding="0" width="100%" border="0">
                            <tr>
                                <td valign="top" style="height: 25px">
                                    将部门<asp:DropDownList ID="UnitName" runat="server" Width="361px">
                                    </asp:DropDownList>数据转移到用户<asp:TextBox ID="Realname" runat="server" Width="19%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser();" alt="" src="../images/FDJ.gif" border="0"></A>
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="确定转移" /></td>
                            </tr>
						</table>
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
            
              <div id="printshow3">
              <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                      <td width="17" >
                          &nbsp;</td>
                      <td valign="top" background="../images/next_bg.jpg">
                          &nbsp;</td>
                      <td width="17">
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="Username" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="OldUsername" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="Unit" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="UnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="QxString" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="Respon" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ResponId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	


var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('Username').value+"|"+document.getElementById('Realname').value+"|"+document.getElementById('Unit').value+"|"+document.getElementById('UnitId').value+"|"+document.getElementById('QxString').value+"|"+document.getElementById('Respon').value+"|"+document.getElementById('ResponId').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_all.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("Username").value=arr[0]; 
document.getElementById("Realname").value=arr[1];
document.getElementById("Unit").value=arr[2]; 
document.getElementById("UnitId").value=arr[3]; 
document.getElementById("QxString").value=arr[4]; 
document.getElementById("Respon").value=arr[5]; 
document.getElementById("ResponId").value=arr[6];  
}
}


var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('OldUsername').value+"|"+document.getElementById('OldRealname').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("OldUsername").value=arr[0]; 
document.getElementById("OldRealname").value=arr[1]; 
}
}


</script>  


    </form>
</body>
</html>

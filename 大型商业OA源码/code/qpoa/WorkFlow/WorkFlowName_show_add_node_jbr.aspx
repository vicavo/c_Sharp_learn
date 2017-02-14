<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_jbr.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowName_show_add_node_jbr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('NodeNum').value=='')
    {
    alert('步骤序号不能为空');
    form1.NodeNum.focus();
    return false;
    }	
   
    if(document.getElementById('NodeNum').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('NodeNum').value))
    {
    alert('步骤序号只能为数字');
    form1.NodeNum.focus();
    return false;
    }
    }


    if(document.getElementById('EndtimeSet').value=='')
    {
    alert('结束时间设置不能为空');
    form1.EndtimeSet.focus();
    return false;
    }	
   
    if(document.getElementById('EndtimeSet').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('EndtimeSet').value))
    {
    alert('结束时间设置只能为数字');
    form1.EndtimeSet.focus();
    return false;
    }
    }








    if(document.getElementById('NodeName').value=='')
    {
    alert('步骤名称不能为空');
    form1.NodeName.focus();
    return false;
    }	
    
    
    
    
    showwait();	
}  
				

</script>


<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <base target=_self />	
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    步骤序号：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="NodeNum" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    步骤名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="NodeName" runat="server" Width="90%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    经办人：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                <asp:TextBox ID="JBRObjectName" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1();" alt="" src="../images/FDJ.gif" border="0"></A></td>
                            </tr>
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT></div> </td>
                            </tr>
                          
                        </table>
              <asp:TextBox ID="NodeNumber" runat="server" Visible="False"></asp:TextBox></td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="JBRObjectId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

 <SCRIPT>
var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('JBRObjectId').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JBRObjectId").value=arr[0]; 
document.getElementById("JBRObjectName").value=arr[1]; 
}

}




</SCRIPT>    
   
   
   
   
   
    </form>
</body>
</html>
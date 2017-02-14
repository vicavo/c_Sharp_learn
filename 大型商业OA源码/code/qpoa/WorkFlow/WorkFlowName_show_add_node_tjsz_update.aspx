<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_tjsz_update.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowName_show_add_node_tjsz_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function killErrors() {
return true;
}
window.onerror = killErrors;	

function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('名称不能为空');
    form1.Name.focus();
    return false;
    }	
    
    if(document.getElementById('JudgeBasis').value=='')
    {
    alert('判断依据不能为空');
    form1.JudgeBasis.focus();
    return false;
    }	 
  
  
    
    if(document.getElementById('Type').value=='[数字型]')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('JudgeBasis').value))
    {
    alert('字段为[数字型]，判断依据必须为数字');
    form1.JudgeBasis.focus();
    return false;
    }
    }      
    
    if(document.getElementById('Type').value=='[常规型]')
    {
        if(document.getElementById('Conditions').value=='>'||document.getElementById('Conditions').value=='>='||document.getElementById('Conditions').value=='<='||document.getElementById('Conditions').value=='<'||document.getElementById('Conditions').value=='=')
        {
          alert('常规型不能使用比较符号');
          return false;
        }

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
                                    字段名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openunit()" src="../images/FDJ.gif" border="0"></A>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">字段类型：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="Type" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">条件判断：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="Conditions" runat="server" Width="90%">
                                        <asp:ListItem Value="&gt;">大于</asp:ListItem>
                                        <asp:ListItem Value="&gt;=">大于且等于</asp:ListItem>
                                        <asp:ListItem Value="==">等于</asp:ListItem>
                                        <asp:ListItem Value="&lt;">小于</asp:ListItem>
                                        <asp:ListItem Value="&lt;=">小于且等于</asp:ListItem>
                                        <asp:ListItem>包含</asp:ListItem>
                                        <asp:ListItem>不包含</asp:ListItem>
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                   判断依据： </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="JudgeBasis" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT></div> </td>
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
<asp:TextBox ID="Number" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormNumber" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormName" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowId" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowNumber" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FlowName" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="KeyID" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>


<script language="javascript">	
var  wName_1;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('Number').value+"|"+document.getElementById('Name').value+"|"+document.getElementById('Type').value+"";
FormNumber=document.getElementById('FormNumber').value;
wName_1=window.showModalDialog("../OpenWindows/open_FormFile.aspx?tmp="+num+"&requeststr="+str+"&FormNumber="+FormNumber+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("Number").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
document.getElementById("Type").value=arr[2]; 

}
}
</script>    
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_yz_update.aspx.cs"
    Inherits="qpoa.WorkFlow.WorkFlowName_show_add_yz_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function killErrors() {
return true;
}
window.onerror = killErrors;	

function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('请选择印章域');
        form1.Name.focus();
        return false;
    }	
    
    if(document.getElementById('SyRealname').value=='')
    {
        alert('允许使用人员不能为空');
        form1.SyRealname.focus();
        return false;
    }	    
    showwait();	
}  
				

</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <!--#include file="../public/pleasewait.htm"-->
        <!--#include file="../public/public.js"-->

        <script language="javascript" src="../public/DateSelect.js"></script>

        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
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
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                                        width="15%">
                                                        印章域名：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" width="85%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                                        width="15%">
                                                        允许使用人员：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="SyRealname" runat="server" Height="55px" TextMode="MultiLine" Width="85%"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser1();" alt="" src="../images/FDJ.gif"
                                                                border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                                    type="button" value="关 闭" /></font></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="SyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

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

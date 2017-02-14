<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProManageMG_update.aspx.cs" Inherits="qpoa.ProManage.ProManageMG_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('项目名称不能为空');
    form1.Name.focus();
    return false;
    }	



    if(document.getElementById('ConName').value=='')
    {
    alert('项目编号不能为空');
    form1.ConName.focus();
    return false;
    }	



    if(document.getElementById('Starttime').value=='')
    {
    alert('开始时间不能为空');
    form1.Starttime.focus();
    return false;
    }	


    if(document.getElementById('Endtime').value=='')
    {
    alert('结束时间不能为空');
    form1.Endtime.focus();
    return false;
    }	 
    
    showwait();	
}  
				



function  OpenSaleData1()  
{  
    var  wName2;  
    var num=Math.random();
    var str=document.getElementById("Types").value;
    wName2=window.showModalDialog("../OpenWindows/open_ProData.aspx?tmp="+num+"&requeststr="+str+"&type=9","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
    if(wName2!=null && wName2!= "undefined")
    {
        document.getElementById("Types").value=wName2; 
    }
}

function  OpenSaleData2()  
{  
    var  wName2;  
    var num=Math.random();
    var str=document.getElementById("Jibie").value;
    wName2=window.showModalDialog("../OpenWindows/open_ProData.aspx?tmp="+num+"&requeststr="+str+"&type=1","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
    if(wName2!=null && wName2!= "undefined")
    {
        document.getElementById("Jibie").value=wName2; 
    }
}

</script>

<script language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();

var sAllowExt = "<%=fjkey%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	return false;
}


showwait();	



}


function  down()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');

return false;
}
else
{

var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.open ("../file_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


}

function  delfj()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');
return false;
}
else
{
if (!confirm("是否确定要删除？"))
return false;

showwait();	
var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.showModalDialog("../file_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                

}


}			




</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
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
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="../images/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="../main_d.aspx" class="line_b">工作台</a> >> <a href="ProManageMG.aspx" class="line_b">
                                                                项目创建</a> >> 修改项目创建</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="../images/lingbg.jpg">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
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
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off6k" type="button">
                                                                <font class="shadow_but">项目创建</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目编号：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="ConName" runat="server" Width="90%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目状态：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="States" runat="server" Width="90%">
                                                            <asp:ListItem>进行中</asp:ListItem>
                                                            <asp:ListItem>已暂停</asp:ListItem>
                                                            <asp:ListItem>已结束</asp:ListItem>
                                                            <asp:ListItem>已终止</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img id="Starttime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
                                                                src="../images/FDJ.gif" border="0"></a></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Endtime" runat="server" Width="80%" DataType="DateTime"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
                                                                src="../images/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目类别：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Types" runat="server" Width="80%"></asp:TextBox><a href="javascript:void(0)"><img
                                                            onclick="OpenSaleData1()" alt="" src="../images/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        评审级别：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Jibie" runat="server" Width="80%"></asp:TextBox><a href="javascript:void(0)"><img
                                                            onclick="OpenSaleData2()" alt="" src="../images/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目描述：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="Conetent" runat="server" Height="76px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目负责人：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="FzRealname" runat="server" Width="80%"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser();" alt="" src="../images/FDJ.gif"
                                                                border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        项目参与人：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="CyRealname" runat="server" Height="81px" TextMode="MultiLine" Width="80%"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser1();" alt="" src="../images/FDJ.gif"
                                                                border="0"></a></td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:DropDownList ID="fjlb" runat="server" Width="70%">
                                                        </asp:DropDownList>&nbsp;
                                                        <input id="Button5" type="button" value="下　载" onclick="down();" />
                                                        <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        上传附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue"
                                                                    OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
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
        <asp:TextBox ID="FzUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="CyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	


var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('FzUsername').value+"|"+document.getElementById('FzRealname').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("FzUsername").value=arr[0]; 
document.getElementById("FzRealname").value=arr[1]; 
}
}


var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('CyUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("CyUsername").value=arr[0]; 
document.getElementById("CyRealname").value=arr[1]; 
}
}



        </script>

    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_update.aspx.cs"
    Inherits="qpoa.WorkFlow.WorkFlowName_show_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function chknull()
{
    if(document.getElementById('FlowName').value=='')
    {
    alert('流程名称不能为空');
    form1.FlowName.focus();
    return false;
    }	


   if(document.getElementById('BianhaoJs').value=='')
    {
        alert('自动编号计数器不能为空');
        form1.BianhaoJs.focus();
        return false;
    }	
   
    if(document.getElementById('BianhaoJs').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('BianhaoJs').value))
        {
            alert("自动编号计数器只能为正数");
            form1.BianhaoJs.focus();
            return false;
        }
    }
    
    
    if(document.getElementById('BianhaoWs').value=='')
    {
        alert('自动编号位数不能为空');
        form1.BianhaoWs.focus();
        return false;
    }	
   
    if(document.getElementById('BianhaoWs').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('BianhaoWs').value))
        {
            alert("自动编号位数只能为正数");
            form1.BianhaoWs.focus();
            return false;
        }
    }    
    
    
    showwait();					
}

function my_tip()
{
   if(document.getElementById("tip").style.display=="none")
      document.getElementById("tip").style.display="";
   else
   	  document.getElementById("tip").style.display="none";
}

</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
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
                                工作台 >> 修改流程名称</td>
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
                                                        流程名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="FlowName" runat="server" Width="90%" MaxLength="10"></asp:TextBox>(10字符)</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                                        width="17%">
                                                        对应表单：</td>
                                                    <td class="newtd2" colspan="3" height="24">
                                                        <asp:DropDownList ID="FormName" runat="server" Width="95%" Enabled="False">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                                        width="17%">
                                                        流程状态：</td>
                                                    <td class="newtd2" colspan="3" height="24">
                                                        <asp:DropDownList ID="FlowType" runat="server" Width="95%">
                                                            <asp:ListItem>正常</asp:ListItem>
                                                            <asp:ListItem>停用</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                                        width="15%">
                                                        允许监控用户：</td>
                                                    <td class="newtd2" height="24" width="85%" colspan="3">
                                                        <asp:TextBox ID="JkRealname" runat="server" Height="34px" TextMode="MultiLine" Width="85%"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser1()" src="../images/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                                        width="15%">
                                                        使用人部门：</td>
                                                    <td class="newtd2" height="24" width="85%" colspan="3">
                                                        <asp:TextBox ID="FlowUnitName" runat="server" Height="34px" TextMode="MultiLine"
                                                            Width="85%"></asp:TextBox><a href="javascript:void(0)"><img onclick="openunit()"
                                                                src="../images/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                                        width="15%">
                                                        结束后归档：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="OverSetCon" runat="server" Width="90%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <b>工作名称/文号的设定</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        是否允许修改文号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="xgwenhao" runat="server" Width="90%">
                                                            <asp:ListItem Value="是">是</asp:ListItem>
                                                            <asp:ListItem Value="否">否</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        自动文号表达式：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Wenhao" runat="server" Width="90%"></asp:TextBox><a href="javascript:my_tip()">查看说明</a>
                                                    </td>
                                                </tr>
                                                <tr id="tip" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        说明：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        表达式中可以使用以下特殊标记：<br>
                                                        {Y}：表示年<br>
                                                        {M}：表示月<br>
                                                        {D}：表示日<br>
                                                        {H}：表示时<br>
                                                        {I}：表示分<br>
                                                        {S}：表示秒<br>
                                                        {W}：表示星期<br>
                                                        {F}：表示流程名<br>
                                                        {U}：表示用户姓名<br>
                                                        {DN}：部门编号<br>
                                                        {SD}：表示短部门<br>
                                                        {R}：表示角色<br>
                                                        {N}：表示编号，通过 <u>编号计数器</u> 取值并自动增加计数值<br>
                                                        <br>
                                                        例如，表达式为：成建委发[{Y}]{N}号，编号位数为4<br>
                                                        自动生成文号如：成建委发[2006]0001号<br>
                                                        <br>
                                                        例如，表达式为：BH{N}，编号位数为3<br>
                                                        自动生成文号如：BH001<br>
                                                        <br>
                                                        例如，表达式为：{F}流程（{Y}年{M}月{D}日{H}:{I}）{U}<br>
                                                        自动生成文号如：请假流程（2006年01月01日10:30）张三<br>
                                                        <br>
                                                        可以不填写自动文号表达式，则系统默认按以下格式，如：<br>
                                                        请假流程(2006-01-01 10:30:30)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        自动编号计数器：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BianhaoJs" runat="server" Width="65%">0</asp:TextBox>同一流程下编号开始的数字
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        自动编号位数：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BianhaoWs" runat="server" Width="90%">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="button_blue" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                                    type="button" value="关闭" /></font></div>
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
        <asp:TextBox ID="JkUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowUnitId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
var  wName_2;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('FlowUnitId').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_UnitName_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("FlowUnitId").value=arr[0]; 
document.getElementById("FlowUnitName").value=arr[1]; 
}
}



var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('JkUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JkUsername").value=arr[0]; 
document.getElementById("JkRealname").value=arr[1]; 
}
}

        </script>

    </form>
</body>
</html>

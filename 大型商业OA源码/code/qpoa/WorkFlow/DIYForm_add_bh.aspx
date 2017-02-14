<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add_bh.aspx.cs"
    Inherits="qpoa.WorkFlow.DIYForm_add_bh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function  insertfile()  
{  
    var cValue = <%=Request.QueryString["Number"] %>;
    var cvalues = document.getElementById('Name').value;
    
   
    var str='<input  id="Text2" name="'+cValue+'"  type="text" value="'+cvalues+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>';
    window.opener.qiupengmodel(str);
    window.close();
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
    <title>伟控时代网络办公自动化</title>
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
                                                        自动编号表达式：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="60%"></asp:TextBox><a href="javascript:my_tip()">查看说明</a>
                                                    </td>
                                                </tr>
                                                <tr id="tip" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                                        width="15%">
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
                                                        {SD}：表示部门名称<br>
                                                        {R}：表示角色<br>
                                                        {BD}：表示工作名称/文号<br>
                                                        <br>
                                                        例如，表达式为：{F}流程（{Y}年{M}月{D}日{H}:{I}）{U}<br>
                                                        自动生成文号如：请假流程（2006年01月01日10:30）张三
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button1" class="button_blue" onclick="javascript:insertfile()" type="button"
                                                                    value="确 定" />
                                                                <input id="Button3" class="button_blue" onclick="javascript:window.close()" type="button"
                                                                    value="关 闭" /></font></div>
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowListSpYzY.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowListSpYzY" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>我的印章</title>
<base target=_self />	
    <script>
    function chknull()
    {
    
    	    if (document.getElementById('DropDownList1').value=="请选择")
			{
				alert("请先选择印章！"); 
				return(false); 
			} 
			else
			{
			    if (!confirm("确定插入印章到文档的光标停留处？"))
                return false;
			}
	}
	function _onchange()
    {
        if (document.getElementById('DropDownList1').value=="请选择")
        {
           document.getElementById('img1').src="CompanySeal/onchange.jpg";
        }
        else
        {
          document.getElementById('img1').src="CompanySeal/"+document.getElementById('DropDownList1').value+"";
        }
    }
	
    
    </script>

    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <link href="../css/public.css" type="text/css" rel="stylesheet">
    <link href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody" onclick="_onchange();">
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
                                        </td>
                                        <td valign="top">
                                            <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                                                style="width: 407px">
                                                <tr>
                                                    <td class="newtd2" height="17" width="50%" valign="top">
                                                        <table border="0" cellpadding="4" cellspacing="0" style="width: 100%; height: 100%">
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    选择印章</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="184px" onchange="_onchange()">
                                                                    </asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    输入密码</td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 100px">
                                                                    <asp:TextBox ID="Password" runat="server" Width="180px" TextMode="Password"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="height: 22px">
                                                                    <asp:Button ID="Button1" runat="server" Text="确 定" OnClick="Button1_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td class="newtd2" height="17" style="width: 572%">
                                                        <img src="CompanySeal/onchange.jpg" style="width: 196px; height: 187px" id="img1" name="img1" /></td>
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
    </form>
</body>
</html>
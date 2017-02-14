<%@ Page Language="C#" AutoEventWireup="true" Codebehind="main_d.aspx.cs" Inherits="qpoa.main_d" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function _del(a)
{
    msg="确认在工作台不显示此模块吗?";
    if(window.confirm(msg))
    {
    
      window.open ("main_d_del.aspx?id="+a+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }
}

function _update(a)
{           
     var aw = 380;
     var ah = 130;
     var al = (screen.width - aw)/2-100;
     var at = (screen.height - ah)/5+200;
     window.open ("main_d_update.aspx?id="+a+"", "_blank", "height=130, width=380,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no,top="+at+",left="+al+"")
}
</script>

<head runat="server">
    <link href="css/public.css" type="text/css" rel="stylesheet">
    <title>无标题页</title>
</head>
<body class="newbody">
    <form id="form1" runat="server">
     <!--#include file="public/public.js"-->
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="images/top_3.gif"></td>
                                                    <td width="16%" valign="bottom">
                                                        <a href="main_d.aspx" class="line_b">工作台</a></td>
                                                    <td width="81%">
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" background="images/lingbg.jpg">
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
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <div id="show" style="display: none">
                                                <font color="#ff0000" size="2">
                                                    <br>
                                                    <b>请等待...</b></font></div>

                                            <script language="javascript">
    document.getElementById('show').style.display=''; 
                                            </script>

                                            <asp:Label ID="Label" runat="server"></asp:Label>
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

        <script type="text/javascript">
	    parent.closeAlert('UploadChoose');
        </script>

    </form>
</body>
</html>

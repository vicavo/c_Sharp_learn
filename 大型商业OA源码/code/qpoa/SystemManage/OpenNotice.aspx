<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenNotice.aspx.cs" Inherits="qpoa.SystemManage.qp_OpenNotice" validateRequest="false"%>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
<script>
function  openshow()  
{
if (!confirm("保存以后才能预览，请先确定是否保存？"))
return false;
var num=Math.random();
window.open ("OpenNotice_show.aspx?tmp="+num+"", "_blank", "height=600, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
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
                      <td width="81%" valign="bottom"><a href="../main_d.aspx" class="line_b">工作台</a> >> 弹出公告设置</td>
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
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">弹出公告</font></button>
                            </td>
                              <td style="height: 26px" align="right" > </td>
                        </tr >
                    </table>
                    </div>
                  
              
                      <table align="center" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px" align="center">
                                <fckeditorv2:fckeditor id="d_content" runat="server" height="400px" toolbarset="Qiupeng1"></fckeditorv2:fckeditor>
                                &nbsp;</td>
                         
                        </tr >
                          <tr>
                            <td width=30% style="height: 26px" align="center">
                                是否允许弹出：<asp:DropDownList ID="IfOpen" runat="server" Width="66px">
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList></td>
                         
                        </tr >
                    </table>
              <table align="center" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px" align="center">
                                <asp:Button ID="Button1" runat="server" Text="确　定" CssClass="button_blue" OnClick="Button1_Click" />
                                <input id="Button2" type="button"
                                    value="预　览" class="button_blue" onclick="openshow()"/>
                            </td>
                         
                        </tr >
                    </table>
              
              
                </td>
                <td width="17" style="height: 40px">&nbsp;</td>
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

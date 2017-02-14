<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalariesSet_add_sczd.aspx.cs" Inherits="qpoa.HumanResources.SalariesSet_add_sczd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
         <script>
  
function chkyema()
{
    if(document.getElementById('GoPage').value=='')
    {
    alert('页码不能为空');
    form1.GoPage.focus();
    return false;
    }	
   
    if(document.getElementById('GoPage').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('GoPage').value))
    {
    alert('页码只能为数字');
    form1.GoPage.focus();
    return false;
    }
    }
   
    
    showwait();	
}  


function showfrom(str)
{
var num=Math.random();
window.open ("SalariesSet_add_jjcp_update.aspx?tmp="+num+"&number=<%=Request.QueryString["number"]%>&id="+str+"", "_blank", "height=370, width=650,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=120,left=150")
}


function addfrom()
{
var num=Math.random();
window.open ("SalariesSet_add_jjcp_add.aspx?tmp="+num+"&number=<%=Request.QueryString["number"]%>", "_blank", "height=370, width=650,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=120,left=150")
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
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17" style="height: 40px">&nbsp;</td>
                <td valign="top" style="height: 40px"> 
                   <div id="printshow2"> <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 26px; width: 11%;">
                              <button class="btn4off" onclick="javascript:window.location='SalariesSet_add_xzxm.aspx?number=<%=Request.QueryString["number"]%>';showwait();"type="button"><font class="shadow_but">薪资项目</font></button>
                                <button class="btn4off" onclick="javascript:window.location='SalariesSet_add_jjcp.aspx?number=<%=Request.QueryString["number"]%>';showwait();" type="button"><font class="shadow_but">计件产品</font></button>
                               <button class="btn4off" onclick="javascript:window.location='SalariesSet_add_jjgx.aspx?number=<%=Request.QueryString["number"]%>';showwait();" type="button"><font class="shadow_but">计件工序</font></button>
                            <button class="btn4off" onclick="javascript:window.location='SalariesSet_add_jjgz.aspx?number=<%=Request.QueryString["number"]%>';showwait();" type="button"><font class="shadow_but">计时工种</font></button>
                             <button class="btn4off" onclick="javascript:window.location='SalariesSet_add_rydy.aspx?number=<%=Request.QueryString["number"]%>';showwait();" type="button"><font class="shadow_but">人员对应</font></button>
                           
                            </td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
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
                    <td valign="top" align="center">
                        <table border="0" cellpadding="0" cellspacing="0" style="width: 588px; height: 49px">
                            <tr>
                                <td style="height: 31px; text-align: center">
                                    <asp:CheckBox ID="Sajjcp" runat="server" Text="计件产品" />&nbsp;<asp:CheckBox ID="Sajjgx"
                                        runat="server" Text="计件工序" />
                                    <asp:CheckBox ID="Sajsgz" runat="server" Text="计时工种" /></td>
                            </tr>
                            <tr>
                                <td style="height: 31px; text-align: center">
                                    <table border="0" cellpadding="0" cellspacing="0" style="height: 302px">
                                        <tr>
                                            <td align="center" style="width: 113px" valign="top">
                                                <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                            <td align="center" style="width: 42px" valign="top">
                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                                <br />
                                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                                <br />
                                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                                <br />
                                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                            </td>
                                            <td align="center" style="width: 100px" valign="top">
                                                <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="157px"></asp:ListBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 31px; text-align: center">
                                    &nbsp;<asp:Button ID="Button7" runat="server" CssClass="button_blue" OnClick="Button7_Click"
                                        Text="确  定" />
                                    <input id="Button3" class="button_blue" onclick="javascript:window.close();" type="button" value="关　闭" /></td>
                            </tr>
                        </table>
                                    <asp:TextBox ID="KeyBox" runat="server" Style="display: none"></asp:TextBox>
                                    <asp:TextBox ID="requeststr" runat="server" Style="display: none"></asp:TextBox></td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
            
              <div id="printshow3">
              <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                  <tr>
                      <td width="17" >
                          &nbsp;</td>
                      <td valign="top" >
                          </td>
                      <td width="17" >
                          &nbsp;</td>
                  </tr>
              </table>
              </div>
              
              
          </td>
        </tr>
      </table></td>
  </tr>
</table>
    </form>
</body>
</html>

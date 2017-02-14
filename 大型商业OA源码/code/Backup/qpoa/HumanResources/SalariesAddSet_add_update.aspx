<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalariesAddSet_add_update.aspx.cs" Inherits="qpoa.HumanResources.SalariesAddSet_add_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{

    if(document.getElementById('SaMoney').value=='')
    {
    alert('薪资金额不能为空');
    form1.SaMoney.focus();
    return false;
    }	
    
    if(document.getElementById('SaMoney').value!='')
    {
   // var objRe = /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
    var objRe = /^[-+]?\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('SaMoney').value))
    {
    alert('薪资金额只能输入数字');
    form1.SaMoney.focus();
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
              人员薪资修改::::此处的修改，只针对此次的薪资录入，不影响帐套设置::::“-”表示负数，如果为正数则直接填写数字</td>
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
                                    width="17%">
                                    薪资名称：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%" ReadOnly="True" ></asp:TextBox>
                                </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    人员姓名：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="DyRealname" runat="server" Width="90%" ReadOnly="True"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    薪资项目：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="SaItem" runat="server" Width="90%" ReadOnly="True"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    薪资金额：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="SaMoney" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
  
                                   
                      
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp;&nbsp;
                                            <input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关闭" /></FONT></div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
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
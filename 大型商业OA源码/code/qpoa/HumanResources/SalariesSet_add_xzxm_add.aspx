<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalariesSet_add_xzxm_add.aspx.cs" Inherits="qpoa.HumanResources.SalariesSet_add_xzxm_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('项目名称不能为空');
    form1.Name.focus();
    return false;
    }	

    if(document.getElementById('CsMoney').value=='')
    {
    alert('初始值不能为空');
    form1.CsMoney.focus();
    return false;
    }	
    
    if(document.getElementById('CsMoney').value!='')
    {
    var objRe = /^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$/;
    if(!objRe.test(document.getElementById('CsMoney').value))
    {
    alert('初始值只能为大于0数字');
    form1.CsMoney.focus();
    return false;
    }
    }       
    
    
    
    showwait();					
}


function chkset()
{
    if(document.getElementById('txtForumla').value=='')
    {
    alert('公式不能为空');
    form1.txtForumla.focus();
    return false;
    }	
}



function inputkey(operator)
{
    insertAtCaret(form1.txtForumla,operator)
}


function insertAtCaret (textEl, text)
{

    if(document.getElementById('txtForumla').value=='')
    {
        document.getElementById('txtForumla').value=text;
    }	

    else
    {
        document.form1.txtForumla.focus();  
        document.selection.createRange().text   =   text;
    }

}

function Clear()
{
    if (confirm('确认要清除公式内容吗?'))
    {
	    form1.txtForumla.value=""
    }
}

</script>





<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body class="newbody">
    <form id="form1" runat="server">
    
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              薪资项目管理<asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox></td>
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
                                    项目名称：</td>
                                <td class="newtd2" height="17" width="33%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%" ></asp:TextBox>
                                </td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    style="color: #000000" width="15%">
                                    初始值：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="CsMoney" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="24">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Text="是否包含计算公式" AutoPostBack="True" />&nbsp;
                                </td>
                            </tr>
                            <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
                            <tr>
                                <td class="newtd2" colspan="4" height="24">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 100%">
                                        <tr>
                                            <td width=50% valign="top">
                                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="#0000C0" OnClick="LinkButton1_Click">检验计算公式</asp:LinkButton>
                                                <a href="javascript:void(0)" onclick="Clear()"><font color=#0000C0>清空计算公式</font></a><asp:TextBox ID="txtForumla" runat="server" Width="97%"></asp:TextBox><br />
                                     <font color=red>每个"薪资项目"只能在项目公式中引用一个"考勤项目"，否则所生成的公式将会产生错误！</font> <br /><div align=center>
                                         <strong>考勤项目</strong><br><br><a href="javascript:void(0)" onclick="inputkey('[迟到次数]')">[迟到次数]</a><a href="javascript:void(0)" onclick="inputkey('[早退次数]')">[早退次数]</a><br><br><a href="javascript:void(0)" onclick="inputkey('[出差天数]')">[出差天数]</a><a href="javascript:void(0)" onclick="inputkey('[事假天数]')">[事假天数]</a><a href="javascript:void(0)" onclick="inputkey('[病假天数]')">[病假天数]</a><a href="javascript:void(0)" onclick="inputkey('[加班小时]')">[加班小时]</a></div>
                                            </td>
                                            <td width=50%>
                                                <table id="tblOpertor" runat="server" border="0" cellpadding="0" height="167" 
                                                   >
                                                    <tr align="center">
                                                        <td style="width: 34px">
                                                            <input name="k7" onclick="inputkey('7')" style="color: blue" type="button" value=" 7 " />
                                                        </td>
                                                        <td>
                                                            <input name="k8" onclick="inputkey('8')" style="color: blue" type="button" value=" 8 " />
                                                        </td>
                                                        <td>
                                                            <input name="k9" onclick="inputkey('9')" style="color: blue" type="button" value=" 9 " />
                                                        </td>
                                                        <td>
                                                            <input onclick="inputkey('/')" style="color: red" type="button" value=" / " />
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="width: 34px">
                                                            <input name="k4" onclick="inputkey('4')" style="color: blue" type="button" value=" 4 " />
                                                        </td>
                                                        <td>
                                                            <input name="k5" onclick="inputkey('5')" style="color: blue" type="button" value=" 5 " />
                                                        </td>
                                                        <td>
                                                            <input name="k6" onclick="inputkey('6')" style="color: blue" type="button" value=" 6 " />
                                                        </td>
                                                        <td>
                                                            <input onclick="inputkey('*')" style="color: red" type="button" value=" * " />
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="width: 34px">
                                                            <input onclick="inputkey('1')" style="color: blue" type="button" value=" 1 " />
                                                        </td>
                                                        <td>
                                                            <input name="k2" onclick="inputkey('2')" style="color: blue" type="button" value=" 2 " />
                                                        </td>
                                                        <td>
                                                            <input name="k3" onclick="inputkey('3')" style="color: blue" type="button" value=" 3 " />
                                                        </td>
                                                        <td>
                                                            <input onclick="inputkey('-')" style="color: red" type="button" value=" - " />
                                                        </td>
                                                    </tr>
                                                    <tr align="center">
                                                        <td style="width: 34px">
                                                            <input onclick="inputkey('0')" style="color: blue" type="button" value=" 0 " />
                                                        </td>
                                                        <td>
                                                            <input onclick="inputkey('(')" style="color: #ff00ff" type="button" value=" ( " />&nbsp;</td>
                                                        <td>
                                                            <input onclick="inputkey(')')" style="color: #ff00ff" type="button" value=" ) " />&nbsp;</td>
                                                        <td>
                                                            <input onclick="inputkey('+')" style="color: red" type="button" value=" + " />&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            </asp:Panel>
                      
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="提交" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;&nbsp;<input id="Button3" class="button_blue" onclick="javascript:window.close()"
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
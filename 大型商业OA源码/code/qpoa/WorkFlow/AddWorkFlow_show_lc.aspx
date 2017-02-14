<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlow_show_lc.aspx.cs" Inherits="qpoa.WorkFlow.AddWorkFlow_show_lc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
    if(document.getElementById('FlowName').value=='')
    {
    alert('流程名称不能为空');
    form1.FlowName.focus();
    return false;
    }	


	
	
    showwait();					
}



</script>




<script Language="JavaScript">
function copy_main()
{
  parent.set_main.document.execCommand('selectall');
  parent.set_main.document.execCommand('copy');
  alert("流程图已复制到剪贴板！");
}
</script>







<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <META http-equiv=Pragma content=no-cache>
<META http-equiv=Cache-Control content=no-cache>
<META http-equiv=Expires content=0>
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
           工作台 >> 设置工作流</td>
            
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
                                <td  class="newtd2" colspan="4" height="17">
                                  
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width=33% >
                                                    <strong>设计视图：</strong>  
                                                        <input id="txst" type="button" value="图形视图" onclick="parent.set_main.location='AddWorkFlow_show_lc_tx.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>'"/>
                                                        <input id="Button1" type="button" value="列表视图" onclick="parent.set_main.location='AddWorkFlow_show_lc_lb.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>'"/>
                                                   </td>
                                                <td width=67% align="right" >
                                                        <input id="Button2" type="button" value="刷  新" onclick="parent.set_main.location.reload();"/>
                                                        <input id="Button4" type="button" value="打  印" onclick="parent.set_main.document.execCommand('Print');" title="直接打印流程页面" />
                                                        <input id="Button5" type="button" value="复  制" onclick="copy_main();"/>
                                                        <input id="Button6" type="button" value="关  闭" onclick="parent.close();"/></td>          
                                                     
                                            </tr>
                                        </table>
                                 
                                </td>
                            </tr>
                            
                            <tr>
                                <td class="newtd2" colspan="4" height="24">
                               <IFRAME border="0" name="set_main" marginWidth="1" marginHeight="1" src="AddWorkFlow_show_lc_tx.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>" frameBorder="0" width="100%"  height="500" BORDERCOLOR="#EDEDED"></IFRAME>
                                    </td>
                               
                            </tr>
                       
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <input id="Button3" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关闭窗口" /></FONT>&nbsp;</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        &nbsp;</td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>
<asp:TextBox ID="FormId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="FormName" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  <asp:TextBox ID="FormNumber" runat="server" style="DISPLAY: none"></asp:TextBox>
   <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox>
    </form>
</body>
</html>
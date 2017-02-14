<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowSearchDp.aspx.cs" Inherits="qpoa.WorkFlow.WorkFlowSearchDp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


<SCRIPT language="javascript" type="text/javascript">

function _change()
{
   var text=form1.normalcontent.value;
   if (text !="请选择")
   {
       document.getElementById('SpContent').value +="\r\n"+text;
   }
}




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



//var objRe = /^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(<%=fjkey%>)$/;
//if(!objRe.test(document.getElementById('uploadFile').value))
//{
//alert("提示:\r不支持此格式的文件！请区分文件扩展名大小写\r只能上传<%=fjkey%>");
//form1.uploadFile.focus();
//return false;
//}
var sAllowExt = "<%=fjkey%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	return false;
}
var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
document.getElementById("ContractContentupdate").value=content;  

showwait();	



}
</SCRIPT>







<script>

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

window.open ("AddWorkFlow_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("AddWorkFlow_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=600px;status:no;scroll=yes;help:no");                
//var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
//document.getElementById("ContractContentupdate").value=content;  


}


}			



function  OpenSpyj()  
{
var num=Math.random();
//var aaaa=document.getElementById('Number').value;
window.open ("AddWorkFlow_spyj.aspx?tmp="+num+"&id=<%=Request.QueryString["id"] %>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


</script>



<head id="Head1" runat="server">
    <title>网络办公系统</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" onload="Settb();Load_Do();" >
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top">
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
                            <tr class="">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    常用审批备注：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:DropDownList ID="normalcontent" runat="server" onchange="_change()" Width="90%">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr class="">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    审批意见：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <asp:TextBox ID="SpContent" runat="server" Height="55px" TextMode="MultiLine" Width="90%"></asp:TextBox></td>
                            </tr>
                            <tr class="">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    审批附件：</td>
                                <td class="newtd2" colspan="3" height="17" width="83%">
                                    <input id="uploadFile" runat="server" name="uploadFile" style="width: 383px" type="file" /></td>
                            </tr>
                            
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="保 存" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp;&nbsp;&nbsp;</FONT></div> </td>
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
<asp:TextBox ID="TextBox1" runat="server" style="DISPLAY: none" ></asp:TextBox>
 <asp:TextBox ID="ContractContent" runat="server" Height="67px" TextMode="MultiLine" Width="424px"  style="DISPLAY: none"></asp:TextBox>
 <SCRIPT>
 
function   Settb()  
{  
//setTimeout("Settb()",0);
//var   content=document.getElementById("strhtm").innerHTML;  
//document.getElementById("TextBox1").value=content;  
document.getElementById("strhtm").innerHTML=document.getElementById("TextBox1").value;

}   
 
 
function Load_Do()
{
//document.getElementById("strhtm").innerHTML=document.getElementById("ContractContent").value;
setTimeout("Load_Do()",0);
var content = document.getElementById("strhtm").innerHTML
document.getElementById("ContractContent").value=content;  
document.getElementById("TextBox1").value=document.getElementById("ContractContent").value;
}

</SCRIPT>     
              <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox>
    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paper_update.aspx.cs" Inherits="qpoa.MyAffairs.Paper_update" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{


if(document.getElementById('Name').value=='')
{
alert('名称不能为空');
form1.Name.focus();
return false;
}	

    if(document.getElementById('PxNum').value=='')
    {
    alert('排序号不能为空，如果没有可以填写为0');
    form1.PxNum.focus();
    return false;
    }
    
    if(document.getElementById('PxNum').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('PxNum').value))
    {
    alert("排序号只能为正数");
    form1.PxNum.focus();
    return false;
    }

    } 



    showwait();					
}


</script>








<SCRIPT language="javascript" type="text/javascript">

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

window.open ("Paper_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("Paper_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                
var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
document.getElementById("ContractContentupdate").value=content;  


}


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
<body  class="newbody" onload="Load_Do()">
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
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    文件名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    排序号：</td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:TextBox ID="PxNum" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    文件夹：
                                </td>
                                <td class="newtd2" colspan="3" height="17" width="85%">
                                    <asp:DropDownList ID="Folder" runat="server" Width="95%">
                                    </asp:DropDownList></td>
                            </tr>
                        
     
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    文件内容：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
                   
<iframe name="EDIT_HTML" width="100%" height=260 src="../myeditor/updateeditor.htm" viewastext type="text/x-scriptlet"></iframe>


                                
                                </td>
                            </tr>
                       

                                                                           <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="70%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
                            </tr> 
                       
                         
                            
                            
                            
  
                                
                      
                          
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" />
                             
								</FONT>
							</div> </td>
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

<asp:TextBox ID="ContractContent" runat="server"  style="DISPLAY: none"></asp:TextBox>
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox>
<asp:TextBox ID="JyUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>
<asp:TextBox ID="ContractContentupdate" runat="server" style="DISPLAY: none"></asp:TextBox>
 <SCRIPT>
var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('JyUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("JyUsername").value=arr[0]; 
document.getElementById("JyRealname").value=arr[1]; 
}
}




  
function Load_Do()
{
setTimeout("Load_Do()",0);
var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
document.getElementById("ContractContent").value=content;  
}


</SCRIPT>   
    
    </form>
</body>
</html>
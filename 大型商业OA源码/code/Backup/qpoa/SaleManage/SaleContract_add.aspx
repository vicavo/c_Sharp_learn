<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleContract_add.aspx.cs" Inherits="qpoa.SaleManage.SaleContract_add" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
  if(document.getElementById('Name').value=='')
    {
    alert('客户名称不能为空');
    form1.Name.focus();
    return false;
    }	



    if(document.getElementById('ContractName').value=='')
    {
    alert('合同名称不能为空');
    form1.ContractName.focus();
    return false;
    }	

    if(document.getElementById('ContractMoney').value=='')
    {
    alert('合同金额不能为空，如果没有可以填写为0');
    form1.ContractMoney.focus();
    return false;
    }
    if(document.getElementById('ContractMoney').value!='')
    {    
    var objRe = /^\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('ContractMoney').value))
    {
    alert("提示:\r合同金额只能为正数");
    form1.ContractMoney.focus();
    return false;
    }

    }
    if(document.getElementById('ContractorA').value=='')
    {
    alert('签约人(甲方)不能为空');
    form1.ContractorA.focus();
    return false;
    }	

    if(document.getElementById('ContractorB').value=='')
    {
    alert('签约人(乙方)不能为空');
    form1.ContractorB.focus();
    return false;
    }	


    if(document.getElementById('Startime').value=='')
    {
    alert('生效日期时间不能为空');
    form1.Startime.focus();
    return false;
    }	


    if(document.getElementById('Endtime').value=='')
    {
    alert('终止日期时间不能为空');
    form1.Endtime.focus();
    return false;
    }	 
    
    showwait();					
}



var  wName3;  
function  OpenSaleData8()  
{  

var num=Math.random();
var str=document.getElementById("ContractType").value;
wName3=window.showModalDialog("../OpenWindows/open_SaleData.aspx?tmp="+num+"&requeststr="+str+"&type=11","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("ContractType").value=wName3; 
}

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

window.open ("SaleContract_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("SaleContract_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                
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
              <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
           <div id="printshow1">
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="../images/top_3.gif" ></td>
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="SaleContract.aspx"  class="line_b">销售合同</a> >> 新增销售合同</td>
                      <td width="81%">&nbsp;</td>
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
             </div>
            </td>
        </tr>
      </table>
      <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
        <tr> 
          <td height="35">
            <div id="printshow2"> 
          <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
              <tr> 
                <td width="17">&nbsp;</td>
                <td valign="top"> 
           <table align="center" background="../images/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">销售合同</font></button></td>
                              <td style="height: 26px" align="right" > &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td width="17">&nbsp;</td>
              </tr>
            </table>
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    客户名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="90%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openSupplier();" alt="" src="../images/FDJ.gif" border="0"></A>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同名称：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="ContractName" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同编号：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="ContractNum" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                                      <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    合同类型：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="ContractType" runat="server" DataType="DateTime" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG onclick="OpenSaleData8()" src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    合同金额：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="ContractMoney" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                            
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    生效日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Startime" runat="server" Width="80%" ></asp:TextBox>
                                    <script>SetNeed('StartTime')</script>
                                      <A href="javascript:void(0)"><IMG id="Startime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                     终止日期：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="80%" ></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>  
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人(甲方)：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="ContractorA" runat="server" Width="90%"></asp:TextBox></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    签约人(乙方)：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="ContractorB" runat="server"  Width="80%"></asp:TextBox>
                                     <A href="javascript:void(0)"><IMG onclick="openuser()" src="../images/FDJ.gif" border="0"></A>
                                    
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    创建日期：</td>
                                <td class="newtd2" height="17" width="35%">
                                      <asp:TextBox ID="CreateDate" runat="server" Width="80%" ></asp:TextBox>
                                    <script>SetNeed('CreateDate')</script>
                                      <A href="javascript:void(0)"><IMG id="CreateDate_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    创建人：</td>
                                <td class="newtd2" height="17" width="35%">
                                    <asp:TextBox ID="Realname" runat="server" Width="90%"></asp:TextBox></td>
                            </tr>
                            
                            
                            
                  
               
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同描述：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Description" runat="server"  Width="99%" Height="90px" TextMode="MultiLine"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同条款：</td>
                                <td class="newtd2" colspan="3" height="17">
                                    <asp:TextBox ID="ContractTerms" runat="server" Height="90px" TextMode="MultiLine" Width="99%"></asp:TextBox></td>
                            </tr>
                                                        <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="80%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 501px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
                            </tr>  
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    合同内容：</td>
                                <td class="newtd2" colspan="3" height="17" width=85% style="word-break:break-all">
                   
<iframe name="EDIT_HTML" width="100%" height=260 src="../myeditor/updateeditor.htm" viewastext type="text/x-scriptlet"></iframe>


                                
                                </td>
                            </tr>
                       

                       
                       
                              <tr class="" id="Tr1">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center">
                                            <strong>备注信息</strong>&nbsp;</div> </td>
                            </tr>
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="99%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>                           
                            
                            
                            
  
                                   <%=showjg%> 
                      
                          
                          
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
<asp:TextBox ID="KeyId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  
   <asp:TextBox ID="ContractorUser" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox> 
     <asp:TextBox ID="ContractContent" runat="server"  style="DISPLAY: none"></asp:TextBox>
     <asp:TextBox ID="ContractContentupdate" runat="server"   style="DISPLAY: none"></asp:TextBox>
<script language="javascript">	


var  wName_1;  
function  openSupplier()  
{  
var num=Math.random();
var str=""+document.getElementById('KeyId').value+"|"+document.getElementById('Name').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_CustomerPublic.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("KeyId").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
}
}




</script>  
    


    
<script language="javascript">	

var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('ContractorUser').value+"|"+document.getElementById('ContractorB').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("ContractorUser").value=arr[0]; 
document.getElementById("ContractorB").value=arr[1]; 
}
}



</script>    
    
 <SCRIPT>

  
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
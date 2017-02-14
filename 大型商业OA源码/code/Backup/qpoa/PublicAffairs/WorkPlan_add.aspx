<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlan_add.aspx.cs" Inherits="qpoa.PublicAffairs.WorkPlan_add" %>
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

window.open ("WorkPlan_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("WorkPlan_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                
}


}			


var  wName6;  
function  OpenSaleData6()  
{  

var num=Math.random();
var str=document.getElementById("PlanType").value;
wName6=window.showModalDialog("../OpenWindows/open_PlanCycle.aspx?tmp="+num+"&requeststr="+str+"&type=1","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName6!=null && wName6!= "undefined")
{
document.getElementById("PlanType").value=wName6; 
}

}


var  wName3;  
function  OpenSaleData3()  
{  

var num=Math.random();
var str=document.getElementById("PlanCycle").value;
wName3=window.showModalDialog("../OpenWindows/open_PlanCycle.aspx?tmp="+num+"&requeststr="+str+"&type=2","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");               
if(wName3!=null && wName3!= "undefined")
{
document.getElementById("PlanCycle").value=wName3; 
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="WorkPlan.aspx"  class="line_b">计划管理</a> >> 新增计划管理</td>
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
                                    <font class="shadow_but">计划管理</font></button></td>
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
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    计划名称：</td>
                                <td class="newtd2" height="17" colspan="3" width="85%">
                                    <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    计划内容：</td>
                                <td class="newtd2" height="24" width="85%" colspan=3>
                                    <asp:TextBox ID="Content" runat="server" Height="90px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                               
                            </tr>
                            
                                      <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="17%">
                                    计划周期：</td>
                                <td class="newtd2" height="24" width="33%">
                                    <asp:TextBox ID="PlanCycle" runat="server" Width="85%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG onclick="OpenSaleData3()" src="../images/FDJ.gif" border="0"></A></td>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    计划类型：</td>
                                <td class="newtd2" height="24" width="35%">
                                    <asp:TextBox ID="PlanType" runat="server" Width="85%"></asp:TextBox>
                                      <A href="javascript:void(0)"><IMG onclick="OpenSaleData6()" src="../images/FDJ.gif" border="0"></A>
                                    </td>
                            </tr>
                            
                            
                         <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                    有效期(开始)：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Startime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('Startime')</script>
                                      <A href="javascript:void(0)"><IMG id="Startime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>
                                 <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="15%">
                                     有效期(结束)：
                                </td>
                                <td class="newtd2"  height="17" width="35%">
                                    <asp:TextBox ID="Endtime" runat="server" Width="85%" ></asp:TextBox>
                                    <script>SetNeed('Endtime')</script>
                                      <A href="javascript:void(0)"><IMG id="Endtime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A></td>           
                                
                                
                                
                            </tr>  
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    参与部门：</td>
                                <td class="newtd2" height="24" width="85%"  colspan=3>
                                    <asp:TextBox ID="SendUnit" runat="server" Height="34px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openunit()" src="../images/FDJ.gif" border="0"></A></td>
                               
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="24" nowrap="nowrap"
                                    width="15%">
                                    参与人员：</td>
                                <td class="newtd2" height="24" width="85%"  colspan=3>
                                    <asp:TextBox ID="SendRealname" runat="server" Height="37px" TextMode="MultiLine" Width="85%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser1()" src="../images/FDJ.gif" border="0"></A></td>
                               
                            </tr>
                            
                            
                            
                  
               
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    负责人：</td>
                                <td class="newtd2" colspan="3" style="height: 17px">
                                    <asp:TextBox ID="Header" runat="server" Width="95%"></asp:TextBox><A href="javascript:void(0)"><IMG onclick="openuser()" src="../images/FDJ.gif" border="0"></A></td>
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
                          
              
                       
                                             <tr  class="" id="Tr1">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件说明：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="FjRemark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
                            </tr>             
                            
                            
                            <tr  class="" id="Tr2">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    备注：</td>
                                <td class="newtd2" height="17" width="33%" colspan=3>
                                    <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
                          
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
<asp:TextBox ID="SendUnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
  
   <asp:TextBox ID="SendUsername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox> 
     <asp:TextBox ID="HeaderUser" runat="server"  style="DISPLAY: none"></asp:TextBox>

    


    
<script language="javascript">	

var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('HeaderUser').value+"|"+document.getElementById('Header').value+"";
wName_3=window.showModalDialog("../OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("HeaderUser").value=arr[0]; 
document.getElementById("Header").value=arr[1]; 
}
}



var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('SendUsername').value+"";
wName_1=window.showModalDialog("../OpenWindows/open_Username.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SendUsername").value=arr[0]; 
document.getElementById("SendRealname").value=arr[1]; 
}
}

var  wName_2;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('SendUnitId').value+"";
wName_2=window.showModalDialog("../OpenWindows/open_UnitName_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SendUnitId").value=arr[0]; 
document.getElementById("SendUnit").value=arr[1]; 
}
}


</script>    

    
    </form>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FilesManageBook_update.aspx.cs" Inherits="qpoa.FilesManage.FilesManageBook_update" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{
  if(document.getElementById('Num').value=='')
    {
    alert('文件号不能为空');
    form1.Num.focus();
    return false;
    }	



  if(document.getElementById('Name').value=='')
    {
    alert('主题词不能为空');
    form1.Name.focus();
    return false;
    }	

  if(document.getElementById('FilesName').value=='')
    {
    alert('所属案卷不能为空');
    form1.FilesName.focus();
    return false;
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

window.open ("FilesManageBook_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("FilesManageBook_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");                

}


}			


function zxcheck()
{

if(document.getElementById('fjlb').value=='')
{
    alert('未选种编辑文件');
    return false;
}
else
{

    var littleproduct=document.getElementById("fjlb");
    var cindex = littleproduct.selectedIndex;
    var cValue = littleproduct.options[cindex].value;
    var picOK=false;
    var nameLen=cValue.length;
    var rightName=cValue.substr(nameLen-4,4).toLowerCase();
    if (nameLen>0)
    {
        if (  rightName==".doc"  ||   rightName==".DOC"    ||   rightName==".xls"    ||   rightName==".XLS"  ||   rightName==".ppt"    ||   rightName==".PPT"    )
        { 
        picOK=true;
        var num= document.getElementById("Number").value;
        var tmp=Math.random();
        window.open("FilesManageBook_add_online.aspx?tmp="+tmp+"&number="+num+"&file="+cValue+"&filetype="+rightName+"","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");
        }

        if (picOK==false)
        { alert("提示:\r只能编辑.doc|.xls|.ppt|格式的文件！");
        return(false);
        }
    }

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
           </td>
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="FilesManageBook.aspx"  class="line_b">文件管理</a> >> 修改文件</td>
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
                                    <font class="shadow_but">文件管理</font></button></td>
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
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    文件号：</td>
                                <td class="newtd2"  height="24" width="33%">
                                    <asp:TextBox ID="Num" runat="server" Width="95%"></asp:TextBox></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    文件主题词：</td>
                                <td class="newtd2"  height="24" width="35%">
                                   <asp:TextBox ID="Name" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            
     <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    文件标题：</td>
                                <td class="newtd2"  height="24" width="33%">
                                    <asp:TextBox ID="Title" runat="server" Width="95%"></asp:TextBox></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    文件辅标题：</td>
                                <td class="newtd2"  height="24" width="35%">
                                   <asp:TextBox ID="OtherTitle" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    发文单位：</td>
                                <td class="newtd2"  height="24" width="33%">
                                    <asp:TextBox ID="FwCompany" runat="server" Width="95%"></asp:TextBox></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    发文日期：</td>
                                <td class="newtd2"  height="24" width="35%">
                                  <asp:TextBox ID="FwTime" runat="server" Width="80%"></asp:TextBox>
                                    <A href="javascript:void(0)"><IMG id="FwTime_HelpButton" onclick="Jscript:var sID ;sID = event.srcElement.id; sID = sID.substring(0,sID.lastIndexOf('_HelpButton'));DateSelect(sID);"
																		src="../images/FDJ.gif" border="0"></A>
                                   </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    密级：</td>
                                <td class="newtd2"  height="24" width="33%"><asp:DropDownList ID="Miji" runat="server" Width="95%">
                                </asp:DropDownList></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    紧急等级：</td>
                                <td class="newtd2"  height="24" width="35%"><asp:DropDownList ID="Dengji" runat="server" Width="95%">
                                </asp:DropDownList></td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    文件分类：</td>
                                <td class="newtd2"  height="24" width="33%"><asp:DropDownList ID="WjType" runat="server" Width="95%">
                                </asp:DropDownList></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    公文类别：</td>
                                <td class="newtd2"  height="24" width="35%"><asp:DropDownList ID="GwType" runat="server" Width="95%">
                                </asp:DropDownList></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    文件页数：</td>
                                <td class="newtd2"  height="24" width="33%">
                                    <asp:TextBox ID="WjNum" runat="server" Width="95%"></asp:TextBox></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    打印页数：</td>
                                <td class="newtd2"  height="24" width="35%">
                                   <asp:TextBox ID="DyNum" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="17%">
                                    所属案卷：</td>
                                <td class="newtd2"  height="24" width="33%">
                                    <asp:DropDownList ID="FilesName" runat="server" Width="95%">
                                </asp:DropDownList></td>
                                <td align="right" class="newtd1"  height="24" nowrap="nowrap"
                                    width="15%">
                                    备注：</td>
                                <td class="newtd2"  height="24" width="35%">
                                   <asp:TextBox ID="Remark" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                            
                              <tr>
                                 <td class="newtd2"  colspan="4" height="17" style="text-align: center">
                                     <strong>文件附件</strong></td>
                            </tr>                           
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    附件列表：</td>
                                <td class="newtd2"  height="17" width="83%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="53%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" />
                                    <INPUT onclick="zxcheck()" type="button" value="在线编辑"></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2"  height="17" width="83%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
                            </tr>                                 
                          
                             <tr  id="printshow3">
                                <td align="center" class="newtd2"  colspan="4" height="26" width="33%">
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
<asp:TextBox ID="QxUnitId" runat="server" Width="90%" style="DISPLAY: none"></asp:TextBox>
 
 <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox>
    
    </form>
</body>
</html>
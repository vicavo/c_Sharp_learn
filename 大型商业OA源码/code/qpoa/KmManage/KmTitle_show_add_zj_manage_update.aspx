<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KmTitle_show_add_zj_manage_update.aspx.cs" Inherits="qpoa.KmManage.KmTitle_show_add_zj_manage_update" validateRequest="false"%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<script>
function chknull()
{

    if(document.getElementById('Name').value=='')
    {
    alert('章节标题不能为空');
    form1.Name.focus();
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

window.open ("KmTitle_show_add_zj_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("KmTitle_show_add_zj_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");                

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
        var num= document.getElementById("number").value;
        var tmp=Math.random();
        window.open("KmTitle_show_online.aspx?tmp="+tmp+"&number="+num+"&file="+cValue+"&filetype="+rightName+"","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");
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
    <title>办公自动化</title>
        <LINK href="../css/public.css" type="text/css" rel="stylesheet">
         <LINK href="../css/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body  class="newbody" >
    <form id="form1" runat="server">
    <!--#include file="../public/pleasewait.htm"-->
    <!--#include file="../public/public.js"-->
    <script language="javascript" src="../public/DateSelect.js"></script>
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top" style="height: 573px"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              工作台 &gt;&gt;&nbsp; 我的知识 &gt;&gt;&nbsp; 知识章节&nbsp; &gt;&gt;&nbsp;<span style="color: #ff0000">
                  <%=KmTitle %></span></td>
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
                            
                        <tr  class="" id="Tr1">
                                <td align="right" class="newtd1"  height="17" nowrap="nowrap"
                                    width="17%">
                                    章节标题：</td>
                                <td class="newtd2"  height="17" width="83%" colspan=3>
                                    <asp:TextBox ID="Name" runat="server" Width="99%"></asp:TextBox></td>
                          
                            </tr>     
                            
                            
                            <tr>
                                <td class="newtd2"  colspan="4" height="17">
       <FCKeditorV2:FCKeditor ID="d_content" runat="server" ToolbarSet="Qiupeng1" Height="250px">
                                    </FCKeditorV2:FCKeditor>
                                    
                                
                                </td>
                            </tr>                         
                            
                            <tr>
                                 <td class="newtd2"  colspan="4" height="17" style="text-align: center">
                                     <strong>章节附件</strong></td>
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
                                &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<input id="Button2" class="button_blue" onclick="javascript:window.close()"
                                                type="button" value="关 闭" /></FONT></div> </td>
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
              <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox></td>
  </tr>
</table>

  
    
    </form>
</body>
</html>
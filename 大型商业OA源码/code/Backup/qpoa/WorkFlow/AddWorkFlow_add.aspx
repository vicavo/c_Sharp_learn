<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlow_add.aspx.cs" Inherits="qpoa.WorkFlow.AddWorkFlow_add" validateRequest="false"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >


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

        function opensetyz(str1,str2)
        {
            //控件宽
            var aw = 420;
            //控件高
            var ah = 320;
            //计算控件水平位置
            var al = (screen.width - aw)/2-100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
           
            mytop=screen.availHeight-500;
            myleft=200;
            var aaaa=document.getElementById('Number').value;
            window.open("WorkFlowListSpYzY.aspx?Number="+aaaa+"&picname="+str1+"&yznum="+str2+"&FlowNumber=<%=Request.QueryString["FlowNumber"] %>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
        }

        function setpic(str1,str2)
        {
          document.getElementById(''+str1+'').src = "CompanySeal/"+str2+"";
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

window.showModalDialog("AddWorkFlow_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");                
//var  content=document.frames("EDIT_HTML").document.forms("Members").elements("Search").value;  
//document.getElementById("ContractContentupdate").value=content;  


}


}			



function  OpenSpyj()  
{
var num=Math.random();
var aaaa=document.getElementById('Number').value;
window.open ("AddWorkFlow_spyj.aspx?tmp="+num+"&Number="+aaaa+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function  OpenYzLog()  
{

var num= document.getElementById("Number").value;
window.open ("WorkFlowListSpYzLog.aspx?Number="+num+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
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
        window.open("Document_online.aspx?tmp="+tmp+"&number="+num+"&file="+cValue+"&filetype="+rightName+"","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");
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
    <td valign="top"><table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td>
              <asp:TextBox ID="Number" runat="server" style="DISPLAY: none"></asp:TextBox>
              <asp:TextBox ID="GqUpNodeNumKey" runat="server" Visible="False"></asp:TextBox></td>
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
                      <td width="3%" style="height: 24px"><img src="../images/top_3.gif" ></td>
                       <td width="60%" valign="bottom" style="height: 24px"><a href="../main_d.aspx"  class="line_b">工作台</a> >> <a href="AddWorkFlow.aspx"  class="line_b">新建工作</a> >> 快速新建</td>
                      <td align="right" style="height: 24px" >&nbsp;<input id="Button6" type="button" value="流程图" onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'/>
                          <input id="Button7" type="button" value="审批意见" onclick="OpenSpyj();"/>
                           <input id="Button8" type="button" value="印章记录" onclick="OpenYzLog();"/>
                           </td>
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
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        &nbsp;</td>
                    <td valign="top" >
                  
                        <table align="center" class="newtable" border="0" cellpadding="4" cellspacing="1"
                            width="100%">
                            <tr>
                                <td class="newtd2" colspan="4" height="17">
                                    流水号：<%=lshid %> － 
                                    <asp:TextBox ID="whname" runat="server" Width="254px" CssClass="Twhname1"></asp:TextBox> － 当前步骤：<%=NodeName %></td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                    <strong>表单信息</strong>
                                    

                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="#ffffff" class="cpx12hei" colspan="4" height="17">
                                     <div id="strhtm"></div>
                                    </td>
                                
                                
                                
                                
                            </tr>                            
                             <tr>
                                 <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                     <strong>公共附件</strong></td>
                            </tr>                           
                            <tr  class="" id="nextrs22">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    附件列表：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                                    <asp:DropDownList ID="fjlb" runat="server" Width="53%">
                                    </asp:DropDownList>&nbsp;
                                    <input id="Button5" type="button" value="下　载" onclick="down();"/>
                                    <asp:Button ID="Button3" runat="server" Text="删　除" />
                                    <INPUT onclick="zxcheck()" type="button" value="在线编辑" id="Button9" runat="server"></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" /></td>
                          
                            </tr>         
                            
                            
                            
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="下一步" CssClass="button_blue" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_blue" OnClick="Button2_Click" /></FONT></div> </td>
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
    
    </form>
</body>
</html>
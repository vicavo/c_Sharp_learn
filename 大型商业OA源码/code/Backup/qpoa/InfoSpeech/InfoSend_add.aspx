<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoSend_add.aspx.cs" Inherits="qpoa.InfoSpeech.InfoSend_add"  validateRequest="false"%>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<script>
function chknull()
{
if(document.getElementById('Title').value=='')
{
alert('主题不能为空');
form1.Title.focus();
return false;
}	

showwait();					


}


function openqiupengmodle()
{
var num=Math.random();
window.open ("../fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
oEditor.InsertHtml(''+str+'');
}


</script>

<script language="javascript">	
function  openuser1()  
{  
    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("InfoSend_add_people.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
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

window.open ("InfoSend_add_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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

window.showModalDialog("InfoSend_add_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");                

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
        window.open("InfoSend_add_online.aspx?tmp="+tmp+"&number="+num+"&file="+cValue+"&filetype="+rightName+"","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");
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
                       <td width="81%" valign="bottom"><a href="../main_d.aspx"  class="line_b">工作台</a> >>&nbsp; 传阅文件</td>
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
                                    <font class="shadow_but">传阅文件</font></button></td>
                              <td style="height: 26px" align="right" > 
                                  <a href="javascript:void(0)"></a></td>
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
                            width="100%" id="tableprint">
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    主题：</td>
                                <td class="newtd2" height="17" colspan="3" width="83%">
                                    <asp:TextBox ID="Title" runat="server" Width="95%"></asp:TextBox></td>
                            </tr>
                             <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    &nbsp;<fckeditorv2:fckeditor id="d_content" runat="server" height="300px" toolbarset="Qiupeng1"></fckeditorv2:fckeditor></td>
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
                                    <INPUT onclick="zxcheck()" type="button" value="在线编辑"></td>
                          
                            </tr>                           
  
                           <tr  class="" id="nextrs23">
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    上传附件：</td>
                                <td class="newtd2" height="17" width="83%" colspan=3>
                                    <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="上　传" /></td>
                          
                            </tr>      
                            
                            
                                                     
                            <tr>
                                <td class="newtd2" colspan="4" height="17">
                                    <asp:CheckBox ID="C1" runat="server" Text="允许接收人编辑WORD,EXCEL,PPT附件" Checked="True" />
                                    &nbsp;
                                    <asp:CheckBox ID="C2" runat="server" Text="允许接收人额外新增接收人" Checked="True" />&nbsp; &nbsp;<asp:CheckBox ID="C3" runat="server" Text="允许接收人转发传阅" Checked="True" Visible="False" />&nbsp;
                                    <img src="../images/menu/work_plan.gif" />
                                    <asp:LinkButton ID="LinkButton1" runat="server">新增接收人</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td class="newtd2" colspan="4" height="17">
                                  <div id="Div1" class="mainDiv">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#4D77B1"
                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="True">
                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                        <Columns>
                                            <asp:BoundField DataField="QrRealname" HeaderText="姓名" SortExpression="QrRealname">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QrTime" HeaderText="确认时间" SortExpression="QrTime">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="QrContent" HeaderText="确认意见" SortExpression="QrContent">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="State" HeaderText="状态" SortExpression="State">
                                                <ItemStyle Wrap="False" />
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Wrap="False" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="相关操作">
                                                <HeaderStyle CssClass="newtitle" ForeColor="white" Width="59px" Wrap="False" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                        CommandName="ShanChu">删除</asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" Width="59px" Wrap="False" />
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                        <AlternatingRowStyle BackColor="#E6EDF7" />
                                        <EmptyDataTemplate>
                                            <div align="center">
                                                <font color="white">无相关数据！</font></div>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                    </div>
                                </td>
                            </tr>
                             <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                            <asp:Button ID="Button2" runat="server" CssClass="button_blue" OnClick="Button1_Click"
                                                Text="确 定" />
                                            &nbsp; &nbsp;
                                            &nbsp;&nbsp;<asp:Button ID="Button4" runat="server" CssClass="button_blue" OnClick="Button4_Click"
                                                Text="返 回" /></FONT></div> </td>
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
<asp:TextBox ID="acceptusername" runat="server" Width="90%"  style="DISPLAY: none"></asp:TextBox>

<asp:TextBox ID="Number" runat="server"  style="DISPLAY: none"></asp:TextBox>


    </form>
</body>
</html>